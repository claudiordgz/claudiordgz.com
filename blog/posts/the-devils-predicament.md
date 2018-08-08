---
title: The Devil's Predicament
slug: the-devils-predicament
date_published: 1970-01-01T00:00:00.000Z
date_updated:   2014-03-17T05:08:59.038Z
tags: c++
draft: true
---

DISCLAIMER: This case arises from the an implementation done on a real world System, for which abstraction and design were done differently. All persons appearing in this work are ficticious. Any resemblance to real persons, living or dead, is purely coincidental.

Homer Simpson, Garfield, Ron Weasley, Heffer, Petter Griffin, and Cartman are in a van riding together up to a Justin Bieber concert when God felt so dissapointed in them that struck them with Hellfire. The whole pack burned up in flames and ended down in hell.
Down in Hell the Devil was tracking his methodologies trying to implement Six Sigma in all his torture factories when suddenly one of his Supervisor Hellspawns reports to him, Sir, we have 6 newcommers, and the Devil said, What did they do?, his Supervisor just said, they were Beliebers.
Say no more, replied the Devil.
So what do we got on them? 
They love eating, answered his Hellspawn. The Devil replied, I think I have a dejavú with some of these guys, and his Hellspawn replied, Yes sir, you have over fed them before, some of them anyway. Well, let's try that again, said the Devil. But sir, the supplies, said his Hellspawn with a worrysome frown, Oh Shit! the supplies. He made a pause for a moment, taking a second to breath and consider his options. His eyes wandered to his factories, they looked ravaged by time, as if they were a sand blasted mirror on the point of breaking. Alright then, give them floury crap. His Hellspawn looked confused, Floury?. Yes yes, you know, pastries, pasta, bread, carbs, whatever you give 'em stay off the protein, we need the protein for the succubus. 

So the Devil is the Manager of the food, and he orders just things with carbs for each Hellspawn in charge of each subject, in this case:

    - Homer Simpson
    - Garfield 
    - Ron Weasley
    - Heffer 
    - Petter Griffin 
    - Cartman 

That's means we have 6  Hellspawns and 6 Subjects. Plus a continuous stream of carb food to feed them. The Hellspawns are in charge of overseeing that each of the subjects eats at least the double calories needed of the point of not being able to breathe correctly anymore. So for example Homer Simpson needs 5000 calories to reach his "I can't breath properly anymore," thus the Hellspawn must feed Homer 10000 calories in one sitting, this will make Homer collapse into a coma. 
The foods the Devil is going to provide for his Hellspawns is the following:

###The floury stuff food groups###

![The Food Groups!](http://res.cloudinary.com/www-claudiordgz-com/image/upload/v1395032775/thefoodgroups_yi59kg.png)

As you can see, it is a lot of food, it comes in different groups of which he just grabs and gives. But the Devil doesn't sweat it and just hands groups as they come to their attention. 
This amount of food comes catalogued with quantity, units and calories per unit. But since unit are different from one another we should have a conversion table. We need every Hellspawn to know the conversion table but it is a waste of resources to instantiate a conversion table for every hellspawn. So instead we are going to think of the hellspawns as a group that has access to a collective memory everyone shares (kinda like having one conversion table in a laminated paper and everyone must share it). This is a great opportunity to test the Registry Pattern by Martin Fowler.
