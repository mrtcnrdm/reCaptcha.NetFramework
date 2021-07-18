﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace reCaptcha.NetFramework.Models
{
    public class reCaptcha
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}