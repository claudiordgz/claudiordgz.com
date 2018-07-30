---
title: The Ad Generator App - Beginning
slug: the-ad-generator-app-beginning
date_published: 2014-01-31T19:56:36.000Z
date_updated:   2014-03-08T22:00:43.485Z
---

<span style="line-height: 1.5em;">To explain the Ad Generator, first let me talk about some history.</span>
<h2>History</h2>
<h3>Video Games</h3>
I love them. The feelings you may encounter when unleashing the fury in a video game, or when you delve deeper into a story, or even when you save a princess, are just too good to be described.&nbsp;
<h3>The Change</h3>
But somewhere along the way I discovered I wanted to do Artificial Intelligence, and then I discovered that video games were stealing time from learning. Thus, I started to just import and sell video games.

I like selling video games, it not only allows me to meet other just-as-me crazy gamers, but it allows me to come close to the collector's games I wont be buying because I just don't earn enough dough. No matter though, I don't feel the same rush from buying the impossible-to-buy collectors edition from the old days. Nowadays I am happy to just see a huge box, look at it, and make a customer happy for getting him the ungettable thing.
<h2>The Problem</h2>
Buying/Selling takes time from my Artificial Intelligence learning, and that pisses me off. The amount of frustration from wasting my time is so enormous that it is hard to explain. I'm not an official reseller, I buy things in the US, get them to Mexico, and sell them there.

So I decided to break down the problem, how to waste less time until the day I waste... virtually no time.
<h3>Every time I buy something to sell it I do the following:</h3>
<ol>
	<li>Import it to Mexico</li>
	<li>(Optional) Take pictures of the product</li>
	<li>Create an ad in html</li>
	<li>Host the photos and some images to the ad in a public server</li>
	<li>Publish the ad somewhere (mercado libre in my case).</li>
	<li>Answer Questions</li>
	<li>Sell</li>
</ol>
It is pretty straightforward, but it can take a huge chunk of my time.

Thus I need an app for it.
<h2>What do I need</h2>
Let's order our list:
<ol>
	<li>Import it to Mexico
<ul>
	<li><strong>hard, unavoidable time</strong></li>
</ul>
</li>
	<li>(Optional) Take pictures of the product
<ul>
	<li><strong><strong>cellphone possible, complicated feature (for one person)</strong></strong>&nbsp;</li>
</ul>
</li>
	<li>Create an ad in html
<ul>
	<li><strong>CSS Objects, HTML code, Images, Photos and Description</strong></li>
</ul>
</li>
	<li>Host the photos and some images to the ad in a public server
<ul>
	<li><strong>Push to server using ftp, maybe something else in the future</strong></li>
</ul>
</li>
	<li>Publish the ad somewhere
<ul>
	<li><strong>Mercado Libre in my case, maybe something else in the future</strong></li>
</ul>
</li>
	<li>Answer Questions
<ul>
	<li><strong>I don't think it is in the scope of the project</strong></li>
</ul>
</li>
	<li>Sell
<ul>
	<li><strong>Happiness ensues</strong></li>
</ul>
</li>
</ol>
<h2>Why to do it</h2>
Most sellers in the website do the following: Design an ad in an edition tool, suchs as gimp, paint, powerpoint, word, or photoshop. Afterwards they publish the image in chunks. This is all right, it gets the job done. Alas, this is highly inefficient, and it has the following problems:
<ul>
	<li>What if the server hosting the images is down or slow?</li>
	<li>What if the user has low bandwith?</li>
	<li>What if the user is in a cellphone?</li>
	<li>What if the user is in a shitty cellphone with text only?</li>
</ul>
A website has to be fast, and use as low as possible of the client's resources to allow the MOST important thing, to get the information to him, when he wants it.

So... let's continue to how to do it...
<h1>How to do it</h1>
THIS IS IT! The time has come to start implementation. Let's look at a basic MercadoLibre ad, courtesy of me.

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1393991654/AdExample_ghwmbn.png"><img class="size-large wp-image-64" alt="Ad example" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/h_1024,w_526/v1393991654/AdExample_ghwmbn.png" width="526" height="1024" /></a> This is just a typical ad of MercadoLibre

The ad has the following properties:
<ul>
	<li>Store Name</li>
	<li>Tite/Subtitle</li>
	<li>Politics or Terms of Sale</li>
	<li>Images</li>
	<li>Photographs</li>
	<li>Description(s)</li>
</ul>
All of these items may expand to the users content. For example, some sellers put A LOT of Terms of Sales stuff while others just a few lines. Similarly, some users may want to change their politics for certain products (for example shipping rates).
<h2>So what do we need?</h2>
<ul>
	<li>HTML Code + CSS Objects carefully crafted</li>
	<li>Images in a server for our links to work</li>
</ul>
Seems simple doesn't it? Of course it does. But we need to be able to let the user edit those things fast. So it would be something like this:
<ul>
	<li>User opens the app
<ul>
	<li>Creates/Opens his profile</li>
	<li>Watches/Creates his ads in a TreeView/List of Ads</li>
	<li>Now he can create a new ad, on the first page he should be able to:
<ul>
	<li>Edit the ad name</li>
	<li>Edit the Image Gallery</li>
	<li>Edit the Photo Gallery</li>
	<li>Add a description</li>
</ul>
</li>
	<li>Now he should be able to connect via FTP or Request to a remote folder to drop his images and photographs</li>
</ul>
</li>
	<li>User closes the App</li>
</ul>
<h1>Kickoff</h1>
<a title="AdGenerator Repo" href="https://github.com/claudiordgz/AdGenerator" target="_blank"><img class="size-thumbnail wp-image-73" alt="GitHub" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png" width="150" height="150" /></a> The Cat from GitHub

&nbsp;We shall begin the program first by handing the engine that builds the ad. I put the code in a repo in <a title="Ad Generator Repo" href="https://github.com/claudiordgz/AdGenerator" target="_blank">github&nbsp;here</a>.

Then we shall code the UI/UX in kivy as well in Python.

Doing the engine in python allows for migration in the future and sustaining the UI/UX in python.

