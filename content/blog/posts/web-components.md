---
title: The need for Web Components
slug: web-components
date_published: 1970-01-01T00:00:00.000Z
date_updated:   2016-02-09T00:12:15.421Z
draft: true
---

##The Study Series

The Study Series is a project to document studies using LaTeX, currently going through a full redesign in both Application Level and System Architectures. 

It all started with a careful review of the Study Series's tech stack, and a careful review of what is required in terms of usability. Interestingly enough, the requirements are very similar to any customer's requirements. 

##Requirements and their importance

Back when I was a kid, I used to shuffle my bedroom quite often. Move the bed a bit to the right, change some furniture for a recycled one my parents renewed, move stuff from a drawer into a cabinet, probably some paint job here and there, probably some maintenance which involved killing some pest. Maintenance was simple, and could be done in a different time (so that means redesign and maintenance could be separated). 

This reminds a lot of my customer's requirements:

 - I need a new set of furniture 
 - I need to make space for X new documents
 - I need to change the layout and colors
 - I just need to change colors
 - That pile of stuff, I need to reorganize it and place it into binders and then place it into some newly installed equipment.

During that process the customer may or delegate the following:
  
  - I got a new drill, please use it.
  - Please use the Interior Designers 37 LLC for the interior layout and colors.
  - Please provide your own tools except for the drill.
  - Please install a new sound system for my current TV, it is a very old 17 inch CATV.
  - Please also install a new TV, one of those flat LED TVs with the highest resolution available and something to play the latest media.
  - I want the same sound system to work for both, same goes for the media player. 

That sounds very reasonable to me, all of it. We can assume some things safely:

  - We can't glue or drill any furniture to where it is, since the customer may want to shuffle all the things at a later date. 
  - We seriously can't change the customer's documents, and if we taint them, all hell will and should break loose. 
  - Everything the customer wants in binders needs to be carefully reviewed during that clean up process.
  - We may bill for two sound systems and two media players, and we may bill for a switch between both systems. 
  - We may bill for one big piece of furniture with wheels, though we first need to measure where it is going to be placed. 

Now let me be blunt for one moment. When talking software... **it is exactly the same shit.** 

##We need more granularity

One thing I learned from working with the [Android Open Source Project (AOSP) source](https://android.googlesource.com/) and from the [Software Architecture Bundle books from Simon Brown](https://leanpub.com/b/software-architecture) is that Software shouldn't be modeled as a giant Behemoth of an application paired together with a leviathan of a Web Service paired together with a Cthulhu of UI. 

Software should be a perfect sized town, with balanced semaphores of traffic and well designed streets and public transportation system so that everyone can move around. A Town because sometimes businesses die and buildings (resources) need to be re purposed into new businesses. A place with buildings containing data warehouses (databases) and complex management and security operations to protect such data. A place with multiple forms of communication, with each owning its own logistic logic. With buildings that can be torn down and built using wood and then torn down again in months and built using glass and metal beams. 

Because when talking about software, everything can be destroyed, improved, repeat. 

##The AOSP as an example

The AOSP is lovely modeled. With drivers built using C, then some extra functionality or just a wrapper added in a C++ library using that C library, then a JNI library that calls that code or the c code directly, then the Android SDK in Java that can be used using any language that translates into the JVM (i.e. Java, Kotlin, Scala, Clojure, Jython, ..., among many others). 

Obviously this is a huge undertaking. Each one of those things is a git repository, to retrieve your Android version you would need EACH of those projects. The process is very pragmatic, you first retrieve a wonderful python script called `repo`, after which you use it to obtain the manifest of the android version you which to download. This is going to look like this: `repo init -u https://android.googlesource.com/platform/manifest -b android-6.0.0_r7`, after which you do a `repo sync j∞` and wait for all that sweet source to download. 

Then you should go to sleep, it's going to take a while. 

##Pain is a choice

Setting up a work environment is **painful** and should only be done when building the entire distribution. But if we only need to make changes to one project we can use other tools. We can do unit tests, offline edge cases tests (we say offline because is just specifically for that project the developer is working on at that point), and then we go an setup the entire distribution. 

This is a process I have seen **nowhere** but in the wonderful world of mobile apps. Business oriented mobile apps (not videogames, text editors, media players) are a blessed breed. They get to communicate with a few APIs, retrieve some data, and then just display that data. It's a simple process made to tackle the hardest thing of them all... *change*.     

Some people take years to prepare their car for an auto show. They customize paint, suspension, engine parts, hoses, seats, and even extras like a full blown home theater. An application, specially the user interface, is a lot like a car that is going to an auto show, the only difference is, the entire interface needs to change entirely in 6 months time after receiving the input from consumers. 

Depending on the groundwork, those 6 months may turn into `years * N`, where `N` is the amount of time that was required by business to say the magic words **just build it from scratch**. 

##Everything is a module

Building reusable components in Android is a drag. Doing them in WPF is also a bit a drag. Doing them in Kivy is a bit easier. There is usually not a recipe to do it, and we say "we'll let the man that will do it in 5 years worry about it". Which is a sure fire way of getting the current code scrapped into a trash, and it is a damn shame. 

For example in WPF you are on your own with a big trail of MVVM explanations and implementations in different ways. It will probably take solid 80 hours before you turn your Status Bar, your Menu Bar, your Widget, and your Dialog Box into 4 different components each in its own separate library with it's own set of Unit Tests and use them comfortably from your Application. That is if you don't give into temptation and pull one variable from a module into another. 

*Even though I walk through the valley of freedom, I shall fear all comfort, for there is no one with me; no rod to hit me in my head, no comfort before me.*

Of course most teams nowadays are **agile**, a word just as misused as the bible itself. So to try to sell to a customer that we will take 2 extra weeks to convert every feature into a module is plain down stupid. I learn these things on my own. I have always been successful at work, and anyone can be too, as long as they give a shit. Learning the process to make **anything** into a module requires two things. First comes the fresh knowledge, which will take some time, then repetition. Which if you turn everything into a module there will come a time when that is how you start to code anyway. 

Eventually you'll learn that you also need micro web services with its own set of modules inside. Same thing, learn to build one, repeat. 

##We have the tools

In chronological order from 2009, The first time I:

 - Used LaTeX I couldn't believe it. 
 - Developed with boost I couldn't believe it.
 - Used pip with a requirements file I couldn't believe it. 
 - Used [biicode](https://www.biicode.com/) I couldn't believe it.
 - Developed unit tests AND doctests with Python I most definitely couldn't believe it.  
 - Used npm I couldn't believe it.
 - Used gradle in an android project I couldn't believe it.
 - Developed unit tests using [catch](https://github.com/philsquared/Catch) I couldn't believe it. 
 - Used AMD modules I couldn't believe it.
 - Used the revealing module pattern I couldn't believe it. 
 
Every single time... I couldn't believe it. 

I once saw a function span thousands of lines of code. When that function failed, we restarted the system. To this day the memory of that decision haunts me. Developers are usually the hit man in the development process, software architects are the ones who order such hit, both hold the same level of guilt. Sometimes a developer may very well be the architect. Sometimes he is just the forensic's guy, tasked with cleaning up a rotting dead corpse for the following years to come. I'll state the obvious, don't maintain rotting corpses. 

The problem with code is not the language, it's the implementer. And the problem is not training the implementer, as human beings we feel and when we are angry we may very well take it up with the code. So you may think **CODE REVIEWS**, and speak it as a believer would shout his deity's name. Sadly, if the project is rough or if the mood is wrong, then both implementer and reviewers wont care, just as nobody cared about any other tragedy in human history. 

We can adapt to anything, even hell itself... just ask any drug addict. 

##The Wrong Tool for the Wrong Job

I once maintained a reporter of sorts, it received a bunch of data, maintained current and previous state, made some calculations, then send that data through a SOAP web service. It was in C++, and it was the most interesting thing. 

We ran into stack overflow issues, data type issues, memory leak issues. The problem was not C++, the problem was the simplicity of the requirement, C++ was not even remotely a good fit for the requirement, we had no performance gains from using it. But because of the simple requirement, people expected a fast solution without considering building the proper checks required by C++98. 

C++98 takes more time to develop than Javascript or Python for example. Consider the type checks in the unit tests, the stack overflow tests, and the memory leak tests. Data type would probably be removed and maybe just a `null` check here and there. Memory leaks can happen anywhere. And stack overflows can be prevented using some library. Plus seeing an error on a browser saying your script has crashed is better than urging into a client's system, retrieving the log data, then read the logs to find a possible memory leak, either that or receiving a phone call at 3 am. What if the client is in Siberia and you are chilling in some remote beach in Guaymas, Mexico.

You will find some people that say '*it is impossible to find the perfect tool for the job in software*', and such thing is by all means correct. But I could tell you a number of ways you can pick **A** wrong tool for the job. It can also be the worst tool for the job, for example building a solution in a language that is not supported in the target platform. 

Software itself is a tool, so just as you can pick a wrong tool, you can also create the wrong tool. 

##Tackling Change

Change is the single most important thing software must tackle. Some people will say "that it works" is the most important thing, sadly it isn't, because working is not optional. Software must work, you won't get away with it not working, and the people working with the solution will pay the price if it doesn't work correctly. The first priority is to get a solution, 

Some tools are perfect and will never change, but some others will. Which is exactly what pains me about Applications. The UI will change, the content will change, content retrieval could change, calculations/operations on content could change, but are not likely to change. We are at a stage were it is possible to finally separate things into change ratios. 

###Agile in Architectures

Agile tends to put *Architecture* for later, and then it becomes a *it doesn't sound as a good investment*. That is true, it doesn't and it probably is not a good investment to create a good solid foundation once you already built an entire structure on top of a non existing one. Just as if you built a house on land without checking the ground compression and in the next rain your entire house may or may not fall apart. 

Foundation is set from the beginning, and it is a very mechanical process, and it requires some maintenance constantly. The bigger the house, the bigger the foundation. If you want a solid talk of this concern check the following Keynote of the [O'Reilly Software Architecture Conference in 2015](http://conferences.oreilly.com/software-architecture/engineering-business-us):

<iframe style="width: 80%; margin: 0 auto;" src="https://www.youtube.com/embed/VjKYO6DP3fo" frameborder="0" allowfullscreen></iframe>

My background as a Mechatronics Engineer has been a lot of help in this area. Part of the problems We've encountered in every team has somehow been tackled by Engineers in other areas, specifically everything taught in the Lean Manufacturing area.

###Change in software is different than change in other areas

Software is ubiquitous at this point in life. A software solution's lifetime is dictated by the market it owns. If the software is generating billions, you can be sure some people will want a piece of that action. Since software can be designed and created anywhere with a computer regardless of ergonomics, proper lightning conditions, good coffee, then you can safely assume that most companies are cooking their own competition if they treat their employees unfairly. 

People rise to the occasion, and nothing makes people rise higher than an unreasonable purpose. Constant design errors bring people down. Constant nagging about UI by business because they realized they didn't want the first thing in the first place also helps. Constant harassment of the implementation team because they promised a wrong date. All of those are potentially the tipping point between owning 100% of the market now and 10% later. You can see Kodak's history for good examples of breeding competition and making moves into other markets too late in the game (markets they invented). 

We can't really control these things, and that is OK. It is not really a problem for us. The problem is that when the time comes to tackle the new kid in the block, we must be able to tackle change to keep our solution marketable. This wouldn't be too much of a problem if we analyze our user's and improve the way they interact with our solution, but that is another subject entirely. So we can either accept that change will come in the form new competition, or we can accept that it will come because we want to improve everyone's life. Not changing is not even part of the discussion.

This is not new, in fact this is pretty much of the same that has been said for the last 20 years or so. I did experience the DLL hell which was one of the problems that was fixed by package managers (such as `npm`, and `biicode`).  

##Wishful Thinking


