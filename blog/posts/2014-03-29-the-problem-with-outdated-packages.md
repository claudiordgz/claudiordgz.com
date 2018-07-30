---
title: Using FontAwesome in your XeLaTeX document
slug: the-problem-with-outdated-packages
date_published: 2014-03-29T04:17:00.246Z
date_updated:   2014-03-29T19:53:49.322Z
---

Yesterday I downloaded `FontAwesome.otf` and saw that it had some new fonts that the `XeLaTeX` version does not have. So I decided to rebuild the package with the [new **otf** directly from the repository](http://fortawesome.github.io/Font-Awesome/). The symbols and memory addresses are already set and I could test it in my XeLaTeX. 

Here is an example of how the `sty` file looks...

###STY with memaddresses
 
```language-latex
 
\RequirePackage{fontspec}
   
\def\faGlass{\symbol{"F000}}
\def\faMusic{\symbol{"F001}}
\def\faSearch{\symbol{"F002}}
\def\faEnvelopeO{\symbol{"F003}}
\def\faHeart{\symbol{"F004}}
\def\faStar{\symbol{"F005}}
\def\faStarO{\symbol{"F006}}

\newfontfamily{\FA}{FontAwesome.otf}

\def\glass{{\FA \faGlass}}
\def\music{{\FA \faMusic}}
\def\search{{\FA \faSearch}}
\def\envelopeO{{\FA \faEnvelopeO}}
\def\heart{{\FA \faHeart}}
\def\star{{\FA \faStar}}
\def\starO{{\FA \faStarO}}
```

### Steps for setting up and using


1. `\usepackage{fontawesome}` 

Click on the cat to see the demo and download the required files.

[![Github for FontAwesome](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_scale,w_256/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/FontAwesomeXeTeX)

You wanna know why I updated the **sty** from the one from [Honza Ustohal gist](https://gist.github.com/sway/3101743)?

###[I wanted the f******ing fighter jet](http://fortawesome.github.io/Font-Awesome/icon/fighter-jet/)

Not only that, for some reason **CTAN** official version which is [pretty up to date here](http://mirror.unl.edu/ctan/fonts/fontawesome/fontawesome.sty) from Xavier Danaux didn't work with my environment. So I was killing two birds with one stone this way.

###[You can also check the demo of how your sweet laTeX icons will look on your document here.](http://claudiordgz.github.io/FontAwesomeXeTeX/fontawesome.pdf)


