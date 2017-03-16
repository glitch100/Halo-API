# Changelog

**Release Date: 16/03/2017**
### 2.1.0
- Added in new Halo Wars 2 Endpoints
- GetCampaignLevels
- GetCampaignLogs
- GetCardKeywords
- GetCards
- GetCSRDesignations
- Adjusted models to be more generic
- Tests

### 2.0.0
**Release Date: 23/02/2017**
- Adjusted folder structure to be title specific
- Adjusted `Endpoints` to be title specific
- Started adding in HW2 Endpoints:
  - GetCampaignLevels
- Added `HaloWars2` TO `HaloApiService` - plan on creating a `Halo5` associated property also
- Tests adjusted
- Major solution cleanup; first steps

### 1.7.0
**Release Date: 30/01/2017**
- `GetPlayerMatches` endpoint updated with optional `seasonId`

### 1.6.0
**Release Date: 22/01/2017**
- `GetCSRDesignations` endpoint added under metadata, after it was randomly missing
- `bustCache` param added to all calls within the `HaloAPIService`. Doing so will by pass the cache and refill it with the new result

### 1.5.0
**Release Date: 13/01/2017**
- `StatTimelapse` adjusted to not ignore
- Optional param in constructor to allow for new `CacheManager` that utilises `IApiCacheManager`
- Tests adjusted

### 1.4.0
**Release Date: 22/11/2016**
- Added new types of events: Impulses, Medals, Player Spawns, Round Starts, Round Ends, Weapon Drops, Weapon Pickups, and Weapon Pickup Pads.
> !Deprecated - `Event` - Renamed to `FullEvent` and should no longer be used. Refer to the abstract class `GameEvent` and it's usages on the above mentioned new events.
- Added properties to `XPInfo` model:
  - MatchSpeedWinAmount
  - ObjectivesCompletedAmount
  - BoostData.
- Added in `MapVariantResourceId` and `GameVariantResourceId` as `Variants` on all post-game classes (via `MatchDetails`)
- Minor restructure of classes in prep for more file movement
- Added `docs` folder at root

### 1.3.0
**Release Date: 17/11/2016**
- Added UGC Endpoints
- Added in Player Leaderboard Endpoint
- Additional types

### 1.2.6
**Release Date: N/A**
- Added in `Infection` to `Medal.cs`

### 1.2.5
**Release Date: N/A**
- Fix to `Guid` translation using JacobSnyders branch (manual)
- Adjustmnet to SeasonId
- Additional tests

#### Previous Versions.
Check NuGet history
