---
title: Annotating Images with TikZ, and converting PDF to PNG
slug: i-effing-python
date_published: 2014-04-22T16:37:18.965Z
date_updated:   2015-07-24T13:22:17.260Z
tags: latex, Python, Yaml
---

Parsing laTeX
A phrase you are not even supposed to know
Not even supposed to consider

[Of course lots and lots of people have resort to some kind of solution that involves parsing laTeX](http://www.tex.ac.uk/cgi-bin/texfaq2html?label=LaTeX2HTML). 

- HTLaTeX
- latex2html
- pandoc

Currently my manual has lots of images. These images are presented in the following format:

![The lonely Image](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398181222/DummyImage_brzf9k.png)

> This is a screenshot of my blog, I have buttons, posts, links to my social media, and my logo!


For a User's Manual that image speaks a **presentation**. It is a *look at me* please. But the User has to keep track of the content and the image as well.

##What's wrong with this approach?

When we present an image first and text later or viceversa just like anyone would do it in a Scientific Paper we create the following issues:

- User has to keep track of content/Images
- Maintenance becomes harder since editing requires checking the images AND the text.
- The text looses value, and therefore looses audience, being thrown into oblivion. 

###Adding value to the image with the power of TiKz

I've never been to much of an user of Image Editors. Photoshop and GIMP are awesome image editors, but the portability of some good old laTeX code is way simpler and easier to keep version control.

So we annotate the image using XeLaTeX and Tikz.

Currently I am editing multiple images at the same time. I generate a standalone pdf file with the image, then I convert that pdf to png.

It is a very simple procedure that works with no problem. You can visualize the process in the next image.

[![The Process](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398443511/ProcessingMultipleTexDocs_-_New_Page_dn4oim.png)](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398443511/ProcessingMultipleTexDocs_-_New_Page_dn4oim.png)

That **sty** file on the image are global settings for all the images. Concretely I am talking about colors, fonts, font sizes, and img source locations. 

The **TeX** file contains only **TiKz** code plus some settings to make the standalone pdf. Which is the following:

```language-latex
\documentclass{article}
\usepackage{../globals}
\begin{document}
	%TiKz Code
\end{document}
```

And hereafter I show you the code to edit the image using **TiKz**, which may look like gibberish. 

```language-latex
\documentclass{article}
% GLOBALS.STY CODE
\usepackage{graphicx}
\usepackage{tikz}
\usetikzlibrary{external}
\tikzexternalize
\tikzexternalize[shell escape=-enable-write18]
% END OF GLOBALS.STY

\begin{document}

\begin{tikzpicture}
	\node[anchor=south west,inner sep=0] (image) at (0,0) {%
	%trim option's parameter order: left bottom right top
	\includegraphics[width=0.9\linewidth]{DummyImage.png}};
	\begin{scope}[x={(image.south east)},y={(image.north west)}]
		\draw (0.3,1.11) node [right] {\Huge This is my blog!};
		\draw[<-, thick] (0.075,0.98) -- (0.075,1.15) node [above] {\small These will get you \textbf{HOME}};
		\draw[<-, thick] (0.172,0.98) -- (0.172,1.075) -- (0.075,1.075);
		\draw[ white, thick] (0.89,0.4) -- (0.45,0.4) node [left] {\small Links to social Media};
		\draw[<-, white, thick] (0.89,0.46) -- (0.89,0.4);
		\draw[<-, white, thick] (0.82,0.46) -- (0.82,0.4);
		\draw[<-, white, thick] (0.75,0.46) -- (0.75,0.4);
		\draw[<-, white, thick] (0.675,0.46) -- (0.675,0.4);
		\draw[<-, thick] (0.37,0.22) -- (0.3,0.22) node [left] {\small And Posts!};
	\end{scope}
\end{tikzpicture}
\end{document}

```

>Globals.sty is a file that contains code to create a standalone PDF with our TiKz image

> The pdf image looks something like this:

![The edited image](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1398184307/example_cwhxy3.png)

###An Additional Problem with PDFs

- Images are generated in pdf... which I can't add to TeX code using XeLaTeX. 

####Furthermore I can't just add the TiKz code to the Manual because

- Parsing TikZ code gets *horrible*, just look at that piece of crappy scripting
- The manual becomes harder to read for future developers

####So the good way to go

- Adding only **PNG** images to the manual and leave image edition to the image edition department (which I don't have, but I am going to suppose I own one).

###The Solution

Not everyone wants TikZ, hell, my fellow developers will most likely use PowerPoint for editing images.

**So the solution is to keep a Python script that converts the pdf to png!**

By using the following:

- [ImageMagick](http://www.imagemagick.org/)
- Python
- Yaml Config Files

We will be able to create a script that converts ALL of our standalone images in pdf to png.

#### The Python Script 

The Python script should run the **convert.exe** from the ImageMagick redistributable. 

```language-python
__author__ = 'CRodriguez'

import yaml
import sys, os

"""Return the yaml config file in lovely form, still yet to be standarized 
"""
def load_config(config_name):
    stream = open(config_name, 'r')
    img_to_convert_config = yaml.load(stream)
    return img_to_convert_config

"""Convert ALL the images! 
"""
def main():
    config = load_config("CONFIG.yml")
    convert_path = '{bin_dir}{img_magick}convert.exe'.format(bin_dir=config['bin_dir'],
                                                              img_magick=config['img_magick'])
    dir = os.path.dirname(os.path.abspath('__file__'))
    convert_path = os.path.join(dir, convert_path)
    print convert_path

    for image in config['img_list']:
        image_src = ' {img_dir}{directory}/{img_name} '.format(img_dir = config['img_dir'],
            directory = image['directory'],
            img_name = image['img_name'])
        image_dest = ' {output_dir}{filename}.png '.format(
            output_dir = config['output_dir'],
            filename = image['directory'])
        image_conversion = ''.join(filter(None, [image['args_before'],
                                                 image_src,
                                                 image['args_after'],
                                                 image_dest]))
        print image_conversion
        os.system('{convertapp} {image_conversion}'.format(convertapp=convert_path,
                                                           image_conversion=image_conversion))

if __name__ == '__main__':
    main()
```

And the **config** file is a file in YAML format. It should provide the arguments to each folder and image file:

Like this:
```language-yaml
# The path and folder in which 
# convert is stored
bin_dir: "../../bin/"
img_magick: "ImageMagick-6.8.9-0/" 
# The path and folder that contains  
# the standalone images
img_dir: "../latex_standalone_img/"
# The path and folder of the output
output_dir: "../"
# Miscellaneous options to pass to each image
command_dictionary:
  before:  
    sixhundreddpi: &id600dpi -units PixelsPerInch -density 600
  after:
    resize_for_sharpness: &idresize25 None

    
    
    
# The image list is comprised of the following
# directory: Name of the folder where the image is
# img_name: Name of the img file complete with type
# ARGUMENTS FOR IMAGE MAGICK
# args_before:  args passed before the source img
# args_after: args passed before the target img
img_list: 
  - directory: Example00 
    img_name: Example00-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25

  - directory: Example01 
    img_name: Example01-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25
  
  - directory: example 
    img_name: DummyExample-figure0.pdf
    args_before: *id600dpi
    args_after: #*idresize25
```

Of course this code is all stripped down from comments, modularization, and tests. It is a basic form of what would need to be done to convert multiple folders with pdfs to images. 

###Converting the image

The Python script processes multiple folders with images and converts them using convert from ImageMagick 

This way we **add value** to the image. The user doesn't have to read crap anymore, he can just use the image without having to use both image and text.

Good presentation is important for any content.

And remember, you are only as strong as the weakest link in your product, so try to keep a whole balance. While an annotated image with bad typesetting like the one pictured above is not complete, it is way better that the image plastered and a paragraph of text.

Improve your customer's life dammit. 



