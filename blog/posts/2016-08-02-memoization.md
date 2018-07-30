---
title: Memoization
slug: memoization
date_published: 2016-08-02T04:06:07.287Z
date_updated:   2016-08-02T04:06:07.284Z
tags: Python
---

Memoization is a technique. It means to keep track of previous results in a cache and returning that result. 

I got stuck this week battling this:

```language-python
def answer(food, grid):
    @memoize
    def search(f, row, column):
        f -= grid[row][column]
        if row < 0 or column < 0 or f < 0:
            return food + 1
        elif row == column == 0:
            return f
        else:
            return min(search(f, row - 1, column), search(f, row, column - 1))
    remainder = search(food, len(grid) - 1, len(grid) - 1)
    return remainder if remainder <= food else -1
```

It searches a matrix `N x N` where `N` is less than 20.

The test cases I was given were the following:

```language-python
def test():
    N = 20
    data = [(
        # First Test Case F=7, N=3, Answer=0
        7,
        [[0, 2, 5], [1, 1, 3], [2, 1, 1]],
        0
    ),(
        12,
        [[0, 2, 5], [1, 1, 3], [2, 1, 1]],
        1
    ),(
        # The custom test case
        200,
        [[randrange(1, 6) for i in range(N)] for j in range(N)],
        None
    )]
    for food, grid, r in data:
        result = answer(food, grid)
        print(result == r if r else result)
```

Sadly for the third test case it failed, because there are too many possibilities. I left it run it for a while, according to my bad calculations it would take more than a day, don't really know how much more... just more. 

This is where Python's help comes to the rescue (note: memoization is a technique not exclusive to python). [In here](https://wiki.python.org/moin/PythonDecoratorLibrary#Memoize) there are several examples of how to create a memoizer, some of the using an elegant decorator. I copied and pasted the following:

```language-python
import functools


def memoize(obj):
    cache = obj.cache = {}

    @functools.wraps(obj)
    def memoizer(*args, **kwargs):
        key = str(args) + str(kwargs)
        if key not in cache:
            cache[key] = obj(*args, **kwargs)
        return cache[key]
    return memoizer
```

[Of course my first option was to do a way more complex solution of finding paths via Depth First Search](https://github.com/claudiordgz/udacity_cs212/blob/6ca0c9cc7afdce401cc175cc18c7894485a6a744/foobar/save_beta_rabbit.py). But who cares.

After memoizing the solution works, which is pretty awesome. 

