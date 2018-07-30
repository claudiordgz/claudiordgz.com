---
title: Migrating to Ghost
slug: migrating-to-ghost
date_published: 2014-03-08T23:42:28.175Z
date_updated:   2014-03-10T00:05:07.354Z
tags: blog, ghost
---

####Leaving the powerhouse.

I've loved wordpress for a while. I though I was never going to leave it. 

> Wordpress is like a huge room, a drawing board on one side, with power tools underneath the table, and delicate paint brushes right next to the welding station. If you can't create something using Wordpress you are in deep deep shit.

#### Why continuous writing?

So many years using laTeX had made me a lover of continuous writing. For example when I'm using laTeX I can do something like this:

```language-latex
\includegraphics[width=1\texwidth]{img01.png}
```
And after so many times typing crap like that you get faster at it. Damn, even copy/pasting gets optimized.

Adding images and positioning depends on you knowing laTeX than on your mouse-clicking skills. 

> 'Cus, creating a document is not a StarCraft game of 300 clicks per second and micro management

Of course, of course, this is a lot of text compared to:

1. Click insert Image
2. Search for your image
3. Position the stuff in the right place 
4. Write your caption
5. Reference it in your text

But maybe, just maybe, you just don't want to repeat all that crap for over 250 images.

I learned laTeX mostly because it gave me a power I didn't know I could have.  

The power to edit a range of pages without blowing a full document to smithereens. 

> With Word it's... You know what? Just go ahead and resize the image in page 150 to triple it's size and see what happens to the rest of the 500 pages. 

Ghost reminds me of that feeling all over again. The feeling that I can focus specifically on content instead of wasting my time worrying about format. With laTeX I would waste 3 to 4 days for just formatting (making things pretty is very expensive). Development is divided in two phases:

1. Make things pretty
2. Build things based on the prettyness

Of course in software is usually the other way around. 

####Why is it so awesome

Dude... I can write code so fast now

```language-cpp
class HtmlPolicy
{
public:
  process()
  {
	this->html_parse();
  }

private:
  html_parse()
  {
	std::cout << "This is the Html Policy" << std::endl;
  }

};

class CssPolicy
{
public:
  process()
  {
  	this->specific();
  }

private:
  specific()
  {
  	std::cout << "This is the Css Policy" << std::endl;
  }
};

template<class Policy>
class ProcessConfig
{
public:
  ProcessConfig()
  {
  	policy_.process();
  }

private:
	Policy policy_;
};

int main()
{
  ProcessConfig<HtmlPolicy> foo;    
  ProcessConfig<CssPolicy> bar;
  return(0);
}
``` 

And it has **colors**... go figure.

####Is it hard?

I use BlueHost VPS Service. Then I SSH to my VPS, then installed node.js from console, downloaded ghost, and hacked and slashed some apache configuration.

> So it will be very hard if you haven't use linux terminal, configured apache, and if you want to add your icons you'll need some css and html knowledge. 

So you could say it is not easy if you don't have all that knowledge. 

> But acquiring all that knowledge is easy using the interwebz, it's all there for the taking

####How long does it take

Around 8 hours of getting tools, configuring them, and shaping them to what you want.

####Do you recommend it

Adding content to your blog should be the numero uno priority. No matter what. Your blog could be your personal notes, your future partner when you forget how did you solve a weird algorithm. **This is your safe haven**

> So yeah, I do recommend markdown, I do recommend javascript, and of course I recommend ghost simple infrastructure. 
