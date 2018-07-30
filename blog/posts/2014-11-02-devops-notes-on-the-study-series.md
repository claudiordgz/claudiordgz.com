---
title: "DevOps - Study Series: Collapsable Code after Compiling"
slug: devops-notes-on-the-study-series
date_published: 2014-11-02T16:30:46.712Z
date_updated:   2015-08-20T03:58:32.610Z
tags: latex, tex4ht
---

Crafting the perfect configuration for your latex TeX4HT is a very tricky process. You become a surgeon, toying with every character and environment. Debugging is a mess, because you need a website first, and a configuration later. Plus, the configuration Hooks and Manuals are hard to find. I have not delved in the code of Tex4HT, I don't there is a way back from going there. I am very thankful for the help of [Michal Hoftich](https://github.com/michal-h21) in the [TeX Stackenchange](http://tex.stackexchange.com/). 

The first is securing that you compile you TeX main file using your configuration as follows:

```language-bash
htlatex MyTexFile.tex MyConfig.cfg
```

This is as easy as it gets, try to place the rest of the things you want inside the configuration. For example, I want a css less configuration, and I don't want those crappy font thingies that latex puts in my html, so I use `-css` and `\NoFonts` respectively. 


<!-- BlopTop -->
<div class="center-unknown">
    <div class="el">
        <ins class="adsbygoogle adslot_1"
             style="display:inline-block;margin: 0 auto 0 auto; width: 90%;"
             data-ad-client="ca-pub-1525337072631150"
             data-ad-slot="3858661425"
             data-ad-format="auto"></ins>
    </div>
</div>
    

###On Google Code Prettify

Google Code Prettify works good, but the generated code adds extra spans, spaces, and breaks, making the thing take way too much code. So I though it would be amazing to be able to collapse the code so that it does not get in the way.

LaTeX configuration to the rescue.

```language-latex
\ConfigureEnv{lstlisting}{\HCode{
<div class="panel-group" id="accordion\CurSecHaddr">\Hnewline
  <div class="panel panel-default">\Hnewline
    <a class="accordion-toggle" data-toggle="collapse" data-parent="\#accordion\CurSecHaddr" href="\#collapse\CurSecHaddr">\Hnewline
     <div class="panel-heading">\Hnewline
      <h4 class="panel-title">\Hnewline
					<FONT style="font-size:15px" COLOR="\#FE2E2E">View Code</FONT> <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span>\Hnewline
					</h4>\Hnewline
    </div>\Hnewline
        </a>\Hnewline
    <div id="collapse\CurSecHaddr" class="panel-collapse collapse">\Hnewline
      <div class="panel-body">\Hnewline
				<pre class="prettyprint"><p>\Hnewline}}
{\HCode{</p></pre>\Hnewline
      </div>\Hnewline
    </div>\Hnewline
  </div>\Hnewline
</div>\Hnewline}}{}{}
```
And some JavaScript for that Chevron to work properly.

```language-javascript
/* swap open/close side menu icons */
$('[data-toggle=collapse]').click(function(){
  	// toggle icon
  	$(this).find("i").toggleClass("glyphicon-chevron-up glyphicon-chevron-down");
});
```

So now I have collapsable code! 

[![Collapsed code](http://i.stack.imgur.com/86dXT.png)](claudiordgz.github.io/GoodrichTamassiaGoldwasser)

[![Expanded code](http://i.stack.imgur.com/MeguA.png)](claudiordgz.github.io/GoodrichTamassiaGoldwasser)


##Or check any code related to the WebSite in the repository GoodrichTamassiaGoldwasser

[![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/GoodrichTamassiaGoldwasser/tree/gh-pages)
