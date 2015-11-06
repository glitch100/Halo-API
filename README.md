# Halo API

A C# Wrapper for the official Halo 5 API that can be seen at [http://developer.haloapi.com](http://developer.haloapi.com) - Easy to use, and implement. 

*Current Version: 0.5*

###Currently Supported
- GetMatchesForPlayer
- GetArenaPostGameCarnageReport
- GetArenaServiceRecords


Currently in the process of modelling everything out. Adding more endpoints as I go and building tests seperately. Once in a more comfortable position then I will add more advanced features once all endpoints are complete

####Usage

```C#
//Initialize service with API Token. Optionally provide base api url
var haloApiService = new HaloAPIService("MYAPITOKEN");
//Retrieve the player matches from an associated gamertag,with optional gamemode, 
//start and count
var playerMatches = await haloAPIService.GetMatchesForPlayer("Glitch100", GameMode.Arena);
//Example of returning gamevariants from the match result set 
var gameVariants = playerMatches.Results.Select(r => r.GameVariants);
```

####On the way
- Adding more endpoints
- Full test coverage
- More advanced logic and determination

####Help? 
Contact me on Twitter @Glitch100

####Notes

Please note that if you pull the repo the tests will need your API Key in order to pass as I haven't interfaced out the `HttpClient` and they rely on genuine data.

