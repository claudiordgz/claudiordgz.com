---
title: Top 5 Do's and Don'ts Rules for Unit Testing
slug: top-5-dos-and-donts-rules-for-unit-testing
date_published: 2015-07-23T17:48:09.029Z
date_updated:   2015-07-30T15:30:07.910Z
tags: c++, Unit Testing
draft: true
---


##### <span style="color:limegreen">Do:</span> Test the "should never happen" 

##### <span style="color:red">Don't:</span> Test everything you can

##### <span style="color:limegreen">Do:</span> Reuse pieces of your tests using static functions, or a nice pattern to keep your code readable.

##### <span style="color:red">Don't:</span> Care about performance in your tests or give priority to anything other than readability.

##### <span style="color:limegreen">Do:</span> Run unit tests during your production process

##### <span style="color:red">Don't:</span> Combine White Box Tests with Black Box Tests

##### <span style="color:limegreen">Do:</span> Order your mock files as anally as possible (mock\_for\_a\_very\_specific\_set\_of\_skills.csv)

##### <span style="color:red">Don't:</span> Do mock loading in multiple parts of the code (Inheritance Dude!)

##### <span style="color:limegreen">Do:</span> Allow for extra functionality in the test runner

##### <span style="color:red">Don't:</span> Do network dependent tests (use mock files instead or a disabling decorator for your CI test runner)


