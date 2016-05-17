﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Settings
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SettingsTemplate
    {

        [JsonProperty("IgnotrMissingFilesOnVersion", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool IgnoreMissingFilesOnVersion { get; set; }
    }
}
