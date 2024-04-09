﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Microsoft.Security.Utilities
{
    internal class AzureMessageLegacyCredentials : RegexPattern
    {
        public AzureMessageLegacyCredentials()
        {
            Id = "SEC101/105";
            Name = nameof(AzureMessageLegacyCredentials);
            DetectionMetadata = DetectionMetadata.HighEntropy | DetectionMetadata.ObsoleteFormat;
            Pattern = "(?i)\\.servicebus\\.windows.+[^0-9a-z\\/+](?P<refine>[0-9a-z\\/+]{43}=)(?:[^=]|$)";
        }

        public override Tuple<string, string> GetMatchIdAndName(string match)
        {
            if (IdentifiableMetadata.IsAzureCosmosDBIdentifiableKey(match))
            {
                return null;
            }

            return base.GetMatchIdAndName(match);
        }

        public override IEnumerable<string> GenerateTestExamples()
        {
            yield return $"Endpoint=sb://doesnotexist.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey={WellKnownRegexPatterns.RandomBase64(43)}=";
        }
    }
}