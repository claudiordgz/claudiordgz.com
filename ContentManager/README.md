# CI/CD Tools for claudiordgz.com content

## CLI Options

  - `{InputType} i, input` The directory to process, ALL to process all directories
    ```
	enum InputType {
		ALL,
		BLOG,
		FEEDS,
		PROJECTS,
		STUDY
	}
	```

  - `{BuildType} t, type` Instructs to process diff from latest tag or all content
	```
	enum BuildType {
		ORIGIN,
		INCREMENTAL
	} 
	```

```
Content is created in markdown in it's own folder
Push to repo triggerS:
if environment variable 'INPUT' is ALL
     process all directories
else
     process only specific directories
if environment variable 'TYPE' is ORIGIN
     process all content
else
     process differences between HEAD and last tag
Each change (POST OR FEED), pushed forward
new changes will need to get deployed
blog
 each POST creates new item
feeds
 1 xml file
 file contains FEEDS
 each FEED creates new item
 each FEED triggers service that pulls posts as individual items <-- maybe?
study
 each directory is STUDY and creates new item
 each POST in STUDY creates new item
projects
 each directory is PROJECT and creates new item
 each POST in PROJECT creates new item
 ```