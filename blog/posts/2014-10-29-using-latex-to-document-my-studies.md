---
title: Using LaTeX to document my Studies - Part 1
slug: using-latex-to-document-my-studies
date_published: 2014-10-29T06:06:59.400Z
date_updated:   2015-07-24T13:11:08.694Z
tags: latex, tex4ht
---

My memory has never been exceptional. I find the only way to get something through my thick skull is by repetition, repetition, and more repetition. Even though I read a lot of subjects, reading does not give me the amount of productivity I really need.

It is important to take advantage of all the technology possible to keep improving. 

###Production process

It is really important to keep the money on the most impotant thing... **Code**. In the end it is implementing the solution what matters. The problem is wasting too much time documenting all the work done. Problem is this documentation is also important for the production process. 

####Enter LaTeX 

I've been through this before, generating an static HTML website using Tex4HT. Thanks to [Michal Hoftich](http://tex.stackexchange.com/users/2891/michal-h21) I was able to craft slowly a configuration file to allow a direct conversion from LaTeX into HTML. 

And it is not pretty.

And it is not finished.

For example in this excerpt I add the Cascade Styling Sheets

```language-latex
\Configure{@HEAD}{\HCode{<link
	 rel="stylesheet" type="text/css"
	 href="css/bootstrap.min.css" />\Hnewline}}
\Configure{@HEAD}{\HCode{<link
	 rel="stylesheet" type="text/css"
	 href="css/bootstrap-theme.min.css" />\Hnewline}}
\Configure{@HEAD}{\HCode{<link
	 rel="stylesheet" type="text/css"
	 href="css/blog.css" />\Hnewline}}
\Css { .cmcsc-10x-x-248{font-size:90\%;} } 
% Configuring QuattrocentoSans and Droid Sans font
\Css { @font-face { font-family: DroidSansMono; src: url("fonts/DroidSansMono.ttf") format('truetype'); } }
\Css { @font-face { font-family: QuattrocentoSans; src: url("fonts/QuattrocentoSans-Regular.ttf") format('truetype'); } }
\Css { @font-face { font-family: QuattrocentoSans Bold; src: url("fonts/QuattrocentoSans-Bold.ttf") format('truetype'); } }
\Css { @font-face { font-family: QuattrocentoSans Italic; src: url("fonts/QuattrocentoSans-Italic.ttf") format('truetype'); } }
\Css { @font-face { font-family: QuattrocentoSans Bold Italic; src: url("fonts/QuattrocentoSans-BoldItalic.ttf") format('truetype'); } }
% Add Droid Sans Mono to everything
\Css { * { font-size: 102\%; font-family: 'DroidSansMono'; } }

\Css { .tableofcontents {} } 
\Css { .container { float:left; top:20px; padding-left:15px; width:65\%; height:1024px; } }
\Css { table { width:100\% !important; } }
\Css { div.tabular { width:inherit !important; } }
\Css { td p img { height:auto !important; width:120px !important; } }
\Css { img.center { height:inherit; display: block; margin-left: auto; margin-right: auto; } }
\Css { .likechapterHead { display:none !important; } }
\Css { span.titlemark { display:none !important; } }
\Css { .navbar-bright { background-color:\#3C54A6; color:\#fff; }}
\Css { .navbar-bright a, \#masthead a, \#masthead .lead {  color:\#aaaacc; }}
\Css { .navbar-bright li > a:hover { background-color:\#000033; }}
\Css { @media (min-width: 979px) { \#sidebar.affix-top { position: static; margin-top:0px; width:310px; }}}
\Css { \#sidebar.affix { position: fixed; top:65px; width:310px; } }
\Css { \#sidebar li.active { border:0 \#eee solid; border-right-width:4px; }}
\Configure{TITLE+}{Claudiordgz Blog Series}
```

Andin the following we clean the paths to the images we add in LaTeX.

```language-latex
\Configure{graphics*}  
	 {pdf}  
	 {\Needs{"convert \csname Gin@base\endcsname.pdf  
						   \csname Gin@base\endcsname.png"}%  
	  \Picture[pict]{\csname Gin@base\endcsname.png}%  
	  \special{t4ht+@File: \csname Gin@base\endcsname.png}
	 }  
```

And we format the structure using **Bootstrap**

```language-latex
\Configure{tableofcontents}
{\IgnorePar\EndP\HCode{<div class="container-fluid"><div class="row"><div class="col-sm-3" id="leftCol"><div class="nav nav-stacked"  id="sidebar"><a href="http://www.claudiordgz.com/"><div class="boxed"><img src="logo/logo_black.png" alt="pict" class="center" border="0" /></div></a><h4 class="likesectionHead">Contents</h4><div class="tableofcontents"\csname a:LRdir\endcsname>}\IgnorePar}
{\ifTag{tex4ht-body}{\HCode{<br />}\Link{tex4ht-body}{}Home\EndLink}{}}
{\IgnorePar\EndP\HCode{</div></div></div><div class="col-sm-8">}\ShowPar}
{\HCode{<br />}}   {}
```

And of course we redefine the environments to use them comfortably in LaTeX.

```language-latex
% Translate \textbf, \textit and \texttt directives into <b>, <em> and <code>
\Configure{textbf}{\ifvmode\ShowPar\fi\HCode{<b>}}{\HCode{</b>}}
\Configure{textit}{\ifvmode\ShowPar\fi\HCode{<i>}}{\HCode{</i>}}
\Configure{texttt}{\ifvmode\ShowPar\fi\HCode{<code>}}{\HCode{</code>}}
% Translate verbatim and lstlisting blocks into <pre> elements
\ConfigureEnv{verbatim}{\HCode{<pre class="prettyprint">}}{\HCode{</pre>}}{}{}
\ConfigureEnv{lstlisting}{\HCode{<pre class="prettyprint">}}{\HCode{</pre>}}{}{}
 
% Do not set `indent`/`noindent` classes on paragraphs
\Configure{HtmlPar}
{\EndP\Tg<p>}
{\EndP\Tg<p>}
{\HCode{</p>\Hnewline}}
{\HCode{</p>\Hnewline}}
```

And we even can add the JavaScript files easily. We add our code to the blog.js.

```language-latex
\Configure{BODY}{\HCode{<body>}}{\HCode{
		</div>\Hnewline
		</div>\Hnewline
    </div>\Hnewline
		<script type="text/javascript"\Hnewline src="https://c328740.ssl.cf1.rackcdn.com/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML"\Hnewline></script>\Hnewline
		<script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js"></script>\Hnewline
    <script src="js/jquery-1.11.1.min.js" type="text/javascript"/>\Hnewline
    <script src="js/bootstrap.min.js" type="text/javascript"/>\Hnewline
    <script src="script/blog.js" type="text/javascript"/>\Hnewline</body>}
    }
\EndPreamble
```

####Advantages

 - Mathjax JS integration
 - JQuery & Bootstrap and any other library
 - LateX power!
 - Functionality is fantastic, and extending is easy breezy.
 
####Disadvantages
 
 - If you don't know LaTeX I suggest something else for know, moving things in the configuration requires time and dedication.
 - You still need to know HTML5, at least be able to make changes
 
#The end result
 
 [You can check the website generated from LaTeX in here](http://claudiordgz.github.io/GoodrichTamassiaGoldwasser/)
 
##Or check any code related to the WebSite in the repository GoodrichTamassiaGoldwasser

[![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/GoodrichTamassiaGoldwasser/tree/gh-pages)

