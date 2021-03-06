﻿using System;
using System.Collections.Generic;

namespace HaloEzAPI.Model.Response.MetaData.Halo5
{
    public class CSRDesignation
    {
        public string Name { get; set; }
        public string BannerImageUrl { get; set; }
        public IEnumerable<CSRTier> Tiers { get; set; }
        public int Id { get; set; }
        public Guid ContentId { get; set; }
    }
}