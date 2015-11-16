using System;
using System.Collections.Specialized;
using HaloEzAPI.Abstraction.Enum;
using HaloEzAPI.Model.Response.Error;

namespace HaloEzAPI
{
    internal static class Endpoints
    {
        internal static string MajorPrefix;
        private const string Title = "h5";

        public static class Stats
        {
            internal static readonly string MinorPrefix = "stats";

            public static Uri GetMatchesForPlayer(string gamertag, GameMode gamemode = GameMode.All, int start = 0, int count = 25)
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
                if (count > 0 && count < 25 )
                {
                    values.Add("count",count.ToString());
                }
                string baseUrl = string.Format("{0}/{1}/{2}/players/{3}/matches?",MajorPrefix,MinorPrefix,Title,gamertag);
                return values.BuildUri(baseUrl);
            }

            public static Uri GetPostGameCarnageReport(string matchId, GameMode gameMode)
            {
                if (gameMode == GameMode.Arena)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/arena/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                if (gameMode == GameMode.Campaign)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/campaign/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }                
                if (gameMode == GameMode.Custom)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/custom/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                if (gameMode == GameMode.Warzone)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/warzone/matches/{3}", MajorPrefix, MinorPrefix, Title, matchId));
                }
                throw new HaloAPIException("Unsupported GameMode provided for Post Game Carnage Report");
            }            
            
            public static Uri GetServiceRecords(string[] players, GameMode gameMode)
            {
                if (gameMode == GameMode.Arena)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/arena?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",",players)));
                }
                if (gameMode == GameMode.Campaign)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/campaign?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",", players)));
                }                
                if (gameMode == GameMode.Custom)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/custom?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",", players)));
                }        
                if (gameMode == GameMode.Warzone)
                {
                    return new Uri(string.Format("{0}/{1}/{2}/servicerecords/warzone?players={3}", MajorPrefix, MinorPrefix, Title, string.Join(",", players)));
                }
                throw new HaloAPIException("Unsupported GameMode provided for Service Record. Please use Arena, or Campaign");
            }
        }

        public static class MetaData
        {
            internal static readonly string MinorPrefix = "metadata";

            public static Uri GetCampaignMissions()
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/campaign-missions", MajorPrefix, MinorPrefix, Title));
            }   
        
            public static Uri GetCommendations()
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/commendations", MajorPrefix, MinorPrefix, Title));
            }        
   
            public static Uri GetCSRDesignations()
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/csr-designations", MajorPrefix, MinorPrefix, Title));
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
                return new Uri(string.Format("{0}/{1}/{2}/metadata/game-base-variants", MajorPrefix, MinorPrefix, Title));
            }   

            public static Uri GetGameVariant(string id)
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/game-variants/{3}", MajorPrefix, MinorPrefix, Title, id));
            }   

            public static Uri GetImpulses()
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/impulses", MajorPrefix, MinorPrefix, Title));
            }

            public static Uri GetMapVariants(string id)
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/map-variants/{3}", MajorPrefix, MinorPrefix, Title, id));
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
                return new Uri(string.Format("{0}/{1}/{2}/metadata/requisition-packs/{3}", MajorPrefix, MinorPrefix, Title,id.ToString()));
            }

            public static Uri GetRequisitionPacks()
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/requisition-pack", MajorPrefix, MinorPrefix, Title));
            }

            public static Uri GetRequisition(Guid id)
            {
                return new Uri(string.Format("{0}/{1}/{2}/metadata/requisitions/{3}", MajorPrefix, MinorPrefix, Title, id));
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

        }

        public static class Profile
        {
            internal static readonly string MinorPrefix = "profile";

            public static Uri GetEmblemImage(string gamerTag, int size = 256)
            {
                var values = new NameValueCollection {{"size", size.ToString()}};

                var baseUrl = string.Format("{0}/{1}/{2}/profiles/{3}/emblem", MajorPrefix, MinorPrefix, Title,gamerTag);
                return values.BuildUri(baseUrl);
            }   

            public static Uri GetSpartanImage(string gamerTag, int size = 256, CropType cropType = CropType.Full)
            {
                var values = new NameValueCollection
                {
                    {"size", size.ToString()},
                    {"crop", cropType.ToString().ToLower()}
                };

                var baseUrl = string.Format("{0}/{1}/{2}/profiles/{3}/spartan", MajorPrefix, MinorPrefix, Title, gamerTag);
                return values.BuildUri(baseUrl);
            }   
        }
    }
}