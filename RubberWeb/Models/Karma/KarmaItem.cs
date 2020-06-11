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

        public KarmaItem() { }

        public KarmaItem(Entity.KarmaItem item)
        {
            UserID = Convert.ToUInt64(item.MemberID);
            Karma = item.Karma;
        }
    }
}
