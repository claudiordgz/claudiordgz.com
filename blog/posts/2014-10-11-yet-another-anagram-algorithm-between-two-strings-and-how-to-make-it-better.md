---
title: Yet Another Anagram algorithm between two strings... and how to make it better
slug: yet-another-anagram-algorithm-between-two-strings-and-how-to-make-it-better
date_published: 2014-10-11T06:05:53.721Z
date_updated:   2015-07-24T13:18:41.617Z
tags: C++, Complexity
---

I am reading "Cracking the Coding interview" and doing some exercises I began coding a algorithm to find is a string is permutation of another. I found that the first implementation I did was completely wrong since I was taking repeated characters as one.

###The wrong version

So there I was, thinking **Permutations**, when suddenly I felt struck by lightning. I started coding with intent and confidence, and when the time came for comparing *parangacutirimicuaro* and *oraucimiritucagnarap*... it told me `true`.

I went to sleep, drowned in my own personal success.

Weeks passed, and I started reading the code trying to see what I had done.

I saw it at first glance, the error was staring at my face.

> This thing can't detect repeated values.

```language-cpp
void PushOffsetIntoContainer(int &bit_container, char const &element);

bool is_permutation(std::string const &lhs, std::string const &rhs)
{
  bool returnVal = false;
  if(lhs.size() == rhs.size()){
    int flag_lhs = 0;
    int flag_rhs = 0;
    for(std::size_t i=0; i != lhs.size(); ++i){
      PushOffsetIntoContainer(flag_lhs, lhs.at(i));
      PushOffsetIntoContainer(flag_rhs, rhs.at(i));
    }
    if(flag_lhs == flag_rhs){
      returnVal = true;
    }
  }
  return (returnVal);
}

void PushOffsetIntoContainer(int &bit_container, char const &element){
  int offset_ = element - 'a';
  offset_ = 1 << offset_;
  bit_container = bit_container | offset_;
}
```

>Fail

Feeling dumb doesn't really get to me when I'm working on something. Feeling too proud does leave a scar.

That moment when your own confidence gets the best of you.

So before checking on the web, I decided I wanted mine to be able to detect for multiple characters.

###But first I interrupt this boletin to fix that ugly duckling iteration over two arrays

```language-cpp

#include <boost/tuple/tuple.hpp>
#include <boost/iterator/zip_iterator.hpp>
#include <boost/range/iterator_range.hpp>

template<class... Conts>
auto zip_range(Conts&... conts)
  -> decltype(boost::make_iterator_range(
  boost::make_zip_iterator(boost::make_tuple(conts.begin()...)),
  boost::make_zip_iterator(boost::make_tuple(conts.end()...))))
{
  return {boost::make_zip_iterator(boost::make_tuple(conts.begin()...)),
          boost::make_zip_iterator(boost::make_tuple(conts.end()...))};
}

bool is_permutation(std::string const &lhs, std::string const &rhs)
{
  bool returnVal = false;
  if(lhs.size() == rhs.size()){
    int flag_lhs = 0;
    int flag_rhs = 0;
    for(auto&& str : zip_range(lhs, rhs)) {
		PushOffsetIntoContainer(flag_lhs, str.get<0>());
		PushOffsetIntoContainer(flag_rhs, str.get<1>());
    }
    if(flag_lhs == flag_rhs){
      returnVal = true;
    }
  }
  return (returnVal);
}
```

Way better.

###Handling multiple values

So I figured, if I was checking the values in a Bit Container, well maybe I could do the same using an array of Bit Containers. 

For example for our test case *parangacutirimicuaro* and *oraucimiritucagnarap* we should have 4 bit containers.

But Why? Well because the *a* is repeated four times, this means that we will waste 4 integers in memory. 

```language-cpp
bool IsPermutation(std::string const &lhs, std::string const &rhs)
{
  bool returnVal = false;
  if(lhs.size() == rhs.size()) {
    std::vector<int> flag_lhs { 0 };
    std::vector<int> flag_rhs { 0 };
    for(auto&& str : zip_range(lhs, rhs)) {
		PushOffsetIntoContainer(flag_lhs, str.get<0>());
		PushOffsetIntoContainer(flag_rhs, str.get<1>());
    }
    if(flag_rhs.size() == flag_lhs.size()) {
      for(auto&& bitContainer : zip_range(flag_lhs, flag_rhs)) {
		if (bitContainer.get<0>() == bitContainer.get<1>()) {
          returnVal = true;
        } else {
          returnVal = false;
        }
      }
    }
  }
  return (returnVal);
}

void PushOffsetIntoContainer(std::vector<int> &bit_container, char const &element)
{
  int offset_ = element - 'a';
  offset_ = 1 << offset_;
  for(auto it = bit_container.begin(); it != bit_container.end(); ++it) {
    if(*it & offset_) {
      if (std::distance(it, bit_container.end()) == 1) {
	    int pushIt = std::distance(bit_container.begin(), it);
		bit_container.push_back(0);
		it = bit_container.begin();
		std::advance(bit_container.begin(), pushIt);
      }
    } else {
      *it = *it | offset_;  
      break;
    }
  }
}
```

###Analysis

So... we will need an extra integer everytime there is a repeated character, which means we will have our memory being taken from us *m* times... Where *m* is  **the** character that was repeated *the most*. 

We will also need to check every character, and in the worst case, every integer of *m*. That means that this thing will require *n* characters times *m* the repeated stuff.

Almost O(n<sup>2</sup>), the *m* stuff really downgrades the stuff to O(n*m). 

###Is there something better.

Well, we need to see the advantages, and the disadvantages. 

####Advantages
 
- Handles repeated values
- Works... and that's pretty much it

####Disadvantages 

- O(m) memory 
- O(n*m) linear complexity
- Only handles low case letters
- Only handles english letters

So the disadvantages pretty much destroy any happiness factor about the algorithm. And it may be better than O(n<sup>2</sup>), but that does not mean we have a good solution. 

###How to make it better

We are going to try *sorting* algorithms. We sort each string, and then they must be the same. That is pretty much it.

There are multiple ways of sorting, but the advantages can be spotted immediately.

- Once sorted, it is just one check
- They can handle any character
- Any length
- Complexity depends on the sorting algorithm

For our test case *parangacutirimicuaro* and *oraucimiritucagnarap* we have *a* repeating four times, meaning our **m** factor is 4. And we have an **n** of 20.

Our previous algorithm

- O(n*m) = 80

Sorting, in case or Mergesort or Heapsort

- O(n*log n)  = 86.43

Not so bad eh?

BUT!

What if the size of our strings gets bigger. Then that means there will be more repeated characters, and the log n of the other complexity will eventually win.

Because O(n*m) is worse than O(n log n).

###Conclusion

After all this I would go after the sort implementation. The reason is simple, robustness, this solution is way too fragile, handling only lowercase and english characters is not really a complete solutions. And we would have to hack and slash this solution to allow for better perfomance. So maybe, just maybe in the end after converting to LowerCase and after determining a special probability that gives us the likelihood that a string has too much repeated characters then we could make a decision between one implementation or the other.

For example... in the case of the following strings:

*ooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaooooooooooooooooooaaaaoooooooo*

and

*ooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaooooooaooooaooooaooooaoooo*

I would rather use the sorting method.

But in a simple case like *Apple*, *Orange*, *car*, *feast*. Then I would rather use my approach. 

But I don't see myself using this solution for strings, as you can see you can detect a permutation of objects by using this simple procedure. So let's say you have two players in a game of StarCraft, and you want to analyze if they use similar approaches because you or someone in your team will be facing them down the road. Then you can analyze the amount of similar characters he uses automatically without even having to see the match, and thus, you can focus on your own. 

###PD

[Yet one more approach](http://k2code.blogspot.mx/2011/09/anagram-checkerto-check-if-2-strings.html)

I found this solution in which the author uses HashMaps. Even though I feel it is a bit overkill, it is a way to handle this problem really fast. If you narrow or know your character space then you can come up with a pretty nice hash function with it. 

##For more info on these problems check the github repository

[![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/AmazonInterviewTraining)
