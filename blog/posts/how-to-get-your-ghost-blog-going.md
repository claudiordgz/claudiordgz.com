---
title: How to get your Ghost Blog going
slug: how-to-get-your-ghost-blog-going
date_published: 2014-11-13T04:47:47.676Z
date_updated:   2015-07-24T12:38:57.867Z
tags: blog, ghost, about me
---

Today a friend asked me more information on my blog. I told him the condensed version of why I'm using ghost and why I'm using Digital Ocean. But here is some information to shed some light on the subject.

###First, some context

![Bluehost](https://www.bluehost.com/blog/wp-content/uploads/2012/12/bluehost-milestone.png)

I started my blog back in 2010, I knew nothing of what I wanted except that I wanted a blog. Back in the day there was only shared hosting and VPS services. VPS was not even considerable and shared hosting was near 85 USD a year. I remember because it was very expensive for a Mexican Masters student. I paid it and learn how to use Wordpress, SQL, and a little PHP in the process. 

I spent months learning these things as a side hobby, my main hobby was C++. Furthermore, getting the behavior I wanted took days of R&D. Getting a blog was easy, getting what I wanted how wanted cost a lot. 

I moved slowly, and year by year I made some improvements, a pluging here, some anti spam key there. When I wanted a cleaner setup I learned how to create a backup of the database and creating a new Wordpress with better management of images. 

But I had no responsiveness, I needed to manage multiple image sizes. It was developer hell. Eventually things got me to javascript, and that there was a better world out there, it just wasn't with WordPress, it was handling HTML5, and harnessing its resources.

Looking at my options was to use Ghost Blogging Platform, or to use Github Pages and Jekyll. I was so traumatized by the Plugins fiasco that I did not wanted anything that wasn't familiar, so I stuck with HTML5 technologies and it was adieu for server side code. 

###Ghost requires NodeJS

![NodeJs](http://nodejs.org/images/logos/nodejs-1280x1024.png)

I required some changes. First to install NodeJS, register my application folder in apache (using Bluehost). Problem is, I couldn't do this using shared hosting. I said to hell with it, and bought a VPS with Bluehost, that motivated me into pushing forward. In a matter of hours I had my Ghost Blog running using the ghost incorporated theme.

Of course this had a few setbacks, I knew linux and ssh so finding my way around the VPS wasn't hard. I also knew how to configure Apache.

```language-bash
ps aux | grep "process to kill"
```

In which `process to kill` was `node` and whichever got in the way.

All of this was costing a fortune. I though, well, I need my blog, helps me document what I'm doing. But then, the worst thing happened.

Bluehost went down severely. And I felt it because for me, my VPS was costing way too much. I entered youtube and a DigitalOcean ad appeared, *a hosting service for developers*. I had my ghost migrated in a matter of one hour. It wasn't that tough leaving Bluehost, in DigitalOcean there was no CPanel, no Mojostuff, no Cloudfare and ads everywhere.

It was simple and beautiful. And now, everytime I access my server is the same thing.

- Stop the Server, which in DigitalOcean is nginx
	`nginx -s stop`
- Kill ghost

```language-bash
ps aux | grep 'node'
kill -9 idnumberghost
kill -9 idnumbernode
```
Recently I moved my wife's blog and discovered that her ghost was registered as a service by default.
```sudo service stop ghost```

- Make Changes
- Reload ghost usually with `npm start production &` or `sudo service ghost start`
- Reload nginx `nginx &`

Managing my blog became easy, and even adding new stuff is also very simple. It is the **Making Changes** part that gets hard, and that is a good thing.

###What will happen in the future

![DigitalOcean](https://www.digitalocean.com/assets/images/logo-3b02463b.jpg)

I'm loving DigitalOcean, they never spam me even if I delay on the payment. I pay 60 usd a year. Bluehost is also cheaper now than in 2011, go figure, but the freedom I get with digital ocean is enough for me, no cpanel crap, no call customer service, no nothing, just me, my virtual machine somewhere in New York, and a Linux console.

Which may be daunting for some people.

###But why Ghost

![Ghost Logo](http://0v.org/content/images/2013/Sep/ghost_logo_big.png)

There are many reasons, like simplicity, responsiveness, easy to push content, markdown syntax or html, access to my css and js files from the markdown screen. But it all boils down to one thing:

> No database

My comments are handled by Disqus, my images by Cloudinary, my hosting by DigitalOcean, and my web Technologies are my decision.

###What if I want a *free* alternative

![octocat](http://www.revive-adserver.com/media/GitHub.jpg)

The only free options I see that comes with **Owning your blog** are **Github Pages** and **Bitbucket Pages**. Currently I am using github pages for the [Study Series](http://www.claudiordgz.com/study-series/) and I have to say it is pretty amazing.

![Bitbucket](http://www.tecnocomputing.com/wordpress/wp-content/uploads/2014/05/bitbucket.png)

Bitbucket is very similar to Github, it is amazing as well. I try to use both. I use Bitbucket for my work projects since they offer free private repos, so I can work on anything and get a full blown repository in there.

####Some pointers

1. You need to pick and know the technology (Ruby, Go, JS, Python, etc), I use LaTeX and HTML5, right now I am using the hell out of Bootstrap 3.
2. You can use AngularJS, very powerful stuff to build a full fledged WebApplication... hosted on github pages... for free... come on, that is pretty fucking awesome.
3. You can even host a game in there, pure HTML5.

Getting a blog up should not take more than 10 minutes. To this day if you don't have a blog it is because you don't want to. I love having a place to relax and talk a bit to myself about what is going on with my life. 

The thing that takes a **HUGE** amount of your time is getting your blog to look like what you have in your head. And this is great, you will face the frustrations of not even knowing what **YOU** want as a consumer.
