---
title: Using LaTeX to Document studies Part 2
slug: using-latex-to-document-studies-part-2
date_published: 2014-11-11T13:53:00.000Z
date_updated:   2015-07-24T12:39:21.747Z
---

I am building websites from LaTeX source. It is fantastic, I got all these amazing things like generation to pdf or to html, awesome looks for formular, the code looks great on paper thanks to a package called listings and great on web thanks to the <a href="https://code.google.com/p/google-code-prettify/" target="_blank">Google Code Prettify</a> project. 

This is an example of navigating the source code:

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415731022/Image_073_wxlgjp.png" target="_blank">![Source](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415731022/Image_073_wxlgjp.png)</a>

This is a generated web page: 

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_WithoutMods_vwhjmp.png" target="_blank">![Generated Website](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_WithoutMods_vwhjmp.png)</a>

But there are still some issues. Creating the configuration for generating HTML is not trivial, I repeat, creating the configuration for generating HTML is not trivial. I could repeat this tons of times, but still won't be enough. 

Analyzing the problems in the webpage is really simple. We need to change our visuals. We need these simple changes now to scale more efficiently down the road.

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_WhatsWrong_dd4czi.png" target="_blank">![Changes required](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_WhatsWrong_dd4czi.png)</a>

We need to:

1. Change the **Go to Top** link to a button or something more visible.
2. Change the **Table of Contents** to something collapsable
3. Add space to prevent the logo from collisioning with the **Table of Contents**

It should look like the following.

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_ImprovementsLook_o1jpz1.png" target="_blank">![Changes needed](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_ImprovementsLook_o1jpz1.png)</a>

The changes are very easy, we just use Bootstrap 3 and be done with it in a matter of minutes. The problem comes that we need all this generated automatically every time we add content.

I wanted to do this using LaTeX from the get go. <a href="http://tex.stackexchange.com/questions/209513/changing-a-tex4ht-span-class-using-confiig-file" target="_blank">Until this happened</a>.

The configuration is a problematic and cryptic file as it is.

So no more. 

I decided to use some C++ scripting for this.

```language-cpp
std::string fileName = argv[1];
std::string outputFileName = argv[2];
std::ifstream infile(fileName);
if (infile) {
  auto contents = loadFile(infile);
  contents = replaceTableWithReponsive(contents);
  contents = fixTableOfContents(contents);
  contents = fixGoTotop(contents);
  outputFile(outputFileName, contents);
}
else {
  std::cout << "file not found!\n";
  return 1;
}
return 0;
```

And the changes look fantastic.

<a href="http://claudiordgz.github.io/GoodrichTamassiaGoldwasser/" target="_blank">You can check the website generated from LaTeX in here</a>

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_Transformation_zvuhrj.png" target="_blank">![Changes](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730314/Nov112014_Transformation_zvuhrj.png)</a>


##Or check any code related to the WebSite in the repository GoodrichTamassiaGoldwasser

<a href="https://github.com/claudiordgz/GoodrichTamassiaGoldwasser/tree/gh-pages" target="_blank">![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)</a>


Here is the full snippet required to change the pieces.

```language-cpp
#include <iostream>
#include <fstream>
#include <string>
#include <iterator>
#include <memory>

/*! @brief Code to make a collapsable chapter in the TableOfContents */
struct tocElement {
  /// @brief the preamble, replace the markup {{}} elements. 
  /// idx with a unique number
  /// headerMarkup with the previous header markup
  std::string header = R"(<div class="panel-group" id="accordionToc">
  <div class="panel panel-default">
    <div class="panel-heading">
      <h4 class="panel-title">
        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordionToc" href="#collapseToc{{idx}}">
<span class="pull-right clickable"><i class="glyphicon glyphicon-chevron-up"></i></span> 
{{headerMarkup}}
 </h4>
    </div>
    <div id="collapseToc{{idx}}" class="panel-collapse collapse">
      <div class="panel-body">)";
  /// @brief closing tags for the preamble
  std::string bodyEnd = R"(</div>
    </div>
  </div>
</div>)";

};

/*! @brief Replaces all the strings with another
*  @param str source content string
*  @param from the original string to be replaced
*  @param to the end string
*  @return modified string */
std::string replaceAll(std::string const& str, std::string const &from, std::string const &to);

/*! @brief Replaces the first string with another
*  @param str source content string
*  @param from the original string to be replaced
*  @param to the end string
*  @return modified string */
std::string replaceFirst(std::string const& str, std::string const &from, std::string const  &to);

/*! @brief Each chapter in the TableOfContents must be enclosed with a Bootstrap 3 accordion
*  @param fileContents the string of html content that contains the table environment
*  @return string with new changed content */
std::string fixToc(std::string const &fileContents);

/*! @brief Find the TableOfContents in the file and extract it
*  @param fileContents the string of html content 
*  @return string with new changed content */
std::string extractToc(std::string const &fileContents);

/*! @brief Enclose all tables with <div class="table-responsive"> and </div>
 *  @param fileContents the string of html content that contains the table environment
 *  @return string with new changed content */
std::string replaceTableWithReponsive(std::string const &fileContents);

/*! @brief Reads a file into a string
 *  @param infile input file stream
 *  @return file contents in string */
std::string loadFile(std::ifstream &infile);

/*! @brief Writes string to a file
 *  @param fileName name with path of the file
 *  @param contents */
void outputFile(std::string const& fileName, std::string const &contents);

/*! @brief Replaces TableOfContents with Accordion and returns fixed one
*  @param contents */
std::string fixTableOfContents(std::string const &contents);

/*! @brief Replaces Go To Top links with section/chapter to Logo
*  @param contents */
std::string fixGoTotop(std::string const&contents);

int main(int argc, char* argv[]){
  std::cout << argv[0];
  if (argc == 2)
  {
    std::cout << "Not enough arguments." << std::endl;
    exit(1);
  }
  else
  {
    std::string fileName = argv[1];
    std::string outputFileName = argv[2];
    std::ifstream infile(fileName);
    if (infile) {
      auto contents = loadFile(infile);
      contents = replaceTableWithReponsive(contents);
      contents = fixTableOfContents(contents);
      contents = fixGoTotop(contents);
      outputFile(outputFileName, contents);
    }
    else {
      std::cout << "file not found!\n";
      return 1;
    }
  }
   return 0 ;
}
std::string fixGoTotop(std::string const&contents) {
  size_t pos = 0;
  std::string retStr(contents);
  std::string findStr = "Go to Top</a>", 
    insertStr = R"(<a href="#claudiordgzLogo" class="btn btn-default pull-right"><span class="glyphicon glyphicon-arrow-up"></span> )";
  while ((pos = retStr.find(findStr, pos)) != std::string::npos) {
    size_t beginPos = retStr.rfind("<a", pos);
    retStr.replace(retStr.begin() + beginPos, retStr.begin() + pos, insertStr);
    pos += insertStr.length() + findStr.length();
  }
  return retStr;
}
std::string fixTableOfContents(std::string const &contents){
  std::string toc = extractToc(contents);
  std::string fixedToc = fixToc(toc);
  return replaceFirst(contents, toc, fixedToc);
}
std::string extractToc(std::string const &fileContents) {
  std::string beginStr = R"(<div class="tableofcontents">)";
  size_t beginPos = fileContents.find(beginStr);
  std::string returnStr("");
  if (beginPos != std::string::npos){
    std::string endStr = R"(<div class="col-md-7" id="docBody">)";
    size_t endPos = fileContents.find(endStr, beginPos);
    if (endPos != std::string::npos) 
      returnStr.append(fileContents.begin() + beginPos, fileContents.begin() + endPos);
  }
  return returnStr;
}
void outputFile(std::string const& fileName, std::string const &contents) {
  std::ofstream out(fileName);
  std::copy(contents.begin(), contents.end(), std::ostreambuf_iterator<char>(out));
}
std::string loadFile(std::ifstream &infile) {
  std::string fileData((std::istreambuf_iterator<char>(infile)),
  std::istreambuf_iterator<char>());
  infile.close();
  return fileData;
}
std::string replaceAll(std::string const& str, std::string const &from, std::string const &to) {
  std::string retStr(str);
  if (!from.empty()) {
    size_t start_pos = 0;
    while ((start_pos = retStr.find(from, start_pos)) != std::string::npos) {
      retStr.replace(start_pos, from.length(), to);
      start_pos += to.length();
    }
  }
  return retStr;
}
std::string replaceFirst(std::string const& str, std::string const &from, std::string const  &to) {
  std::string retStr(str);
  if (!from.empty()) {
    size_t start_pos = retStr.find(from);
    if (start_pos != std::string::npos) {
      retStr.replace(start_pos, from.length(), to);
    }
  }
  return retStr;
}
std::string fixToc(std::string const &tableOfContents){
  size_t beginPos = 0, counter = 1;
  std::string content(tableOfContents);
  std::string findStr = R"(<span class="chapterToc")", endStr = R"(</span>)";
  std::string insertStr;
  while ((beginPos = content.find(findStr, beginPos)) != std::string::npos) {
    tocElement instance;
    if (counter > 1){
      insertStr = instance.bodyEnd;
      content.insert(beginPos, insertStr);
      beginPos += insertStr.length();
    }
    size_t endingPos = content.find(endStr, beginPos);
    if (endingPos != std::string::npos) {
      std::string title(content.begin() + beginPos, content.begin() + endingPos + endStr.length());
      instance.header = replaceAll(instance.header, "{{idx}}", std::to_string(counter));
      instance.header = replaceFirst(instance.header, "{{headerMarkup}}", title);
      content = replaceFirst(content, title, instance.header);
      beginPos = content.find(instance.header) + instance.header.length();
      counter++;
    }
    else {
      // parsing error
    }
  }
  content.append(insertStr);
  return content;
}
std::string replaceTableWithReponsive(std::string const &fileContents) {
  size_t pos = 0;
  std::string content(fileContents);
  std::string findStr = R"(<table)", insertStr = R"(<div class="table-responsive">)";
  while ((pos = content.find(findStr, pos)) != std::string::npos) {
    content.insert(pos, insertStr);
    std::string endStr = R"(</table>)", insertCloseStr = R"(</div>)";
    size_t endingPos = content.find(endStr, pos);
    if (endingPos != std::string::npos) {
      endingPos = endingPos + endStr.length();
      content.insert(endingPos, insertCloseStr);
    }
    pos += insertStr.length() + findStr.length();
  }  
  return content;
}
```

###Plus... we have responsive tables now

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730313/Nov112014_responsiveTables_orwm2z.png" target="_blank">![Responsive Tables](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415730313/Nov112014_responsiveTables_orwm2z.png)</a>
