﻿using System.ComponentModel.DataAnnotations;
using YS.Knife;

namespace YS.Time
{
    [OptionsClass]
    public class RemoteTimeOptions
    {
        [Range(1, int.MaxValue)]
        public int CacheSeconds { get; set; } = 300;
    }
}
