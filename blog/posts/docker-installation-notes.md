---
title: Docker Installation Notes
slug: docker-installation-notes
date_published: 1970-01-01T00:00:00.000Z
date_updated:   2014-12-05T01:10:29.904Z
draft: true
---

To install docker in a Linux machine you need a specific Kernel Version. To check that you can see [Docker's recommendation](https://docs.docker.com/installation/binaries/), but as of writing this they recommend Linux Kernel 3.8.

Check the Headers of your Linux Version. 

<a name="checkHeaders"></a> `apt-cache search linux-headers-$(uname -r)`

And to update if necessary:

`sudo apt-get install linux-image-generic-lts-raring linux-headers-generic-lts-raring`

Then reboot the system, and [check again using `apt-cache`](#checkHeaders).


