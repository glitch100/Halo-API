Halo API
---------------
<img src="http://i.imgur.com/EP1ilsq.png?1" />

A C# Wrapper for the official Halo 5 API that can be seen at [http://developer.haloapi.com](http://developer.haloapi.com) - Easy to use, and implement. It contains all current endpoints, tests, a rate handler and a cache system!

Enjoy Halo 5 Guardians Game Data faster than ever before with this wrapper. Currently a WIP and soon to be finished and polished up, the API is updated almost daily with optimisations and more! Download it now, or utilise it via **NuGet**!

###Current Version: 1.2.6

###Supported Features
- Rate Handling and Limit on Requests!
- Caching of Requests (hourly stats/daily meta)!
- All the Endpoints the API has to offer!

**Stats**
- Get Events For Match
- Get Matches For Player
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
- Get Impulses
- Get Map Variants
- Get Maps
- Get Medals
- Get Playlists
- Get Requisition Pack
- Get Requistion
- Get Skulls
- Get Spartan Ranks
- Get Team Colours 
- Get Vehicles 
- Get Weapons 

**Profile**
- Get Emblem Image
- Get Spartan Image


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
- More advanced logic and determination
- Culminating results into richer data

----------


####Help? 
Contact me on Twitter **@Glitch100**

####Notes
Please note that if you pull the repo the tests will need your API Key in order to pass as I haven't interfaced out the `HttpClient` and they rely on genuine data.
