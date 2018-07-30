---
title: Waveforms
slug: temp-slug-4
date_published: 1970-01-01T00:00:00.000Z
date_updated:   2014-03-10T08:37:19.981Z
draft: true
---


<h2><strong>Playing with Signals</strong></h2>
Matlab, Scilab, Octave...

They are awesome, so simple to use, so powerful. But Matlab is just &nbsp;too expensive for your average hobbyist.

In my work we process signals, Voltages and Currents to be precise. We have to play with them. To us, they are balls bouncing around and we must guide them to a certain path while adding value to them.

There are no testing mechanism in my work of any kind. This is sad, but what is extremely sad, is that people here know that they have to do testing, architectures, and apply better practices, but they don't do it.

I hate doing the right thing, most of the times it is boring, takes a hell of a time, and it always takes more time and it is harder.

But it has to be done. People expect better from the product we develop. As Mudvayne states, step by step I'm pushing through this...&nbsp;

So I need a waveform, preferably in a dynamic linking library. In my repository.&nbsp;

My waveforms have an Amplitude, a Frequency, and also a number of Samples. But no, these &nbsp;are no ordinary samples, these are divided by component.&nbsp;

Thus I have to provide mechanisms for that.

```language-cpp
#ifndef WAVEFORM_HPP_
#define WAVEFORM_HPP_

#include <stdint.h>
#include <map>
#include <vector>

class Waveform
{
protected:
  int _amplitude;
  int _frequency;
  int _samples;
  std::map<int,double> _SampleTimes;
  std::vector<std::vector<int16_t> > _wave;
  static const double PI = 3.1415926;
public:
  Waveform():
    _amplitude(0),
    _frequency(0),
    _samples(0)
    {   }

  virtual ~Waveform() {}

  void set_properties(int const &litude,
      int const &frequency,
      int const &total_samples)
  {
    _amplitude = amplitude;
    _frequency = frequency;
    _samples = total_samples;
    _SampleTimes[64] = 0.000260416666666666667;
    _SampleTimes[128] = 0.000130208333333333333333;
    _SampleTimes[256] = 0.000065104166666666667;
    _SampleTimes[512] = 0.00003255208333333333333;
    _SampleTimes[1024] = 0.000016276041666666667;
    init();
  }

  template<class T>
  T Omega(T const &frequency)
  {
    T omega = 2 * PI * frequency;
    return omega;
  }

  int Amplitude() { return _amplitude; }
  int Frequency() { return _frequency; }
  int Samples() { return _samples; }
  std::size_t size() { return _wave.size(); }
  void resize(std::size_t const &size) { _wave.resize(size); }

  virtual void init() = 0;

  typedef std::vector<std::vector<int16_t> >::iterator iterator;
  iterator component_begin() { return _wave.begin(); }
  iterator component_end() { return _wave.end(); }

  typedef std::vector<int16_t>::iterator inner_iterator;
  virtual inner_iterator samples_begin(iterator pos) = 0;
  virtual inner_iterator samples_end(iterator pos) = 0;

  virtual void print(std::string const &name) = 0;

};

typedef Waveform* create_t();
typedef void destroy_t(Waveform*);

#endif /* WAVEFORM_HPP_ */
```

As you can see my inner iterators are virtual and they receive the current container. Also our waveform is a Matrix. This is personal to the implementation, but you may choose to do the waveforms in a vector approach.

I totally approve a vector approach.


