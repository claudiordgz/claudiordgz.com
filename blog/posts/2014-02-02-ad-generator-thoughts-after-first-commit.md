---
title: Ad Generator - Thoughts after first commit
slug: ad-generator-thoughts-after-first-commit
date_published: 2014-02-03T03:05:13.000Z
date_updated:   2015-11-07T15:48:17.842Z
draft: true
---

<h1>The First Iteration</h1>
<span style="line-height: 1.5em;">I started the Ad Generator pretty roughly focusing only on getting 3 ads out by the door. &nbsp;It took around 6 hours straight to come up with the code and a few more hours of editing photographs (courtesy of my wife). The ad generator was not a full program, it was just raw python code combined with some yaml files for configuration purposes.</span>

All this tedious processing bared unseen fruits when in my day job I created a new script for generating a special xml file to be used with TopServer. &nbsp;Nevertheless, this unrelenting crunching of code led me to a path of inexorable pain as I tasted the result of not creating proper architecture, even for such a small of scripts.&nbsp;

Don't fret over small business.&nbsp;

I crunched 10 more ads which resulted in 10 painless and successful and great tasting sales. Sweet, as a nice warm cup of tea and honey with a side of bread and jam and not cinnabon sweet but sweet nonetheless. Suddenly I could dedicate my time and effort to giving a more delicate and thoughtful customer service, and life was good. The ad generator, in its primitive and raw state was a great idea but it needed to grow into a more mature process and for that sleepless night of productivity and coffee would be necessary.

It all continued with my day job as I crunched more and more of that script that started burping tens of thousands of lines of lines horrid xml. As a yaml and json advocating person watching xml is like seeing a man being cooked on a brazen bull while feeling his excruciating pain. My day job script needed an UI, and I looked over to python which eventually took me to Kivy. My boss in a weird turn of events gifted me with Roberto Ulloa's book on Kivy.

Will you use it for work?

Yes.

Then don't pay me the book.

There are so many ideas rambling in my head of how to use Kivy for my workplace and most of them relate to generating &nbsp;special tools to make better deployment of our products, alas that is not a subject for here. Kivy is a beautiful tool to creating UI/UX experiences using the KV languaje paired with Python code and even though I'm still learning the ropes and then some, it is by creating tools to help us solve our problems that we will succeed in making our work in less time and thus in less money and effort. It is by spending less money that we can earn more money and by earning more money we could just get a little ahead so I can build a decent computer to play gta 4 will superb mods.&nbsp;
<h2>The Structure of the First Iteration</h2>
The Model looked something of an aberration which was a product of the&nbsp;Jörmungandr and HTML who had a twin that looked like the offspring of a Fairy and yaml. &nbsp;Don't get me wrong, both of them got the job done, but software is a terrible business for the hideous and in this place only the pretty, well structured, smart, and knowledgeable will mature into giants while others wither and die like old men from the cold lands. Sadly there is no such things as vaccines for software, no enfagrow to ensure a better core development and we are left to knowledge spread in books who are precocious and with so many different options to begin development that after so much reading and bleeding through your eyes you will be left full of fears and warnings even worse than when you started. And you'll only think of Gandalf pleading you to run, you fool. &nbsp;&nbsp;

Why things are born better when they're pushed through fire?

Who says there were born better?

More successful

Because success is impervious to a bad beginning, to be successful sometimes you gotta push through.

Then why don't push through this?

There is no pushing through software in one sitting, you gotta know the development cycle, and accept that the end will only result in a new beginning as you did with you first script and now you want to make it better, more mature. Once you know the fuzzy future in the firmament you know there is only more future and as soon as you accept that the future is plagued with work, maintenance, taxes, and more future until death then the sooner you can start pre processing the future in the present until you come up with a cycle that you can control.

So, to death it is?

Someone will take over your crap.

What if there is no one?

There will always be someone, and that someone could be a sad person which you just cursed with a huge piece of legacy, unsustainable, and undocumented shit or it could be someone who will drop your shit and start creating new, whichever there is, there is someone. &nbsp;The world is an statistical monster in which history repeats itself.&nbsp;
<h3>&nbsp;The Ad Model</h3>
The first ad has the following:
<ul>
	<li>A path comprised of the customer's categories in which the ad enters</li>
	<li>A header which has:
<ul>
	<li>Name</li>
	<li>Description</li>
</ul>
</li>
	<li>Format for the &nbsp;images</li>
	<li>Banner image with format</li>
	<li>Header image with format</li>
	<li>List of images</li>
	<li>List of photos</li>
</ul>
<h3>The Skeleton Model</h3>
It is just cold raw html crap that will make your sphincter so tightly closed and cold that it will start to chip into little pieces and will leave a burn so deep into the dark cavities of your ass that will make you walk like a walrus for the rest of your life. Such is the price of results I'm afraid. &nbsp;&nbsp;

Why is it so crappy if it works?

Because making a GUI for it makes it crappier. There is no such thing as smart growing for something like this. Fortunately in the world of engineering we are gods playing with words, symbols and formulas as we see fit until they become a force to be reckoned with and this is no exception. For all the hours I take right now will translate into less hour when taking this horrid monster into the next level. &nbsp;
<h2>The next model</h2>
<h3>The User Model</h3>
I want to be the user and not the programmer just as any guy wants to be the lover and not the fan and just as any wants to be the hero and not the random cop that died mercilessly. And as a user I demand the following:
<ul>
	<li><span style="line-height: 1.5em;">I want to have all my ads listed on screen, this thing has to remember me because I have a shitty memory</span>
<ul>
	<li>List of ads per user</li>
</ul>
</li>
	<li>This thing should remember where I want my images stored, either locally, in a remote server, dropbox, whatever. And you better make this thing secure tiger or else it will be row duty on the galleons for you.
<ul>
	<li>List of communications with encrypted passwords</li>
</ul>
</li>
	<li>Oh yeah the name and description by ad are a yes
<ul>
	<li>Name, Description ok</li>
</ul>
</li>
	<li>List of images and photos, cool
<ul>
	<li>List of images, photos, with formats, ok</li>
</ul>
</li>
	<li>What... I can't change my ad terms of sales? Whatz diz? Change diz immediately herr cruncher programmer.&nbsp;
<ul>
	<li>Custom politics per ad</li>
</ul>
</li>
	<li><span style="line-height: 1.5em;">No custom css objects for moi? No sugar for toto?</span>
<ul>
	<li>List of css objects so user may extend</li>
</ul>
</li>
	<li><span style="line-height: 1.5em;">Arrrrrg what's with the uneditable, unextendable, unforgettable plaster of html</span>
<ul>
	<li>Html should be as modular as possible</li>
</ul>
</li>
</ul>
<h4>The Ad Manager Model</h4>
Because every user should have lots of ads, then we should have a model where all ads are located.&nbsp;
<h3>The Skeleton Model</h3>
Gone should be the days were html is plastered on a single config file and begone to another model I cast you oh css objects &nbsp;from hades. This would translate to a model that has a list of css objects and mechanisms to reuse the html code.&nbsp;
<h2>When will the next iteration be ready</h2>
February 3rd my boy

February 3rd

in one commit
<h1></h1>

