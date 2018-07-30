---
title: UML tools notes
slug: on-staruml-2
date_published: 2014-11-10T16:32:10.081Z
date_updated:   2015-07-24T12:40:03.746Z
tags: C++, Architectures, UML2.0, Doxygen, Visual C++
---

I had a big surprise today, something very unexpected. So unexpected in fact, that writing about it was of the essence. 

The first tool I used to learn UML was [Enterprise Architect](http://www.sparxsystems.com.au/products/ea/index.html) by [Sparx Systems](http://www.sparxsystems.com.au/). It was an excellent choice because years later I would use it at AMI GE to reverse engineer legacy code. To be honest I've never been a big fan of Modeling tools, but not for the reasons you may think. 

<div class="row">
	<div class="col-md-10">
<p>I can't use a tool to build something I have not built using my own knowledge. The main reason is that I discovered template metaprogramming ever since I read Modern C++ Design: Generic Programming and Design Patterns by Andrei Alexandrescu.</p>
	</div>
    <div class="col-md-2">
		<a href="http://www.amazon.com/Modern-Design-Generic-Programming-Patterns/dp/0201704315/ref=sr_1_2?ie=UTF8&qid=1415632624&sr=8-2&keywords=modern+c%2B%2B"><img src="http://ecx.images-amazon.com/images/I/914ncVx1hxL.jpg" alt="ModernCPP"/></a>
	</div>
</div>

I was having such a hard time with UML, mostly because I could think of several ways of doing the same thing. It was until years later that I started accepting things that I could let go and use the best course of action based on simplicity.

For example nowadays I like leaving free functions enclosed in a namespace, a simple way of implementing a module whereas the usual way of doing this is to enclose the functions in an object. This may seem trivial but it is not, it has a great deal of issues down the road. For example every function can become a function object, but every object that holds 10 similar functions or functions that belong to the same area may eventually share dependencies in a way that is hard to tear apart later on.

I don't like managing a lot of libraries, specially in visual studio where adding compilation flags is bothersome. 

So I don't do UML first, what I do is I build vertical hierarchies. Modules using naemspaces, function objects to hold states, and try to keep my classes as lightweight as possible. Similarly, I don't do a lot of inheritance, I prefer to use composition and Policy Based Design.

Policies and Templates have a higher degree of complexity since not a lot of people have dedicated the time to them. So this carries a big weight, which is that I need to documenting my code, I use Doxygen for this, since eventually it will generate me my UML diagram using Graphviz and I will be able to see if it's a tree instead of a spider web. If it is a Spider Web, then I refactor some parts until it is a tree. 

I also do Unit Tests, a great way to document my code. If I come back months later then I just debug the code until I get a grasp of it, a read some parts of the documentation to get the hang of it. 

But today I didn't have any of those things. I am going back to a recent project, I had to refactor the thing until it was a library, executable, and testing project, separated some bloat parts, and I am still considering going a bit further but first I need to finish some features. 

So I decided to check the UML first. 

###StarUML 2.0

I discovered my laptop had no Graphviz, that means no UML generation for all my comments, not a problem since I had not define the modules just yet (in Doxygen I mean). So I decided to download the next best thing, the [StarUML Modeling tool](http://staruml.io/). I had a very pleasant surprise to discover it had been revamped with slick visuals.

So StarUML went from this:

[![The usual](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415634467/48455_n7llbi.jpg)](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415634467/48455_n7llbi.jpg)

To this.

[![Slick Visuals](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415634402/Image_064_enw7ct.png)](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415634402/Image_064_enw7ct.png)

There is just one problem.

It can't use the extensions from StarUML 1, so no UML Generation from C++ Code. It is fine, I download StarUML 1.0, load the code, and set up some links here and there, and open my ***.uml file in StarUML 2.

[![Example](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415637311/Overview_of_RetrievalUtil_vxzaee.svg)](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415637311/Overview_of_RetrievalUtil_vxzaee.svg)

This is not the actual code, I removed the source objects. What this does is **maps** a JSON object to a struct object inside my code, and thus when loading that JSON I can translate back and forth a string without actually storing anything. The ElementAdapter is creating depending if it is a Object1 or Object2 and also depending if it is an Input or Output. Like the following:

```language-cpp
ElementAdapter<Object1Policy<Input>>  instance;
ElementAdapter<Object1Policy<Output>> instance;
ElementAdapter<Object2Policy<Input>>  instance;
ElementAdapter<Object2Policy<Output>> instance;
```

This is exceedengly convenient, and this way I don't store anything. 

So far I am really enjoying the new visuals in StarUML2.0, plus seeing my dependencies like this really helps. Now I need to draw the Namespace modules to help understanding what is going on. 

I will keep using StarUML2.0 to expand my architectures and who know, maybe even use it to generate my code, and just optimize it later. 
