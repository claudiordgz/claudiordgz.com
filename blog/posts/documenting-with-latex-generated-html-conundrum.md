---
title: Documenting with LaTeX - Generated HTML Conundrum
slug: documenting-with-latex-generated-html-conundrum
date_published: 2014-11-27T16:18:43.185Z
date_updated:   2015-07-24T12:10:57.189Z
tags: C++, latex, Python, study diary, BeautifulSoup
---

This is part of the Study Series, a project in which we use LaTeX to generate a pdf and a website to document our studies. To generate it we use HTLaTeX, a process that runs TeX4HT and some other things. To give the generated website the look we want we use a custom configuration file. The configuration file overrides certain defaults from Tex4HT and adds our process.

It gets rough when you need to access specific classes and replace the generated tags.

#The uncomfortable truth from using Tex4HT

There is a tool called Tidy for HTML, basically it grabs your HTML file and makes it pretty again. I have a plugin for my Notepad++ that does this process on my text file. And I found it quite disturbing that it made a mess when trying to Tidy the HTML code behind of the LaTeX generated HTML.

<div class="panel-group" id="accordion">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Click here to see a snippet from the generated HTML</a>
            </h4>
        </div>
        <div id="collapseOne" class="panel-collapse collapse">
            <div class="panel-body">
```language-markup
<p>   <a 
 id="sssec:ex1_1"></a>  <table id="TBL-3" class="tabular" 
cellspacing="0" cellpadding="0"  
><colgroup id="TBL-3-1g"><col 
id="TBL-3-1" /><col 
id="TBL-3-2" /></colgroup><tr  
 style="vertical-align:baseline;" id="TBL-3-1-"><td  style="text-align:left;" id="TBL-3-1-1"  
class="td11">
 <h5 class="subsubsectionHead"><a 
 id="x1-80001"></a><b>R-1.1</b></h5>
 <p>                                                                          </p> 
</td><td  style="text-align:right; white-space:nowrap;" id="TBL-3-1-2"  
class="td11"> <a 
href="#chap:PythonPrimer">Go to Top</a>  </td>
 </tr><tr  
 style="vertical-align:baseline;" id="TBL-3-2-"><td  style="text-align:left;" id="TBL-3-2-1"  
class="td11"> <p>                                                                   </p> 
</td> </tr></table>
<p>   Write a short Python function, <code>is_multiple(n, m)</code>, that takes two integer values and returns <code>True</code> if
<!--l. 3--><math 
 xmlns="http://www.w3.org/1998/Math/MathML"  
display="inline" ><mi 
>n</mi></math> is a multiple
of <!--l. 3--><math 
 xmlns="http://www.w3.org/1998/Math/MathML"  
display="inline" ><mi 
>m</mi></math>, that is,
<!--l. 3--><math 
 xmlns="http://www.w3.org/1998/Math/MathML"  
display="inline" ><mi 
>n</mi> <mo 
class="MathClass-rel">=</mo> <mi 
>m</mi><mi 
>i</mi></math> for some
integer <!--l. 3--><math 
 xmlns="http://www.w3.org/1998/Math/MathML"  
display="inline" ><mi 
>i</mi></math>,
and <code>False</code> otherwise.
   </p> 
<div 
  id="accordion2" class="panel-group"  ><div class="panel panel-default"> 
 <a 
href="#collapse2" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" > 
<div class="panel-heading"> 
<h4 class="panel-title"> 
<FONT style="font-size:15px" COLOR="#FE2E2E">View Code</FONT> <span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span></h4> 
</div> 
</a> 
<div id="collapse2" class="panel-collapse collapse"> 
<div class="panel-body"><pre class="prettyprint"> 
<br /> <div class="caption" 
><span class="id">: </span><span  
class="content">Exercise R-1.1</span></div><!--tex4ht:label?: x1-80001 --><!--l. 5--><pre class="listings">&#x00A0;<br /><span class="label"><a 
 id="x1-8001r1"></a></span><!--l. 1--><span class="listings-nested">&#8221;&#8221;</span><!--l. 1--><span class="listings-nested">&#8221;Write&#x00A0;a&#x00A0;short&#x00A0;Python&#x00A0;function,&#x00A0;is_multiple(n,&#x00A0;m),&#x00A0;that&#x00A0;takes&#x00A0;two&#x00A0;integer&#x00A0;<br /><span class="label"><a 
 id="x1-8002r2"></a></span>values&#x00A0;and&#x00A0;returns&#x00A0;True&#x00A0;if&#x00A0;n&#x00A0;is&#x00A0;a&#x00A0;multiple&#x00A0;of&#x00A0;m,&#x00A0;that&#x00A0;is,&#x00A0;n&#x00A0;=&#x00A0;mi&#x00A0;for&#x00A0;some&#x00A0;<br /><span class="label"><a 
 id="x1-8003r3"></a></span>integer&#x00A0;i,&#x00A0;and&#x00A0;False&#x00A0;otherwise.&#x00A0;<br /><span class="label"><a 
 id="x1-8004r4"></a></span>&#x00A0;<br /><span class="label"><a 
 id="x1-8005r5"></a></span>&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(50,3)&#x00A0;<br /><span class="label"><a 
 id="x1-8006r6"></a></span>False&#x00A0;<br /><span class="label"><a 
 id="x1-8007r7"></a></span>&#8221;</span><!--l. 7--><span class="listings-nested">&#8221;&#8221;</span>&#x00A0;<br /><span class="label"><a 
 id="x1-8008r8"></a></span>&#x00A0;<br /><span class="label"><a 
 id="x1-8009r9"></a></span>def&#x00A0;is_multiple(n,&#x00A0;m):&#x00A0;<br /><span class="label"><a 
 id="x1-8010r10"></a></span><!--l. 10--><span class="listings-nested">&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#8221;&#8221;</span><!--l. 10--><span class="listings-nested">&#8221;Return&#x00A0;True&#x00A0;if&#x00A0;n&#x00A0;is&#x00A0;multiple&#x00A0;of&#x00A0;m&#x00A0;such&#x00A0;that&#x00A0;n&#x00A0;=&#x00A0;mi&#x00A0;<br /><span class="label"><a 
 id="x1-8011r11"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;Else&#x00A0;returns&#x00A0;False&#x00A0;<br /><span class="label"><a 
 id="x1-8012r12"></a></span>&#x00A0;<br /><span class="label"><a 
 id="x1-8013r13"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(50,3)&#x00A0;<br /><span class="label"><a 
 id="x1-8014r14"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;False&#x00A0;<br /><span class="label"><a 
 id="x1-8015r15"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(60,3)&#x00A0;<br /><span class="label"><a 
 id="x1-8016r16"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;True&#x00A0;<br /><span class="label"><a 
 id="x1-8017r17"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(70,3)&#x00A0;<br /><span class="label"><a 
 id="x1-8018r18"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;False&#x00A0;<br /><span class="label"><a 
 id="x1-8019r19"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(-50,2)&#x00A0;<br /><span class="label"><a 
 id="x1-8020r20"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;True&#x00A0;<br /><span class="label"><a 
 id="x1-8021r21"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(-60,2)&#x00A0;<br /><span class="label"><a 
 id="x1-8022r22"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;True&#x00A0;<br /><span class="label"><a 
 id="x1-8023r23"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(&#8221;</span>test<!--l. 23--><span class="listings-nested">&#8221;,10)&#x00A0;<br /><span class="label"><a 
 id="x1-8024r24"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;Numbers&#x00A0;must&#x00A0;be&#x00A0;Integer&#x00A0;values&#x00A0;<br /><span class="label"><a 
 id="x1-8025r25"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x003E;&#x003E;&#x003E;&#x00A0;is_multiple(-60,&#8221;</span>test<!--l. 25--><span class="listings-nested">&#8221;)&#x00A0;<br /><span class="label"><a 
 id="x1-8026r26"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;Numbers&#x00A0;must&#x00A0;be&#x00A0;Integer&#x00A0;values&#x00A0;<br /><span class="label"><a 
 id="x1-8027r27"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#8221;</span><!--l. 27--><span class="listings-nested">&#8221;&#8221;</span>&#x00A0;<br /><span class="label"><a 
 id="x1-8028r28"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;try:&#x00A0;<br /><span class="label"><a 
 id="x1-8029r29"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;return&#x00A0;True&#x00A0;if&#x00A0;(int(n)&#x00A0;%&#x00A0;int(m)&#x00A0;==&#x00A0;0)&#x00A0;else&#x00A0;False&#x00A0;<br /><span class="label"><a 
 id="x1-8030r30"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;except&#x00A0;ValueError:&#x00A0;<br /><span class="label"><a 
 id="x1-8031r31"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;&#x00A0;print(<!--l. 31--><span class="listings-nested">&#8221;Numbers&#x00A0;must&#x00A0;be&#x00A0;Integer&#x00A0;values&#8221;</span>)
   &#x00A0;<br /><span class="label"><a 
 id="x1-8032r32"></a></span></pre>
   </pre> </div> 
</div> 
</div> 
 </div> <a 
 id="sssec:ex1_2"></a>  <table id="TBL-6" class="tabular" 
cellspacing="0" cellpadding="0"  
><colgroup id="TBL-6-1g"><col 
id="TBL-6-1" /><col 
id="TBL-6-2" /></colgroup><tr  
 style="vertical-align:baseline;" id="TBL-6-1-"><td  style="text-align:left;" id="TBL-6-1-1"  
class="td11">
 <h5 class="subsubsectionHead"><a 
 id="x1-110001"></a><b>R-1.2</b></h5>
 <p>                                                                          </p> 
</td><td  style="text-align:right; white-space:nowrap;" id="TBL-6-1-2"  
class="td11"> <a 
href="#chap:PythonPrimer">Go to Top</a>  </td> 
</tr><tr  
 style="vertical-align:baseline;" id="TBL-6-2-"><td  style="text-align:left;" id="TBL-6-2-1"  
class="td11"> <p>                                                                   </p> 
</td> </tr></table>
```
             </div>
        </div>
    </div>
</div>

As you can see, the code generated is pretty rough on the eyes and on the mind. We wont adding any features directly to the HTML, but this does not mean it is not a problem. Thing is, this makes it excessively hard to debug the website. Even with the powerful tools that the browsers give us it is not easy to mess around in a big swamp of code. 

###The LatexCleaner script

I developed a simple script to add extra functionality I needed directly to the HTML. These features where too much muscle to perform in the configuration of TeX4HT. A script of a few hundred lines can perform the same muscle without having to add thousand of lines of functionality to LaTeX.

###Evolution of LatexCleaner into StudySeries Bootstrapify

I decided to begin a project to add all the functionality to make HTML Tidy work. This project will work in the following day. 

<p align="center">
<img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1417108873/Image_081_yg7jeo.png" alt="BootstrapifyProcess"></img>
</p>

The bigger the HTML code then the bigger the numeber of errors. So far for one chapter here is the output for Tidy2.

```language-bash
line 74 column 1 - Warning: missing &lt;/span&gt; before &lt;a&gt;
line 75 column 48 - Warning: discarding unexpected &lt;/span&gt;
line 72 column 5 - Warning: missing &lt;/a&gt;
line 131 column 1 - Warning: missing &lt;/span&gt; before &lt;a&gt;
line 132 column 64 - Warning: discarding unexpected &lt;/span&gt;
line 129 column 5 - Warning: missing &lt;/a&gt;
line 180 column 25 - Warning: missing &lt;/pre&gt; before &lt;div&gt;
line 183 column 35 - Warning: inserting implicit &lt;pre&gt;
line 183 column 35 - Warning: missing &lt;/pre&gt; before &lt;pre&gt;
line 188 column 28 - Warning: inserting implicit &lt;pre&gt;
line 201 column 13 - Error: &lt;math&gt; is not recognized!
line 201 column 13 - Warning: discarding unexpected &lt;math&gt;
line 203 column 19 - Error: &lt;mn&gt; is not recognized!
line 203 column 19 - Warning: discarding unexpected &lt;mn&gt;
line 203 column 24 - Warning: discarding unexpected &lt;/mn&gt;
line 203 column 29 - Error: &lt;mo&gt; is not recognized!
line 203 column 29 - Warning: discarding unexpected &lt;mo&gt;
line 204 column 25 - Warning: discarding unexpected &lt;/mo&gt;
line 204 column 30 - Error: &lt;mn&gt; is not recognized!
line 204 column 30 - Warning: discarding unexpected &lt;mn&gt;
line 204 column 35 - Warning: discarding unexpected &lt;/mn&gt;
line 204 column 40 - Warning: discarding unexpected &lt;/math&gt;
line 205 column 13 - Error: &lt;math&gt; is not recognized!
line 205 column 13 - Warning: discarding unexpected &lt;math&gt;
line 207 column 20 - Error: &lt;mo&gt; is not recognized!
1045 warnings, 410 errors were found! Not all warnings/errors were shown.

This document has errors that must be fixed before
using HTML Tidy to generate a tidied up version.
```

As you can see there is much to be done. This is why the StudySeries Bootstrapify project is so important. First we will convert the previous list of errors to actions and then we will clean up the HTML, then we run Tidy2 again and now we will have a nice clean HTML code. 

###Adding a configuration to Tidy2 to suppress the errors

Errors in tidy according to the output are:

```language-bash
line 201 column 13 - Error: &lt;math&gt; is not recognized!
line 203 column 19 - Error: &lt;mn&gt; is not recognized!
line 203 column 29 - Error: &lt;mo&gt; is not recognized!
line 204 column 30 - Error: &lt;mn&gt; is not recognized!
line 205 column 13 - Error: &lt;math&gt; is not recognized!
line 207 column 20 - Error: &lt;mo&gt; is not recognized!
```

So what we do now is to use a configuration file for tidy.

```language-bash
new-blocklevel-tags: math, mn, mo, mi, mrow
```

Afterwards we proceed to run Tidy2. 

`..\tools\tidy2\tidy.exe -config tidy_config.txt -o index.html file.html`

> But this will not indent the HTML

To indent we extend our config file.

```language-bash
new-blocklevel-tags: math, mn, mo, mi, mrow #Our previous line
indent-spaces: 4
tab-size: 4
```

###Results

<div class="panel-group" id="accordionTwo">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordionTwo" href="#collapseTwo">First the code - Click to expand</a>
            </h4>
        </div>
        <div id="collapseTwo" class="panel-collapse collapse">
            <div class="panel-body">
```language-markup
<div id="accordion1" class="panel-group">
    <div class="panel panel-default">
        <a href="#collapse1" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1">
        <div class="panel-heading">
            <h4 class="panel-title">
                <font style="font-size:15px" color="#FE2E2E">View Code</font>
            </h4>
        </div></a>
        <div id="collapse1" class="panel-collapse collapse">
            <div class="panel-body">
                <pre class="prettyprint">

<br> 
</pre>
                <div class="caption">
                    <span class="id">:</span> <span class="content">DoctestMain</span>
                </div>
                <pre>
<!--tex4ht:label?: x1-40001 --><!--l. 9-->
</pre>
                <pre class="listings">
&#x00A0;<br><span class="label"><a id="x1-4001r1"></a></span>if&#x00A0;__name__&#x00A0;==&#x00A0;<!--l. 10--><span class=
"listings-nested">&#8221;__main__&#8221;</span>:&#x00A0;<br><span class="label"><a id=
"x1-4002r2"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;import&#x00A0;doctest&#x00A0;<br><span class="label"><a id=
"x1-4003r3"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;doctest.testmod()
&#x00A0;<br><span class="label"><a id="x1-4004r4"></a></span>
</pre>
                <pre>

</pre>
            </div>
        </div>
    </div>
</div>
```
             </div>
        </div>
    </div>
</div>

> The code is way prettier

###The uncomfortable truth

By Running Tidy2, we are **fixing** our HTML code, which is quite not really what we want.

![Comparison1](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1417231713/TocAfterTidy2_mwtrzb.png)

We lost one functionality there, because Tidy2 decided the glyph was extra.

![Comparison2](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1417231713/CodeAfterTidy2_hxzecr.png)

Those breaks in the code is Tidy2 removing excess `br` elements, I understand, there is a complete excess of those things generated by Tex4HT... thing is, it looks better with them than without them.

Tidy removes crucial elements of the HTML to match tags with another, and removes elements it doesn't deem fit. So we extend to configuration to **try** to prevent this.

<div class="panel-group" id="accordionThree">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordionThree" href="#collapseThree">The Bazooka of configurations - Click to expand</a>
            </h4>
        </div>
        <div id="collapseThree" class="panel-collapse collapse">
            <div class="panel-body">
```language-bash
new-blocklevel-tags: math, mn, mo, mi, mrow
doctype: omit
drop-empty-paras: no
fix-backslash: no
fix-bad-comments: no
fix-uri:no
hide-endtags: yes   #?
#input-xml: yes     #?
join-styles: no
literal-attributes: yes
lower-literals: no
merge-divs: no
merge-spans: no
output-html: yes
preserve-entities: yes
quote-ampersand: no
quote-nbsp: no
show-body-only: no
anchor-as-name: no

#Diagnostics Options Reference
show-errors: 0
show-warnings: 0

#Pretty Print Options Reference
break-before-br: yes
indent: yes
indent-attributes: no   #default
indent-spaces: 4
tab-size: 4
wrap: 132
wrap-asp: no
wrap-jste: no
wrap-php: no
wrap-sections: no

#Character Encoding Options Reference
char-encoding: utf8

#Miscellaneous Options Reference
force-output: yes
quiet: yes
tidy-mark: no
```
             </div>
        </div>
    </div>
</div>

> The results are the same

So we take a few minutes to think as follows:

![Cry](http://i1.kym-cdn.com/entries/icons/original/000/012/073/7686178464_fdc8ea66c7.jpg)

###Moving on

So Tidy2 was a big fiasco, no problem, onwwards and forwards 'til you leave hell. 

We test out a [webservice called PrettyDiff](http://prettydiff.com/) and the code provided looks gorgeous!

> PrettyDiff returns gorgeous and beautiful HTML

<div class="panel-group" id="accordionFour">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordionFour" href="#collapseFour">PrettyDiffs pure absolute awesomeness code - Click to expand</a>
            </h4>
        </div>
        <div id="collapseFour" class="panel-collapse collapse">
            <div class="panel-body">
```language-markup
<div class="panel-group" id="accordion1">
        <div class="panel panel-default">
            <a class="accordion-toggle" data-parent="#accordion1" data-toggle="collapse" href="#collapse1">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <FONT COLOR="#FE2E2E" style="font-size:15px">View Code</FONT>
                        <span class="pull-right clickable">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                        </span>
                    </h4>
                </div>
            </a>
            <div class="panel-collapse collapse" id="collapse1">
                <div class="panel-body"><pre class="prettyprint"> 
<br/> <div class="caption"><span class="id">: </span><span  
class="content">DoctestMain</span></div><!--tex4ht:label?: x1-40001 --><!--l. 9--><pre class="listings">&#x00A0;<br/><span class="label"><a 
id="x1-4001r1"></a></span>if&#x00A0;__name__&#x00A0;==&#x00A0;<!--l. 10--><span class="listings-nested">&#8221;__main__&#8221;</span>:&#x00A0;<br/><span class="label"><a 
id="x1-4002r2"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;import&#x00A0;doctest&#x00A0;<br/><span class="label"><a 
id="x1-4003r3"></a></span>&#x00A0;&#x00A0;&#x00A0;&#x00A0;doctest.testmod()
&#x00A0;<br/><span class="label"><a 
id="x1-4004r4"></a></span></pre>
</pre>
            </div>
        </div>
    </div>
</div>
```
             </div>
        </div>
    </div>
</div>

> PrettyDiff leaves the webpage intact!

>But PrettyDiff is a webservice

That's too big of a bazooka, let's try the olde trusty BeautifulSoup.

####Enter BeautifulSoup

<blockquote>
Note: I tried lxml, I know it is faster, it has parse errors, my head hurts for repeating this subject all over again, I just want this to end. Leave me alone. AAAARGGGGH

<small>Fixing, parsing, handling HTML sucks... there, I said it... moving on!</small>
</blockquote>

```language-python
from bs4 import BeautifulSoup
import re

orig_prettify = BeautifulSoup.prettify
r = re.compile(r'^(\s*)', re.MULTILINE)
def prettify(self, encoding=None, formatter="minimal", indent_width=4):
    return r.sub(r'\1' * indent_width, orig_prettify(self, encoding, formatter))
BeautifulSoup.prettify = prettify


if __name__ == "__main__":
    linestring = open("E:/Claudio/git/sites/GoodrichTamassiaGoldwasser/file.html", 'r').read()
    soup = BeautifulSoup(linestring)
    # Custom indentation, Unicode
    text = soup.prettify("utf-8", indent_width=3)
    text_file = open("E:/Claudio/git/sites/GoodrichTamassiaGoldwasser/index.html", "wb")
    text_file.write(text)
    text_file.close()
```

And voilá, fast and pretty html.

<div class="panel-group" id="accordionFive">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-toggle="collapse" data-parent="#accordionFive" href="#collapseFive">BeautifulSoup prettyprint - Click to expand</a>
            </h4>
        </div>
        <div id="collapseFive" class="panel-collapse collapse">
            <div class="panel-body">
```language-markup
<div class="panel-group" id="accordion1">
   <div class="panel panel-default">
      <a class="accordion-toggle" data-parent="#accordion1" data-toggle="collapse" href="#collapse1">
         <div class="panel-heading">
            <h4 class="panel-title">
               <font color="#FE2E2E" style="font-size:15px">
                  View Code
               </font>
               <span class="pull-right clickable">
                  <i class="glyphicon glyphicon-chevron-up">
                  </i>
               </span>
            </h4>
         </div>
      </a>
      <div class="panel-collapse collapse" id="collapse1">
         <div class="panel-body">
            <pre class="prettyprint"> 
<br/> <div class="caption"><span class="id">: </span><span class="content">DoctestMain</span></div><!--tex4ht:label?: x1-40001 --><!--l. 9--><pre class="listings"> <br/><span class="label"><a id="x1-4001r1"></a></span>if __name__ == <!--l. 10--><span class="listings-nested">”__main__”</span>: <br/><span class="label"><a id="x1-4002r2"></a></span>    import doctest <br/><span class="label"><a id="x1-4003r3"></a></span>    doctest.testmod()
<br/><span class="label"><a id="x1-4004r4"></a></span></pre>
</pre>
         </div>
      </div>
   </div>
</div>
```
             </div>
        </div>
    </div>
</div>

So... the next step is adding more pretty crap. 

##Special Thanks

Special thanks go to [Michal Hoftich](https://github.com/michal-h21) for pointing out where the possible error might be.

And to OCRemix for the following song:

<iframe width="560" height="315" src="//www.youtube.com/embed/ijJ60pjy68c" frameborder="0" allowfullscreen></iframe>

Without that this would not have been possible. 

You can check the code in bitbucket for the C++ part that adds functionality to the ToC and to other elements. 

<p align="center">
<a href="https://bitbucket.org/claudiordgz/bootstrapify/src" target="_blank"><img src="https://d3oaxc4q5k2d6q.cloudfront.net/m/1ce7982dcf37/img/homepage/bitbucket-logo-blue.svg" alt="BitbucketLogo" width="50%"/></a>
</p>

<p align="center">
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- Blog02Inline -->
<ins class="adsbygoogle"
     style="display:inline-block;width:300px;height:250px"
     data-ad-client="ca-pub-1525337072631150"
     data-ad-slot="6162666226"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
</p>
