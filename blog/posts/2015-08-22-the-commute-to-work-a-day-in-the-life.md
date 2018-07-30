---
title: The commute to work - A day in the life
slug: the-commute-to-work-a-day-in-the-life
date_published: 2015-08-23T01:50:44.712Z
date_updated:   2015-08-23T02:12:36.628Z
tags: blog, Python, HTML, responsive-design
---


The man wakes up, and even though blue light still crawls through the window shades from a drowsy sun, he knows it's late. He throws himself out of the bed as if he were a whale run aground trying desperately to return to the sea. 

<div class="center-unknown">
  <div class="el">
    <iframe style="max-width:560px; width:100%; margin: 0 auto; max-height:315px; height: 315px;" src="https://www.youtube.com/embed/tQBnlWAMq_Q" frameborder="0" allowfullscreen></iframe>
  </div>
</div>

##Blast through the door

A pair of pants, a shirt, which shirt? It's Friday, no one gives a shit, a Sunday shirt it is! Maybe someone will? No time, just go. Take a shower, teeth, hair, shoes, roll out, a kiss on every living being's cheek, and a treat for my Zelda for waiving me goodbye to the door. 

I'm outside, where is my lunch!? Oh shoot, he thinks to himself, no time just go! He catches the bus as soon as he hits the bus stop. A rough day awaits at the office, it's Internet Explorer 9 debugging day, one of those things you have to get done. It's important NOT to think about it, yet the blitzing headache from sleeping too little hauls like angry wind, shut the brain, shut it, quiet. He opens his Kindle app on his phone, can't read, too much noise on his heads, pops the music, runs through his other tasks.

##HTML Placeholders

What kind of templates do I need on the blog? He thinks to himself as he sees the old man swivel his wheelchair to position it on the disabled area, it's too enchanting not to look at. He keeps running through things, Well I'm going to need a template for loading images, maybe I can write in my CMS something like

```language-markup
<ins class="post-insert"
    id="this-is-my-dog-and-hes-made-for-crapping"
    data-type="image-card">
    <script>
       var ThisIsMyDogAndHesMadeForCrapping = {
          src: 'tonight/we/dine/bacon.png'
          srcWebP: 'tonight/we/dine/bacon.webp'
          srcRetina: 'tonight/we/dine/bacon2x.png'
       };
    </script>
</ins>
```

and probably one to shoot text into a card

```language-markup
<ins class="post-insert"
    id="this-is-my-daughter-clapping"
    data-type="post-card">
    <script>
       var ThisIsMyDaughterClapping = { 
            title: "Beautiful Tiny Demon", 
            background: 'https://res.cloudinary.com/www-claudiordgz-com/image/upload/v1440131499/2015-08-16_ecezo0.jpg', 
            content: "My daughter eats people for breakfast with her cute eyes... watch out."
        };
    </script>
</ins>
```

But wait if I want a card inside a card, for recursion purposes?, his mind thought.

```language-markup
<ins class="post-insert"
    id="oakworms"
    data-type="grid-card">
    <script>
       var whiteStripedOakworm = [
         { col-tablet: '8', col-phone: '4', col-default: '6'
           content: {
             type: 'image-card',
             content: {
                 src: 'white-striped-oakworm.png'
                 srcWebP: 'white-striped-oakworm.webp'
                 srcRetina: 'white-striped-oakworm2x.png'
         } } },
         { col-tablet: '8', col-phone: '4', col-default: '6'
           content: {
             type: 'html',
             content: {
               ad-client:"ca-pub-1525337072631150",
               ad-slot:"3858661425",
               ad-format: "auto"
         } } },
         { col-tablet: '8', col-phone: '4', col-default: '6'
           content: {
             type: 'image-card',
             content: {
                 src: 'spicebush-swallowtail.png'
                 srcWebP: 'spicebush-swallowtail.webp'
                 srcRetina: 'spicebush-swallowtail2x.png'
                 caption: 'caterpie'
         } } },
         { col-tablet: '8', col-phone: '4', default: '6'
           content: {
             type: 'image-card',
             content: {
                 src: 'yellow-striped-oakworm.png'
                 srcWebP: 'yellow-striped-oakworm.webp'
                 srcRetina: 'yellow-striped-oakworm2x.png'
         } } }
       ];
    </script>
</ins>
```

But how to do the templates?, he though, Jade, Handlebars, ICanHaz, Dust... let's use Dust, what could go wrong? The man investigated several comparison opinions of the most famous template engines before, but it is a subject that is always getting to his nerves. He believes comparing stuff is a waste of time after some point.

##Templates?

As the man writes on his cellphone he notices the lack of fighting people on the bus, the missing glamorous women talking loud, or the dude that thinks his cell phone is an office phone horribly harassing someone on the phone. No!, mmmm no no I'm not paying that, tell that n**** I'm not paying for that shit, you tell him, otherwise it is your ass. These men are as usual as squirrels, and squirrels are everywhere. He went to his phone, thinking how would a template look, for example ICanHaz.

```language-markup
<div id="elCard{{ idx }}" class="mdl-card mdl-shadow--2dp post-card">
  <div class="mdl-card__title" style="background-image: url('{{ background }}');">
    <h2 class="mdl-card__title-text_two">{{ title }}</h2>
  </div>
  <div class="mdl-card__supporting-text">
     {{ content }}
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect mdl-button--colored" onclick="feedDialog('elCard{{ idx }}', '{{ caption }}', '{{ img }}')">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>
```

##The train station

The bus passes by the Grady Hospital, the Hospital that housed Whitney Houston's daughter, and he worries if he'll have have to visit it in the future, yet hopes he doesn't. He gets down at the Pryor St SE @ Wall St SE and walks to Five Points Station. Outside the station a man is arguing with the police, but the three cops (one woman, two men) don't seem involved. The person arguing has some kind of beef with them. Regardless, he's in the way. 

The options of why this person is doing what he's doing are so vast, it is pointless wondering about it, yet he keeps close attention to all faces, body image, and mutes his music to listen closely as he walks towards them. His face when commuting is usually non friendly, and given his looks and size people look at him with fear. A fear that he comes from middle east. The person arguing looks like a homeless person, and crosses eyes with the man, he keeps arguing with the police as he stays out of the way by several meters, and starts dancing, twerking, and slapping his ass while looking at the police. I guess he wants to be taken in, thinks the man, but continues walking, don't stop, never stop. 

As he descended into the train station he runs to catch the train and opens his trello board clawing the last seconds of signal before going underground, he didn't even pay attention to see if it was his train. He checks the trello board and see one of the tasks reads "screenshots". Fool, fool, foolish man, he thinks, for he forgot placing screenshots when running his examples. How could he forget the most important prototyping piece? He thinks of the project. I need a `setup.py` for mcpipy, to do a `pip install -e git+repository_url@branch#egg=mcpi`. I'll get to that later, need some screenshots, need to install mcpi. His mind drifts through the music, and the movement and gets out at Lindbergh station when he hears that the train is set to Doraville, he has made that mistake before, going somewhere and getting lost. 

The study series comes to his mind again, I need the template system from the blog first, or do I? He thinks. To create an html he created a configuration file for tex4ht with rules. These rules convert the latex code into html markup. 

The config file got out of hand and eventually too big at a small size, changes were difficult. What would take seconds in a well designed environment took minutes, and those minutes converted into hassle, that hassle destroyed progress. 

He needs an architecture for those rules, in a filesystem order that makes it easy to re pick the project later on. I could use tex4ht hooks in sty files for this, I need to read more on syntax about that, `providepackage`,  `usepackage`, that is all he could conjure from bare memory. 

Across him, a man reads Piranha by Clive Cussler, another one reads The complete start to finish MBA admission guide, other plays Bejeweled on his Samsung Galaxy phone, other reads A gate at the stairs by Lorrie Moore. 

He looks through the window to the river of cars and thinks, damn, I want a fighter jet! To surge through the skies at mach speed 1, or 2, or 3, whatever my body can take, that would be fantastic. His conclusion is starting to sound like dogma, I need moar money. 

He tastes the cinnamon in his breath as he reaches Dunwoody station, he may have forgotten his food but he didn't forget his vitamins. That will probably keep him awake for most of the day. He thinks of all the people in Mexico that believe vitamins make you fat, he remembers arguing with a few about it, and how they were certain that <a href="http://amzn.to/1MFW8Nn" target="_blank">1000mg of C vitamin</a> would turn you into a blob of fat. Humanity wears him down. 

##Planning for later

Today I'll get out of work and I'll watch <a href="http://www.amazon.com/eps1-0_hellofriend-mov/dp/B00YBX8QEO/ref=as_li_ss_tl?ie=UTF8&qid=1440295834&sr=8-1&keywords=mr+robot&pebp=1440295845348&perid=1CND5NT7RJBQXCHVY6F7&linkCode=sl1&tag=l0b84-20&linkId=c34e8bda0eb9f18b24d251ac87bdc9f7">Mr. Robot</a>, sleep, just sleep, and tomorrow I'll pay the rent, and this time I'll pay priority express, he says to himself, now he needs to don't forget it. He wonders why USPS priority express costs around 6 dollars and Certified Mail costs 4 dollars, 3 business days guaranteed delivery versus 10 business days lost in shipment non guaranteed delivery all because of a 2 dollar difference, that sucks.

As he got in and checked his email, crank the music, and started coding he received a notice. 

<div class="image-card mdl-card mdl-shadow--2dp" style="padding: 0 0 35% 0; background-image: url('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1440277487/0821151208_b6u8jg.jpg');">
  <div class="mdl-card__title mdl-card--expand">TODAY IS FOOD TRUCK FRIDAY</div>
  <div class="mdl-card__actions">
    <span class="image-card__filename">His wife loves round balloons</span>
  </div>
</div>




