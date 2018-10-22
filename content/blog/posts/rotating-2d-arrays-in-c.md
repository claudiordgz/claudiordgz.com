---
title: Rotating 2D Arrays in C++
slug: rotating-2d-arrays-in-c
date_published: 2014-10-12T05:04:45.668Z
date_updated:   2015-07-24T13:18:09.997Z
tags: C++, programming
---

###Problem

Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

####Analysis

I have one problem basically... it does not specify if is Clockwise or Counterclockwise. Guess we'll have to make it for both.

It would also be nice to be able to rotate something more than just 4 bytes... so we will make it able to process a vector of vectors of **something**.

The first step is coming up with the rotations.


####Clockwise

```language-cpp
template<class _T>
class CW {
public:
  void rotate(_T &upperLCorner, _T &upperRCorner, _T &lowerLCorner, _T &lowerRCorner){
    _T temp = upperLCorner;
    upperLCorner = lowerLCorner;
    lowerLCorner = lowerRCorner;
    lowerRCorner = upperRCorner;
    upperRCorner = temp;
  }
};
```

###Counter Clockwise

```language-cpp
template<class _T>
class CCW {
public:
  void rotate(_T &upperLCorner, _T &upperRCorner, _T &lowerLCorner, _T &lowerRCorner){
    _T temp = upperLCorner;
    upperLCorner = upperRCorner;
    upperRCorner = lowerRCorner;
    lowerRCorner = lowerLCorner;
    lowerLCorner = temp;
  }
};
```

###The Rotation

As you see we are already expecting anything. Basically we need to receive the mentioned corners from the matrix per iteration. 

```language-cpp
 for (int i = 0; i != N/2; ++i) {
      for (int j = 0; j != (N+1)/2; ++j) {
        direction.rotate(squareMatrix[i][j], squareMatrix[j][n - i],
          squareMatrix[n - j][i], squareMatrix[n - i][n - j]);
      }
 }
```

Here is a visual explanation of the cells obtained per loop. 

![Rotation](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1413129091/MatrixRotation_vkkcc8.png)

Now onto the 2D Array stuff, its going to be a functor that takes the direction as a policy class.

```language-cpp
template<template<typename> class DirectionPolicy, class _Type>
class Rotate {
  DirectionPolicy<_Type> direction;
public:
  Rotate(std::vector<std::vector<_Type> > &squareMatrix){
    int n = squareMatrix.size() - 1;
    int outerEnd = squareMatrix.size() / 2;
    int innerEnd = (squareMatrix.size() + 1) / 2;
    for (int i = 0; i != outerEnd; ++i) {
      for (int j = 0; j != innerEnd; ++j) {
        direction.rotate(squareMatrix[i][j], squareMatrix[j][n - i],
          squareMatrix[n - j][i], squareMatrix[n - i][n - j]);
      }
    }
  }
};
```

This leaves us with a way to rotate any vector of vectors of things, clockwise or counterclockwise.

###Usage

```language-cpp
#include <Training/basicAdt/matrixOperations.hpp>


int main() {
  using basicAdt::Rotate;

  std::vector< std::vector<int> > intMatrix {
      { 1, 2, 3, 4 },
      { 5, 6, 7, 8 },
      { 9, 10, 11, 12 },
      { 13, 14, 15, 16 }
  };

  Rotate<basicAdt::CW, int> rotateIntClockwise(intMatrix);
  Rotate<basicAdt::CCW, int> rotateIntCClockwise(intMatrix);

  std::vector< std::vector<double> > doubleMatrix{
      { 1, 2, 3, 4 },
      { 5, 6, 7, 8 },
      { 9, 10, 11, 12 },
      { 13, 14, 15, 16 }
  };

  Rotate<basicAdt::CW, double> rotateDblClockwise(doubleMatrix);
  Rotate<basicAdt::CCW, double> rotateDblCClockwise(doubleMatrix);

  std::vector< std::vector<std::string> > stringMatrix{
      { "1", "2", "3", "4" },
      { "5", "6", "7", "8" },
      { "9", "10", "11", "12" },
      { "13", "14", "15", "16" }
  };

  Rotate<basicAdt::CW, std::string> rotateStringClockwise(stringMatrix);
  Rotate<basicAdt::CCW, std::string> rotateStringCClockwise(stringMatrix);
  return (0);
}
```

##For more info on these problems check the github repository

[![octocat](http://res.cloudinary.com/www-claudiordgz-com/image/upload/c_crop,h_512,w_512,x_0,y_0/h_150,w_150/v1393991651/blacktocat_ad3w8x.png)](https://github.com/claudiordgz/AmazonInterviewTraining)
