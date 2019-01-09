namespace HaloEzAPI
{
    public class HaloAPIConfig
    {
        public string APIToken { get; set; }
        public int StatCacheExpiry { get; set; }
        public int MetaCacheExpiry { get; set; }
        public int ProfileCacheExpiry { get; set; }
        public int UGCCacheExpiry { get; set; }
        public string BaseApiUrl { get; set; }
    }
}