---
title: Map object to strings Objects in C++ and Json
slug: map-object-to-strings-objects-in-c-and-json
date_published: 2014-11-15T07:35:28.957Z
date_updated:   2015-07-24T12:36:32.172Z
tags: C++, parsing, policy based design, template metaprogramming
---

##Motivation 

The following illustrate my feelings against OOP.


<div class="row">
  <div class="col-md-6"><ul><li>I love Object Oriented Programming</li><li>I love polymorphism</li></ul></div>
  <div class="col-md-6"><ul><li>I hate inheritance</li><li>I hate more than 5 dependencies per module</li></ul></div>
</div>


I specially, more than anything in life, hate the following kind of inheritance.

```language-cpp
class CSNode:public CNode, public IMvcSubject, public CBaseLink,
         public CBaseVarObserver,public CBaseDataExchange, public CBaseVarOwner
```

The amount of reading I needed to understand just to make changes to the crappy `CSNode` is to this day something I don't want anyone to go through ever. 

When I read *API Design for C++* by Martin Reddy and *Code Complete* by Steve McConnell I was always thinking **So this is like it is huh?** similar like when you are watching a movie, say Interstellar, and something so unbelievable happens that irks you deep within your soul, and you just say **Ok ok, this stuff is awesome, I'm going to accept this, because I don't know shit**.

I think like that, and I though people thought like that, I was wrong. Truth is, most people I ran with are the kind that say **Who cares man? Header file? Meh, just put everything in one source file and be done with it. Nine thousand lines in one source file? Nah man, doesn't need a refactoring yet.**

But I digress. I love Object Oriented Programming.

But C is still to this day blazingly fast and putting other languages to shame. One friend told me, your C++ is crap, I was programming Python at the time so I didn't put any attention. 

<p align="center">
  <b>Until he said Objects are shit.</b><br>
  <img src="http://i190.photobucket.com/albums/z192/Def_Fit/14sntcy.gif" alt="what"><br>
  <a href="http://research.scee.net/files/presentations/gcapaustralia09/Pitfalls_of_Object_Oriented_Programming_GCAP_09.pdf" target="_blank"><b>Then he threw a Sony presentation at my face.</b><br><img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1416062528/Image_079_dut5a3.png" alt="SonyPresentation"></a>
</p>

The presentation concludes one main idea.

> Design based on your data. Placed all your data contiguously so that memory access is fast.

That was mind blowing, I had never though of that. Then I remembered one headline, <a href="http://arstechnica.com/information-technology/2013/05/native-level-performance-on-the-web-a-brief-examination-of-asm-js/" target="_blank">Surprise! Mozilla can produce near-native performance on the Web</a>

And I remember a Google Developers presentation. <a href="http://v8-io12.appspot.com/" target="_blank">Google V8 Engine Optimization presentation.</a> In it they explain some... 

> Design based on your data

Datatypes, initialization, everything correlates to how you use and handle your memory.

##Maybe our Data Oriented Design means that our Object Oriented Programming is Incomplete

Maybe we should be doing C Style Objects everywhere, maybe we should put all data contiguosly everywhere, maybe the rise of Javascript is telling us that placing data in its own object and bind it using functions is the right thing.

So I decided to try it out. To use only C Style objects, no matter what, no matter how.

And it led to some amazing simplicity, I find myself dedicating more time adapting objects. Recently I had to parse json, I was working with C++, so I used a library named <a href="https://github.com/miloyip/rapidjson" target="_blank">Rapidjson</a>.

I created C Style Objects to represent the Json Object.

<div class="row">
  <div class="col-xs-3">
  <img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1416028877/CustomerAchievement_nhp9jp.png" alt="objects">
  </div>
  <div class="col-xs-9">
<pre>
  <code class="language-javascript">
  {
    "customer_data": {
        "name": "Foo Bar", "age": "102", "height": "180",
        "achievements": [
            { "name": "Completed GOW", "date": 2012 },
            { "name": "Completed FF", "date": 2014 },
            { "name": "Completed WOW", "date": 2058 } ]
    }
}
  </code>
</pre>
  </div>
</div>

Problem is mapping one to the other, so that we may use pure objects. So to do this a create a map using one instance of my object and the names of the variable in my json. 
####Mapping
![Mapping](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1416032147/Mapping_gng6qq.png)

Similarly, we need to inverse map if we want to translate easily to the Json string.
####Inverse Mapping
![InverseMapping](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1416032488/MappingInverse_b1ibua.png)

###The values are references in an object

So by this same principle, we need to create a map that uses an instance to an object. We use the reference to each variable inside that instance to map it to the variable name in the Json.

Let's say we received a json in a string, we want to parse it, I use rapidjson for this.

```language-cpp
rapidjson::Value::ConstValueIterator elItr = itr->Begin();
auto vectorItr = cfgMap.configMap.find(elItr->GetString());
if(vectorItr != cfgMap.configMap.end()) {
  for (++elItr; elItr != itr->End(); ++elItr) {
    vectorItr->second->push_back(elItr->GetString());
  }
}
```

This is an example of how to extract information, we need to parse that information into our objects. We search the json for what we want without hard coding in multiple places. And we want to create this map in the following way:

```language-cpp
Customer customer;
ElementAdapter<CustomerPolicy<Input>> configurationMap(customer);
AdaptJsonUsingRapidjson(configurationMap);
// Use customer object for whatever our needs
```

The objects will look as follows:

<div class="row">
  <div class="col-md-8">
<pre>
  <code class="language-cpp">
struct Customer {
    std::string name; 
    std::string age;  
    std::string height;   
    typedef Achievement inner_element;  
    typedef std::vector< inner_element > ::iterator inner_iterator;
    std::vector< inner_element > achievementList;
  };
  </code></pre>
  </div>
  <div class="col-md-4">
<pre>
  <code class="language-cpp">
struct Achievement {
    std::string name; 
    std::string date;   
  };
  </code>
</pre>
  </div>
</div>

So this means we need some policies, but first we define the interface, this may not look like an interface, but I believe in the following:

> The interface should depend on the implementation

And I may go to hell for it, I don't care. We pass down the `configMap` variable, which holds all the things we need, which are the things from the Mapping and Inverse Mapping (Yes, this interface will work for both).

```language-cpp
template<class StructPolicy>
struct ElementAdapter {
  typename typedef StructPolicy policy;
  typename typedef policy::Element element;
  typename typedef policy::primary primary;
  typename typedef policy::secondary secondary;
  typename typedef std::map<primary, secondary> ConfigurationMap;
  typename ConfigurationMap configMap; 
  typename typedef ConfigurationMap::iterator iterator;
  typename typedef ConfigurationMap::const_iterator const_iterator;
  policy instance;

  ElementAdapter(){}
  ElementAdapter(element &el){
      instance(el, configMap);
    }
  void operator()(element &el){
      instance(el, configMap);
    }
};
```

So now we need to define the Policy for each struct, in this case the `CustomerPolicy` and the `AchievementPolicy`.

```language-cpp
/*! @brief StructPolicy Customer Policy - Metafunction Object maps 
 * Customer struct to the json variables names
 * @details
 * Usage: <pre class="prettyprint">CustomerPolicy<IOPolicy> instance;
 * instance(Customer, std::map<IOPolicy::primary, IOPolicy::secondary>, bool=true);</pre> 
 * @tparam IOPolicy Input or Output */
template<template<typename T = std::string> class IOPolicy >
class CustomerPolicy {
public:
  /// @brief IOPolicy Input or Output
  typename typedef IOPolicy<> IOType;
  /// @brief string or string*
  typename typedef IOType::primary primary;
  /// @brief string or string*
  typename typedef IOType::secondary secondary;
  /// @brief struct that its binding to names
  typedef Customer Element;
  /// @brief A typedef for the inner map
  typename typedef map<primary, secondary> InnerMap;
  /// @brief IOPolicy instance
  IOType ioPolicy;

  /// @brief Default Constructor
  CustomerPolicy(){}

  /*! @brief Maps the struct element to variable names according
   * to the specified policy. This changes are reflected in the
   * configMap which has Customer attributes addresses and the 
   * name of that variale in the JSON object
   * @param element the IOPolicy object we are mapping
   * @param configMap Maps JSON attribute names and variables in a Structure */
  void operator()(Element &cfg, InnerMap &configMap){
      std::vector<std::string> keyVector { "name", "age", "height" };
    std::vector<std::string*> variablesVector { &cfg.name, &cfg.age, &cfg.height };  
    ioPolicy(variablesVector, keyVector, configMap);
    }
};


/*! @brief StructPolicy Achievement Policy - Metafunction Object maps 
 * Achievement struct to the json variables names
 * @details
 * Usage: <pre class="prettyprint">AchievementPolicy<IOPolicy> instance;
 * instance(Achievement, std::map<IOPolicy::primary, IOPolicy::secondary>, bool=true);</pre> 
 * @tparam IOPolicy Input or Output */
template<template<typename T = std::string> class IOPolicy >
class AchievementPolicy {
public:
  /// @brief IOPolicy Input or Output
  typename typedef IOPolicy<> IOType;
  /// @brief string or string*
  typename typedef IOType::primary primary;
  /// @brief string or string*
  typename typedef IOType::secondary secondary;
  /// @brief struct that its binding to names
  typedef Achievement Element;
  /// @brief A typedef for the inner map
  typename typedef map<primary, secondary> InnerMap;
  /// @brief IOPolicy instance
  IOType ioPolicy;

  /// @brief Default Constructor
  AchievementPolicy() {}
  
  /*! @brief Maps the struct element to variable names according
   * to the specified policy. This changes are reflected in the
   * configMap which has SkuElement attributes addresses and the 
   * name of that variale in the JSON object
   * @param element the IOPolicy object we are mapping
   * @param configMap Maps JSON attribute names and variables in a Structure  */
  void operator()(Element &element, InnerMap &configMap, bool const &toFile=true) {
    std::vector<std::string> keyVector { "name", "date" };
    std::vector<std::string*> variablesVector { &cfg.name, &cfg.date };  
    ioPolicy(variablesVector, keyVector, configMap);
    }
};
```

So now we map each variable to the string and viceversa.

```language-cpp
/*! @brief IOPolicy - Input Policy - Function Object 
 * @details
 * Usage: <pre class="prettyprint">Input instance;
 * instance(std::vector<string*>, std::vector<string>, std::map<string, string*>);</pre> */
template<class T>
class Input {
public:
  /*! @brief The primary type allows to set the std::map<primary, string*> 
   * in the interface */
  typedef std::string primary;
  /*! @brief The secondary type allows to set the std::map<string, secondary> 
   * in the interface */
  typedef typename T* secondary;

  // Default Constructor
  Input();

  /*! @brief maps all (string)->(string variable) by 
   * doing a zip(strings, string variables). 
   * @param variables struct attributes we are mapping onto keys
   * @param keys the variable name in a json object
   * @param configMap the map we need to fill to map our json object to its respective
   * variable name
   * @return Changes configMap */
  void operator()(std::vector<secondary> &variables, std::vector<std::string> &keys, 
                std::map<std::string,secondary> &configMap){
        auto itrVal = variables.begin();
      if(variables.size() == keys.size()){
      for(auto it = keys.begin(); it != keys.end(); ++it) {
        configMap[it->c_str()] = *itrVal;
      advance(itrVal, 1);
      }
      } else {
      // error
      }
    }
};

/*! @brief IOPolicy - Output Policy - Function Object 
 * @details
 * Usage: <pre class="prettyprint">Output instance;
 * instance(std::vector<string*>, std::vector<string>, std::map<string*, string>);</pre> */
template<class T>
class Output {
public:
  /*! @brief The primary type allows to set the std::map<primary, string> 
   * in the interface */
  typedef typename T* primary;
  /*! @brief The secondary type allows to set the std::map<string*, secondary> 
   * in the interface */
  typedef std::string secondary;

  // Default Constructor
  Output(){}

  /*! @brief maps all (string variable)->(string) by 
   * doing a zip(string variable, string). 
   * @param variables struct attributes we are mapping onto keys
   * @param keys the variable name in a json object
   * @param configMap the map we need to fill to map our json object to its respective
   * variable name
   * @return Changes configMap */
  void operator()(std::vector<primary> &variables, std::vector<std::string> &keys, 
                std::map<primary,std::string> &configMap) {
       auto itrVal = keys.begin();
     if(variables.size() == keys.size()){
       for(auto it = variables.begin(); it != variables.end(); ++it) {
         configMap[*it] = *itrVal;
       advance(itrVal, 1);
       }
     } else {
     //error
     } 
     }
};
```

So what we have so far is a class diagram like the one that follows:

<a href="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415637311/Overview_of_RetrievalUtil_vxzaee.svg" target="_blank"><img src="http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1415637311/Overview_of_RetrievalUtil_vxzaee.svg" alt="ClassDiagram"></a>

Notice that is the no template parameter in the `Input` and `Output` objects. Because this was when I needed to use pure strings.

But wait... there is more... What if we want to map a different structure, let's say some vectors. Thus we need another object.

<div class="row">
  <div class="col-md-4">
  <pre>
  <code class="language-javascript">
  {
    "customer_data": [
        [],
        [],
        [],
        [],
        []
    ]
  }
  </code>
  </pre>
  </div>
  <div class="col-md-8">
  <pre>
  <code class="language-cpp">
struct AnotherObject {
    std::vector< std::string> one;
    std::vector< std::string> two;
    std::vector< std::string> three;
    std::vector< std::string> four;
    std::vector< std::string> five;
  }
  </code>
  </pre>
  </div>
</div>

Then all we need is another `StructurePolicy`, and the template parameter in the `IOPolicy` (The `Input` and `Output`).

```language-cpp
template<template<typename T = std::vector<std::string> > class IOPolicy>
class AnotherObjectPolicy {
public:
  /// @brief IOPolicy Input or Output
  typename typedef IOPolicy<> IOType;
  /// @brief string or std::vector<std::string>*
  typename typedef IOType::primary primary;
  /// @brief string or std::vector<std::string>*
  typename typedef IOType::secondary secondary;
  /// @brief struct that its binding to names
  typedef ConfigurationTestData Element;
  /// @brief A typedef for the inner map
  typename typedef map<primary, secondary> InnerMap;
  /// @brief IOPolicy instance
  IOType ioPolicy;

  /// @brief Default Constructor
  AnotherObjectPolicy(){}
  
  /*! @brief Maps the struct element to variable names according
   * to the specified policy. This changes are reflected in the
   * configMap which has SkuElement attributes addresses and the 
   * name of that variale in the JSON object
   * @param element the IOPolicy object we are mapping
   * @param configMap Maps JSON attribute names and variables in a Structure */
  void operator()(Element &element, InnerMap &configMap, 
    bool const &toFile=true){
      std::vector<std::string> keyVector { "one", "two", "three", "four", "five" };
      std::vector<std::vector<std::string>* > variables {&cfg.one, &cfg.two, &cfg.three, &cfg.four, &cfg.five };
    ioPolicy(variablesVector, keyVector, configMap); 
    }
};
```

And that's it. Two use out mapping of the Vectors to string we just do:

```language-cpp
ElementAdapter<AnotherObjectPolicy<Input> > configMapTwoVectors;
AnotherObject instance;
configMapTwoVectors(instance);
```

Then we use that config map to parse from the Json using rapidjson, and then in our software we work only with the defined structures.

This creates very clean and simple functionality on the business code, and removes any garbage regarding parsing.

Working with a model and working with ordered data is fantastic, as it allows a much better order than working with dirty raw strings. Remember, Parse once, use infinitely. 

So now we parse the input json into the object as follows.

```language-cpp

/// @brief The Highest level, we process the jsonText
ParsingError ParseJson(std::string const &jsonText){
  Customer customerInstance;
  ElementAdapter<CustomerPolicy<Input> > cfgMap(customerInstance);
  rapidjson::Document document;
  if(document.Parse(jsonText.c_str()).HasParseError())
    return ParsingError::ParseError;
  if(!document.IsObject())
    return ParsingError::NoJsonObject;

  rapidjson::Value::MemberIterator variable = document.FindMember("customer_data");
  if(variable == document.MemberEnd()) 
      return ParsingError::NoCustomerDataObject;
  ProcessCustomer(variable->value, cfgMap);
    ProcessAchievements(variable->value, customerInstance);
  return ParsingError::Success;
}

/// @brief in here we process the first elements
void ProcessCustomer(rapidjson::Value &customerData, ElementAdapter<CustomerPolicy<Input> > &cfgMap){
  for(ElementAdapter<CustomerPolicy<Input> >::iterator it = cfgMap.configMap.begin(); it != cfgMap.configMap.end(); ++it) {
    rapidjson::Value::MemberIterator variable = customerData.FindMember(it->first.c_str());
    if(variable != customerData.MemberEnd() && variable->value.IsString()){
      *(it->second) = std::string(variable->value.GetString());
    }
  }
}

/// @brief Here is the top level for managing achievements
void ProcessAchievement(rapidjson::Value &customerData, Customer &cfg) {
  const rapidjson::Value& a = customerData["achievements"];
  assert(a.IsArray());
  cfg.achievementList.reserve(a.Size());
  for (rapidjson::Value::ConstValueIterator itr = a.Begin(); itr != a.End(); ++itr) {
    Customer::inner_element achievement;
    ProcessAllAchievements(itr, achievement);
    cfg.achievementList.push_back(achievement);
  }
}

/// @brief This is the top level, the array of Achievements
void ProcessAllAchievements(rapidjson::Value::ConstValueIterator &itr, Customer::inner_element &achievement) {
  ElementAdapter<AchievementPolicy<Input> > map(achievement);
  for(ElementAdapter<AchievementPolicy<Input> >::iterator it = map.configMap.begin(); it != map.configMap.end(); ++it) {
    rapidjson::Value::ConstMemberIterator variable = itr->FindMember(it->first.c_str());
    if(variable != itr->MemberEnd())
    {
      ProcessSingleAchievement(variable, *(it->second));
    }
  }
}

/// @brief Here we process ONE Achievement
void ProcessSingleAchievement(rapidjson::Value::ConstMemberIterator &variable, std::string &strRhs) {
  // This could very well be a switch case depending on the json input
  if(variable->value.IsString()){
    std::string tmp(variable->value.GetString());
    strRhs = tmp;
  } else {
    std::stringstream ss("");
    ss << variable->value.GetInt();
    strRhs = ss.str();
  }
}
```

###It may seem like much

But trust me, now you only add variables to the ElementAdapter mechanism and this simple processing will get new variables from the json text. 

The main purpose is to use a Model of our variables to work with, and in one stage we work and work and work on adapting whatever is comming to that Model, which makes it really easy for us to extend the business logic.

I recently was involved in a project that included parsing json strings from the web, and decided to use C++ for cross platform reasons and because I had no authorization to installing anything in the client's computer. I was only going to be ablet to ship an exe.

I was given very little amount of requirements, thus I was expecting things to grow (usually when you are given a small amount of information you can expect things to grow fast). And yes, things grew more fast than expected, with little time for refactoring and regression testing (which is not required by the customer) it is important to prethink these things, specially if you are expected to ship in a matter of days. 

So thanks to using a model we where able to add regression tests, a build system, and we are way on track on adding Continuous Integration. 


