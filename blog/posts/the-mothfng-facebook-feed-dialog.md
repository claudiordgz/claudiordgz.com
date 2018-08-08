---
title: Using Facebook JS SDK to create custom Feed Dialogs
slug: the-mothfng-facebook-feed-dialog
date_published: 2015-07-10T16:36:21.829Z
date_updated:   2015-08-15T13:10:44.398Z
tags: Javascript, facebook-sdk
---

Should you feel bad that you can't share some specific information from your site or app when someone click's share. Yes, yes you should, because delivering custom information on facebook has a way of doing it in the front end, and here is how.

I should feel sorry for not keeping in touch... but I don't feel a thing. Keeping in touch gets in the way of progress. What feels weird is that nowadays it is easier to share stuff to **the world** than to share stuff to a few loved ones. So many platforms, one could say that share buttons are ubiquitous in the web. 

## Who doesn't love sharing stuff to facebook? (I know a few)

Sharing stuff is so easy once you have the social networking accounts. Nowadays we have these fantastic cards that even show a tiny image of what you are sharing, so that people can see a screenshot and feel engaged way before clicking anything. An image speaks a thousand words.

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
  <div class="mdl-card__supporting-text" style="width:100%;">
    <div class="mdl-grid">
      <div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
        <img alt="Look at this!" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819788/Screenshot_of_Google_Chrome_7-10-15_6_50_52_PM_kxsy19-compressor_ezajj4.png" style="width:100%;"/>
        <p style="text-align: center; width: 100%;">Facebook Open Graph</p> 
      </div>
      <div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
        <img alt="Look at this too!" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_Chrome_7-10-15_6_53_01_PM_fj07hn-compressor_zfjjaw.png" style="width:100%;"/>
        <p style="text-align: center; width: 100%;">Twitter Card</p> 
      </div>
    </div>
  </div>
</div>

## Initializing Facebook's SDK

First you register as a developer and then register an app in facebook, afterwards you use the Javascript SDK (or the pertinent one, I just needed to do it in JS in this case). 


<div class="mdl-card mdl-shadow--2dp demo-card-wide">
    <div class="mdl-card__supporting-text" style="width:100%;">
<div class="mdl-grid">
<div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436570828/Screenshot_of_Google_Chrome_7-10-15_7_26_03_PM_kq5anq.png" target="_blank"> 
![Developer's Site](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_Chrome_7-10-15_7_26_03_PM_kq5anq-compressor_dhwj19.png)
<p style="text-align: center; width: 80%;">Go to Facebook's Developers Site</p> 
</a>
</div>
<div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet"> 
<ins class="adsbygoogle adslot_inside_card_100pw_300pxh"
     style="display: inline-block; z-index: 1500;"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="3297134621"
     data-ad-format="auto"></ins>
</div>
</div>
<div class="mdl-grid">
<div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436570836/Screenshot_of_Google_Chrome_share1_o4nzmo.png" target="_blank"> 
![Stuff](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_Chrome_share1_o4nzmo-compressor_lwp7iw.png)
<p style="text-align: center; width: 80%;">Create new app</p> 
</a>
</div>
<div class="mdl-cell mdl-cell--6-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_share2_jxevha-compressor_vgthzc.png" target="_blank"> 
![Moard](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_share2_jxevha-compressor_vgthzc.png)
<p style="text-align: center; width: 80%;">Your app, click getting started</p> 
</a>
</div>
</div>
</div>
</div>

<br/>

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
    <div class="mdl-card__supporting-text">
      <h4>One final note before developing</h4>
<div class="mdl-grid">
<div class="mdl-cell mdl-cell--12-col mdl-cell--4-col-phone mdl-cell--8-col-tablet">
<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436625465/facebook_settings_ggolc5.png" style="text-align: center; width: 100%;"><img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436625465/facebook_settings_small_muaaib.png" style="margin-left: auto; margin-right:auto; width: 80%; max-width:400px;"/>
</a>
<p style="text-align: center; width: 100%;"><b>You must configure your domain in your facebook's developer account, it's the field that says Site URL</b></p> 
</div> </div></div> <div class="mdl-card__actions">
  <a href="#" class="mdl-button mdl-js-ripple-effect mdl-button--colored" data-toggle="modal" data-target="#faceBookInit" style="background-color:SeaGreen; color:white;">Check init code for using the facebook SDK.</a>
  </div>
</div> <div class="modal" id="faceBookInit" role="dialog" aria-labelledby="faceLabelBookInit" data-backdrop="false" style="top: 15%;">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="mmLabelInit">Facebook Initialization Code</h4>
      </div>
      <div class="modal-body">
```language-javascript
  window.fbAsyncInit = function() {
    FB.init({
      appId      : USE_YOUR_APP_ID,
      xfbml      : true,
      version    : 'v2.4'
    });
  };

  (function(d, s, id){
     var js, fjs = d.getElementsByTagName(s)[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement(s); js.id = id;
     js.src = "//connect.facebook.net/en_US/sdk.js";
     fjs.parentNode.insertBefore(js, fjs);
   }(document, 'script', 'facebook-jssdk'));
```
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

So let's assume I have a list of cards inside my website, and I want to share to facebook an individual card, but not the website itself. Let's look at the basic, most barebones facebook functionality in the following example. (**Bro tip**: click share link at top right).

<script>
function shareDialog() {
    FB.ui(
	      {
	        method: 'share',
	        href: window.location.href,
	      },
	      function(response, show_error) {
	        if (response && response.post_id) {
	            console.log('Post was published.');
	        } else {
	            console.log('Post was not published.');
	        }
	      }
	   );
}
</script>

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
  <div class="mdl-card__title">
    <h2 class="mdl-card__title-text">The Chizza</h2>
  </div>
  <div class="mdl-card__supporting-text">
     On July 9 KFC unveiled their CHIZZA, a pizza that uses chicken as crust, showing to that world the real meaning of IDGAF.
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-js-button mdl-button--fab mdl-button--mini-fab mdl-button--colored mdl-js-ripple-effect" onclick="shareDialog()">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>

<br/>

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
    <div class="mdl-card__supporting-text">
      <h4>The Basic Share Dialog</h4>
      As you can see the result of a Share Dialog looks pretty nice and it takes minutes. Problem is that you need to have a sound and robust production process. Your og mega tags need to be in order, this is not optional. Facebook provides some SDKs for multiple platforms to allow you to share a website fast & hot. But what if you want more? or what if you don't have control of the meta tags in the website? or what if you want to share one specific piece, like a cooking recipe, or a song, or a video in YouTube. And in this case we want to be able to share the CHIZZA picture and not the post's picture. How can we achieve this?
<br/><br/><ins class="adsbygoogle adslot_inside_card"
     style="display: inline-block;margin-left: auto;margin-right: auto;width: 100%;"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="4467437029"
     data-ad-format="auto"></ins>
<br/></div>
    <div class="mdl-card__actions">
      <a href="#" class="mdl-button mdl-js-ripple-effect mdl-button--colored" data-toggle="modal" data-target="#faceBookShareDialog" style="background-color:SeaGreen; color:white;">Check the basic code of the share button</a>
    </div>
  </div>

<br/>

<div class="modal" id="faceBookShareDialog" role="dialog" aria-labelledby="modalLabelFacebookShare" data-backdrop="false" style="top: 15%;">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">The Share Dialog Code</h4>
      </div>
      <div class="modal-body">
```language-javascript
function shareDialog() {
    FB.ui(
	      {
	        method: 'share',
	        href: window.location.href,
	      },
	      function(response, show_error) {
	        if (response && response.post_id) {
	            console.log('Post was published.');
	        } else {
	            console.log('Post was not published.');
	        }
	      }
	   );
}
```
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>


So I need a Facebook share button using Javascript but I want custom images and text because that's what's cool (seriously Yo'). So according to the Facebook SDK there is something called the [Feed Dialog](https://developers.facebook.com/docs/sharing/reference/feed-dialog/v2.4), which according to some alarmists it is deprecated.  I present forth [exhibit A](https://stackoverflow.com/questions/26282456/if-facebook-feed-dialog-is-deprecated-how-are-you-to-share-posts-on-facebook) and [exhibit B](https://ux.stackexchange.com/questions/70199/what-is-the-difference-between-facebooks-share-dialog-and-feed-dialog). 

Furthermore testing this functionality is not really a walk in the park since you can't test it in *localhost*. You don't know what I mean? This blog post is a whole testing playground. 

<div class="mdl-card mdl-shadow--2dp demo-card-wide" style="max-width: 600px;"><div class="mdl-card__supporting-text" style="width:100%;">
<img alt="Seriously Facebook!" src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436543894/Screenshot_of_Google_Chrome_7-10-15_11_59_06_AM_jutivf.png" style="width: 100%" class="img-responsive Seriously Facebook!"><p style="text-align: center; width: 100%;">Damn Facebook, damn.</p> 
</div> 
</div>

The ghost blog platform works wonderfully with Facebook, that is due to the **og** meta tags that are injected as soon as my post is published. Just like twitter that has the **card** tags. Problem is these tags need to come from the server and the app is working as a SPA and everything is generated on the client side. 


<div id='fbFeedDialog' class="mdl-card mdl-shadow--2dp demo-card-wide">
  <div class="mdl-card__title">
    <h2 class="mdl-card__title-text">The Chizza</h2>
  </div>
  <div class="mdl-card__supporting-text">
     On July 9 KFC unveiled their CHIZZA, a pizza that uses chicken as crust, showing to that world the real meaning of IDGAF.
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-js-button mdl-button--fab mdl-button--mini-fab mdl-button--colored mdl-js-ripple-effect" onclick="feedDialog('fbFeedDialog')">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>

<br/>

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
    <div class="mdl-card__supporting-text">
      <h4>The Basic Feed Button</h4>
      So using the Javascript SDK you can add that extra power to these cards everyone is loosing their shit about. Allowing you to take full advantage of your application without depending on your og meta tags. Doing a feed dialog is pretty easy, but we need to delve into the nitpickings. 
<br/>
<ins class="adsbygoogle adslot_inside_card"
     style="display: inline-block; margin-left: auto; margin-right: auto; width: 100%;"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="1228095823"
     data-ad-format="auto"></ins>
<br/>
    </div>
    <div class="mdl-card__actions">
      <a href="#" class="mdl-button mdl-js-ripple-effect mdl-button--colored" data-toggle="modal" data-target="#faceBookFeedDialog" style="background-color:SeaGreen; color:white;">Check the basic code of the feed button</a>
    </div>
  </div>

<br/>

<div class="modal" id="faceBookFeedDialog" role="dialog" aria-labelledby="modalLabelFacebookFeed" data-backdrop="false" style="top: 15%;">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Feed Dialog Code</h4>
      </div>
      <div class="modal-body">
```language-javascript
function feedDialog() {
    FB.ui(
	      {
	        method: 'feed',
	        name: 'The Chizza power',
        link: window.location.href,
        description: 'On July 9 KFC unveiled their CHIZZA, a pizza that uses chicken as crust, showing to that world the real meaning of IDGAF.',
        caption: 'It has arrived to riddle all your veins with fat',
        picture: 'http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/19369967005_0dc811c9a0_muuode-compressor_bxvrjl.jpg',
        display: 'popup'
	      },
	      function(response, show_error) {
	        if (response && response.post_id) {
	            console.log('Post was published.');
	        } else {
	            console.log('Post was not published.');
	        }
	      }
	   );
}
```
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

### Feed button **vs** Share Button

So on one you can share specifics, which in this case since we have **one** card, but when we have, say... 25 cards, well, then using the feed dialog may prove invaluable. Now if only you could use **several domains** with one **app id**. Guess one can only dream. 

<div class="mdl-card mdl-shadow--2dp demo-card-wide">
    <div class="mdl-card__supporting-text" style="width:100%;">
<div class="row">
<div class="col-sm-5 col-md-6"> 
<img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_Chrome_7-10-15_7_50_00_PM_e08i2q-compressor_pfu6va.png" width="100%"/>
<p style="text-align: center; width: 80%;">Using the Share Dialog</p> 
</div>
<div class="col-sm-5 col-sm-offset-2 col-md-6 col-md-offset-0"> 
<img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/Screenshot_of_Google_Chrome_7-10-15_7_49_38_PM_s72bav-compressor_ld6mlw.png" width="100%"/>
<p style="text-align: center; width: 80%;">Using the Feed Dialog</p>
</div>
</div>
</div>
</div>

<br/>

<a name="listview-test"></a>
## ListView Test

Let's take it up a notch and test Facebook's feed dialog on multiple cards in the same page. So far I known that if you pass a caption with extra quotes (') the SDK will fail, regardless if they are escaped with a backslash \ or if the string is correct ("I'm a correct string Yo'").

## Top nastiest/delicious/obscene assassin foods in the world

<div id="card-list"></div>

<script src="/assets/js/posts/ICanHaz.min.js" ></script>

<script id="elcard" type="text/html">
<div id="elCard{{ idx }}" class="mdl-card mdl-shadow--2dp demo-card-wide-small">
  <div class="mdl-card__title" style="background-image: url('{{ img }}');">
    <h2 class="mdl-card__title-text_two">{{ title }}</h2>
  </div>
  <div class="mdl-card__supporting-text">
     {{ content }}
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-js-button mdl-button--fab mdl-button--mini-fab mdl-button--colored mdl-js-ripple-effect" onclick="feedDialog('elCard{{ idx }}', '{{ caption }}', '{{ img }}')">
      <i class="material-icons">share</i>
    </button>
  </div>
</div>
</script>

<script type="text/javascript">
function getUrl(stringAElement){
    return stringAElement.match(/href="([^"]*)/)[1];
}

  document.addEventListener("DOMContentLoaded", function(event) { 
      var cardData, card;
      var div = document.createElement('div');
      div.innerHTML = 'http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436713622/19369967005_0dc811c9a0_muuode.jpg';
      var url = div.querySelectorAll('a')[0].href;
     
      cardData = [
{ title: "Quadruple Bypass Burger", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819786/ap_triple_bypass_burger_heart_attack_ll_120215_wblog-compressor_f7odsr.jpg'), content: "With 20 slices of bacon and packing 9,982 calories, this baby is sure to leave you breathless in a very literal way. If you feel like it you could try the Octuple Bypass Burger for a sure fire heart attack.", caption: "The Owner warns you that it will kill you" },
{ title: "The 7-pound breakfast burrito", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819788/4811704245_3d51a7c919-compressor_oqi5zc.jpg'), content: "Jack-N-Grill's burrito is bound to destroy you. 7 potatoes, 12 eggs, a pound of ham, onion, cheese, and chili. As a mexican I wouldn't call this a burrito, but hey... seven pounds.", caption: "Can you accept the challenge?" },
{ title: "Doogie\'s 24 inch hotdog", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819788/P1090622-compressor_hz4hew.jpg'), content: "Is it a fallus? Is it insanity? Is it too long? Does size even matters anymore? I need to say that the website's quote 'It's a love affair with really good food.' does make me feel I need to eat there. This is commitment people!", caption: 'You are seeing right, 2 feet long' },
{ title: "The Luther Burger", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/churchkey-burger-compressor_dsct4p.jpg'), content: "Could possibly be one of the biggest legacies of Luther Vandross... maybe not... but who knows. A burger with buns made of krispy kreme... that's gotta be a product of genius and it probably took some heavy weeds use to get to that genius level. It is all about what you leave behind to humanity.", caption: "The Boondocks S01E10 The Itis" },
{ title: "Fried Brain Sandwich", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/l-compressor_fpyecd.jpg'), content: "I love eating heads of cows, cow tongue tacos, cow brain tacos, such delicacy, much deliciousness. The best tacos I tried in the last five years have been of my own making. But I have never tried a fried brain sandwich... now I must go and run a few laps, for I want to try this one in the future.", caption: "Hilltop Inn, search for it in yelp" },
{ title: "Hot Beef Sundae", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819786/hot-beef-sundae-400-compressor_ix7dqs.jpg'), content: "Oh Iowa, you gave us Slipknot, something that we may never be able to repay you, but you also gave us this weird contraption. A mixture of totally opposite tastes to create a ying and yang of flavor.", caption: "Iowa State Fair" },
{ title: "Deep Fried Coca Cola", img: getUrl('http://s2.reutersmedia.net/resources/r/?m=02&d=20061027&t=2&i=26583&w=644&fh=&fw=&ll=&pl=&r=26583'), content: "I can't believe I have not seen this in a more ubiquitous manner, I mean come one... coca cola is practically everywhere, strawberries are almost everywhere thanks to globalization (ironic huh?).", caption: "Also born from a State Fair, by Abel Gonzales" },
{ title: "Aligot", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436752400/461-5_iooois.jpg'), content: "Mashed potatoes and cheese, delicious, and maybe someday 'Murica will make us the favor of deep frying this one. It sounds cheap, and delicious.", caption: "FRANCE!!!!" },
{ title: "The Double Down", img: getUrl('http://cache.fastfoodnutrition.org/social2/39.jpg'), content: "What? Did you really though KFC's other masterpiece regarded as a milestone in humanity's current decadence wouldn't make this list? This thing is the merging between simplicity, deliciousness, and fat, of course fat.", caption: "Delicious KFC" },
{ title: "XXXL Fat Burger", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819786/Screenshot_from_2015-07-12_10_08_12_w6fgab-compressor_xxorza.png'), content: "FatBurger's XXXL burger may not look as much since a Six Dollar Burger from Carl's Jr. has over 1000 calories, but between one thousand and fifteen hundred calories there is a huge difference, and this baddie has almost double.", caption: "It almost looks like it can talk" },
{ title: "Acaraje", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436713782/acaraje_ugkc7n.jpg'), content: "While America holds the baton while it comes to creativity and pushing forward the discovery of deep frying stuff, you can't deny this Afro-Brazilian dish is not a ball of deep fried black eyed peas mass that looks like it needs a huge portion of sour cream on top.", caption: "Palm oil for the win" },
{ title: "Tony's BLT", img: getUrl('http://thisiswhyyourehuge.com/wp-content/uploads/2010/07/tumblr_l4ujenlA5W1qcn3o7o1_500.jpg'), content: "One pound of crispy bacon with lettuce, mayonnaise and tomato served on your choice of bread. Are you not entertained?", caption: "Do I need to add more?" },
{ title: "The Bacon Wrapped Pizza", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436712945/BaconCrust-600_xedlcq.png'), content: "Little Caesars outdid themselves with this one, a pizza so cheap and so wrapped in bacon that if you are surviving from hunger in America then you are in serious problems.", caption: "When in doubt, wrap it in bacon." },
{ title: "The Five Five Challenge", img: getUrl('http://www1.theladbible.com/images/content/537dcc52686aa.png'), content: "From Hwy 55 comes the 55 challenge which is '55 oz. of burger with at least 4 trimmings on a bun, plus fries & a 24 oz. drink!'", caption: "Get it free, munch it in less than 30 minutes" },
{ title: "Beer Barrel Belly Buster", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819786/15-pound-compressor_sxltta.jpg'), content: "I knew of the existence of this one from a Maxim magazine back around 2004 or 2005, it is a 15 pound monster that requires a 24 hour notice. From Deny's Beer Barrel Pub.", caption: "I shall fear no evil" },
{ title: "Big Ugly", img: getUrl('http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1436819787/14-compressor_rcdu11.jpg'), content: "I have never tried elk, but if there is a sure way to make damn sure I know what elk meat tastes like is by eating one pound of it. You'll find it on Bub's Burgers & Ice Cream.", caption: "How majestic is eating elk?" },
{ title: "Frito Pie", img: getUrl('http://cf2.foodista.com/sites/default/files/styles/featured/public/field/image/pie_12.jpg'), content: "Just like the name sounds, a pie made of Frito Lays, this is kind of Nachos on steroids, hell you could add nacho cheese on top.", caption: "Embrace the fritos." },
{ title: "Turducken", img: getUrl('http://www.schallerweber.com/cms/wp-content/uploads/2012/11/foo_ck_turducken_1223.jpeg'), content: "The Turducken is a turkey stuffed with a duck stuffed with a chicken, I don't know if you can get more intense than that. The amount of precision required for this dish is paramount.", caption: "The matryoshka doll of dishes" },
{ title: "Vermonster", img: getUrl('http://thisiswhyyourehuge.com/wp-content/uploads/2011/12/tumblr_lw7c2fQS4H1qcn3o7o1_1280-560x533.jpg'), content: "Ben and Jerrys had a dream, a dream of a bucket of ice cream, and way too many toppings. Should you eat it one sitting? Given the 14,000 calories I would suggest to do it in at least one month but what do I know.", caption: "20 Scoops of ice cream." },
{ title: "Triple Triple Burger", img: getUrl('http://www.gannett-cdn.com/-mm-/c476f0858f1165d09b0ebfaa89c425a87f4d9346/c=634-0-4911-3216&r=x513&c=680x510/local/-/media/2015/04/01/SNJGroup/CherryHill/635634435504830681-phillies1.jpg'), content: "9 Patties, 9 Slices of American Cheese, Lettuce, Tomato. Does too much of the same thing can be too much? Has anyone seen A Good Day to Die Hard or Expendables 3?", caption: "Look at that tower! Wayback Burgers" },
{ title: "Bubba's wide burgers", img: getUrl('http://www.supersizedmeals.com/food/images/articles/20071008-Hillbilly_Hotdogs_10_lb_Burger_17.JPG'), content: "Hillbilly hotdogs restaurant is a crown jewel in size. Their menu is jam packed with big size items.", caption: "Share sizes man! Share sizes!" }
      ];
      for(var idx = 0; idx != cardData.length; ++idx) {
        cardData[idx]['idx'] = idx.toString();
        card = ich.elcard(cardData[idx]);       
        var items = document.getElementById("card-list");
        items.innerHTML = items.innerHTML + card;
      }
  });
</script>


## Conclusion

Even after forcing an invalid og:url and rescraping the information usign [facebook URL debugger](https://developers.facebook.com/tools/debug/og/object/) we can still see the **feed dialog** working correctly which means that any issue or error is related to the **Site URL** we previously had to place in our App Settings in the Facebook site. But one thing is sure, if you have everything in place you will harvest the power of sharing custom information with the feed dialog with no problems.


<script type="text/javascript">
  var disqus_identifier = 'the-mothfng-facebook-feed-dialog';
</script>

