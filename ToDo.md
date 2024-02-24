## To Do
* Add Collections of StellarObjects to builders for more flexibility
* Add metadata to StandardStellarMap
* Move physical properties from StellarObject Properties into it's own class
* Utility application to build realistic Solar System and save in json. Add json as resource to Core with deserialization for common use.


## Done
* ~~Remove Type from StellarObjectType~~
* ~~Add Create to StellarObjectType~~
* ~~Add Properties to StellarObject~~
* ~~Remove AlternativeName, Description and Designation from StellarObject, use Properties if needed~~
* ~~Add Common Property constants~~
* ~~Equality for StellarObjects~~
* ~~Remove DwarfePlanet and add IsDwarf parameter to Planet~~
* ~~Builders~~
	* ~~StellarObject~~
	* ~~Star~~
	* ~~Planet~~
	* ~~Satelite~~
	* ~~Asteroid~~
	* ~~Comet~~
* ~~Rename StellarMap to StandardStellarMap so it doesn't confict with the namespace.~~
* ~~Get StallarMap Dictionary<Identifier, T> to work with Json serializer~~
	* I ended up changing IStellarMap from Dictionary<Identifier, T> to Dictionary<string, T>. This was much easier to get the map serialization to work without having to write a complete JsonConverter for Dictionary<Identifier, T>.
* ~~Order objects for serialization for better reading~~
* ~~Get StellarObjectType to work with Json serializer~~
* ~~Move StellarClass from Properties to Star property~~
* ~~Equality tests for stellar objects~~
* ~~Force StandardStellarMap equality to always return false~~
