---
title: "Small Notes on std::unique_ptr and Data Structures"
slug: small-notes-on-stdunique_ptr-and-data-structures
date_published: 2014-10-14T21:34:34.874Z
date_updated:   2015-07-24T13:15:24.125Z
tags: C++, programming, unique_ptr
---

Been studying some good ol' data structures, but before taking on the subject, I needed some sauce. I have been wanting to get on the smart_ptr wagon ever since boost introduced them.

[And then this blog post by Herb Sutter](http://herbsutter.com/2013/05/29/gotw-89-solution-smart-pointers/)

So to get on the unique_ptr bandwagon I though I was going to begin with a faithful barebones linked list.

Let's assume your linked list class holds the root node only (for now) and also holds the size. 

### The node object


```language-cpp
#ifndef __LINKEDLIST__HPP__
#define __LINKEDLIST__HPP__

#include <memory>

namespace linkedlist
{
template<class T>
class Node {
public:
  Node(){}
  Node(T const &pData) : data(pData) {}

  std::unique_ptr<Node<T> > next = nullptr;
  T data;
};
}
```
###And the linked list class

```language-cpp
namespace linkedlist
{

template<class T>
class List {
public:
  typedef Node<T>* iterator;
  List() : _size(0) {}
  List(T const &root);
  void push_back(T const &root);
  void erase(T const& value, int const &amount=-1);
  iterator begin() { return _root.get(); }
  
private:
  std::unique_ptr<Node<T> > _root;
  std::size_t _size;
};

}

#include <Training\linkedlist\linkedlistImpl.hpp>

#endif
```

For now all I want is to push back elements. But I want something I wasn't able to find anywhere online.

I want to remove elements. 

Because... reasons.


```language-cpp
template<class T>
List<T>::List(T const &root) : _size(1) {
  _root.reset(new Node<T>(root));
}

template<class T>
void List<T>::push_back(T const &root) {
  if (_root == nullptr) {
    _root.reset(new Node<T>(root));
    _size++;
  }
  else {
    auto current = begin();
    while (current->next != nullptr) {
      current = current->next.get();
    }
    current->next.reset(new Node<T>(root));
    _size++;
  }
}
```

As you can see... the push back method **is horrible**. Later on we will add a tail node to iterate backwards, but for now we are ok.

###How to delete a value from a list?

```language-cpp
template<class T>
void List<T>::erase(T const& value, int const &amount) {
  int count{ 0 };
  if (_root == nullptr) return;
  iterator current = begin(), previous = nullptr;
  while (current != nullptr) {
    if (count == amount) return;
    if (current->data != value){
      previous = current;
    } else {
      if (previous == nullptr){
        _root = std::move(_root->next);
        current = begin();
      } else {
        previous->next = std::move(current->next);
        current = previous;
      }
      _size--; count++;
    }
    if (previous != nullptr)
      current = current->next.get();
  }
}
```

###Advantages

Do you see `delete` anywhere? That's cause we are using `amazing_ptr`... I mean `uniqure_ptr` which as soon as there is no owner, omg it goes PUFF! It is magical.

It is fantastics.

It is supercalifragilisticexpialidocious.

This is amazing. 

> Unique pointer is awesome

##For more info on these problems check the github repository

[![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/AmazonInterviewTraining)
