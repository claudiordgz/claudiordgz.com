---
title: OpenGL Programming
slug: temp-slug-10
date_published: 2014-03-10T08:30:14.120Z
date_updated:   2014-03-10T08:54:24.812Z
tags: OpenGL, C, C++
---

####The continuing of a long awaited journey

I've never used OpenGL for what I wanted to use it... *toying with matrices and Dynamic Programming*. 

I am mostly a Windows user, but for this... Linux feels more appropiate and simple. 

I program using Lubuntu on a Virtual Machine in my laptop, gotta work with what I got. 
I do wish to go full Linux but I still need my Windows for C# development and  (plus I love Visual Studio). Eventually I shall get a normal desktop pc with and pack some linux distro in it.

####OpenGL Components 

The first step is to install your proper graphics drivers. For this vmplayer supplies their drivers. Afterwards just get all the proper libraries.

```language-bash
~ $ sudo apt-get install gcc-4.8.1 g++-4.8.1 
~ $ sudo apt-get install git-core
~ $ sudo apt-get install automake libtool libpthread-stubs0-dev
~ $ sudo apt-get install xserver-xorg-dev x11proto-xinerama-dev libx11-xcb-dev
~ $ sudo apt-get install libxcb-glx0-dev libxrender-dev
~ $ sudo apt-get build-dep libgl1-mesa-dri libxcb-glx0-dev
```

> You'll also need the The OpenGL Extension Wrangler Library which you can get from glew.sourceforge.net. 

You may go ahead and feel brave enough to download everything from a repo and building on your pc. But just allow me one thing to say, don't try this on a virtual machine in which you don't control the libraries, otherwise be ready for a world of pain.

You may be asking yourself... **Why installing gcc 4.8.1 and g++ 4.8.1?** I have no reason or explanation, lately I have been toying with decltype, unique_ptr, but most of all auto thus I feel more comfortable using pure C++11 when developing. 

####The OpenGL Redbook

This is a sad moment indeed. If you grabbed the redbook of OpenGL like me you'll find that it requires certain Core Version, my example requires **OpenGL 4.2**, sadly my Mesa runs on **OpenGL 2.1**.

But never despair, so far the only differences I've seen have been with some vertex shader loading. Nothing too fancy. So we just have to create our own Vertex and Fragment Shaders inside of the code instead of a fancy file with little code. 

Besides... I just found this [Tutorial compatible with my Mesa OpenGL 2.1](http://en.wikibooks.org/wiki/OpenGL_Programming/Modern_OpenGL_Introduction)

> Of course, my cutting edge scratchy feeling inside is slowly killing me, until the day I get an OpenGL 4.X compatible machine. 

So for know we'll be using the Wikibooks tutorial and tomorrow we'll recreate our RedBook example for OpenGL 2.1, which shouldn't require too much changes.

```language-cpp

#include <iostream>
#include "vgl.h"
#include "LoadShaders.h"
#include <string>
#include <GL/glew.h>

GLuint program;
GLint attribute_coord2d;

int init(void);
void display(void);
void free_resources();

//Main program
int main(int argc, char **argv)
{
  glutInit(&argc, argv);
  glutInitWindowPosition(10, 10);
  glutInitDisplayMode(GLUT_DOUBLE | GLUT_DEPTH | GLUT_RGBA );
  glutInitWindowSize(512, 512);
  glutInitContextVersion(2, 1);
  glutInitContextProfile(GLUT_CORE_PROFILE);
  glewExperimental = GL_TRUE;
  std::string testing = "testing";
  glutCreateWindow(testing.c_str());

  GLenum glew_status = glewInit();
  if(glew_status != GLEW_OK)
  {
    std::cerr << "Unable to initialize GLEW... exiting" << std::endl;
    exit(EXIT_FAILURE);
  }
  std::cout << glGetString( GL_VERSION ) << std::endl;

  if(1 == init())
  {
    /* We can display it if everything goes OK */
    glutDisplayFunc(display);
    glutMainLoop();
  }

  /* If the program exits in the usual way,
  free resources and exit with a success */
  free_resources();

  return (EXIT_SUCCESS);
}

int init(void)
{
  GLint compile_ok = GL_FALSE, link_ok = GL_FALSE;

  GLuint vs = glCreateShader(GL_VERTEX_SHADER);
  const char *vs_source =
#ifdef GL_ES_VERSION_2_0
    "#version 100\n"  // OpenGL ES 2.0
#else
    "#version 120\n"  // OpenGL 2.1
#endif
    "attribute vec2 coord2d;                  "
    "void main(void) {                        "
    "  gl_Position = vec4(coord2d, 0.0, 1.0); "
    "}";
  glShaderSource(vs, 1, &vs_source, NULL);
  glCompileShader(vs);
  glGetShaderiv(vs, GL_COMPILE_STATUS, &compile_ok);
  if (0 == compile_ok)
  {
    std::cerr << "Error in vertex shader\n";
    return (0);
  }

  GLuint fs = glCreateShader(GL_FRAGMENT_SHADER);
  const char *fs_source =
    "#version 120           \n"
    "void main(void) {        "
    "  gl_FragColor[0] = 0.0; "
    "  gl_FragColor[1] = 0.0; "
    "  gl_FragColor[2] = 1.0; "
    "}";
  glShaderSource(fs, 1, &fs_source, NULL);
  glCompileShader(fs);
  glGetShaderiv(fs, GL_COMPILE_STATUS, &compile_ok);
  if (!compile_ok)
  {
    std::cerr << "Error in fragment shader\n";
    return (0);
  }
  program = glCreateProgram();
  glAttachShader(program, vs);
  glAttachShader(program, fs);
  glLinkProgram(program);
  glGetProgramiv(program, GL_LINK_STATUS, &link_ok);
  if (!link_ok)
  {
    std::cerr << "glLinkProgram:";
    return (0);
  }

  const char* attribute_name = "coord2d";
  attribute_coord2d = glGetAttribLocation(program, attribute_name);
  if (attribute_coord2d == -1)
  {
    std::cerr << "Could not bind attribute " << attribute_name << std::endl;
    return (0);
  }

  return (1);

}


void display(void)
{
  /* Clear the background as white */
  glClearColor(1.0, 1.0, 1.0, 1.0);
  glClear(GL_COLOR_BUFFER_BIT);

  glUseProgram(program);
  glEnableVertexAttribArray(attribute_coord2d);
  GLfloat triangle_vertices[] = {
     0.0,  0.8,
    -0.8, -0.8,
     0.8, -0.8,
  };
  /* Describe our vertices array to OpenGL (it can't guess its format automatically) */
  glVertexAttribPointer(
    attribute_coord2d, // attribute
    2,                 // number of elements per vertex, here (x,y)
    GL_FLOAT,          // the type of each element
    GL_FALSE,          // take our values as-is
    0,                 // no extra data between each position
    triangle_vertices  // pointer to the C array
  );

  /* Push each element in buffer_vertices to the vertex shader */
  glDrawArrays(GL_TRIANGLES, 0, 3);
  glDisableVertexAttribArray(attribute_coord2d);

  /* Display the result */
  glutSwapBuffers();
}

void free_resources()
{
  glDeleteProgram(program);
}
```
