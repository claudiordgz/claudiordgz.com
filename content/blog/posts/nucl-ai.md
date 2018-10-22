---
title: Nucl.ai & Blog Updates
slug: nucl-ai
date_published: 2015-08-18T23:06:58.867Z
date_updated:   2015-08-19T16:07:22.454Z
tags: blog, Coffeescript, Nucl.ai, HammerJS
---

Logo picture from [Antoine Fortier](https://twitter.com/mafzzz) twitter's.

##The resolution of the interwebz

My internet was restored on Wednesday August 12, I can't really speak well for the company though. You just don't say 'attaboy' to someone you harassed, bent, and forced into submission. This is the beginning of keeping tabs, and micromanage the hell out of someone, this is how it starts. Because that is what a good dictator would do. 

Sadly the internet alternatives are not exactly any different, so dropping this one for another is... not an option. 

##Game AI and Nucl.ai

Speaking about keeping tabs, a few months back I discovered [Nucl.ai](http://events.nucl.ai/) while I was browsing the news on [AiGameDev](http://aigamedev.com/). I couldn't attend the conference for obvious reasons (piss poor), but their are eventually placing all the conferences online so not everything is lost. 

Lots of super cool stuff happen in these conferences, for example reading about the [state of the art in skin graphics](http://gl.ict.usc.edu/Research/SkinStretch/). I mean seriously just look at this stuff:


<div class="center-unknown">
    <div class="el">
        <img alt="no-responsive" width="300px" src="http://gl.ict.usc.edu/Research/SkinStretch/images/figure02.jpg"/>
    </div>
</div>

<p>
So why do I bring Nucl.ai up? Because on Thursday Alex Champandard was tweeting that Nucl.ai is bringin a course on Game AI. Videogames nowadays use very hefty AI, and it is only getting better, which is super cool. 
</p>


<div class="center-unknown">
    <div class="el">
         <blockquote class="twitter-tweet" lang="en">
         <p lang="en" dir="ltr">Those of you already keen on taking our Game AI course in Autumn, we could use some advance help for extra credits! 
<a href="http://t.co/Gml74fYdQX">pic.twitter.com/Gml74fYdQX"</a>  
         </p>
         <p>&mdash; Alex J. Champandard (@alexjc)
         <a href="https://twitter.com/alexjc/status/631948266859425792">August 13, 2015</a>
         </p>
        </blockquote>
   </div>
</div>


##More on Nucl.ai

Right now Nucl.ai is steadily growing and fortunately it will be easier to find out more stuff for people like me who can't afford to go to the conferences (hopefully not for long). But at least I can find out more info on [AiGameDev](http://aigamedev.com/), a wonderful hub of discovery in AI and videogames.


##Blog Status


The latest things I was working on before working with the Nucl.ai guys was developing stuff for my blog. Since I had no internet during one weekend I decided to pick up HammerJS, a small library that is **readable** in case I decide to read source.

My end result was finishing the Table of Contents.

<div class="center-unknown">
    <div class="el">
         <a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1439937621/out_pixhuc.gif" targe="_blank" alt="cloudinarySwipeNavGif">
         <img alt="no-responsive-SwipeNavigationDrawerHammerJS" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1439937621/out_pixhuc.gif" style="width:100%; max-width:640px;"/>
          </a>
    </div>
</div>


###The Table of Contents (TOC)

The table of contents (or navigation drawer as I call it because of the functionality) now has the proper elements in the index of the post and it works like a navigation drawer on mobile phones and web too, with an horizontal swipe from left to right.

I placed all the code of the TOC of the Hydra theme (that is the name of my blog theme). While Hydra is still in small kid stage it has the potential to reach catastrophe-ical levels pretty easily, but just as taming a lion I believe Hydra can be tamed into becoming what it should, a massive destroyer. One must be wary of having fierce pets. 

This is what my TOC module looks like:

```language-bash
TOC
│   main.coffee
│   contents.coffee
│   touch-events.coffee
```

<div class="center-unknown">
   <div class="el">
       <div class="post-ad" style="width:300px; margin: 0 auto;">
<iframe src="http://rcm-na.amazon-adsystem.com/e/cm?t=l0b84-20&o=1&p=12&l=ur1&category=amazon_student&banner=11JR04FNKYYANW06VJ82&f=ifr&lc=pf4&linkID=WWMOP522LHWV36RU" width="300" height="250" scrolling="no" border="0" marginwidth="0" style="border:none;" frameborder="0"></iframe>
       </div>
    </div>
</div>

###<a href="http://amzn.to/1PybeEk" target="_blank" alt="advertisement-coffeescript">Coffeescript Code for the Table of Contents and Navigation Drawer</a>

As I advance in Coffeescript I slowly start to like it a little less. Mostly because of its dependency on functional syntax. But the readability gains are enough for me to keep using it so far. So far my favorite has been Typescript. 

####Generating the Table of Contents from the Post

```language-coffeescript
util = require "../../common/util"
```

The first step is to include whatever I'll need. In this case I just need an util module with my `slugify` function, it just converts whatever text I pass into something that is valid for web.

```language-coffeescript
contentsTOC =
  init: () ->
    this.setTitle()
    this.setContent()

  setTitle: () ->
    
  setContent: () ->
    
  processDomChildTag: (navigationLinks, childNode) ->
    
  createAnchor: (slugifiedText) ->
    
  closeDrawer: () ->
   
  createLinkToAnchor: (slugifiedText, Text, tagName) ->
   
```

The main module for the content generation, or the main class, will be called contentsTOC, for lack of a better name, and it will contain all the functionality required to assemble the TOC and a convenient `init` method to just call on startup. 

####Setting the Title

```language-coffeescript
  setTitle: () ->
    postTitle = document.getElementsByClassName('post-title')[0]
    navigationTitle = document.getElementsByClassName('mdl-layout-title')[0]
    if navigationTitle.innerText
      navigationTitle.innerText = postTitle.innerText
    else if navigationTitle.innerHTML
      navigationTitle.innerHTML = postTitle.innerHTML
```

To get the title we need to get the `post-title` which is a field in our Ghost Platform. We also need to get the Title for the Navigation Drawer which is called `mdl-layout-title` in Material Design Lite. Once that is done we just reset the text of the Title.



####Setting the Content of the TOC

```language-coffeescript
  setContent: () ->
    results = document.querySelectorAll('h2,h3,h4,h5,h6');
    navigationLinks = document.getElementsByClassName('mdl-navigation')[0]
    for childNode in results
      aLink = this.processDomChildTag(navigationLinks, childNode)
      navigationLinks.appendChild aLink if aLink
    return
```

The content would be a little bit harder if we supported IE8, but I don't, I'm just a one man team, so I can't really afford that stuff. We obtain all the headers in the post, which will gives us a list of such subtitles, and then we setup links to such objects, these links will be comprised of two pieces, the link and the anchor to which the link is pointing to. Both need to be positioned carefully. 



#####Processing the Links

```language-coffeescript
  processDomChildTag: (navigationLinks, childNode) ->
    childNodeStr = if childNode then if childNode.className then childNode.className.toString() else null
    tagName = childNode.tagName
    if childNode && childNodeStr != "search-label" && childNodeStr != "box-title"
      if tagName == 'H2' || tagName == 'H3' || tagName == 'H4' || tagName == 'H5' || tagName == 'H6'
        textToSlugify = if childNode.innerText then childNode.innerText else if childNode.innerHTML then childNode.innerHTML else childNode.textContent
        slugifiedText = util.slugify(textToSlugify)
        childNode.outerHTML += this.createAnchor(slugifiedText).outerHTML
        aLink = this.createLinkToAnchor(slugifiedText, textToSlugify, tagName)
        return aLink
    return null
```

Each link needs an anchor, so we pass the Container that will contain our links, in here called `navigationLinks` and we pass each subtitle. To create the anchor we `slugify` the text in the subtitle, and then we create the `<a>` link tag that points to the anchor. 

######Creating anchors

```language-coffeescript
  createAnchor: (slugifiedText) ->
    aTag = document.createElement('a')
    aTag.setAttribute 'name', slugifiedText
    return aTag
```

An anchor is an `a` tag with a `name` instead of an `href`. 
`<a name="the-bane-of-my-existence"/>`



######The link to the anchor

```language-coffeescript
  createLinkToAnchor: (slugifiedText, Text, tagName) ->
    linkToTag = document.createElement('a')
    linkToTag.innerHTML = Text
    linkToTag.className = 'mdl-navigation__link toc' + tagName
    linkToTag.href = '#' + slugifiedText
    linkToTag.onclick = this.closeDrawer.bind(this)
    return linkToTag
```

The link is another `<a>` html object, and this one points to the previously created anchor. Such as:

`<a class"mdl-navigation__link tocH2" href="#the-bane-of-my-existence" onclick="this.closeDrawer.bind(this)"/>`

You may start feeling betrayed right now. Where this `mdl-navigation__link` came from? What is `tocH2`? What the hell is `onclick="this.closeDrawer.bind(this)"`?

The `mdl-navigation__link` is a class that activated the sweet Material Design Lite features, such as the ripple effect.

`tocH2` is a CSS class I am using to establish the margin to the left, this creates the nice effect on the TOC that we have subtitles. 

The last piece `onclick="this.closeDrawer.bind(this)"` is a function defined below to Toggle the navigation drawer, this means that when someone clicks something in the TOC the navigation drawer will close. 



######Closing the drawer

```language-coffeescript
  closeDrawer: () ->
    className = 'mdl-layout__drawer'
    drawer = document.getElementsByClassName(className)[0]
    if /is-visible/.test(drawer.className)
      drawer.className = className
```

We should have an utility function to close the drawer if necessary, and this is really easy by toggling the `is-visible` class in the `mdl-layout__drawer` object.



###Exporting the class

```language-coffeescript
module.exports = {
  contentsTOC: contentsTOC
}
```

I use `browserify` modules, it creates a nice clean way for me to have packages and modules in javascript, which allows for cleaner and more manageable code. 

####The hammer js swipe detection

Swipe detection is decoupled from table of contents generation. I don't want to infect my precious table of contents (which will most likely change) with my HammerJS (which will change because of different reasons). Thus, since both are prone to change, in different timeframes, they should be separated.

```language-coffeescript

touchTOC =
  init: () ->
    this.setupTOCSwipe()
```

#####Calculate the offset to the top

```language-coffeescript
# Get the offset from the top to the post content, including the sticky header
# @return (Object) { shouldWeAddTopOffset - True if the post-header is visible and
#     bigger than the sticky fixed header
#     offsetToTopPixels - Pair of Max between height of the sticky fixed
#     header and 0 if no sticky fixed header visible
#     newTOCHeightPixels - The distance between the current position and
#     the end of the document so that the TOC doesn't overflow
# }
  getOffsetToTopToPostContent: () ->
    postHeader = document.getElementsByClassName('post-header')[0];
    drawerContainingContainer = document.getElementsByClassName('mdl-layout__container')[0]
    stickyHeader = document.getElementsByClassName('header header-standard fixed-top')[0];
    extraOffset = if stickyHeader then Math.max(stickyHeader.clientHeight, stickyHeader.offsetHeight, stickyHeader.scrollHeight) else 0
    return {
    shouldWeAddTopOffset: postHeader.getBoundingClientRect().bottom <= extraOffset,
    offsetToTopPixels: extraOffset.toString(),
    newTOCHeightPixels: drawerContainingContainer.getBoundingClientRect().bottom.toString()  + 'px'
    }
```

#####The Swipe Event

The Swipe event should be triggered only after a swipe from left to right on the post content.

```language-coffeescript
# Sets the correct position for the TOC and the correct Height.
# Will set the position to fixed if there is no post-header visible in sight
# otherwise it will be absolute
  handleTOCSwipeOpen: (ev) ->
    className = 'mdl-layout__drawer'
    drawer = document.getElementsByClassName(className)[0]
    if !/is-visible/.test(drawer.className)
      calculatedDimensions = this.getOffsetToTopToPostContent()
      topOffset = if calculatedDimensions.shouldWeAddTopOffset then  + calculatedDimensions.offsetToTopPixels + 'px' else '0'
      positionSwitch = if calculatedDimensions.shouldWeAddTopOffset then ' position: fixed;' else 'position: absolute;'
      drawer.style.cssText += positionSwitch + ' top: ' + topOffset + ';'
      drawer.style.cssText += 'height: ' + calculatedDimensions.newTOCHeightPixels + ';'
      drawer.className += ' is-visible'
    return
```

#####Setting up the Swipe Event

```language-coffeescript
  setupTOCSwipe: () ->
    showDrawer = document.getElementsByClassName('page-content')[0]
    mcShowDrawerSwipe = new Hammer(showDrawer, {
      cssProps: {
        userSelect: true
      }
    })
    mcShowDrawerSwipe.on("swiperight", this.handleTOCSwipeOpen.bind(this))
```

#####Conclusion

As you can see we only used Hammer swipe function in one very specific place, and that's it. 

```language-coffeescript
module.exports = {
  touchTOC: touchTOC
}
```

##Next

Before continuing any further with my R&D of Material Design Lite, I must implement a template system that uses another one, think of a matryoshka of template systems. Currently Ghost editor won't render most of my html, so I am writing my html bare on the editor. But I need a simpler, more scalable way of doing my Cards. 

Once that is done we will be ready to revive the study series, which is another effort being done in parallel. 

Cheers.
