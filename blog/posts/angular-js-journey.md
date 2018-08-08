---
title: Angular JS Journey - Part 1
slug: angular-js-journey
date_published: 2014-11-08T04:51:59.416Z
date_updated:   2015-07-24T12:41:31.912Z
tags: AngularJS, HTML, Javascript
---

![Angular Power](https://angularjs.org/img/AngularJS-large.png)

I started learning AngularJS today... again. The main reason is that I discovered that github pages supported AngularJS, so I decided I needed to get mine going.

It is hard trying to juggle with many languajes at the same time, but as with everything, the main ingredient is discipline. With so many distractions lurking around it gets worse. Today I found out there is a new blizzard game coming out, I have to stop reading about videogames. Playing games keeps me centered, not reading about them. 

Thankfully, the book I am using on AngularJS is on my Kindle for PC, [Pro AngularJS](http://www.amazon.com/Pro-AngularJS-Experts-Voice-Development/dp/1430264489/ref=sr_1_1?ie=UTF8&qid=1415416126&sr=8-1&keywords=pro+angularjs), sitting there. I opened and it tells me I got to chapter 2, that's sad.

I crank my OCRemix up, a song comes up, it is [Close Door All Way "Sealed Door" by Star Salzman](https://www.youtube.com/watch?v=7QX9HEz4qog), what an amazing sound.

<iframe width="560" height="315" src="//www.youtube.com/embed/7QX9HEz4qog" frameborder="0" allowfullscreen></iframe>

####Resuming knowledge injection

So... I am using Windows 8 at this moment, I [installed Node JS](http://nodejs.org/). I opened an Administrator Command Prompt and navigated to `C:\Program Files\nodejs` to  install some stuff:

- `npm install connect`
- `npm install -g karma`
- `npm install server-static` 

No, I didn't got this from the book, there were some deprecated issues, and these lines may be deprecated in a few months too. It's fine, don't get detracted. 

Then I created a file named `server.js` inside my nodejs folder with the following content.

```language-javascript
var connect = require('connect'); 
var serveStatic = require('serve-static');
var app = connect(); 
app.use(serveStatic('E:/Claudio/git/angularjs')); 
app.listen(5000);
```

[Thank you stackoverflow](http://stackoverflow.com/questions/23978734/node-connect-issue-object-function-createserver-has-no-method-static)

Then in my `angularjs` folder I placed the following:

```language-bash
angularjs
│    test.html
│    README.md
├─── css
│   │    bootstrap.css
│   │    bootstrap.css.nao
│   │    bootstrap.min.css
│   │    bootstrap-theme.css
│   │    bootstrap-theme.css.map
│   │    bootstrap-theme.min.css
│	
└─── extra
│    │   angular-animate.js
│    │   angular-mock.js
│    │   angular-route.js
│    │   angular-sanitize.js
│    │   angular-touch.js
└─── fonts
│    │   glyphicons-halflings-regular.eot
│    │   glyphicons-halflings-regular.svg
│    │   glyphicons-halflings-regular.ttf
│    │   glyphicons-halflings-regular.woff
└─── js
│    │   angular.js
│    │   bootstrap.js
│    │   bootstrap.min.js
│    │   npm.js
│    │   app.js
```

Those are the resources we'll be using in the tutorial. Remember the purpose is getting to the MEAN stack eventually.

So the first part of the tutorial is getting a dictionary to look like a table on the screen. Since Bootstrap is handling our CSS needs, we are going to need HTML and JS code to achieve this.

So we are going to get into the **MVC** (Model View Controller) Pattern. Which is more an advise than rule, the MVC pattern was documented by human beings who want the best for you. I suggest either abiding by it, or learn something equally adopted, like the MVVM pattern for example. How would you implement the MVVM pattern in AngularJS? I have no idea, first I would need become good at AngularJS before even considering moving anything.

Before starting we need to start the **node** server with the snippet we created. In our command line we type 

```
C:\Program Files\nodejs>node server.js
```

And just like Al Pacino and Johnny Depp say...

> Forget About it

Seriously just leave it running, the purpose of the server is to allow you to open a Web Browser and do the following

```
http://localhost:5000/test.html
```

####Hello World

First... we create the dictionary with the data we want to present in the HTML, this is referred as **the model**. Dictionaries in Javascript are a joy to write, if you don't feel the same, grab your nearest C Compiler and roll the same thing, just for the heck of it.

We put the following definition in the file `app.js`

```language-javascript
var model = {
user: "Trainee",
items: [{ action: "Buy Rice", done: false },
		{ action: "Feed Beasts", done: true },
		{ action: "Get some exercises done (Python)", done: true },
		{ action: "Drink Coffee", done: false }]
};
```

That was fast. A Dictionary and a list of Dictionaries, simple. 

We are going to create a **module** and a **controller**. The Controller will have a variable that  holds the value of our **model**. 

```language-javascript
var todoApp = angular.module("todoApp", []);
todoApp.controller("ToDoCtrl", function($scope) {
  $scope.todo = model;
});
```

This way we can access the dictionary from the HTML markup. To denote data binding in HTML, AngularJS uses double braces `{{ }}`. 

```language-markup
<!DOCTYPE html>
<html ng-app="todoApp"><!--The name of our app-->
<head>
  <title>TO DO List</title>
  <link href="css/bootstrap.css" rel="stylesheet" />
  <link href="css/bootstrap-theme.css" rel="stylesheet" />
</head>
<body ng-controller="ToDoCtrl"> <!-- We bind our controller right here -->
  <div class="page-header">
    <h1> 
      {{todo.user}}'s To Do List <!--Should display Trainee-->
      <span class="label label-default">
        {{todo.items.length}} <!--This is an attribute of our dictionary-->
      </span>
    </h1>
  </div>
  <div class="panel">
    <div class="input-group">
      <input class="form-control"/>
      <span class="input-group-btn">
        <button class="btn btn-default">Add</button> <!--Nothing here just yet-->
      </span>
    </div>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Description</th>
          <th>Done</th>
        </tr>
      </thead>
      <tbody>
        <tr ng-repeat="item in todo.items"> <!--Here we bind our dict items-->
        <!--Similar to a for loop-->
          <td>{{item.action}}</td> 
          <td>{{item.done}}</td> 
        </tr>
      </tbody>
    </table>
  </div>
  <script src="js/angular.js"></script> <!--Here we add our angular-->
  <script src="js/app.js"></script>	<!--Afterwards we add our own code-->
</body>
</html>
```

And it looks pretty neat for such simple stuff.

![Hello World](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415422688/Image_063_e7z13d.png)

**Pro Tip**: Don’t use data bindings to perform complex logic or to manipulate the model; that’s the job of the controller. Freeman, Adam (p. 24)

**Never Forget**: `ng-repeat` is an AngularJS **directive**, you need to learn those... eventually.





