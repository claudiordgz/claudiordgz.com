---
title: About
slug: about
date_published: 2014-10-30T07:03:29.705Z
date_updated:   2016-02-06T20:03:30.132Z
tags: about me, Reading List
---

<div class="row">
<div class="col-md-2 col-md-offset-5">
<form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="hosted_button_id" value="594VVEHMUN4YL">
<input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>
</div>
</div>

#The blog

This site is built using [Ghost Blog Framework](https://ghost.org/download/), it is pretty cool an simple. They used to be database free but that has change (databases are good). 

## The backend

The blog runs locally on a machine somewhere, to find it we use [nginx](https://www.nginx.com/), and we use that to cache stuff from the blog (like for example extra image files). The caching is also provided by nginx.

Currently there is no CDN prepared for this blog, but maybe at some point later on I create one for it. 

The SSL part you see at the very top (https) is provided by [letsencrypt](https://letsencrypt.org/) a free SSL provider my good friend [Ernesto](https://github.com/ehtd) told me about. It's pretty awesome. 

## The frontend

The front end will be constantly changing and evolving. Right now we are at a point that we will not be doing a lot of changes to the backend, so we will likely continue to evolve the UI.

I worked with Android and Web quite some time now, and one thing that catches my attention is that on Android I can consume information from several providers, and I'm in charge of making it look pretty. 

On web on the other hand things are not so simple, you need to be able to leverage server side rendering somehow. There is a growing tendency as of late 2015 to make everything run on Javascript, which is fine as long as your team is up to speed. 

Sadly, on the Web world, your team needs to know everything about how to leverage backend and frontend, furthermore they need to be good at making animations using CSS, SASS, LESS and good structures on HTML or JADE. And on top we have that JS is becoming more and more opinionated (before I had to talk about modules and revealing modules), with the inclusion of classes and build tools all over the place. 

### Bundling
Gitlab
Some stories in the blog have different functionality, therefore they need different tools and resources. Nowadays there is a tool called Webpack that makes this part easy for us developers. 

### Animations 
You can create animations and UI changes by switching stuff in Javascript, but this only creates unnecessary code compared to doing `.setAttribute('data-state', state);` to change several child classes. 

There is this huge divide between people wanting to do everything in one language, which is always a solid bad idea, against the rest. I'm against moving everything in one place, it is the one thing we have learning in the past century of software development. Of course not everything is so transparent, because they do have less clutter when it comes to importing multiple elements. 

But animations should be mostly done where they're available, so if it's about switching classes in a single **component** (a component is a conceptual thing, which means a single atomic piece in your UI). 

### Global Events

Some **components** communicate with each other. Conceptually speaking this code goes in a higher level somehow. This way components can be maintained in one place and the Blog theme someplace else that includes the global events.

### APIs

After much reading I'll be using [ReactiveJs](https://github.com/Reactive-Extensions/RxJS) which is part of the Reactive Programming project to declutter my API consumption. 

Reactive programming can really help reduce the amount of crap generated when parsing JSON from the web.

## The Devops

Right now there hasn't been much of DevOps going on, which is pretty wrong. I have no analytics of how my servers are doing. The roadmap to fix this is as follows:

####Backend

 - [Continuous Deliver using my StriderCD server](http://cloudci.info)
 - CDNs for Private Content
 - Gitlab
 - Find a way to move Ghost's database 
 - Cron jobs to update Front End code

####Frontend

  - Using webpack
    - Feature toggles
    - Different bundles per story
    - Components for the homepage

#TL;DR

We have a lot to do, and it will not be simple to do. But we need to have a flexible and evolving UI that is also light and simple for the users. I hate it when I open my cellphone and look for my blog to quick check for something I'm coding and it the load slows to a crawl. 


