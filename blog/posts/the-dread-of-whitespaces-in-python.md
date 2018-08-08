---
title: How to disable a device in Ubuntu
slug: the-dread-of-whitespaces-in-python
date_published: 2014-04-26T23:18:42.056Z
date_updated:   2014-04-26T23:55:19.110Z
tags: Ubuntu 14.04 LTS, Linux
---

My touchpad is constantly killing me and messing with me. Thankfully I got a mouse for that and the touchpad of my MSI GS70 Stealthpro is crap (no joke, it is probably the worst part of the machine).

My Ubuntu is `14.04 LTS`


1. Open a Terminal `Ctrl`+`Alt`+`T`
2. Use `xinput list`
3. Detect the Touchpad from the presented list
	- [![My terminal](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398554196/killing_touchpad_bryf1u.jpg)](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398554196/killing_touchpad_bryf1u.jpg)
4. As you can see my Touchpad has `id=14` so to kill it
5. `xinput set-prop 14 "Device Enabled" 0`
6. Repeat everytime you want to kill it, or create a bash sript for it. 


