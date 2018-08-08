---
title: Server side ES6 Programming with Webpack
slug: server-side-es6-programming-with-webpack
date_published: 2016-03-25T05:20:53.017Z
date_updated:   2016-03-26T04:57:28.588Z
tags: Webpack, ES6, Babel, ESLint
---

##Prologue

Content Management Systems (CMS) are monoliths that will get out of hand at some point. 

Companies add features to the CMS, but adding more to your sandwich does not improve it. 

Life is about tuning the bacon needed to add rainbows. 

When the sandwich gets too expensive, then comes up a *challenge*: Consume our product and it's free. Soon companies throw everything in a timeless trash room, salvaging the mayo and the lettuce, and then add it to the next CMS. You can find 5.25" diskettes in the trash room. 

[Last year I wrote a demo on Facebook Javascript's SDK.](https://claudiordgz.com/the-mothfng-facebook-feed-dialog/) The load time added withers my soul. I couldn't take it any longer and went into a 7 month soul searching journey in search of forgiveness. 

Shit got serious.

![services-physical-books](https://lh3.googleusercontent.com/gCu4U5nsGXJR7NnLv8ECBANOdQ6sjsvoEP54_eKg6B2IguXWC1a2Ek_4RqSgkFYiSWdUGtfxzNeMgmONAIhvNJtfz_abvodp-9Y0z9d6_YaVK_tGDILkuWsw2bziAMwplVh7bcvqTpxFxNSw3DIkvW53iJBZz3C2S2Ng531UbljbRNwhmmgmnksqpFq43ou3A96Zd4Sw12_Ts9G_IuKBUAQAkMS-J4CU8s7VS4ycHWsA4xmVALdnxjzfAUHoUBiBJVfqr12NlLxfmuIQjEBd2Tj_ESbinBkGxLGoflcwvCsnSUTxbXGhbEx-ohu-hlgFcTQs-nDkqdpWtmhnBa3KmmBFZfM7oY-Ld-g27w8bpvYSU3WnbKA--wsuCftOuN4XQasEm80LqSB5jK1D0sHdrtATEe-YycxId_4GxBU4Brn1vIu8O3nSNms52fzSiqGS_Q-EXSglCPPSHqMBQesbHeJzR_UMQuiNRi5JCgajRw9BYJDgWrPWRiVQTeJ_BiQ5oby2PFhHVGQSpxPmGpnCDkNueUAT0XLMDWonO8M-7fnK6rQBJwnxEroIty6xN_QNDigD=w1741-h979-no)

Very serious.

![google-books](https://res.cloudinary.com/www-claudiordgz-com/image/upload/v1458879178/SC_20160325002-min_zhojhd.png)

Figuring these problems for one's blog is no different in a big company. The requirements are the same, but one man can't spend thousands of man hours in project maintenance. *It's a resources issue* said the positivist fool.

> Ignorantia legis neminem excusat.

##Go Serverless

> [AWS Lambda] Functions are executed in containers . Containers are a server virtualization method where the kernel of the OS implements multiple isolated environments. ... there are still physical servers executing the code, but since you don’t need to spend time managing them, it is common to define this kind of approach as serverless. **Danilo Poccia**, *AWS Lambda in Action*

O'Reilly's cover choice for *Building Microservices* is appropriate. Learning one language in life means constraining yourself in a silver cage. Honey slips from your reach. 

Google just announced their Cloud Functions API, which is their competitor product against AWS Lambda. I requested access to it to build another functionality. 

Now we are able to use run a chunk of software in AWS, another in Google, hold some data in RedisLab, another service in DigitalOcean, more data in Cloudinary. Real honey is finally within my reach. One person, all the cloud, all the power. The only cage now is your own.  

##Using ES6 and RXJS in AWS Node JS

To use ES6 in a Lambda, code needs to be converted from ES6 into something Node can consume. We will be using Babel for that.

We'll also be needing ESLint, Unit Tests, and Debugging. 

There is no need to reinvent the wheel setting up Webpack, [James R. Nelson made an amazing article that walks through Babel's dependencies](http://jamesknelson.com/using-es6-in-the-browser-with-babel-6-and-webpack/). 

Everything related to React can go since this is a backend application. To do that we `target: 'node'` to stop it from bundling any `node_modules`, otherwise it tries to pack specific system dependencies. 

It all boils down to four files: 

 - `.eslintrc` configuration 
 - Cherry picked dependencies for the `package.json` 
 - `webpack.config.js` that handles the build process. 
 - `.babelrc` configuration

[`eslintrc`, `webpack.config.js` and `package.json` files are here.](https://gist.github.com/claudiordgz/b2f923d0f6ca3628580b)

###Debugging in WebsStorm

`webpack.config.js` generates a source maps and bundles them. This allows someone to place breakpoints in his code, and debug those by Running or Debugging the generated `bundle.js`. When I saw Webstorm stopping on my breakpoints... honey.

###ESLint

ESlint happens automatically everytime you run webpack like Dark Magic. The `.eslintrc` provides the required rules for linting. 

###Testing

Refactoring will protect your future. 

In the free weight zone, John feels he's killing it. He does that thing for his biceps, grunting with rep. Then works his chest and then he emulates the lunges some girl is doing, and finally something that makes his shoulders tight. He is killing it so hard that everyone is looking at him as if He were a rare animal. John will never see the light of progress.

Refactoring is the task with the goal to get the code in shape. To do this it requires specific tasks and this is were abstraction and separation of concerns come in. People say *document changes*, but planning on how to pay a debt later in life without a context is a fool's game. 

Code has a very complex physiology, and only the people in contact with it know it. What eyes don't see, the heart can't feel. This is were tests come in. They are the measuring tape of your code, they track how those legs are growing after such unforgiving squatting routine. 

The most valuable measure from refactoring success is code complexity and growth rate. Code depends on the solution which is then broken down into tiny pieces which all have relative but different complexity levels which means measuring code complexity evolves into a general relativity problem.

Stick with 'Works as it worked before just 5k less lines of code' and everything will be fine. 

Nobody cares how you get to the gym, they care what you did to get the results you have. To get there you do:

```
"scripts": {
    "test": "./node_modules/.bin/babel-tape-runner src/test/**/*.js"
  }
```

When it comes to tests... just do it.

###Test don't run

The `.babelrc` configuration file is the glue that holds together both webpack and babel-tape-runner. 

Babel provides some features in the ES6 and ES7 spec, but not all of them, and it doesn't do it all by default. Such powerful magic is not yet available for mere mortals like us. Naturally, we cheat using presets provided by Babel.

There are already all the presets I require in my `package.json`.

```
{
  "plugins": ["transform-runtime"],
  "presets": ["es2015", "stage-0"]
}
```
###Files

<script src="https://gist.github.com/claudiordgz/b2f923d0f6ca3628580b.js"></script>
