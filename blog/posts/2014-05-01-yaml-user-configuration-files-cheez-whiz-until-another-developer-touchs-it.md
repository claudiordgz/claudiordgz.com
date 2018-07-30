---
title: Unit Testing in Python... a regular Use Case with code
slug: yaml-user-configuration-files-cheez-whiz-until-another-developer-touchs-it
date_published: 2014-05-01T23:24:43.998Z
date_updated:   2015-07-24T13:21:46.648Z
tags: Python, Unit Testing
---

###Unit Testing

Testing is essential. The worst part of not having a team that believes unit testing is essential for production is mostly that you'll be on your own when designing each test. Most tests are procedural, having parts that will repeat in concept but may differ a little in implementation. For example:

- Testing bad user input.
- Testing null user input.
- Testing wrong characters or different encodings.
- Logging to help the user of what went wrong. 
- Presenting the logs in a easy and readable way.

All these cases will apply to most of your problems. And the implementation should handle each of these. 

These test cases are what I like to call **the fodder**.

You need to get these out of the way, and fast, because there are other test cases that are carefully crafted for each functionality you create.  

### A Simple Test Case

####With configuration files for an application

I love configuration files, they make me feel so safe, users don't really move them. I've used the following:

 - INI in videogames
 - JSON for web applications
 - YAML for everything!
 - XML for most work applications
 - Hell, I've used sqlite files for this which is a **HORRIBLE** idea
 
Configuration files are awesome when:

 - Creating an installer
 - Changing quick things without recompiling stuff
 - Command Line Interface (CLI)
 - Work Environments, for example working with different directories
 - MVC and MVVM, just change a config file from your User Interface and make your Controller use that.
 
If you haven't seen a configuration file, it's ok, you are untainted, a virgin and unconscious. 

But today you shall face reality. Look for xml files in your computer, json files in websites, and files that have no extension. 

Most of us developers dread the day when a tornado comes and erase some lines in our config files.

- But why would you do that?
- That is never going to happen?
- Users usually backup their files before changing them.
- Then let the idiots uninstall and reinstall.

Are just commmon things you will hear when telling test cases to your developers. 

####But what happens when people change the config files?

Usually things get blown to pieces. Thus testing a configuration file is of the essence. We need to be able to tell our user is his configuration file was valid or invalid.

This can be done in the application easily when running the application.

But I still believe that way before running the application we should be able to give the user the ability to test his configuration files.

Since developers love hacking configuration files.

####How to test a configuration file

1. Test for all required variables.
2. Add defaults for variables that is possible to add a default, notify the user of the default.
3. Test for correct input types for all required variables.
4. If filesystem paths test for existence, if possible navigate the filesystem and find the correct value. 
	- For example you user may think a program is in `usr/bin` and provides that, when the app you need may be installed in `usr/local/bin` and not in `usr/bin`. Tell your user of that possibility.
5. Test every single value provided by the user. I use emacs for development now as I don't make as much typos as I used too, but for some time a simple `;` would make me waste 20 minutes. I did not leave the safety of an IDE until I felt I wouldn't make typos and if I did I would detect them. 

> Don't assume your user has left the typo safezone and he is ready to give you clean and pristine input. 

Again, these rules apply mostly to developers. A normal user just wouldn't mess with a config file.

Using the config file from the post of [Annotating Images with TikZ, and converting PDF to PNG](http://www.claudiordgz.com/i-effing-python/) we observe the need for testing.

```language-yaml
#XeLaTex Path
xelatex:  "c:\\Program Files\\MiKTeX 2.9\\miktex\\bin\\x64\\xelatex.exe"
xelatex_args: " -enable-write18 -synctex=-1 -max-print-line=120 -interaction=nonstopmode "
# The path and folder in which 
# convert is stored
bin_hint: "../"
bin_dir: "bin"
img_magick: "ImageMagick-6.8.9-0/" 
# The path and folder that contains  
# the standalone images
img_hint: "../"
img_dir: "latex_standalone_img"
# The path and folder of the output
output_dir: "../../../"
# Miscellaneous options to pass to each image
command_dictionary:
  before:  
    sixhundreddpi: &id600dpi -units PixelsPerInch -density 900
  after:
    resize_for_sharpness: &idresize25 null


# The image list is comprised of the following
# directory: Name of the folder where the image is
# img_name: Name of the img file complete with type
# ARGUMENTS FOR IMAGE MAGICK
# args_before:  args passed before the source img
# args_after: args passed before the target img
img_list:  
  - directory: Example00 
    img_name: Example00-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25

  - directory: Example01 
    img_name: Example01-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25

  - directory: example 
    img_name: DummyExample-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25
```

As you can see this file contains too much variables and a simple typo may wreak havoc, rendering the application useless. Even when converting some new images I was doing something wrong when using the YAML references. 

### Unit Testing Basics

We need to create the following:

1. A *Test Case* for each input 
2. A *Test Fixture* that contains all the test cases.
3. A *Test Suite* that contains every test fixture

The purpose of the fixture is just to give us feedback of what the unit test is doing, and setup the required variables and things required. For example if we are testing a new fixture to create new pieces in a press machine then we need to setup the dies for every test, check the dies, chunk out some pieces, check the pieces, and so forth. All those things are irrelevant of checking the pieces created. 

Most unit testing frameworks provide a fixture mechanism. I decided to create my own for my projects to provide minimal feedback. It is important not to blast the Console because as users we don't really care about excess information, and it accelerates development. 

Hereafter is the fixture.py, it is in charge of giving me feedback of my unit tests. This is not really necessary for CPPUnit or Boost Test Framework, in fact I just checked and python has a [fixture module](http://farmdev.com/projects/fixture/). I created this fixture a while ago and haven't ever looked back. 

```language-python
import unittest
import inspect

def logPoint(context):
    """ Util method for module and class methods """
    calling_function = inspect.stack()[1][3]
    output = '\t in {mod} - {method}()'.format(mod=context,
       method=calling_function)
    print output

def setUpModule():
    """ Load Module - Once per module """
    logPoint('module {mod}'.format(mod=__name__))

def tearDownModule():
    """ Unload Module - Once per module """
    logPoint('module {mod}'.format(mod=__name__))

class TestFixtures(unittest.TestCase):
    """ Fixture Tester Object """

    @classmethod
    def setUpClass(cls):
        """called once, before any tests"""
        logPoint('class {clss}'.format(clss=cls.__name__))

    @classmethod
    def tearDownClass(cls):
        """called once, after all tests, if setUpClass successful"""
        logPoint('class {clss}'.format(clss=cls.__name__))

    def logPoint(self):
        """utility method to trace control flow"""
        current_test = self.id().split(""".""")[-1]
        calling_function = inspect.stack()[1][3]
        output = '\t in {current_test} - {calling_function}()'.format(
            current_test=current_test, calling_function=calling_function)
        print output

if __name__ == "__main__":
    unittest.main()
```

Now we need to inherit from that thing to create a class that holds our unit test cases.

```language-python
import unittest
import TestFixture as fixture

class LoadConfigFixture(fixture.TestFixtures):
    """ Test the config file for proper
        structure and variables
    """
    def __init__(self, testname, config_file):
    	""" We need an argument for the user's config file
    	"""
        super(LoadConfigFixture, self).__init__(testname)
        self.config = config_file
```

We use a simple namedtuple to keep track of the elements in the user's config.

```language-python
#Inner Content Element
ICE = collections.namedtuple("ICE", "name content")
```

That will give us a way to store the users input by `key name` and `content type`.

Like this:

```language-python
>>> print(self.ConfigMock)
[ICE(name='xelatex', content=<type 'basestring'>), ICE(name='xelatex_args', content=<type 'basestring'>), ICE(name='bin_hint', content=<type 'basestring'>), ICE(name='bin_dir', content=<type 'basestring'>), ICE(name='img_magick', content=<type 'basestring'>), ICE(name='img_hint', content=<type 'basestring'>), ICE(name='img_dir', content=<type 'basestring'>), ICE(name='output_dir', content=<type 'basestring'>), ICE(name='command_dictionary', content=<type 'dict'>), ICE(name='img_list', content=<type 'list'>)]

>>> print(self.ImageMock)
[ICE(name='directory', content=<type 'str'>), ICE(name='img_name', content=<type 'str'>), ICE(name='args_before', content=<type 'str'>), ICE(name='args_after', content=<type 'str'>)]
```

So once we got our mocks all we need is to load the user config, which is a test.


```language-python
def test_CheckKeysAndDataTypes(self):
    """ Navigate all the variables un user's config
    """
    self.logPoint()
    for key in self.ConfigDetail:
        self.assertTrue(key.name in self.config)
        self.assertTrue(isinstance(self.config[key.name], key.content))
    for img_pack in self.config['img_list']:
        for img_key in self.ImageDetail:
            self.assertTrue(img_key.name in img_pack)
            if img_pack[img_key.name] is None:
                print "         Warning >   null found for " \
                      + img_pack['directory'] + ": " + img_key.name
            else:
                self.assertTrue(isinstance(img_pack[img_key.name],
                						img_key.content))
```

Of course to run this fixture it would be better to use a **Suite**.

```language-python
__author__ = 'CRodriguez'

import unittest

def preprocessorSuite():
    """ The Preprocessor Suite should holds all the
    tests inside the Preprocessor test module,
    each added as a class
    """
    suite = unittest.TestSuite()
    import TestConfigurationProcessor as config
    suite.addTest(config.LoadConfigFixture("test_CheckKeysAndDataTypes",
                                           "../../CONFIG.yml"))
    return suite

if __name__ == "__main__":
    unittest.TextTestRunner(verbosity=2).run(preprocessorSuite())
```

The output generated would be like the following:

![Output](https://dl.dropboxusercontent.com/u/15672028/Image%20035.png)

Which is starting to look good. There are a number of ways we could improve the output but for the moment it is really useful.

###Adding further debugging messages

Let's suppose a test fails, now we need to locate exactly why and how it happened. This is the purpose of good and golden debugging messages. Let's add some meaningful messages to our test, the concrete test I mean.

```language-python
def test_CheckKeysAndDataTypes(self):
    """ Navigate all the variables un user's config
    """
    self.logPoint()
    for key in self.ConfigDetail:
        debug_msg = key.name + ' not found'
        self.assertTrue(key.name in self.config,
                        debug_msg)
        debug_msg = 'datatype for ' + key.name + " is incorrect"
        self.assertTrue(isinstance(self.config[key.name], key.content),
                        debug_msg)
    for img_pack in self.config['img_list']:
        for img_key in self.ImageDetail:
            debug_msg = "key " + img_key.name + " not defined"
            self.assertTrue(img_key.name in img_pack, debug_msg)
            if img_pack[img_key.name] is None:
                print "         Warning >   null found for " \
                      + img_pack['directory'] + ": " + img_key.name
            else:
                debug_msg = 'datatype for ' + key.name + " is incorrect"
                self.assertTrue(isinstance(img_pack[img_key.name],
                                        img_key.content), debug_msg)

```

And let's put a simple error in the config file:


```language-python
#XeLaTex Path
xelatex:  1 # This is it!
```

And check the output...

[![The Output](https://dl.dropboxusercontent.com/u/15672028/Image%20041.png)](https://dl.dropboxusercontent.com/u/15672028/Image%20041.png)

![The concrete error](https://dl.dropboxusercontent.com/u/15672028/ErrorMessagePython.png)

> That's what we needed, a good message telling us WHERE is the ERROR

Now all we need is to keep adding tests to our fixture until we feel that we can crash the hell out of a config file. Not only that, we can run the unit test in production so it tells us  what is going on. 

##The complete fixture

This is what the whole Unit Testing Fixture would look like:


```language-python

"""
    ConfigurationProcessor

    Testing the hell out of the ConfigurationProcessor
"""
__author__ = 'CRodriguez'

import unittest
import TestFixture as fixture
from collections import namedtuple

class LoadConfigFixture(fixture.TestFixtures):
    """ Test the config file for proper
        structure and variables
    """
    #Inner Content Element
    ICE = namedtuple("ICE", "name content")

    def __init__(self, testname, config_file):
        super(LoadConfigFixture, self).__init__(testname)
        self.config = config_file
        self.configDetail = list()
        self.imageDetail = list()

    def setUp(self):
        """ Check for correct import and create variables
        """
        self.logPoint()
        from ConversionLibrary.ConfigurationProcessor import load_config
        self.funct = load_config
        self.assertTrue(hasattr(self.funct, '__call__'), 'load_config could not be loaded')
        self.__MockConstruction()
        self.config = self.funct(self.config)

    def tearDown(self):
        """ unassemble
        """
        self.logPoint()
        del self.config
        del self.configDetail
        del self.imageDetail

    def test_CheckKeysAndDataTypes(self):
        """ Navigate all the variables un user's config
        """
        self.logPoint()
        for c_key in self.configDetail:
            debug_msg = c_key.name + ' not found'
            self.assertTrue(c_key.name in self.config, debug_msg)
            debug_msg = 'datatype for ' + c_key.name + " is incorrect"
            self.assertTrue(isinstance(self.config[c_key.name], c_key.content), debug_msg)
        for img_pack in self.config['img_list']:
            for img_key in self.imageDetail:
                debug_msg = "key " + img_key.name + " not defined"
                self.assertTrue(img_key.name in img_pack, debug_msg)
                if img_pack[img_key.name] is None:
                    print "         Warning >   null found for " + img_pack['directory'] + ": " + img_key.name
                else:
                    debug_msg = 'datatype for ' + img_key.name + " is incorrect"
                    self.assertTrue(isinstance(img_pack[img_key.name], img_key.content), debug_msg)

    def __MockConstruction(self):
        """ Acquiring mocks
        """
        main_config_keys = ['xelatex', 'xelatex_args', 'bin_hint', 'bin_dir', 'img_magick', 'img_hint',
                            'img_dir', 'output_dir', 'command_dictionary', 'img_list']
        main_config_keys_types = [basestring, basestring, basestring,
                                  basestring, basestring, basestring,
                                  basestring, basestring, dict, list]
        for e_key, e_type in zip(main_config_keys, main_config_keys_types):
            self.configDetail.append(self.ICE(e_key, e_type))
        self.imageDetail = [self.ICE('directory', str), self.ICE('img_name', str), self.ICE('args_before', str), self.ICE('args_after', str)]
```
