---
title: Responsive Typography using Modular Scale
slug: responsive-typography-using-modular-scale
date_published: 2015-08-05T03:21:59.877Z
date_updated:   2015-08-20T04:02:45.598Z
tags: blog, scss, responsive-design
---

Yesterday, the birds were chipping, my daughter was watching Spirited Away, and my wife was working on her community management... all while my brain was exploding. 

Typography was a huge deal for Steve Jobs, but I never quite felt the allure of dedicating myself to the perfect typography, ever since I was a kid I had a *gravitas* toward painting dark stuff, bright light colors were not really my thing, on a subconscious level. And that is why I focused more on colors.

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <h2>A little background</h2>
<p>
I have worked on websites that are not responsive, and makes me wonder why would someone go over the route of having static containers for his information or going the route of supporting two different websites (a mobile and a desktop one) instead of using a responsive one. It is a bit rough that what the client wants is, sometimes at least, completely opposite to what a client needs.
</p><p>
As I was looking in the horizon engulfed in my emptiness over something so meaningless (I make big deals of things), two men came into the bus and started fighting over some keys. "Give me the keys please" said one man, "No, they're mine!" shouted the other. 
</p><p>
The bus driver, a tough woman but not exactly big, started yelling at them, but the men heed no attention to her pleas, as loud as they were. I couldn't help but remember something I heard in True Detective season 2 where Ani Bezzerides masters the art of slashing people with a knife because she didn't have the physical power a man had (at least that was her argument at, later we realize there was something else). We proceeded to wait for them to stop their bickering over some keys or get off the bus. The old man that seemed drugged sat down and just said "No" as he pouted like a child. The other man, that seemed the most reasonable, called the police. The tension rose as he started giving a detailed description of our location, and the old man, rose from his seat and left, walking hastily to leave the scene. 
</p>
</div>
</div>

<div class="mdl-grid">
  <div class="mdl-cell mdl-cell--12-col">
<div class="post-ad">
<iframe src="http://rcm-na.amazon-adsystem.com/e/cm?t=l0b84-20&o=1&p=48&l=ur1&category=audible&banner=0JYEMDNC49A58GM3J902&f=ifr&linkID=L6F4RU6NJ6X3L62D" width="728" height="90" scrolling="no" border="0" marginwidth="0" style="border:none;" frameborder="0"></iframe>
</div>
  </div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <h2>Adaptability</h2>
    <p>
As the two men left the situation I could see all the possible scenarios in my head, in all of them the best possible outcome to make 30 plus people lose half and hour of their lives was to prevent, yes, prevention. 
</p>
<ul>
 <li>Be stronger</li>
 <li>Be faster</li>
 <li>Be richer</li>
 <li>Adapt</li>
</ul>
<p>
All that day, hell, maybe a week something was amiss. I could sense it. 
</p>
<p>
I worked on that day on some piece that didn't work correctly because of some third party library (ShareThis), either it provided a bad experience, or it just did something that caused us more issues down the road. All because we wanted custom buttons that looked pretty and we wouldn't do the normal thing from ShareThis tutorials... adaptability.
</p><p>
When I was returning home I started reading on <a alt="Material Design Lite" href="http://www.getmdl.io/" target="_blank">Material Design Lite</a> and their components. They looked adaptable. I felt I needed them, they don't feel adaptable enough, but I feel if I don't take matters into my own hands now, I'll never do it. I started thinking how to plug it into my blog, and so I started hacking and slashing through my theme. 
</p><p>
I said goodbye to my perfect theme Goblin from Sunflower Themes, and I started replicating the experience using SCSS and Coffeescript and started placing everything in Browserify modules as well as compiling the css into an inlined file which I placed into my <code>default.hbs</code> file from ghost, looking like the following:
</p>
<pre>
<code class="language-markup">
&lt;head>
    {{! Document Settings }}
    &lt;meta charset="utf-8" />
    {{! Page Meta }}
    &lt;title>{{meta_title}}&lt;/title>
    &lt;meta name="description" content="{{meta_description}}" />
    &lt;link href="{{asset "img/favicon.ico"}}" rel="shortcut icon" type="image/x-icon">
    &lt;link href="{{asset "img/apple-touch-icon-precomposed.png"}}" rel="apple-touch-icon">
    &lt;meta name="HandheldFriendly" content="True" />
    &lt;meta name="MobileOptimized" content="320" />
    &lt;meta name="viewport" content="width=device-width, initial-scale=1.0">
    {{#if post}}
    &lt;!-- meta stuff for twitter -->
    &lt;!-- meta stuff for open graph -->
    {{else}}
    &lt;!-- meta stuff for twitter -->
    &lt;!-- meta stuff for open graph -->
    {{/if}}
    {{! Google Webmaster verification }}
    {{>css/bundle}} {{! THIS IS WHERE THE MAGIC STUFF HAPPENS }}
    {{ghost_head}}
    {{! Google Analytics here }}
&lt;/head>
&lt;body>
    &lt;!-- moar body stuff here, like the post and what not -->
 &lt;/script>
    {{#unless posts}}
        &lt;script>
            [].forEach.call(document.querySelectorAll('.adsbygoogle'), function(){
                (adsbygoogle = window.adsbygoogle || []).push({});
            });
        &lt;/script>
    {{/unless}}
    &lt;!-- other scripts -->
    {{#if post}}
        &lt;!-- Load the bundle that includes everything for the theme plus specifics for the post, like ad setup -->
        &lt;script async type="text/javascript" src="{{asset "js/main.post.js"}}">&lt;/script>
    {{else}}
        &lt;!-- Load the bundle for the list of posts, usually lighter, and thus, faster -->
        &lt;script async type="text/javascript" src="{{asset "js/main.js"}}">&lt;/script>
    {{/if}}
&lt;/body>
</code>
</pre>
<p>
It may not seem like much but this arrangement is as minimal as it gets, plus having the css inline works wonders when it comes to checking google metrics. 
</p>
<p>
After setting everything up I wanted to get fonts that would be always readable on my cellphone. My main problem was that the headers took too much space and I wanted to scroll to the content. I rearranged everything so the headers are smaller in my cellphone than my desktop, but the main content (such as these words) is the same readable and normal size, which is fantastic. 
</p>
</div>
</div>

<div class="center-unknown">
<div class="el">
<ins class="adsbygoogle adslot_1"
 style="display:inline-block;margin: 0 auto 0 auto; width: 100%;"
 data-ad-client="ca-pub-1525337072631150"
 data-ad-slot="3858661425"
 data-ad-format="auto"></ins>
</div>
</div>

##Modular Scale

Using SCSS (or Less, or SASS for that matter) doing the breakpoints is a breeze and at some point enjoyable, if you don't enjoy this part stop what you are doing and change whatever it is you are doing, or just copy paste it! I copied a piece and just extended from it. 

Here are the breakpoints.

```language-scss

/* I stole the following from @chriseppstein
 * from issue 554 https://github.com/sass/sass/issues/554 
 * It is a clean way to set up sizes */
$media-types: (phone: '(max-width: 480px)',
        tablet-portrait: '(min-width: 481px) and (max-width: 767px)',
        tablet-landscape-desktop: '(min-width: 768px) and (max-width: 1199px)',
        desktop: '(min-width: 1200px) and (max-width: 1919px)',
        large-desktop: '(min-width: 1920px)',
        non-retina: 'screen and (-webkit-max-device-pixel-ratio: 1)',
        retina: 'screen and (-webkit-min-device-pixel-ratio: 2)');

@mixin respond-to($media) {
  @if not map-contains($media-types, $media) {
    @warn "#{$media} is not a known media type. Using large-desktop instead.";
    $media: large-desktop;
  }
  @media #{map-get($media-types, $media)} {
    @content;
  }
}
```

And here is the implementation of modular-scale, I used `npm install modular-scale-sass` and then adding something like the following to the scss compilation:

```language-bash
node-sass --include-path=vendor/responsive-modular-scale/stylesheets --include-path=node_modules/modularscale-sass/stylesheets --include-path=node_modules/node-bourbon/node_modules/bourbon/app/assets/stylesheets src/scss/main.scss assets/css/bundle.min.css
```

```language-scss
@import '_modular-scale';


/* We set up the modular scale to use the golden ration */
$ms-base: 1em;
$ms-ratio: 1.618;

/* Now we set up lists with the proper sizes for each devices.
 * This is only for the headers. */
$h1-list: 3, 1, 2, 2, 3, 3;
$h2-list: 3, 1, 1, 2, 3, 3;
$h3-list: 3, 1, 1, 2, 2, 2;
$h4-list: 2, 0, 0, 1, 2, 2;
$h5-list: 1, 0, 0, 0, 1, 1;
$h6-list: 0, 0, 0, 0, 1, 1;

/* Now it is time to join the responsive functionality
 * with modular scale.
 * @param {number} $default the default modular scale
 * @param {number} $phone For sizes below 480px
 * @param {number} $tablet-portrait Sizes bigger than 
 *                     phone but smaller than 768px
 * @param {number} $tablet-landscape Bigger than portrait 
 *                     smaller than 1200px
 * @param {number} $desktop Bigger than landscape tablet, 
 *                     smaller than 1080p width
 * @param {number} $large-desktop Anything bigger than 
 *                     1080p for now */
@mixin fontMultiScreen($default, $phone, $tablet-portrait, $tablet-landscape, $desktop, $large-desktop) {
  font-size: ms($default);
  @include respond-to(phone) {
    font-size: ms($phone);
  }
  @include respond-to(tablet-portrait) {
    font-size: ms($tablet-portrait);
  }
  @include respond-to(tablet-landscape-desktop) {
    font-size: ms($tablet-landscape);
  }
  @include respond-to(desktop) {
    font-size: ms($desktop);
  }
  @include respond-to(large-desktop) {
    font-size: ms($large-desktop);
  }
}

/* A wrapper for lists.
 * @param {number[]} $propertiesList the ordered array 
 *                       according to the parameters shown above */
@mixin titlePropertiesList($propertiesList) {
  @include fontMultiScreen( nth($propertiesList, 1),
          nth($propertiesList, 2),
          nth($propertiesList, 3),
          nth($propertiesList, 4),
          nth($propertiesList, 5),
          nth($propertiesList, 6));
}

/* I like to keep for-loops tiny, such is the power of scss */
@mixin headerProperties {
  $header-list: h1, h2, h3, h4, h5, h6;
  $headers: $h1-list, $h2-list, $h3-list, $h4-list, $h5-list, $h6-list;
  @for $i from 1 through length($header-list) {
    #{nth($header-list, $i)} {
      @include titlePropertiesList(nth($headers, $i));
    }
  }
}

/* This is the font I want for default on things that are not
 * headers, the reason is to always to be able to read the text
 * regardless of what device you are using, the headers are not
 * as important. */
@mixin basicParagraphFont {
  @include fontMultiScreen(0, 1, 1, 1, 1, 1);
}
```

<div class="center-unknown">
<div class="el">
<ins class="adsbygoogle adslot_1"
 style="display:inline-block;margin: 0 auto 0 auto; width: 100%;"
 data-ad-client="ca-pub-1525337072631150"
 data-ad-slot="3858661425"
 data-ad-format="auto"></ins>
</div>
</div>


<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <h2>Here is an example of using modular scale</h2>
<p>
Just resize the width of the browser or play with it on CodePen to see the effect on the size of the fonts of every Header. 
</p>
<div data-height="268" data-theme-id="17583" data-slug-hash="KpJzad" data-default-tab="css" data-user="claudiordgz" class='codepen'><pre><code>@import &quot;modular-scale&quot;;
$phone: &#39;(max-width: 480px)&#39;;
$tablet-portrait: &#39;(min-width: 481px) and (max-width: 767px)&#39;;
$tablet-landscape-desktop: &#39;(min-width: 768px) and (max-width: 1199px)&#39;;
$desktop: &#39;(min-width: 1200px) and (max-width: 1919px)&#39;;
$large-desktop: &#39;(min-width: 1920px)&#39;;
@mixin respond-to($media) {
    @media #{$media} {
        @content;
    }
}

$ms-base: 1em;
$ms-ratio: 1.618;
$h1-list: 3, 1, 2, 2, 3, 3;
$h2-list: 3, 1, 1, 2, 3, 3;
$h3-list: 3, 1, 1, 2, 2, 2;
$h4-list: 2, 0, 0, 1, 2, 2;
$h5-list: 1, 0, 0, 0, 1, 1;
$h6-list: 0, 0, 0, 0, 1, 1;

@mixin fontMultiScreen($rh-default, $rh-phone, $rh-tablet-portrait, $rh-tablet-landscape, $rh-desktop, $rh-large-desktop) {
  font-size: ms($rh-default);
  @include respond-to($phone) {
    font-size: ms($rh-phone);
  }
  @include respond-to($tablet-portrait) {
    font-size: ms($rh-tablet-portrait);
  }
  @include respond-to($tablet-landscape-desktop) {
    font-size: ms($rh-tablet-landscape);
  }
  @include respond-to($desktop) {
    font-size: ms($rh-desktop);
  }
  @include respond-to($large-desktop) {
    font-size: ms($rh-large-desktop);
  }
}

@mixin titlePropertiesList($propertiesList) {
  @include fontMultiScreen( nth($propertiesList, 1),
          nth($propertiesList, 2),
          nth($propertiesList, 3),
          nth($propertiesList, 4),
          nth($propertiesList, 5),
          nth($propertiesList, 6));
}

@mixin headerProperties {
  $header-list: h1, h2, h3, h4, h5, h6;
  $headers: $h1-list, $h2-list, $h3-list, $h4-list, $h5-list, $h6-list;
  @for $i from 1 through length($header-list) {
    #{nth($header-list, $i)} {
      @include titlePropertiesList(nth($headers, $i));
    }
  }
}

.title {
  @include titlePropertiesList($h1-list);
}

.display1 {
  @include titlePropertiesList($h1-list);
}

.display2 {
  @include titlePropertiesList($h2-list);
}

.display3 {
  @include titlePropertiesList($h3-list);
}

.display4 {
  @include titlePropertiesList($h4-list);
}

p {
  font-size: ms(1);
  .red {
    @include titlePropertiesList((0,1,1,1,2,2));
    color: red;
  }
  &amp;.small {
     @include titlePropertiesList((0,0,-1,-1,-1,-1));
  }
}</code></pre>
<p>See the Pen <a href='http://codepen.io/claudiordgz/pen/KpJzad/'>KpJzad</a> by Claudio Rodriguez (<a href='http://codepen.io/claudiordgz'>@claudiordgz</a>) on <a href='http://codepen.io'>CodePen</a>.</p>
</div>
</div>
</div>

##Modular Scale

I love having responsive stuff, and now every post I make on my blog will be more readable even on smaller screens. Except IE9 or below, because fuck IE.

<script async src="//assets.codepen.io/assets/embed/ei.js"></script>
