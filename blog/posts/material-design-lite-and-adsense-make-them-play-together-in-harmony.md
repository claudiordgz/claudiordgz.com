---
title: Material Design Lite and Adsense, make them play together in harmony
slug: material-design-lite-and-adsense-make-them-play-together-in-harmony
date_published: 2015-08-11T14:16:39.080Z
date_updated:   2015-08-11T15:11:38.799Z
tags: Javascript, Material Design Lite, Coffeescript, Adsense
---

##Internet blackout

This week has been hot and humid, and I have no internet. I have my company to thank for which they politely called me on Friday August 7th to tell me "Good morning Sir, you will be out of internet because we are rewiring your housa". To which I politely asked "Miss, I have no internet as of now Friday 10am, when will I have internet", "Oh Sir then I will escalate your problem into an emergency and we will rush service and rewire your service at Tuesday 18th August."

<div class="center-unknown">
<div class="el">
<img src="http://media.giphy.com/media/f144V7o9zIhTW/giphy.gif" style="max-width: 398px; margin: 0 auto 0 auto;">
</div>
</div>

The router was reset around 4 times that Friday, with the same results and that fail cat. 

I gave them a call that evening around 9pm, some lady which was clearly talking about the weekend plans with her peers said she escalated the issue and people would be coming to my house the next day (I remember because she said tomorrow). I'm not sure if it is relevant, but setting up that appointment took 40 minutes, mostly waiting. 

The next day We waited, probably the thing I hate doing the most in this life (right next to eating shit). But since I was piss poor because I got a new washer and dryer that week it matter not, we could not go out anyway. So no harm done there in waiting for a plumber, which never came, and for my internet company, which also never came. 

My wife called the company, it seems that the appointment was for Saturday 15th, so we were waiting for naught all day. She re escalated the issue but the little guy on the phone told her there was nothing he could do, it is just the way things are in this company. It took the little man a solid 50 minutes to say that and to fail miserably. 

I'm not sure why they want to do surveys about customer support, What is the point of having customer service if these guys can't do anything for your situation. They are powerless, so any second spent on calling them is a waste of time. This may not be the case for 90% of people, but man, If I had Google Fiber as a viable option I would drop this shitty company as fast as a girls panties thrown at Rockstar's faces.

On Monday my wife called them again, and got promised that we wont be charged for these days outages, which is a promise yet to be seen, and she managed to get the appointment moved to Wednesday, which is a movement yet to be seen as well, with how these guys work it may be possible they meant Wednesday of the next year. 

I managed to finish my Table of contents using a nifty library called HammerJS, but I can't push it because I have no internet at home, so I have to go someplace like Starbucks to do it. Did I mention I was piss poor this week? It seems to be not enough as USPS managed to stole my rent check, I am still hoping they find it, I don't know why these Realty Companies want to be paid in checks and risk their homeowners in loosing a check that takes around 90 days to be refunded if lost. 

##Material Design Lite

A few weeks ago I started implementing [Material Design Lite](http://www.getmdl.io/index.html) on this blog, it has been a slow migration as I remove some features and clean some unnecessary pieces. 

### No Ads for some reason

I noticed that the ads in the site were jumping around and I also noticed that each post loading was all over the place, taking multiple runs and sometimes failing for no reason. Because of this Ads from Adsense would load several times, until they load no more, and thus most of the ad slots appeared empty.

### Not alone in this issue

[I went to the project Issues on Github and saw that someone also had similar isues](https://github.com/google/material-design-lite/issues/1224#issuecomment-127447822). 

Material Design readjusts some pieces during runtime, so we should give it some time to do so before actually loading the ads. 

On the issue Surma commented the following:

> [The mdl-componentupgrade event] should fire exactly once on the element being upgrade (i.e. the node with .mdl-layout). Our upgrade procedure runs after page load, so that should work as well. Give it a try and let me know :)

###The fix

So to do this was very simple:

```language-javascript
setupHandler = function(event) {
    theme.init(); // In here I reload everything related to the theme
    toc.init();   // In here I load the TOC, which will be refactored to some post.init() later on
    [
      {
        src: '//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js',
        asynchronous: true,
        element: null
      }
    ].map(function(script) {
      scriptLoading.loadScript(script.src, script.asynchronous, script.element, adsLoaded);
    });    // Here we load the Adsense objects and let Adsense worry about it
    window.removeEventListener('mdl-componentupgraded', setupHandler, false);   // And never do it again, just run once
  };

  domready(function() {
    return window.addEventListener("mdl-componentupgraded", setupHandler, false); // In here we want to run our setup only once, never twice or more
  });
}).call(this);
```

Or in coffeescript:
```language-coffeescript
setupHandler = (event) ->
  theme.init()
  toc.init()
  [
    { src:'//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js', asynchronous: true, element:null }
  ].map (script) ->
    scriptLoading.loadScript script.src, script.asynchronous, script.element, adsLoaded
    return
  window.removeEventListener('mdl-componentupgraded', setupHandler, false );
  return

domready ->
  window.addEventListener("mdl-componentupgraded", setupHandler, false);
```

Material Design Lite helps a lot when it comes to doing pretty and modern looks on the internet. I hope that by showing how to solve something so simple but crucial for most websites people feel more motivated to adopt a gorgeous look on their sites. 

Cheers. 
