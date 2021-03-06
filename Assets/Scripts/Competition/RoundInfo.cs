using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenSkiJumping.Competition
{
    [Serializable]
    public class RoundInfo
    {
        [JsonConverter(typeof(StringEnumConverter))] public RoundType roundType;
        [JsonConverter(typeof(StringEnumConverter))] public LimitType outLimitType;
        public int outLimit;
        public bool[] useOrdRank = new bool[4];
        public bool has95Rule;
        public bool reversedBibs;
        public bool reassignBibs;
        public RoundInfo() { }
        public RoundInfo(RoundType _roundType, LimitType _outlimitType, int _outLimit, bool _reassignBibs = false, bool _has95Rule = true)
        {
            roundType = _roundType;
            outLimitType = _outlimitType;
            outLimit = _outLimit;
            has95Rule = _has95Rule;
            reversedBibs = (roundType == RoundType.KO ? true : false);
            reassignBibs = _reassignBibs;
        }
    }


}
