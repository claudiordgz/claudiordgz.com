---
title: Coding from the Top Down
slug: coding-with-the-top-down-2
date_published: 2016-08-02T03:54:55.660Z
date_updated:   2016-08-02T03:55:16.700Z
tags: blog, open-learning
---

I never liked the school system in Mexico. 

I've been trying Coursera, Udacity, Egghead, and Pluralsight for over a year. I just started toying with EdX, and FutureLearn, Khan Academy.

They are amazing. And there are four main reasons:

 - It is not harassment oriented learning. Everyone is busy, so don't learn today, this week, or month for all they care, the knowledge will be there, waiting for you.
 - You can take quizzes and homework several times. No more battles with the teacher's enjoyment of seeing you fail (pretty common in Mexico where the average salary is 15k/year and rents costs near 500/month). 
 - Take classes all the times you need, get help from anyone. I was doing a materials homework once, and couldn't get past the first problem because it seemed like whatever subjects in the chapter were non-related. I went to my teacher for days. After many tries He reluctantly agreed to help and looked at my notes and applied a physics law from first grade to calculate the first step, then the stuff in the chapter for the next thing. In online courses there are Forums of great people all over the world are there to help.
 - Top-notch courses. 

I started with a few Scala courses from Coursera from the man himself, Martin Odersky (he wrote the bible on Scala). The course is super rough since it's my first time doing any functional programming. And the examples are intense because they assume I know everything about theoretical math problems. 

We do unit tests. We use sbt to build the projects and IntelliJ as the IDE for the class.

Then I started two courses on Udacity, [CS101](https://www.udacity.com/courses/cs101), and [CS212](https://www.udacity.com/courses/cs212), the second one from Senpai Peter Norvig who wrote the bible on Artificial Intelligence. 

I get to take classes from the best, and it shows. Peter Norvig has a very practical yet master approach to the design of his solutions and codes from the top down, starting from the tests.

Case in point:

```language-python
def test_search():
    a,b,c = lit('a'), lit('b'), lit('c')
    abcstars = seq(star(a), seq(star(b), star(c)))
    dotstar = star(dot)
    assert search(lit('def'), 'abcdefg') == 'def'
    assert search(seq(lit('def'), eol), 'abcdef') == 'def'
    assert search(seq(lit('def'), eol), 'abcdefg') == None
    assert search(a, 'not the start') == 'a'
    assert match(a, 'not the start') == None
    assert match(abcstars, 'aaabbbccccccccdef') == 'aaabbbcccccccc'
    assert match(abcstars, 'junk') == ''
    assert all(match(seq(abcstars, eol), s) == s
               for s in 'abc aaabbccc aaaabcccc'.split())
    assert all(match(seq(abcstars, eol), s) == None
               for s in 'cab aaabbcccd aaaa-b-cccc'.split())
    r = seq(lit('ab'), seq(dotstar, seq(lit('aca'), seq(dotstar, seq(a, eol)))))
    assert all(search(r, s) is not None
               for s in 'abracadabra abacaa about-acacia-flora'.split())
    assert all(match(seq(c, seq(dotstar, b)), s)
               for s in 'crab cb across scab'.split())
    return 'test_search passes'
```
That is a very practical approach to testing. And that's the beginning of the code; nothing will work, and you won't be able to check it or run it. 

It looks scary, but that is the point of learning how to design solutions. 

I recommend learning what you want at your pace. Only you know if that subject is moving you or not. The problem is that people stopped training themselves, and because of this everybody got stuck with shit standards, and standards got bloated due to complex reasons. 

Say no to useless fluff. 












