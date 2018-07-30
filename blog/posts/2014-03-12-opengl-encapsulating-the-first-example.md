---
title: OpenGL Encapsulating the First example
slug: opengl-encapsulating-the-first-example
date_published: 2014-03-12T06:32:19.052Z
date_updated:   2014-03-17T04:55:41.791Z
tags: opengl, c++
---

Before doing anything in OpenGL I copied and pasted the example from [Wikibooks](http://en.wikibooks.org/wiki/OpenGL_Programming/Modern_OpenGL_Introduction). I observed the differences between this example and the one in my Redbook and besides the Version Macros and the beautiful way the Shaders are loaded into a ShaderInfo structure I could not find anything else.

Of course this tiny difference meant a world of changes. But one thing I loved from the Redbook is that the Vertex and Fragments are in a separate GLSL file which is awesome. 

Anyway... putting the rest of the implementation in an object encapsulation proved a little tricky. The main problem was **glutDisplayFunc** that receives a function pointer to the Draw or Display method. 

To circumvent this issue we used a callback to the instance and the Callback. [The Project is in Github.](https://github.com/claudiordgz/playground/tree/master/OpenGL/Nightmare)

###The Callback

Provides a way to encapsulate the Main Loop for OpenGL

```language-cpp
void OpenGLProgram::run(void)
{
  if(1 == Init())
  {
    /* We can display it if everything goes OK */
    SetupDisplayCallback();
    glutMainLoop();
  }

  /* If the program exits in the usual way,
free resources and exit with a success */
  FreeResources();
}

OpenGLProgram* g_CurrentInstance;

extern "C"
void drawCallback()
{
  g_CurrentInstance->_Display();
}

void OpenGLProgram::SetupDisplayCallback()
{
  ::g_CurrentInstance = this;
  ::glutDisplayFunc(::drawCallback);
}
```

Of course this callback sucks, because it allows a big dependency to one instance. To create a multi instance pack of loops we would have to device a different mechanic. 

Hereafter is the header file to the OpenGL example implementation, this includes the Vextex and Fragment setup, and the display function for the main loop. 

```language-cpp
#ifndef OPENGL_METHODS_HPP_
#define OPENGL_METHODS_HPP_
// $Id$
/**
* @file file_operations.hpp
* File Input Output Operations are placed here
* @brief We need to read frag a vert files (GLSL)
*
* @author Claudiordgz
*/
// $Log$

#include "vgl.h"
#include <GL/glew.h>

#include <string>
#include <iostream>


/**
* @class OpenGLProgram
*
* @brief The class that contains the our OpenGL logic
*/
class OpenGLProgram
{
public:
  /**
* Constructor
* @param dir The path to our media files (Frag and Vert)
*/
  OpenGLProgram(char *dir): dir_(dir),
program(0),
attribute_coord2d(0)
  {
  }
  /**
* Main loop of execution
*/
  void run(void);

  /**
* This function gets passed to
* a callback
*/
  void _Display(void);

private:
  int Init(void);
  void FreeResources(void);

  /**
* SetShader acquires the file descriptor for a shader
* using the GetShader method
* @param[in] filename The input file (vert or frag in our case).
* @param[in,out] shader a GLuint to receive the file descriptor to the shader.
*/
  void SetShader(GLuint &shader, const char *filename);

  /*
* Places the Fragment or Vertex in a string
* @param[in] file_name The input file (vert or frag in our case).
* @param[in,out] returnVal The file we need
*/
  void GetShader(const char *file_name, std::string &returnVal);

  /*
* Callback for glutDisplayFunc
*/
  void SetupDisplayCallback();

#ifdef GL_ES_VERSION_2_0
  const std::string open_gl_version = "#version 100\n"; ///< OpenGL ES 2.0
#else
  const std::string open_gl_version = "#version 120\n"; ///< OpenGL 2.1
#endif
  char *dir_;	///< a pointer to the media directory in your drive (GLSL)
  GLuint program;	///< the program descriptor
  GLint attribute_coord2d;	///< the attribute coordinates descriptor
};


#endif /* OPENGL_METHODS_HPP_ */
```
