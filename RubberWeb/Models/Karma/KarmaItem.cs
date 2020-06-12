using RubberWeb.Models.GrillBot;
using System;
using System.Text.Json.Serialization;

namespace RubberWeb.Models.Karma
{
    public class KarmaItem
    {
        [JsonIgnore]
        public ulong UserID { get; set; }

        public SimpleUserInfo User { get; set; }
        public int Karma { get; set; }

        public int Positive { get; set; }
        public int Negative { get; set; }

        public int Position { get; set; }

        public KarmaItem() { }

        public KarmaItem(Entity.KarmaItem item)
        {
            UserID = Convert.ToUInt64(item.MemberID);
            Karma = item.Karma;
            Positive = item.Positive;
            Negative = item.Negative;
        }
    }
}
