---
title: Pulling a User Timeline from Twitter ES6 and RXJS Style
slug: pulling-a-user-timeline-from-twitter-es6-and-rxjs-style
date_published: 2016-03-27T03:45:31.962Z
date_updated:   2016-03-28T19:10:43.983Z
tags: rxjs, ES6, aws-lambda
---

##Prologue

In WordPress there are tons of plugins for integrating Twitter. 

WordPress is a furnished apartment, top choice when you just want a place to live. 

For those out there that don't need a furnished place. Those who feel the need to tear down walls and build a new bathroom or add a fireplace to their backyards. Or maybe their own home gym, because the Community Gym is swarming with 16 year old dudes who make a mess of the dumbbells.

Those with the creative itch. 

Scratch it. 

##Go Serverless

Integrating Twitter **needs** to happen in the server since there are private credentials. Managing servers is a full time job.

[Fortunately nowadays there are technologies that allow you to do your extra features without managing servers](http://www.forbes.com/sites/janakirammsv/2016/03/22/five-serverless-computing-frameworks-to-watch-out-for/#2e4dc559d778). To do that I use the wonderful [Serverless Framework](http://docs.serverless.com/) for AWS Lambda, and [you can ask to be white listed to test drive Google Cloud Functions API](https://cloud.google.com/functions/docs).

There is much to be said about Serverless.

##Twitter Process

The Twitter Process is divided in two steps:

 1. Get permission from Twitter, according to them it's never going to expire, this may change in two or three years.
 2. Ask for your timeline

![twitter-process](https://res.cloudinary.com/www-claudiordgz-com/image/upload/v1459035212/appauth_0_ghc7tp.png)

###Getting your permission

You're going to need a Consumer Key and Consumer Secret. To do that it's necessary to [register an app in here](https://dev.twitter.com/apps). 

```
export function retrieveBearerTokenObservable(consumerData) {
  let key = encodeURIComponent(consumerData.CONSUMER_KEY);
  let secret = encodeURIComponent(consumerData.CONSUMER_SECRET);
  let credentials = new Buffer(String(key + ':' + secret)).toString('base64');
  let settings = {
    url: 'https://api.twitter.com/oauth2/token',
    method: 'POST',
    headers: {
      'Content-type': 'application/x-www-form-urlencoded;charset=UTF-8',
      Authorization: 'Basic ' + credentials
    },
    body: 'grant_type=client_credentials'
  };
  return Rx.Observable.fromCallback(request)(settings)
    // [null, response, body]
    .map(x => {
      return JSON.parse(x[2]);
    });
}
```

That code receives an object with the following:

```
{
  CONSUMER_KEY: "XXXXXXXXXXXXXXXXXXXXXXXXX",
  CONSUMER_SECRET: "xxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
}
```

And returns another object with the Bearer Token.

```
{
  token_type: "bearer",
  access_token: "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA%2FAAAAAAAAAAAAAAAAAAAA%3DAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
}
```

###Storing the Token

Twitter says 'cache your token'. I decided to use Redis Labs for this, either Redis or Memcache would work.

This could be as simple as:

```
let redisClient = new Redis(redisConfig);
let updatedPayload = updateCallback(payload);
redisClient.client.set(redisKey, updatedPayload, Redis.print);
redisClient.client.quit();
```

Cache your Token.

###Getting the User's Timeline

```
export function userTimelineObservable(user, bearerToken, count) {
  let url = 'https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=' + user + '&count=' + count;
  let settings = {
    url: url,
    method: 'GET',
    headers: {
      Authorization: 'Bearer ' + bearerToken
    }
  };
  let observable = Rx.Observable.fromCallback(request);
  return Rx.Observable.defer(() => observable(settings))
    .map(x => {
      try {
        return JSON.parse(x[2]);
      } catch (error) {
        throw new InvalidTwitterPayload(JSON.stringify({
          user: user,
          bearerToken: bearerToken,
          count: count
        }));
      }
    });
}
```

This observable returns the wonderful array with all of its fields. 

###Using the observables

```
let bearerToken$ = retrieveBearerTokenObservable(resources.twitterConfiguration);
return bearerToken$
   .switchMap(cachedData => userTimelineObservable(cachedData.user, cachedData.bearerToken, 100));
```

That says the following: *Get the Bearer Token from Twitter, and then get the User Timeline with that information*. 

Some other things we need:
 
 1. Retrieve permission from a Cache.
   - Check that for errors.
     - Log
   - If there were errors then get the permission for Twitter.
      - Check that too for errors.
         - Log
      - Re cache that thing. 
         - Log
 2. Get User Timeline.
   - Log
   - Check that too for errors.
      - Log
 3. Return or Save timeline somewhere. (i.e. Firebase)
   - Log
 4. Retrieve from UI

The logs are necessary for error backtracking using Amazon CloudWatch. 

Whenever you need some extra functionality... do not put it in the same lambda. Error handling bloats any code and it is absolutely necessary. 



