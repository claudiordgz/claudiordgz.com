---
title: Supremacist based design
slug: supremacist-based-design
date_published: 2014-03-20T07:20:12.644Z
date_updated:   2014-03-20T19:37:43.935Z
tags: blog
---

Lately I've been dedicating a lot of my time to Stack Overflow. Some of the questions posted are just perplexing, some others are just so easy that it feels refreshing to answer them.

My approach is simple, provide a working, correct, and complete solution. [One example was were a user asked how to implement dynamic memory management](http://stackoverflow.com/questions/22491004/dynamically-set-array-size-c/22491076#22491076)

> Please, sir, do not ever suggest using naked pointers. Especially to a person who is not experienced with C++. –  Jefffrey 

I was impressevely bashed for my answer using pointers. But one of the comments shine above the others.

> The goal is not simply to answer questions, but to answer them with best practices and modern approaches in mind. If someone Google's this question and sees this answer, it will perpetuate raw pointer style, which some would go so far as to call deprecated in modern C++. – Sam Cristall

This is a very good point. This is so good point in fact it is the very reason I believe in a community like this. I can post an answer and be provided feedback like this is extremely valuable for my own development.

The problem was that people chose to **forget** what already exists. As if telling people `DON'T LOOK AND DON'T LEARN, IN FACT, RUN` would make somehow the code in their future jobs not have pointers.  

The fact is obsolete practices are everywhere, embedded in very important pieces of software.

But instead of choosing to learn the obsolete practice and learning how to refactor it, handle it, and get better. The community prefers **PASTE** the correct way, without warning of the present. Of course this has its problems since you shouldn't fix what is not broken in the first place.

> The community choses to forget what is wrong with using raw pointers and why the need of iterators and standard practices.

Repeating **you should use the standard** is just as important as saying **why should you use the standard**.

>Because not explaining why breeds dogmatic behavior.

### What is the cost of this Supremacist Community?

Today I was a bit tired at work... so I decided to post an extremely newbie answer at the site. A user wanted to implement dynamic memory management without using `std::vector`, which again is very understandable given the nature of schools and C++. My own college keeps teaching mostly C and not standard C++.

I decided to answer blunty with: [just encapsulate an implementation of your own vector class and then provided an example](http://stackoverflow.com/questions/22519971/array-of-objects-with-non-default-constructor-and-without-using-stl/22520089#22520089).

This wasn't received well.

One of the comments actually **recommended to start by using the stl vector header file**. Another user was pestering me because my answer was not complete. All I could think of was to scream, somewhere, to someone, anyone... **Well of course it is not complete, my answer is implement your own vector, I ain't doing the implementation for the OP**. 

Depending on the users that are responding at that time you will be presented with different challenges not regarding programming at all. Useless to learning new things, useless to getting better at handling multiple problems.

The problem with supremacy.

As every supremacy has proven across all ages.

> Supremacy breeds fanatism.

> Fanatism breeds ignorance.

> Ignorance breeds Unadaptability.

This course of events has happened across thousands of years. To say it will be different with stackoverflow is like saying you will never ever ever kiss the ugly girl no matter how many beers you drink, you will never be in debt, you will never be head over heels, is like vomiting stupidity out of your mouth into the face of history. And history all it can do is clean itself up, and remain there, like the girl from the grudge, staring at you with those big eyes. 

This is a community of millions of users we are talking about, and these are complex subjects. We have laws because we need laws, we have proven it over the course of hundreds of years. What has me all perplexed and scared is the same question all over again....

> Who watches over the watchmen?

Because the community certainly can't, they are banned, buried in downvotes, and overal cast out, just like a nice guy who is creepy and tells terrible jokes. 

### Should we be worried?

Programming is hard, but there is this amazing feeling of solving a problem that comes easier when programming. A big software gets divided by packages, components, and modules. 

Every single module has multiple functionalities. Each functionality is an independent problem. Each problem will feel good when its solved.

I was reading [Jeff Atwood on his rubber ducking problem](http://blog.codinghorror.com/rubber-duck-problem-solving/) and I start seeing this trend.

> We create these communities to help the community so that they can solve everything on their own.

In the end, there is nothing that will alienate you more from society than being a perfectionist prick, which is a huge disclaimer people should tell others when getting into a certain type of area. You want to program, good, you want to be an **shole about it, then be prepared. It's just the way it is. The inability of people to remember they were just as newbs as anyone else perplexes me. 

I may be speaking for myself, even though these communities feel like an essential part of learning how to program, they are still lacking the `beginner` feeling I get from watching the video tutorials from youtube or [Rails for Zombies](http://railsforzombies.org/).

### It could be the language

When I started learning C++ it was really hard since no one was really sure about following the standard. Nowadays you get cruxified for not doing so. But then I go back a few steps and see other less messy languages, for lack of a better word, you observe how the people are happier, they are glad to help.

Easier languages breed more programmers. 

But somehow... C++ breeds hatred. I love C++, but I don't feel as a C++ fanboy mostly because I grew in a world were standarizing mixtures of C/C++ was done to fix bugs and prevent further ones, it was my bread & butter for a while (and to a point it still is). 

### Do we really need to be code supremacists?

This is a gray area. When are we going to care more about purity of standards than about features? 

So to my fellow supremacists:

It's all about the customer, it's all about the industry, and it's all the need to maintain, evolve and create new features continuously. 

If you need none of that... you don't need to go all perfectionist on everyone's ass. But always keep in mind one thing, a good salesman moves the customer's assets into his pocket.

If your supremacy standards are moving programmers away from programming, maybe you should rewrite your gospel. Note that I'm not saying you should stop being a perfectionist standard purist **shole, I just believe it is in your best interest to coco wash programmers into following you into the depths of standards itself. Don't push them away, send them on a crusade, take heed of the past and go ahead a repeat it.

Just be sure of what you are doing, and take the consequences like a man. 









