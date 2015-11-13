Halo API
---------------
<img src="http://i.imgur.com/EP1ilsq.png?1" />

A C# Wrapper for the official Halo 5 API that can be seen at [http://developer.haloapi.com](http://developer.haloapi.com) - Easy to use, and implement. 

Enjoy Halo 5 Guardians Game Data faster than ever before with this wrapper. Currently a WIP and soon to be finished and polished up, the API is updated almost daily with optimisations and more! Download it now, or utilise it via Nuget!

###Current Version: 0.2.0
###Supported Features
- Rate Handling and Limit on Requests!
- Caching of Requests (hourly stats/daily meta)!

**Stats**
- Get Matches ForPlayer
- Get Arena PostGame Carnage Report
- Get Custom PostGame Carnage Report
- Get Campaign PostGame Carnage Report
- Get Warzone PostGame Carnage Report
- Get Arena Service Records
- Get Campaign Service Records
- Get Custom Game Service Records
- Get Warzone Service Records

**Meta Data**
- GetCampaignMissions
- GetCommendations
- Get CSR Designations
- Get Enemies
- Get Flexible Stats
- Get Game Base Variants
- Get Game Variants
- *NEW* Get Impulses
- *NEW* Get Map Variants
- *NEW* Get Maps
- *NEW* Get Medals
- *NEW* Get Playlists
- *NEW* Get Requisition Pack
- *NEW* Get Requistion
- *NEW* Get Skulls
- *NEW* Get Spartan Ranks
- *NEW* Get Team Colours 
- *NEW* Get Vehicles 
- *NEW* Get Weapons 

Only one more set of endpoints to do until we hit the v1 release, at which point, I will begin refactoring and adding in advanced functionality to the Halo API!

####Usage

You can download the source or get it via **NuGet**!
[https://www.nuget.org/packages/HaloEzAPI](https://www.nuget.org/packages/HaloEzAPI)

```C#
//Initialize service with API Token. Optionally provide base api url
var haloApiService = new HaloAPIService("MYAPITOKEN");
//Retrieve the player matches from an associated gamertag,with optional gamemode, 
//start and count
var playerMatches = await haloAPIService.GetMatchesForPlayer("Glitch100", GameMode.Arena);
//Example of returning gamevariants from the match result set 
var gameVariants = playerMatches.Results.Select(r => r.GameVariants);
```

####Future Features On the way
- Adding final endpoints
- More advanced logic and determination
- Culminating results into richer data

----------


####Help? 
Contact me on Twitter **@Glitch100**

####Notes
Please note that if you pull the repo the tests will need your API Key in order to pass as I haven't interfaced out the `HttpClient` and they rely on genuine data.
