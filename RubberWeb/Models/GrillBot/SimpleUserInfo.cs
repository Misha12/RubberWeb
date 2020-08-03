using System.Text.Json.Serialization;

namespace RubberWeb.Models.GrillBot
{
    public class SimpleUserInfo
    {
        [JsonIgnore]
        public ulong ID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Discriminator { get; set; }
        public string AvatarUrl { get; set; }
        public GuildUserStatus GuildUserStatus { get; set; }

        public static SimpleUserInfo DefaultUser
        {
            get => new SimpleUserInfo()
            {
                AvatarUrl = "https://cdn.discordapp.com/embed/avatars/0.png",
                Discriminator = "0000",
                GuildUserStatus = GuildUserStatus.Other,
                Name = "Unknown user",
                Nickname = "Neznámý uživatel"
            };
        }
    }
}
