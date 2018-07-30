---
title: SCons Build System for C++
slug: scons-build-system
date_published: 2014-11-05T01:10:22.631Z
date_updated:   2015-07-24T12:44:04.968Z
tags: C++, SCons, Cross Platform Development
---

SCons is a software construction tool, an alternative to autotools or cmake. The difference is that it depends on Python 2.4 to 2.7 <span style="color:red">(Not Python 3 as of 2014)</span>. You can download it from [Here](http://scons.org/download.php).

The **Advantage**/**Disadvantage** of SCons is that the scripts to process *your* workspace are built using Python. There is a whole lot to say about this, but this will keep your level of sanity to a good degree if you know Python.

When working in a Project, I try to develop some shell projects before beginning to push code. 

![example project](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415139536/Image_076_fa7rfl.png)

These elements are just an example of how your application will grow in time. And we are not even considering third party libraries. 

Now I don't build all this crap from the get go, but I want before coding anything, the following elements:

1. Executable
2. Test Project
3. Library to push code

Eventually things get larger and I need tests that combine dependencies. And of course, a website to push any changes, notes, or something, the [study series](http://www.claudiordgz.com/study-series/) pushed me into creating a way of having fast websites done in minutes using LaTeX, and it has worked wonders, having a nice website to publish your personal work really helps in the motivation department.

And in a country where all your friends are playing videogames, drinking every day, binge watching series on netflix... motivation becomes scarce and hard to find. 

But rebuilding all this environment is bothersome, making it cross platform is a pain, and if you use Visual Studio you risk making a mess of your workspace, Visual Studio or Eclipse are horses, horses that allow you to breeze faster through coding, making you get through modules in matter of days, but I don't know if you have seen a horse trail before, they do leave a lot of shit along the way. 

###But why do I need a Software Construction Thingy

Because every project has elements. In C++ eventually projects appear to have the following:

- Source Files
- Include Files
- resource files
- Linked Libraries 
- Extra include directories 
- Extra source directories

Some elements in there sprout like mushrooms. 

- "Oh Look, a cool library that does the same thing I was doing with another library, let's link it too". 
- "Damn I took a feature from library B that my coworker made, but now I need a feature from the include files of Library A, I'll just link both libraries"

Yes, elements are mushrooms, but mushrooms that sprout from shit. While the little shitakes are really useful, it will take careful cleaning and a critical eye to remove any traces of the shit in which they grew, thus, after growing, you'll need a professional mushroom cleaner to leave all your shrooms ready to eat.

###Enter SCons

A system that will allow you to have minimal extra files, if you need another animal simil, think of SCons as a Tibetan Mastiff trained to rescue you from the frozen state you will find yourself in after designing, coding, recoding, redesigning, and pushing through some ugly code. This super dog will come, and pull you from the frozen thundra, and slap you around a few times, put a warm blanket on top, and leave a bowl of hot soup ahead to allow you to recover yourself. You will wake up refreshed, and ready to analyze the trail you came from again, and continue your journey, while the mastiff goes back to sleep. 

###Installation

- Install Python 2.7.8 or less
- Install SCons 
- Place scons script in your `path` 

###How does it work

Similar to CMake and to Automake, SCons uses scripts in which you place all the rules for your workspace.

This script is written in Python and in a file called `SConstruct`. <i class="fa fa-file"></i> 

<div class="row">
<div class="col-md-5">
<p>
The SConstruct file links <b>all</b> these elements together to build your project using your toolchain, such as g++ or visualc++. The good thing is that this leaves you with pure and absolute code.
</p>
</div>
<div class="col-md-7">
<p>
<b>Pro Tip:</b> <a href="https://gist.github.com/claudiordgz/768c18a7d6219ca76086">I like to keep a Visual Studio <b>project xml</b> handy</a>. With this I only edit some things and now I have a working project linked to my source and include files, without actually leaving any crap anywhere <b>NEAR</b> the source code. Visual Studio is your loyal steed.
</p>
</div>
</div>

This file has the instructions for loading up your Source Files and constructing your Projects. 

```language-python
env = Environment()
env.Append(CPPDEFINES={'VERSION': 1})
env.Append(CPPDEFINES=['RELEASE'])
# build our environment in the build/release folder
env.VariantDir('build/release')
env.Program('helloworld', ['main.cpp'], LIBS=['somelib'], LIBPATH='../path/to/somelib')
```

Similarly, to create a library we change one line only

```language-python
env.Library('helloworld', ['code.cpp'], LIBS=['somelib'], LIBPATH='../path/to/somelib')
```


<div class="row">
<div class="col-md-6">
<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- Blog02Inline -->
<ins class="adsbygoogle"
     style="display:inline-block;width:300px;height:250px"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="6162666226"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
</div>
<div class="col-md-6">
<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- Blog03Inline -->
<ins class="adsbygoogle"
     style="display:inline-block;width:300px;height:250px"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="7639399427"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
</div>
</div>

###Ok, but what about your "Work Environment"

[Let's use the environment in the Cracking the coding interview.](https://github.com/claudiordgz/cracking-the-coding-interview) For each chapter in the book I wanted to have one executable with Unit Tests. I wanted to test each exercise, because my first solution is usually crappy, I like rewriting, but I hate breaking something mid way. If I don't seem to find out what is happening, then I roll out the [visual studio project template](https://gist.github.com/claudiordgz/768c18a7d6219ca76086) and start debugging line by line by one of the most powerful debugging tools on the market.

So to process a workspace with the following:

1. Executable
2. Test Project
3. Library to push code

We need the following:

```language-bash
ProjectNameFolder
│   README.md
│   LICENSE
│   SConstruct <---- Master Creator
│
├─── build
│   ├─── debug
│        │   ...
│   ├─── release
│        │   ...
│
└─── include
│    │    helloworld.hpp
└─── src
│    │    SConstruct <---- Passes args to each Project
│	 └─── ProjectName.App
│    │    │    SConstruct <---- Exe Builder
│    │    │    main.cpp
│    └─── ProjectName.Library
│         │    SConstruct <---- Lib Builder
│         │    main.cpp
```

So we need a top level SConstruct file that navigates downwards.

```language-python
# Let's define a common build environment first...
project_name = 'ProjectName' 
project_src = 'src'
# I am using visual c++ for demonstration purposes
env = Environment()
isWindows =  "win" in env['PLATFORM']
if isWindows:
  buildType='debug'
  # My include paths, including the include folder
  include_path=['C:\\path\\to\\include','E:\\path\\to\\Boost\\include\\boost-version']
  # Path to generated libs, which is our build file
  libs_path='E:\\Claudio\\VisualStudio\\CrossPlatform\\ProjectName\\build\\{build_type}'.format(build_type=buildType)
  # Path to other libs go in this list
  extraLibPaths=['E:\\path\\to\\Boost\\lib']
  commonLibs=[] 
  commonDefines=['DEBUG']
  # Extra flags, for example I want Static Linking, and so I use /MT
  commonCFlags=['/MT', "/EHsc",'-O2']
  # Linker Flags as well
  commonLFlags=["/DEBUG","/INCREMENTAL:NO", "/LTCG", "/SUBSYSTEM:CONSOLE"]
  common_env = Environment(MSVC_USE_SCRIPT= "c:\\Program Files (x86)\\Microsoft Visual Studio 12.0\\VC\\bin\\vcvars32.bat")
  common_env['TARGET_ARCH']='x86'
else: 
  common_env = Environment()
common_env.Append(CPPDEFINES={'VERSION': 1})
    
debug_env = common_env.Clone()
debug_env.VariantDir('build/{build_type}'.format(build_type=buildType), project_src)

# And this is the point I navigate to the src folder for the inner level SConstruct file, here I am passing all my variables
for mode, env in dict(debug=debug_env).iteritems():
    env.SConscript('build/%s/SConscript' % mode, exports=['env', 'include_path', 'libs_path','extraLibPaths', 'commonLibs','commonDefines','commonCFlags','commonLFlags'])
```


In the source file I have a SConstruct file that will build all those projects.

```language-python
Import('env','include_path','libs_path','extraLibPaths', 'commonLibs','commonDefines','commonCFlags','commonLFlags')

projectLibs = ['ProjectName.Library']
# We need to build our Libs before our Apps
for subdir in projectLibs:
	env.SConscript('{folderName}/SConscript'.format(folderName=subdir), exports=['env', 'include_path','libs_path','extraLibPaths', 'commonLibs','commonDefines','commonCFlags','commonLFlags'])

projects = ['ProjectName.App']
  
for subdir in projects:
	print("Building> "+ subdir)
	env.SConscript('{folderName}/SConscript'.format(folderName=subdir), exports=['env', 'include_path','libs_path','extraLibPaths', 'commonLibs','commonDefines','commonCFlags','commonLFlags'])
```

And in **EACH PROJECT** there is a SConstruct

<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- Blog04LargeInline -->
<ins class="adsbygoogle"
     style="display:block"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="9116132629"
     data-ad-format="auto"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>

###For the library

```language-python
Import('env', 'include_path', 'libs_path','extraLibPaths', 'commonLibs','commonDefines','commonCFlags','commonLFlags')

lEnv = env.Clone()
lEnv.Append(CPPPATH=include_path)
lEnv.Append(CPPDEFINES=commonDefines)
lEnv.Append(CCFLAGS=commonCFlags)
lEnv.Append(LINKFLAGS=commonLFlags)
lEnv.StaticLibrary('ProjectName.Library', ['main.cpp'])
```



###For the executable

```language-python
Import('env', 'include_path', 'libs_path','extraLibPaths', 'commonLibs')
# toolkit.h is located in this directory, add it to the include path
lEnv = env.Clone()
lEnv.Append(CPPPATH=include_path)

# We include our Library we have just compiled
includeLibs = ['ProjectName.Library']
libsPaths = list()
for lib in includeLibs:
	newLib = '{libpath}/{lib}'.format(libpath=libs_path, lib=lib)
	print("Libpath > Added Lib >> " + newLib)
	libsPaths.append(newLib)
libsPaths.extend(extraLibPaths)
includeLibs.extend(commonLibs)

lEnv.Append(LIBPATH=libsPaths)
lEnv.Append(LIBS=includeLibs)
lEnv.Program('HelloWorld', ['main.cpp'])
```

###How does this Stack Up
I love Python, and if you do and you also love C++ SCons provides an excellent way to maintain your project. **Plus**, it is compatible with [Drone.IO](https://drone.io/), which is fantastic, plus, Drone.IO is free for public projects!

The future looks amazing.

You might think is a bit excessive to have all this. Lately I was steering of adding unknown technologies into my workplace (Epicor Software), but the alternatives are horrible:

#####Alternatives:

- Not adding Test Coverage 
	- I can't live like this, I don't even want to argue. I have given Test Projects to other people to let them understand the code. Testing is fantastic, any argument against it probably comes from either a person that does not test or creates useless tests. I also hate testing as much as I hate washing my hands every time I go to the bathroom, as much as I hate bureaucratic procedures, and as much as I hate writing a structure to my posts, but it is that hate that reminds me I am still abiding to all these things. I test, therefore I hate testing, therefore I design useful tests because I hate testing. Coding a useless test is like not doing your job.
- Creating the same project in two platforms 
	- The same work you say? Where the hell did you get that idea? Let's assume you are in windows and want to use some web stuff, well the low hanging fruit is the windows libraries, then you go to linux and you have all this implementation that works for windows that is now useless crap in your new environment. So you add new dependencies for linux only, like POSIX, then you add MACROS, and congratulations, you have quite possibly just reinvented the wheel, and I am not talking about a Radio Flyer wheel no, I am talking about a tractor wheel of 10 feet diameter.
- Not having a build system. 
	
```language-cpp
// This will be your production process
void production(platform &) {
    while(true){
    	compile();
        run_tests();
        auto result = analyze();
        if(result == true) {
        	debug();
        } else {
        	result = refactor_optimize();
            if(result) break;
        }
    }
    production(other_platform);
}
  
// This could be your production process with a build system
void production() {
    while(true){
    	result = commit(all_platforms);
        if(result == true) {
        	debug(platform);
        } else {
        	result = refactor_optimize(all_platforms);
            if(result) break;
        }
    }
}
```

###Conclusion

Get a build system, any build system, here are some examples:

- Makefiles
- Autotools
- CMake
- Premake
- SCons

Pick one and get good with it, learn to bend it to your will. I picked SCons because I am really comfortable with Python (maybe too comfortable), but CMake is also fantastic and it is a bit similar. The advantages of a build system outweight the disadvantages, it is one of thsoe things you learn once, and use a lot of times. 

####Who uses SCons... some examples


<div class="row">
<div class="col-md-6">
<p>

<div class="row">
<div class="col-md-6">
<p>
<img src="https://www.blender.org/wp-content/themes/bthree/assets/images/logo.png" alt="Blender Logo">
</p>
</div>
<div class="col-md-6">
<p>
The Blender Project
</p>
</div>
</div>

</p>
</div>
<div class="col-md-6">
<p>

<div class="row">
<div class="col-md-6">
<p>
<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/36/Groovy-logo.svg/614px-Groovy-logo.svg.png" alt="Groovy Logo">
</p>
</div>
<div class="col-md-6">
<p>
In the Groovy Project
</p>
</div>
</div>

</p>
</div>

<div class="col-md-6">
<p>

<div class="row">
<div class="col-md-6">
<p>
<img style="background-color:#402817" src="http://media.mongodb.org/logo-mongodb-header.png" alt="MongoDB Logo">
</p>
</div>
<div class="col-md-6">
<p>
MongoDB Database Project
</p>
</div>
</div>

</p>
</div>
<div class="col-md-6">
<p>

<div class="row">
<div class="col-md-6">
<p>
<img src="http://megagames.com/sites/default/files/game-images/Doom%203%20BFG%20Edition%201.jpg" alt="Doom 3 Logo">
</p>
</div>
<div class="col-md-6">
<p>
Doom 3 Project
</p>
</div>
</div>

</p>
</div>
</div>


Keep Producing, keep building, keep progressing.


###Did you liked this post, check out the Study Series


<div class="row">
<div class="col-md-6">
<p>
<a href="http://claudiordgz.github.io/GoodrichTamassiaGoldwasser">The solutions, chapter by chapter, of Data Structures and Algorithms in Python by Goodrich, Tamassia, and Goldwasser.</a>
</p>
</div>
<div class="col-md-6">
<p>
<a href="http://claudiordgz.github.io/GoodrichTamassiaGoldwasser"><img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1414653165/DataStructuresAndAlgorithmsInPython_jdzjhv.jpg"></a>
</p>
</div>
</div>

