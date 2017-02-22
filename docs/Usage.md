# Usage

You can download the source or get it via **NuGet**!
[https://www.nuget.org/packages/HaloEzAPI](https://www.nuget.org/packages/HaloEzAPI)

```C#
//Initialize service with API Token. Optionally provide base api url
var haloApiService = new HaloAPIService("MYAPITOKEN");
//Retrieve the player matches from an associated gamertag,with optional gamemode,
//start and count
```

## Getting Halo 5 Matches

```c#
var playerMatches = await haloAPIService.GetMatchesForPlayer("Glitch100", GameMode.Arena);
//Example of returning gamevariants from the match result set
var gameVariants = playerMatches.Results.Select(r => r.GameVariants);
```


## Getting Halo Wars 2 Campaign Missions

```c#
var playerMatches = await haloAPIService.HaloWars2.GetCampaignLevels();
```
