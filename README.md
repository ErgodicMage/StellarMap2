# StellarMap2
I originally started programming StellarMap back in 2018 because of my fascination with Winchell Chung's 3D StarMaps https://www.projectrho.com/public_html/starmaps. I also wanted to update my C# programming to include .NET Core (2.1 at the time) to learn the platform and the new features.

6 years later I want to rewrite the entire StellarMap project from scratch. There are several reasons for this:

* Upgrade to .NET 8 using new features of it.
* Include new programming paradigms and techniques into StellarMaps.
* Revisit some of the original design choices.
* Simplify the design and implementation.


## Goals
Experiment and incorporate more functional programming techniques, to improve my skill in the functional paradigm.

Reduce complexity in the code. There are times which I have to spend time determining what I did over the years and it's not always clear how and why I did some things.

Challenge myself to change and improve as a programmer. And of course have some more fun working with star maps.

## Design Considerations

### Maps
In StellarMap there is a stong relationship between StellarBodies (stars, planets, etc.) and the mapping. This can lead to complicated refernces with objects and the maps, leading to code that can be difficult.

#### Map as background context
Having a map that contains the bodies makes sense in order to provide a background (or context) for everything. At this point I think it's a good design choice and will probably keep it. So all objects will have a map that it's associated with. 
I will likely be removing the default map though and force a map to be created.

#### Map storing objects by type
The current Map design stores all objects in a dictionary (for example Planet dictionary) and not with the "parent" object itself. The "parent" object just keeps an identifier to the "child" object and uses the map to retreive the actual object.

One problem with this is that from say a star, one can not immediately get all of the planets. Instead it has to get the indetifiers of the planets and then look them up in the map to get get them. This adds a level of indirection that can be somewhat difficult to follow and adds complexity.

This design does allow better and easier lookup of an object. To look up a planet it just looks at the Planet dictionary instead of having to traverse the entire map as a tree structure. Generating identifiers is also easier done by counting the number of objects of that type and incrementing the number.

It also eases some portions of persistence and serlialization. For example, all planets can be stored in their own Planet table. But should persistence and serialization be a design factor in

Maps do have extra functionality which to implement serialization/deserialization. This functionality is awkard, cumbersome and gets complex to implement.

My initial thoughs is to keep the basic design of seperating objects into their own dictionary. But a better design is needed in serialization/deserialization.

### Objects in Object Oriented heirarchy
Currently all stellar objects form a class heirarchy with StellarBody, StellarBodyParent (yeah horrible name) then Star, Planet etc..
This allows a very good flexibility in adding on new object types which is used well in addon stellar systems wuch as Progression for my fictional hard science fiction setting.
My thoughts now is to keep the OO, but reduce the heirarchy somewhat. Possibly move some of the inherit behaviors to extension methods.

### Serialization
The current serialization/deserialzation handles json files and zipped json files. This was fairly clever in implementation (if I do say so myself), but also leads to alot of complexity in the Mapping classes.

My thoughts are to keep the basic idea but implement it even better such that the mapping is not directly involved in the serialization/deserialization. I.E. move code from the Map to the actual serialing code.

Currently all collections (mainly Dictionaries) use their respective interfaces (IDictionary). This originally lead me to use NewtonSoft JSON which at the time was far superior. Now Microsoft's JSON handling is much better than before, but it doesn't work well with interfaces. Either keep using Netwonsoft or switch to MS and don't use interfaces in serialization/deserialization.

### Handle Complexity better
All code has complexity, but it's a matter of where that complexity is at. Move complexity to the edges such that main functionality isn't as dependent on other more complex portions.

## Programming Considerations
### .NET 8 and higher
Use newer features in .NET 8 (and higher). This will help in keeping up and learning the newest features and programming techniques around them.

### Less Code
Axiom, the more code the more coplexity and the more risk of bugs. Reduce the amount of program code wherever possible. Often this will be in using design patterns where approrpiate.

### Functional programming
In order to learn functional programming better use more of the techniques. This includes pure functions, smaller more predictable functions and using functions as "first class citizens". This will also include more and better use of pattern matching and using Linq when appropriate.

### Builder Patterns
Currently all objects are instatiated and then everything is add directly to the object. Instead look at using builders for such things as Stars, Planets etc..

### Primitive Obsession
Currently StellarMap uses alot of primitive types, particularly strings. For example both identifiers and object types are represented just as strings. Instead of direct strings encapsulate them into types (classes, records, structures) which encapsulates what they do and gives far better type safety.

This is particularly when handling object types. Enums won't work because of other addons (such as Progression) will be adding more types, which Enums don't support. Right now const strings are used which is easily extended with more const strings, but isn't type safe and no guarentee that a string is acutally correct. This is a good place to look into soemthing like Ardalis's SmartEnum or possibly write my own (since Ardalis's work is fairly hefty IMO).

### Result Pattern
I wrote a Nuget package (https://www.nuget.org/packages/ErgodicMage.Result) for implementing the Result Pattern. Use Result and Result<T> to get a better feel of when and how to use them better.

### NestedDictionary
I originally implemented NestedDictionary to provide a class which flexibly haddled many situations. In particularly handling name value properties with an organized tagging mechanism. Though this was interesting to program and implement it introduces alot of complex code that can be hard to follow. Turns out that such flexibility wasn't really used much. I won't be using a NestedDictionary, instead of favoring specific dictionaries to meet the specific need.