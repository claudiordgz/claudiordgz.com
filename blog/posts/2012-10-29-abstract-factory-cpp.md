---
title: Abstract Factory Design Pattern in C++
slug: abstract-factory-cpp
date_published: 2012-10-29T13:48:57.000Z
date_updated:   2015-11-07T15:47:55.990Z
tags: C++, Creational Patterns, Factory, Design Patterns
draft: true
---


The abstract factory patter is part of the creational patterns of programming. It's purpose is to provide an interface for creating similar objects, but we don't really specify a concrete class to be created.&nbsp;
<h2>Why use a Factory Design Pattern</h2>
<p style="text-align: center;"><a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991664/SimpleFactory1_aa6odq.png"><img class="aligncenter  wp-image-9" title="ObjectFactory" alt="ObjectFactory" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991664/SimpleFactory1_aa6odq.png" width="356" height="267" /></a></p>
For example you may want to change the object mini, but the process to create an ObjectMini will remain the same, thus your client only needs to use the CreateObject() Method in this case.&nbsp;

The main purpose of design patterns is code reuse. Code reuse allows your program to be more robust, since you hack yourself to use your own methods just a bit more (since there are fewer ones).

Debugging is easier since you have one method to debug in case an error occurs.&nbsp;
<p style="text-align: center;"><a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991662/SimpleFactoryClientObjec_njkpmc.png"><img class="size-full wp-image-10 aligncenter" title="SimpleFactoryClientObject" alt="How the Client uses the ALL the objects" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991662/SimpleFactoryClientObjec_njkpmc.png" width="343" height="161" /></a></p>

<h2>How to implement it?</h2>
The first thing we'll be needing is the Object and the ObjectMini and ObjectTouch objects. We'll also need a test environment thus we will create a struct of properties.&nbsp;
<h3>Step 1 - The list of includes</h3>
Try to create a unified list of includes, to prevent from loosing track of every tool you have at your disposal.&nbsp;

```language-cpp
#ifndef LIST_INCLUDES_DUMMY_HPP_
#define LIST_INCLUDES_DUMMY_HPP_
#include <iostream>
#include <vector>
#include <string>
#endif
```

<h3>Step 2 - The Dummy Objects</h3>
The Dummy Objects is just a struct of variables for testing purposes.

```language-cpp
    #ifndef VARIABLE_HOLDER_H__
    #define VARIABLE_HOLDER_H__
    #include "list_includes_dummy.hpp"
    
    namespace Dummy
    {
      const std::string VariableHolderName("Objetin");
      const std::string HolderPath("C:VariableHolderhere.txt");
    
    struct VariableHolder
    {
      struct Variables
      {
        int numero_uno;
        double numero_dos;
        float numero_tres;
        std::string numero_cuatro;
      } variables;
    
      struct VariablesSecondPack
      {
        int first_;
        double second_;
        float third_;
        std::string fourth_;
      } second_pack;
    };
    }
    
    #endif
```

And now its time to create our objects and our Factories.

<h3>Step 3 - The Abstract Object</h3>
The abstract object is a class with virtual functions like the following:

```language-cpp
    #ifndef OBJECT_HPP
    #define OBJECT_HPP
    #include "list_includes_object.hpp"
    
    class Object
    {
    public:
      Object(): _variables(NULL) {}
      virtual ~Object(void) {}
      virtual void build(Dummy::VariableHolder * DummyVariables) = 0;
    
    protected:
      Dummy::VariableHolder * _variables;
    };
    
    #endif
```

<h3>Step 4 - The Inherited objects</h3>
Now its time to inherit the Object class. Since our objects "are" the same as our object with minor differences (in theory). Then we can safely code that same behavior in the motherload class (the object), and separate it when devloping each.

```language-cpp
    #ifndef OBJECTS_MINI_HPP_
    #define OBJECTS_MINI_HPP_
    
    #include "Object.h"
    
    class ObjectMini : public Object
    {
    public:
      ObjectMini() { }
      void build(Dummy::VariableHolder * DummyVariables)
      {
        this->_variables = DummyVariables;
        _variables->variables.numero_cuatro = "This is how we test it";
        std::cout << "ObjectMini " << this->_variables->variables.numero_cuatro << std::endl;
      }
      ~ObjectMini(void) { std::cout << "ObjectMini Destructorn"; }
    };
    
    #endif
```

Now comes the ObjectTouch

```language-cpp
    #ifndef OBJECTS_TOUCH_HPP_
    #define OBJECTS_TOUCH_HPP_
    
    #include "Object.h"
    
    class ObjectTouch : public Object
    {
    public:
      ObjectTouch() { }
      void build(Dummy::VariableHolder * DummyVariables)
      {
        this->_variables = DummyVariables;
        _variables->variables.numero_cuatro = "but this Is the Touch Test";
        std::cout << "ObjectTouch " << this->_variables->variables.numero_cuatro << std::endl;
      }
      ~ObjectTouch(void) { std::cout << "ObjectTouch Destructorn"; }
    };
    
    #endif
```

<h3>Step 4 - The Factory</h3>
Now it's time to implement a simple Factory that will return an Object for us.&nbsp;

```language-cpp
    #ifndef OBJECT_FACTORY_HPP_
    #define OBJECT_FACTORY_HPP_
    
    #include "Object.h"
    #include "ObjectMini.hpp"
    #include "ObjectTouch.hpp"
    
    class ObjectFactory
    {
    public:
      Object * createObject(std::string rhs);
    
    };
    
    inline Object * ObjectFactory::createObject(std::string rhs)
    {
      if (rhs == "ObjectMini") return new ObjectMini();
      if (rhs == "ObjectTouch") return new ObjectTouch();
      return NULL;
    }
    
    #endif
```

<h3>Step 5 - Testing the Factory</h3>
We already created 3 objects and one abstract object. This calls for a test, now! before it is too late.&nbsp;

```language-cpp
    #include "Object.h"
    #include "ObjectFactory.hpp"
    #include "VariableHolder.h"
    /// @brief Forward declaration of a function to 
    /// fill data into Testing Object
    Dummy::VariableHolder * fillData();
    
    int main()
    {
      /// Object Creation
      ObjectFactory * factory = new ObjectFactory();
      Object * mini = factory->createObject("ObjectMini");
      Object * touch = factory->createObject("ObjectTouch");
      Dummy::VariableHolder * passing_object = fillData();
      /// Object testing
      mini->build(passing_object);
      touch->build(passing_object);
    
       /// Object Destruction
      delete factory;
      factory = NULL;
      delete mini;
      mini = NULL;
      delete touch;
      touch = NULL;
      delete passing_object;
      passing_object = NULL;
      return 0;
    }
    /// Definition of our testing data
    Dummy::VariableHolder * fillData()
    {
      Dummy::VariableHolder * rvalue = new Dummy::VariableHolder();
      rvalue->variables.numero_uno = 1;
      rvalue->variables.numero_dos = 2.2;
      rvalue->variables.numero_tres = 3.3;
      rvalue->variables.numero_cuatro = "cuatro";
      rvalue->second_pack.first_ = 2;
      rvalue->second_pack.second_ = 2.0000002;
      rvalue->second_pack.third_ = 3.03;
      rvalue->second_pack.fourth_ = "fourth";
      return rvalue;
    }
```
The output printed by this is...


<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991662/Test_zqekw4.png"><img class="aligncenter size-full wp-image-26" title="Test" alt="" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991662/Test_zqekw4.png" width="330" height="50" /></a>

<h1>Disadvantages</h1>
There are many disadvantages with the normal use of an abstract factory. First you already gave your client access to the object, so there is really no need to make an object mess like we had.&nbsp;

Not only that, there is too many object micro management. Thus this needs a refactoring to prevent the object creation from being done by the client.&nbsp;

<h1>What we want</h1>
We want our client to use the factory without knowing anything about the objects. We want our client to access it easily.

And to do this, we have to create a real abstract factory... with function pointers.
<h2>References</h2>
<ul>
<ul>
	<li>Bishop, J. (2007). C# 3.0 design patterns. O’Reilly Media, Incorporated.</li>
	<li>Freeman, E., Robson, E., Bates, B., &amp; Sierra, K. (2004). Head first design patterns. O’Reilly Media,&nbsp;Incorporated.</li>
	<li>Gamma, E., Helm, R., Johnson, R., &amp; Vlissides, J. (1993). Design patterns: Abstraction and reuse of&nbsp;object-oriented design. ECOOP93Object-Oriented Programming, 406–431.</li>
	<li>Pattison, T. (1999). Understanding interface-based programming. Onlineartikel,<a href="http://msdn. microsoft.com/library/default.asp">http://msdn. microsoft.com/library/default.asp</a></li>
	<li>Shalloway, A., &amp; Trott, J. (2005). Design patterns explained: a new perspective on object-oriented design. Addison-Wesley Professional.</li>
</ul>
</ul>
