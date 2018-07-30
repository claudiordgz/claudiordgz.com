---
title: Why developers don't unit test more
slug: why-developers-dont-unit-test
date_published: 2015-07-30T15:35:39.048Z
date_updated:   2015-08-05T10:46:13.491Z
tags: blog, Unit Testing
---

##Unit testing prowess

What is unit testing useful for? What is a unit test exactly? A unit test is a piece of **code** that tests a unit of functionality in your stuff. 

> Tests the functionality in your stuff. 

Regardless what stuff is, there is always a piece of functionality to test.

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <h2>Examples of things you may want to test</h2>
    <ul>
<li>This header in my screen should always be black</li>
<li>We should never leak this api key on any value in the JSON, or XML, or BSON, or Protobuffer, whatever.</li>
<li>It should always return a list (or dictionary, or custom object)</li>
<li>We should always have a list in here</li>
<li>It should always save a pdf</li>
<li>For these 20 values, it should provide these 20 outputs</li>
<li>The FFT should provide these values (you could even have a test deliver visual graphics)</li>
</ul>
  </div>
</div>
<div class="mdl-grid">
  <div class="mdl-cell mdl-cell--6-col">
    <div id="unitTestCardReason" class="mdl-card mdl-shadow--2dp half-page-card">
  <div class="mdl-card__title">
    <h4 class="mdl-card__title-text"><b>Finding devs that unit test properly is NP Hard</b></h4>Why developers don't do more unit testing
  </div>
  <div class="mdl-card__supporting-text">
    Two weeks ago I got an email from <a alt="LeifSinger" href="https://github.com/lsinger">Leif Singer</a> asking me to do a Survey on <b>onboarding techniques from Companies with a heavy focus on testing practices of new and current hires</b>. Testing software is one of the biggest elephants in the room in both Mexico and India (that I know of) and I wanted to dig deeper into the real reason why developers don't do more unit testing. The answer is simple, and yet complicated. From the following we see a derivation on the field, such as lack of budget, lack of time, lack planning, and the worst, lack of know how. 
  </div>
  <div class="mdl-card__actions mdl-card--border">
    <a onclick="location.href='#nphard';" target="_self" class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">
      Continue Reading
    </a>
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect  mdl-button--colored" onclick="feedDialog('unitTestCardReason', 'Unit Testing requires deep analytical skills', null)">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>
</div>
<div class="mdl-cell mdl-cell--1-col">
</div>
<div class="mdl-cell mdl-cell--5-col">
<button class="mdl-button mdl-js-button mdl-button--raised mdl-button--colored mdl-js-ripple-effect" onclick="location.href='#fiverules';" style="margin: 0 auto 0 auto;" disabled>Go to 5 Do's and Don'ts of Unit Testing
</button></div>
</div><a name="nphard"></a>
<div class="mdl-grid">
<div class="mdl-cell mdl-cell--6-col">
<div id="AynRandCard" class="mdl-card mdl-shadow--2dp">
<div class="mdl-card__title">
    <h2 class="mdl-card__title-text">Ayn Rand</h2>
  </div>
  <div class="mdl-card__supporting-text">
    People don't want to think. And the deeper they get into trouble, the less they want to think.
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect  mdl-button--colored" onclick="feedDialog('AynRandCard', 'Thinking, Feelings, and Unit Testing', 'https://pixabay.com/get/ce2490340aec63ea9be7/1438206235/nyc-724003_1280.jpg')">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>
</div>
<div class="mdl-cell mdl-cell--6-col">
<div id="HellenKellerCard" class="mdl-card mdl-shadow--2dp">
  <div class="mdl-card__title">
    <h2 class="mdl-card__title-text">Hellen Keller</h2>
  </div>
  <div class="mdl-card__supporting-text">
    People don’t like to think, if one thinks, one must reach conclusions. Conclusions are not always pleasant.
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect  mdl-button--colored" onclick="feedDialog('HellenKellerCard', 'Thinking, Feelings, and Unit Testing', 'http://www.crazyaboutquotes.com/images/helen-keller-quotes-box2.jpg')">
      <i class="material-icons">share</i>
    </button>
</div>
</div>
</div>
</div>

But what does this mean? Is it true that people don't want to think. Lets leave behind thinkers and writers and move on to more recent studies.

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      You think darkness is your ally?
    </div>
    <h2>Just think: The challenges of the disengaged mind</h2>
    <p>
      In an article published in <b>Science</b> called <a href="http://www.sciencemag.org/content/345/6192/75.full.pdf?keytype=ref&siteid=sci&ijkey=udZOUlZ4IO77I" target="_blank"><b>Just think: The challenges of the disengaged mind</b> by Timothy D. Wilson, David A. Reinhard, Erin C. Westgate, Daniel T. Gilbert, Nicole Ellerbeck, Cheryl Hahn, Casey L. Brown, Adi Shaked</a>, the authors discovered that <b>95%</b> percent of American adults reported that they did at least one leisure activity in the past 24 hours, such as watching television, socializing, or reading for pleasure, but 83% reported they spent no time whatsoever “relaxing or thinking”.
    </p>
    <p>
      Furthermore the study found that the test subjects would <b>cheat</b> and engage in an activity instead of being with their own minds. After trying with students and overall young people, the study move forward with a wider range of ages (up to 77 years). 
    </p>
    <blockquote>
      Many participants elected to receive negative stimulation over no stimulation especially men: <b>67% of men (12 of 18) gave themselves at least one shock during the thinking period.</b>
    </blockquote>
</div>
</div>

<div class="el">
<ins class="adsbygoogle adslot_1"
 style="display:inline-block;margin: 0 auto 0 auto; width: 100%;"
 data-ad-client="ca-pub-1525337072631150"
 data-ad-slot="3858661425"
 data-ad-format="auto"></ins>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      Cognition reigns but does not rule.
    </div>
    <h2>Thinking is not the enemy, but is not your friend either</h2>
    <p>
      I keep myself busy, because right now I am living paycheck to paycheck, because I've had not enough money for my family for the last 4 years, because I want more free time. 
    </p><p>
      But my increase in income and increase in quality of life for myself and my family has been a product of constant thinking, the only time I don't think on purpose is when I'm producing.
    </p><p>
      Should you feel bad for not wanting to think? Not one bit, thinking is just like everything else your body is able to do, it's just a tool for you to use to your own benefit, and to do that you must take control.
    </p><p>
      Let me give you a more specific example.
    </p><p>
      I crank the music up so I don't think about the smell of pee in the bus, and the stench of sweat from the homeless person, and the homeless dog that is about to die on the street, and about the dead raccoon I just saw in the sidewalk, and about the lack of money and how much I wish I had a car. I crank the music up because I have around 20 objectives for this day, all were carefully thought of yesterday night, and because I need to stop the brain from thinking something new to prevent it from getting in the way of progress. I crank the music to blind myself, to not think, to not feel, because even though I have the power to help, I want to help myself first, you may call it selfishness, I call it necessity.
    </p><p>
      I let my desires drive my thinking. I want a diet mountain dew, How do I get one? To where do I go? Can I take the bus? 
</p><p>
      Similarly, I think things like "Damn, why can't my teammates remember what we agreed upon last week?" Is it because they are shitty people? Is it because I am too concentrated on this project and they don't care about it? What if some sibling of them is sick and dying? Should I ask? Should I care? Why would I care? Do I want ice cream to keep thinking on this? Damn wouldn't it be awesome to have a flamethrower right now? What was the name of that song, the one from OCRemix I heard 3 years ago? 
</p>
</div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      A sword never kills anybody; it is a tool in the killer's hand.
    </div>
    <h2>Thinking is a weapon and needs to be controlled</h2>
<p>Take another minute to let that sink in. There is a balance between thinking, planning, and doing, and you need to take care of that balance as it is precarious to the success of your objectives. 
</p><p>
But then, as the natural process of decay, doing gets in the way of thinking, and people start abusing power. Similarly, thinking may get in the way of doing, and the worse, planning may get in the way of both. 
</p><p>
And because thinking is a weapon, it can make or break your own value you generate, it can give you limitless power if applied and controlled correctly, or it can give you what you want and nothing more. 
</p><p>
But why would people want to stop thinking? 
</p>
</div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      The only thing we have to fear is fear itself.
    </div>
    <h2>Enter fear</h2>
<p>Fear is probably the most powerful feeling in your whole body (you fear waking up late, and you fear crashing the car, and you fear buying the wrong cereal because there could be another one on sale, and you fear getting the wrong lunch because it could have too many calories, or fat, or sugar, and you fear not meeting ends meet, and you fear things going sour, you fear meeting new people) you slowly start letting fear creep into your body, into your thoughts, and you just become an overprotective human being, afraid of the world, and then you die, and fear reminds you cheerfully of the things you never did because you were afraid, leaving you with this hellish image of how you wasted your life away to his power while he dances over your sickly dying body. 
</p>
<p>
  Ralph B. Taylor, Sally Ann Shumaker, and Stephen D. Gottfredson help establishing the magnificent power of fear in their work <b>Neighborhood level links between physical features and local sentiments,</b> that depending on Socieconomic Status (SES) how the physical surroundings affect people's fear and confidence. The effect of the physical environment is less in areas of higher SES, but these societies also have a more predictable and stable environment due to that status. Aditionally, people with lower live in more physically deteriorated areas, and in a more complex and less predictable area (such as water drains breaking for like, no reason, or an explosion of a meth lab for like... no reason). The study shows that mid to low SES are more emotionally affected by the physically deteriorated neighborhood they live in then the higher fear of crime and lower confidence they experience. It is important to keep in mind that there is no correlation with economic growth and physical deterioration, but we will see that there is a connection with neigborhood decline and a higher level of fear.
</p>
<p>
  Wesley Skogan published <b>Fear of Crime and Neighborhood Change</b>, a thorough statistical analysis in which he delved into trying to understand the connection between fear and decay. The first is the lack of investment from the landlords into their properties, causing physical decay of the neighborhoods. We also have demolishing and construction, and a reduction in property value, at which point corruption creeps in in the form of real state agents disseminating fear (in the form of lies) into owners to get lower prices and get them to sell. We also have the switch in industries which causes factories and bussines to close. And even though higher crime rates do reduce property value, the highest factor for crime level is set by other physical and social beliefs, reducing the property value based... on opinions, and not value itself (think overpriced products such as sunglasses or Beats headphones).
</p>
<blockquote>
  One of the most significant consequences of fear is physical withdrawal from community life. (Skogan, 1986)
</blockquote>
<p>
  Skogan establishes that people reflect their own vulnerabilities into their opinion on their environment, and because of that, crime perception was higher for women and the elderly. Added to this is the fact that we have channels that inflate or deflate the real value of fear into the residents (just google <b>threads are evil</b>, or <b>vaccines are evil</b> for that matter).  
</p>
<blockquote>
  The anxiety and deterioration and disorder generate among area residents can be a constant psychological irritant. (Skogan, 1986)
</blockquote>
<p>
  And in a glorious finale
</p>
<blockquote>
  Not surprinsingly, fear does not stimulate constructive, preventive, responses to crime. Surveys and experiments indicate that fear reduces people's willingness to take positive action when they see crimes, including simply calling the police. (Skogan, 1986)
</blockquote>
<p>
Fear must be controlled as well, and you must learn to take risks under certain constraints which means sometimes letting chaos take the reins and ride the lightning.
</p>
</div>
</div>

<div class="el">
<ins class="adsbygoogle adslot_1"
 style="display:inline-block;margin: 0 auto 0 auto; width: 100%;"
 data-ad-client="ca-pub-1525337072631150"
 data-ad-slot="3858661425"
 data-ad-format="auto"></ins>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      The Butterfly Effect
    </div>
    <h2>The decay of the software product is the decay of the developer.</h2>
<p><b>Not having tests is the primordial sign of the incompetence in software. Just like a neighborhood in decay, software without tests and documentation gives people the shaky feeling that if you touch it or change anything you may break something, thus you become afraid of making improvements, thus you become incompetent yourself.</b> The worst part is that if you are not careful, you invite this incompetence in, you let it sit on your table, and eat your lassagna while you eat the spoils of those who profit on your incompetent work.  
</p>
<p>
Add to that that you may have a horrible architecture, just like we awe in front of a magnificent building and we cringe in front of a house in shambles, the same can be said for software built on a stupid architecture, and based on that "architecture is always changing", "architecture has no rules", "architecture is based on stakeholder's decisions", then as such, a horrible architecture just adds to fear, since a complex monolith is the same as observing the 9th level of bureaucracy hell. 
</p>
</div></div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      Thinking and Fear, the homogeneous mixture
    </div>
    <h2>Cogito Ergo Sum</h2>
<p>You spent most of your childhood thinking, because it was the cheapest thing to do, you have no unlimited amount of videogames, and if you do, you still need to think to pick. Thinking is the first fight you'll have to solve in this convoluted mess you know as existence.  
</p><p>
But eventually you realize that nothing your mom or dad told you was true, you are not a prince or a princess, you are not that smart, you are just as smart as the surroundings allow you, same goes for how good you are. And instead of accepting this, you defend your stance, you want to be unique and a shining beacon of hope.  
</p><p>
Which you could be don't get me wrong. The problem is that life, the way is set up, is made to make you believe that thinking accounts for nothing and it is only until you start working (and not thinking) that you get to be successful.
</p><p>
It is not thinking about a book it is writing it. Not about an idea, but about the product.
</p><p>But this means that inherently there had to be some thinking in the beginning.</p>
<p>Sadly not everyone gets to reach success, success takes hard work, pain, blood, sometimes broken bones and lost loved ones.</p>
<p>Thus, they learn that doing is better, that planning is necessary, and that thinking is bad. And this accounts for most of humanity that is not happy, and most... of humanity... is unhappy. 
</p>
</div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      Our greatest glory is not in never falling, but in rising every time we fall.
    </div>
    <h2>The fear of failure</h2>
<p>As kids we are capable of anything, we try and fail and try and fail and repeat ad nauseam, nothing stops us. Every day I marvel at how my daughter handles failure with such a powerful hatred for it, and keeps trying, as if failure was the disease she is trying to cure, the antagonist in her princesses stories, the opponent in her games.  
</p>
<p>
There have been thousands on studies on the effects of failure on us, and the effects on our psychological well being.
</p>
<ul>
  <li>Fear of failure and unrealistic vocational aspiration by Charles Mahone.</li>
  <li>Multidimensional Fear of Failure Measurement: The Performance Failure Appraisal Inventory by David Conroy, Jason Willow and Jonathan Metzler</li>
  <li>Fear of failure and achievement goals in sport: Addressing the issue of the chicken and the egg by David Conroy and Andrew Elliot</li>
  <li>Fear of failure, fear of evaluation, perceived competence, and self-esteem in competitive-trait-anxious children by Michael Passer.</li>
  <li>Theories of motivation: From mechanism to cognition by Bernard Weiner.</li>
  <li>The Shame of Failure: Examining the Link Between Fear of Failure and Shame by Andrew Elliot.</li>
</ul>
<p>
  Just to name a few. All of them are very interesting but the last one by Andrew Elliot was the most mind blowing in which we see a correlation between your level of fear and your shame, as well as your closeness to your mother (yes, I'm talking to you, mommy's boy). And the hypothesis that shame is the root of the fear of failure. 
</p>
<p>
  The rise of gamification is a another solid staple in our fragile tender minds and how we need special processes to keep productive and to a certain extent, happy. 
</p>
</div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      Passion is one great force that unleashes creativity, because if you're passionate about something, then you're more willing to take risks.
    </div>
    <h2>The castration of creativity</h2>
<p>I've seen big men cower in fear of just something they don't understand coming into their life, and in their weakness to control it they let panic emanate from their bodies, as if it were sweat. And then they start looking for whatever argument they can make to deter the new thing from coming in.  
</p>
<p>
<a href="http://link.springer.com/article/10.1007%2Fs11192-008-2141-5#page-1" target="_blank">There is even an article that digs into cases that <b>experts</b> would create resistance for new things, new things that eventually meant a Nobel Prize.</a>
</p>
<a name="fiverules"></a> 
<p>
  <a href="http://digitalcommons.ilr.cornell.edu/cgi/viewcontent.cgi?article=1457&context=articles" target="_blank">Cornell University made an entire study to dig deep into why people place so much resistance against creativity, made by Jennifer S. Mueller, Shimul Melwani, Jack A. Goncalo.</a> You have seen the movies, how every washed out man says to a young guy "YOU REMIND ME OF ME WHEN I WAS YOUNG," such a cliche and yet people don't learn squat. 
</p>
<p>
  From the study by Cornell:
</p>
<blockquote>
  Uncertainty is an aversive state which people feel a strong motivation to diminish and avoid. Hence, people can also have negative associations with novelty; an attribute at the heart of what makes ideas creative in the first place. 
</blockquote>
</div>
</div>

<div class="post-container mdl-grid">
  <div class="post-content mdl-color--white mdl-shadow--4dp content mdl-color-text--grey-800 mdl-cell mdl-cell--11-col mdl-cell--12-col-tablet mdl-cell--4-col-phone">
    <div class="demo-crumbs mdl-color-text--grey-500">
      Your best teacher is your last mistake.
    </div>
    <h2>The solution</h2>
<p>The solutions is yet another broken record repeating itself over and over again through history. But if forgetting your past dooms to repeat it, then also forgetting the same things that help people stay strong.   
</p>
<p>
And the first step is accepting that testing takes more time than feature development. While testing edge cases such as <i>This data shouldn't be null</i> will be simple, testing something more complicated such as <i>on X width of the screen the grid should have Y objects on my UI</i>, so the best way to tackle this is simply by accepting, that create automated tests is expensive.
</p>
<p>The solution is to provide easier mechanism to people to learn. Better tutorials, with beautiful visuals to appeal to people's weaknesses and better knowledge regarding how to carry tests on. 
</p>
<p> 
The human mind and body is a curious thing, and one may think that a person living in an environment that he doesn't like living in would cause him to want to make a change. But you also need to keep in mind that the young respect the old, for some f****d up reason, and the old are exhausted from failing. 
</p>
<p>
<a href="http://johnstepper.com/2013/10/26/the-five-monkeys-experiment-with-a-new-lesson/" target="_blank">The lazy become the monkeys eventually from the monkeys and the water spray experiment</a> and a new era of a lack of creativity and making our life's easier begins because the big men with power shut down the small men. Such a procedure has existed for our entire existence. Just like the police man says "Forget it, Jake; it's Chinatown" to Jack Gittes, communities, families, companies, may become the architects of their own demise. 
</p>
</div>
</div>

We will continue our studies by providing the 5 Do's and 5 Don'ts I've encountered in TDD development, this post will be ready in two weeks while I prepare the code examples. 

<div class="center-unknown"><div class="el">
<button id="next-page" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--colored" onclick="location.href='/';" disabled>Go to 5 Do's and Dont's of Unit Testing</button>
</div></div>


  
