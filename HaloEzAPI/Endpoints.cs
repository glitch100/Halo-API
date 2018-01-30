using System;
using System.Collections.Specialized;
using HaloEzAPI.Abstraction.Enum.Halo5;
using HaloEzAPI.Extensions;
using HaloEzAPI.Model.Request;
using HaloEzAPI.Model.Response.Error;

namespace HaloEzAPI
{
    internal static class Endpoints
    {
        public static class Halo5
        {
            internal static string MajorPrefix;
            private const string Title = "h5";

            public static class Stats
            {
                internal static readonly string MinorPrefix = "stats";

                public static Uri GetMatchesForPlayer(string gamertag, GameMode gamemode = GameMode.All, int start = 0,
                    int count = 25)
                {
                    var values = new NameValueCollection();

                    if (gamemode != GameMode.All)
                    {
                        values.Add("modes", gamemode.ToString().ToLower());
                    }

                    if (start > 0)
                    {
                        values.Add("start", start.ToString());
                    }
                    if (count > 0 && count < 25)
                    {
                        values.Add("count", count.ToString());
                    }
                    string baseUrl = string.Format("{0}/{1}/{2}/players/{3}/matches?", MajorPrefix, MinorPrefix, Title,
                        gamertag);
                    return values.BuildUri(baseUrl);
                }

                public static Uri GetEventsForMatch(string matchId)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/matches/{3}/events", MajorPrefix, MinorPrefix, Title, matchId));
                }

                public static Uri GetPostGameCarnageReport(string matchId, GameMode gameMode)
                {
                    if (gameMode == GameMode.Arena)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/arena/matches/{3}", MajorPrefix, MinorPrefix, Title,
                                matchId));
                    }
                    if (gameMode == GameMode.Campaign)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/campaign/matches/{3}", MajorPrefix, MinorPrefix, Title,
                                matchId));
                    }
                    if (gameMode == GameMode.Custom)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/custom/matches/{3}", MajorPrefix, MinorPrefix, Title,
                                matchId));
                    }
                    if (gameMode == GameMode.CustomLocal)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/customlocal/matches/{3}", MajorPrefix, MinorPrefix, Title,
                                matchId));
                    }
                    if (gameMode == GameMode.Warzone)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/warzone/matches/{3}", MajorPrefix, MinorPrefix, Title,
                                matchId));
                    }
                    throw new HaloAPIException("Unsupported GameMode provided for Post Game Carnage Report");
                }

                public static Uri GetServiceRecords(string[] players, GameMode gameMode, string seasonId = "")
                {
                    string suffix = "players={3}";
                    if (seasonId != string.Empty)
                    {
                        suffix = "players={3}&seasonId=" + seasonId;
                    }

                    if (gameMode == GameMode.Arena)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/servicerecords/arena?" + suffix, MajorPrefix, MinorPrefix,
                                Title, string.Join(",", players)));
                    }
                    if (gameMode == GameMode.Campaign)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/servicerecords/campaign?" + suffix, MajorPrefix,
                                MinorPrefix, Title, string.Join(",", players)));
                    }
                    if (gameMode == GameMode.Custom)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/servicerecords/custom?" + suffix, MajorPrefix,
                                MinorPrefix, Title, string.Join(",", players)));
                    }
                    if (gameMode == GameMode.CustomLocal)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/servicerecords/customlocal?" + suffix, MajorPrefix,
                                MinorPrefix, Title, string.Join(",", players)));
                    }
                    if (gameMode == GameMode.Warzone)
                    {
                        return
                            new Uri(string.Format("{0}/{1}/{2}/servicerecords/warzone?" + suffix, MajorPrefix,
                                MinorPrefix, Title, string.Join(",", players)));
                    }

                    throw new HaloAPIException(
                        "Unsupported GameMode provided for Service Record. Please use Arena, or Campaign");
                }

                public static Uri PlayerLeaderboard(string seasonId, string playlistId, int count = 200)
                {
                    if (count == 0)
                    {
                        throw new HaloAPIException(CommonErrorMessages.NoZeroAllowed);
                    }
                    return
                        new Uri(string.Format("{0}/{1}/{2}/player-leaderboards/csr/{3}/{4}?count={5}", MajorPrefix,
                            MinorPrefix, Title, seasonId, playlistId, count));
                }
            }

            public static class MetaData
            {
                internal static readonly string MinorPrefix = "metadata";

                public static Uri GetCampaignMissions()
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/campaign-missions", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetCommendations()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/commendations", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetCSRDesignations()
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/csr-designations", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetEnemies()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/enemies", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetFlexibleStats()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/flexible-stats", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetGameBaseVariants()
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/game-base-variants", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetGameVariant(string id)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/game-variants/{3}", MajorPrefix, MinorPrefix, Title,
                            id));
                }

                public static Uri GetImpulses()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/impulses", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetMapVariants(string id)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/map-variants/{3}", MajorPrefix, MinorPrefix, Title,
                            id));
                }

                public static Uri GetMaps()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/maps", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetMedals()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/medals", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetPlaylists()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/playlists", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetRequisitionPack(Guid id)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/requisition-packs/{3}", MajorPrefix, MinorPrefix,
                            Title, id.ToString()));
                }

                public static Uri GetRequisitionPacks()
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/requisition-pack", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetRequisition(Guid id)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/metadata/requisitions/{3}", MajorPrefix, MinorPrefix, Title,
                            id));
                }

                public static Uri GetSkulls()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/skulls", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetSpartanRanks()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/spartan-ranks", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetTeamColors()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/team-colors", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetVehicles()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/vehicles", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetWeapons()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/weapons", MajorPrefix, MinorPrefix, Title));
                }

                public static Uri GetSeasons()
                {
                    return new Uri(string.Format("{0}/{1}/{2}/metadata/seasons", MajorPrefix, MinorPrefix, Title));
                }
            }

            public static class Profile
            {
                internal static readonly string MinorPrefix = "profile";

                public static Uri GetEmblemImage(string gamerTag, int size = 256)
                {
                    var values = new NameValueCollection {{"size", size.ToString()}};

                    var baseUrl = string.Format("{0}/{1}/{2}/profiles/{3}/emblem", MajorPrefix, MinorPrefix, Title,
                        gamerTag);
                    return values.BuildUri(baseUrl);
                }

                public static Uri GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full)
                {
                    var values = new NameValueCollection
                    {
                        {"size", size.ToString()},
                        {"crop", cropType.ToString().ToLower()}
                    };

                    var baseUrl = string.Format("{0}/{1}/{2}/profiles/{3}/spartan", MajorPrefix, MinorPrefix, Title,
                        gamerTag);
                    return values.BuildUri(baseUrl);
                }
            }

            public static class UGC
            {
                internal static readonly string MinorPrefix = "ugc";

                public static Uri GetGameVariant(string gamertag, string variant)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/players/{3}/gamevariants/{4}", MajorPrefix, MinorPrefix,
                            Title, gamertag, variant));
                }

                public static Uri GetMapVariant(string gamertag, string variant)
                {
                    return
                        new Uri(string.Format("{0}/{1}/{2}/players/{3}/mapvariants/{4}", MajorPrefix, MinorPrefix, Title,
                            gamertag, variant));
                }

                public static Uri ListGameVariants(string gamertag, int start = 0, int count = 25,
                    Sort sort = Sort.Modified, Order order = Order.Desc)
                {
                    var values = new NameValueCollection();

                    if (sort != Sort.Modified)
                    {
                        values.Add("sort", sort.ToString());
                    }
                    if (order != Order.Desc)
                    {
                        values.Add("order", order.ToString());
                    }
                    if (start > 0)
                    {
                        values.Add("start", start.ToString());
                    }
                    if (count > 0 && count < 25)
                    {
                        values.Add("count", count.ToString());
                    }
                    string baseUrl = string.Format("{0}/{1}/{2}/players/{3}/gamevariants?", MajorPrefix, MinorPrefix,
                        Title, gamertag);
                    return values.BuildUri(baseUrl);
                }

                public static Uri ListMapVariants(string gamertag, int start = 0, int count = 25,
                    Sort sort = Sort.Modified, Order order = Order.Desc)
                {
                    var values = new NameValueCollection();

                    if (sort != Sort.Modified)
                    {
                        values.Add("sort", sort.ToString());
                    }
                    if (order != Order.Desc)
                    {
                        values.Add("order", order.ToString());
                    }
                    if (start > 0)
                    {
                        values.Add("start", start.ToString());
                    }
                    if (count > 0 && count < 25)
                    {
                        values.Add("count", count.ToString());
                    }
                    string baseUrl = string.Format("{0}/{1}/{2}/players/{3}/mapvariants?", MajorPrefix, MinorPrefix,
                        Title, gamertag);
                    return values.BuildUri(baseUrl);
                }
            }
        }

        public static class HaloWars2
        {
            internal static string MajorPrefix;
            private const string Title = "hw2";

            public static class MetaData
            {
                internal static readonly string MinorPrefix = "metadata";

                public static Uri GetCampaignLevels(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/campaign-levels/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }                
                
                public static Uri GetCampaignLogs(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/campaign-logs/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }                

                public static Uri GetCardKeywords(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/card-keywords/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }

                public static Uri GetCards(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/cards/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }      
                
                public static Uri GetCSRDesignations(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/csr-designations/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }
                
                public static Uri GetDifficulties(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/difficulties/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }  
                              
                public static Uri GetGameObjectCategories(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/game-object-categories/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }         

                public static Uri GetGameObjects(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/game-objects/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }

                public static Uri GetLeaderPowers(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/leader-powers/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }

                public static Uri GetLeaders(int startAt = 0)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/leaders/?startAt={3}", MajorPrefix, MinorPrefix, Title,
                        startAt));
                }
            }
        }
    }
}