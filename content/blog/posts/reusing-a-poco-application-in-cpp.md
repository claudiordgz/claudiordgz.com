---
title: Reusing a Poco Application in C++ for regression testing
slug: reusing-a-poco-application-in-cpp
date_published: 2014-11-20T06:12:20.328Z
date_updated:   2015-07-24T12:12:28.275Z
tags: C++, policy based design, Poco
---

Here is the definition of the POCO Libraries from the <a href="http://pocoproject.org/" target="_blank">website itself.</a>

>Modern, powerful open source C++ class libraries and frameworks for building network- and internet-based applications that run on desktop, server, mobile and embedded systems.

I've had very little experience with the POCO libraries. So far all I've done with them has been communicating with a web service using the NET SSL and `OpenSSL`, using `auto_ptr`, and handling the POCO `Application`, and some `mutex` operations, and that's been across different projects.

##Motivation

This post is going to be specifically about `POCO::Application`, I had to experiment a bit with it to get what I wanted. 

My requirements are the following:

- The developer must access whichever argument he wants using a simple map. (in this case me)
- The user must be able to pass arguments with no values such as `/test` or `-test`.
- The developer must be able to run the application's main method multiple times with a different set of arguments. (for regression testing purposes)

Poco Application provides the `OptionSet` which is the container that has all the information regarding the user arguments. Except that it can't handle arguments with no value. It's not that I hate the `OptionSet`, it is that it provides way too much fodder.

To prevent all this fodder and hopefully handle all the states in a different place we create a map of the arguments the user provided. This way we can replace the map inside a test application that runs the `main` all over again.

This may differ from production or deployment testing, but is really useful for batch testing and sending all to a log file (which will require further hacks). 

But make no mistake, being able to run the `main` using different arguments without reinitializing anything is a very powerful tool for debugging, it helps finding state errors and finding if you are leaving a dirty state from one run to the next. Which will further help you should you choose to make the jump from a standalone CLI executable to a full fledged web service or application.

##Building a Poco Application

Once you have finished the following chores you'll be ready to get your Poco Application up and runnign.

1. Download poco libraries
2. Link Poco Libraries to your C++ project.

Then it all becomes a matter of filling the default stuff.

```language-cpp
class SampleApplication : public Poco::Util::Application {
public:
  SampleApplication();
  virtual ~SampleApplication(){}
    
protected:  
  /// This is all the boilerplate
    int main(const std::vector<std::string>& args);
  void initialize(Poco::Util::Application& self);
  void uninitialize();
  void reinitialize(Poco::Util::Application& self);
  void defineOptions(Poco::Util::OptionSet& options);
  void handleHelp(const std::string& name, const std::string& value);
  void handleDefine(const std::string& name, const std::string& value);
  void handleConfig(const std::string& name, const std::string& value);
  void displayHelp();
  void defineProperty(const std::string& def);
  void printProperties(const std::string& base);
  
private:
  // Your own personal stuff

};
```

You can find this boilerplate inside the SampleApp in `Poco\Util\samples` of your downloaded Poco Folder.

I'm not getting into the specifics of how to define the options or how to fill each of the methods in the boilerplate. 

###Running our application free of the Preprocessor

Poco recommends using the `POCO Main Macro` as follows:

```language-cpp
POCO_APP_MAIN(SampleApplication)
```

But this creates the problem that we can only test the deployable executable, which is not that bad if you have a design that allows it. But we want to leave all the state processing inside the `Poco Application` and the rest to some worker `agents`.

And we want to be able to run continuously without making a mess of the states. We need to prevent a damaged or dirty state. 

Now let's say we want to run our without that macro.

```language-cpp
int main(int argc, char** argv)     
{                   
  Poco::AutoPtr<SampleApplication> pApp = new SampleApplication;  
  try                 
  {                 
    pApp->init(argc, argv);     
  }                 
  catch (Poco::Exception& exc)    
  { 
    std::string s1 = argv[0];
    s1 = s1.substr(0, s1.find_last_of("\\/"));
    s1.append("/");
    SampleApplication::ApplicationMethods::SetLogger(s1, &pApp->logger());
    log(exc.what(), &pApp->logger());
    pApp->logger().log(exc);      
    return Poco::Util::Application::EXIT_CONFIG;
  }                 
  return pApp->run();         
}
```

Pretty simple. Problem is our Poco Application may return a mess of exceptions:

- Released the Logger and reinitialized to the same file... exception
- Released the logger and then the application... exception (double `delete`)
- Reinit the application without closing it properly... exception

So... don't try anything funny, KISS. 

The `SetLogger` just creates a logging file:

```language-cpp
void SetLogger(std::string const &appDir, Poco::Logger *logger, bool const &rerouteToConsole=false) {
  std::string lAppDir = appDir, loggerType;
  lAppDir.append("SampleLog.log");
  if(!rerouteToConsole)  {
    logger->setChannel(new Poco::SimpleFileChannel(lAppDir));
        loggerType = "FileLogger";
  } else {
    logger->setChannel(new Poco::ConsoleChannel);
        loggerType = "ConsoleLogger";
  }
    logger->open();
  logger->create(loggerType.c_str(), logger, Poco::Message::PRIO_WARNING); 
}
```

###Modifying for regression testing

While this main method works and **BREAKS** wonderfully when something goes wrong, we really want to be able for our application to sleep gently into that goodnight. 

So, if we want to run our main several times and only initializing once... here is what we do:

```language-cpp
int main(int argc, char** argv)     
{       
  std::unique_ptr<SampleApplication> pApp(new SampleApplication); 
  std::string s1 = argv[0];
  std::array<std::string, 2> Test = { "", "/test" };
  std::vector<std::string> args(Test.begin(), Test.end());
  pApp->init(args); 
  pApp->run();
  auto payloads = TestPayloads();
  for(auto &payload : payloads){
    pApp->ReassembleArguments(payload); ///< Here we reload the arguments in our Model
    pApp->main(args); ///< This args is useless, sorry guys
  }
  pApp->release();
  pApp.release();
}
```

Every payload is a set of arguments to pass to the system, in a form of our nifty map.

###Keeping state handling under control

Our application is comprised of some worker agents that perform the tasks at hand, the application shares the resources between the agents. There is no communication between the agents, there is only a trade of information. 

We do this because the application receives the arguments, and we need to test every single optional argument, and fill in what's missing with what is appropiate. 

Just check out this mess...

```language-cpp
int SimpleApplication::main(const std::vector<std::string>& args) {
  log("SimpleApplication logging facility", &logger());
  if(_noop) {
    log("ERROR: No argument provided... shutting down", &logger());
    displayHelp();
    stopOptionsProcessing();
  } else {
    int error = checkConfig(false);
    if(error) {
      log("ERROR: Could not open directory of user configuration", &logger());
      return error;
    }

    if (!_helpRequested) {
      // Running only user configuration
      if(!_arguments["autorun"].empty()) {
              StatePolicy<STATES::RunFromConfig> state(this->_config);
      } else {
        if(_configAgent.GetConfigurationStatus()) {
          int bitmap=0;
          SampleError error = _configAgent.ProcessConfig(); 
          if(error != SampleError::Success) {
            log("ERROR: Configuration Problem", &logger());
          } 
          STATES diff = getState();
          // Only Sku and Version And/Or Message Provided
          if(diff == STATES::RunFromConfig) {
            log("Running RunFromConfig", &logger());
                        StatePolicy<STATES::RunFromConfig> state(this->_config);
          // All arguments provided
          } else if (diff == STATES::RunFromArguments) {
            log("Running RunFromArguments", &logger());
            StatePolicy<STATES::RunFromArguments> state(_arguments);
          } else if (diff == STATES::RunWithoutAType) {
                        log("Running RunWithoutAType", &logger());
                        StatePolicy<STATES::RunWithoutAType> state(_arguments);
          } else {
            log("ERROR: Not enough arguments given", &logger());
          }
        } else {
          // All arguments provided
          if (diff == STATES::RunFromArguments) {
            log("Running RunFromArguments", &logger());
            StatePolicy<STATES::RunFromArguments> state(_arguments);
          } else {
            log("ERROR: No configuration or not enough arguments", &logger());
          }
        } 
      }
    } 
  }
  log("EXIT: Process finished \n\n", &logger());
  return Application::EXIT_OK;
}
```

State handling should get its own space, because it sure as hell requires it. Being able to see the big picture is just one place is really helpful, and the state handling gets so easy you can slice it like its cheese and butter melting under a 120 degree sun. 

###The State is separated fromt he rest of the implementation

So yeah we define each state in their own gorgeous policy, and et voilá... clean stuff.

And we can test the hell out of everything.

And then we add it to Strider Continuous Deployment. 

Happiness ensues, beers, cheers. 

###Reparsing the user input and sending to `main`

Here comes the tricky part... you need a way to rewrite the arguments. I used a **something** for this example, but you can use anything as the model.

```language-cpp
auto payloads = TestPayloads();
```
I used a `map` that holds the arguments, and in the application I defined a `ReassembleArguments(map)` method. This method should be the easiest to replace possible, remember, you want to test fast. 

The `ReassembleArguments` also needs to `reset` the state. And perform any necessary cleanup for the next run. In my case I never used the arguments from the `main` method but you could also use that, of course you need to receive a `vector` of arguments which for me is like a sin, if I can do it easier in the future, then easier it is.

Just remember to test your executable as well.

###Converting from `OptionSet` to something else

`OptionSet` holds the `Option`s, no pun intended. Each option holds all the data that defines that options, which is the full name, the short name, and the rest of the information. We want to search our arguments, those are contained in the `AbstractConfiguration`, which is whatever the user entered.

Sadly, the `AbstractConfiguration` may receive the full name or the short name of the option. Thus we need to be able to handle both.

```language-cpp
/*! @brief Builds our model of the user arguments. */
void SampleApplication::MapUserArguments(){
  std::map<std::string, std::string*> optionMapFullName;  
  std::map<std::string, std::string*> optionMapShortName;
  Poco::Util::OptionSet options = Application::options();
    // Both Maps will point to the same string
  vector<std::string> arguments(std::distance(options.begin(), options.end()));
  std::size_t counter = 0;
  for(Poco::Util::OptionSet::Iterator it = options.begin(); it != options.end(); ++it) {
    optionMapFullName[it->fullName()] = &arguments[counter];  
    optionMapShortName[it->shortName()] = &arguments[counter];
    ++counter;
  }
    // Know we search the user input for what he entered
  ConfigureOptionMaps(optionMapFullName, optionMapShortName);
    // We can use only one of the maps at last, the other one served its purpose
  auto ss(AssembleArguments(optionMapFullName));  
  // Yes, I'm always logging
  log(ss, &logger());
}
```

To process the input from the user we need to iterate the `AbstractConfiguration` and extract our pertinent arguments we want.

```language-cpp
/*! @brief Searches and fills the possible arguments with 
 * the actual values from the user input. */
void SampleApplication::ConfigureOptionMaps(
    std::map<std::string, std::string*> &fullName, 
        std::map<std::string, std::string*> &shortName){
  std::string base = "application";
  Poco::Util::AbstractConfiguration::Keys keys;
  config().keys(base, keys);
  for (auto it = keys.begin(); it != keys.end(); ++it) {
    auto fullKey = getFullKeyToArg(base, *it);
  if(!NumberOfArgsOrFirstArgs(it)){  // If arv[0]/argc don't process
      // a pair with the argument and the position of '='
    auto argAndDelim = GetArgAndDelimiterPosition(config().getString(fullKey));
    if(argAndDelim.second != std::string::npos) {
        // separate argument=value and place it in the model
        std::string argumentValue = ProcessOptionAndValue(argAndDelim.second, argAndDelim.first);
        AppMethods::addToUserModel(fullName, shortName, argAndDelim.first, argVal);
      } else {
        // if the argument has no value then place true in the model
        AppMethods::addToUserModel(fullName, shortName, argAndDelim.first, "true");
      }
    _noop = false;
    }
  }
}
```

Finally we also need to add the variables to the model, we use either the short name or the full name or the argument, both point to the same string. 

```language-cpp
/*! @brief Add the argument and value to the user model 
 * throws and stops everything if input is invalid */
void addToUserModel(std::map<std::string, std::string*> &optionMapFullName, 
    std::map<std::string, std::string*> &optionMapShortName,
    std::string const& msg, std::string const &argument) {
  auto it = optionMapFullName.find(msg);
  if(it == optionMapFullName.end()) {
    it = optionMapShortName.find(msg);
    if(it == optionMapShortName.end()) {
      Poco::InvalidArgumentException p;
      throw p;
    } else {
      std::string *ptr = optionMapShortName[msg];
      *ptr = argument;
    }
  } else {
    std::string *ptr = optionMapFullName[msg];
    *ptr = argument;
  }
}

```

###The future looks extendable

The main advantage of working with a user model is that we can extend functionality to the states in a very simple manner. Furthermore, assembling our inner model of the data from the user input gets easier and allows us to predict the user's intentions when using the application. Thus we can make more interesting things with out states. 

The ability to run the main continuously does add some interesting behavior and possibilities to the application and allow for better decoupling between the inner parts.
