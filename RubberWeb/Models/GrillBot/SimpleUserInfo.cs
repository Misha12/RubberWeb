namespace RubberWeb.Models.GrillBot
{
    public class SimpleUserInfo
    {
        public ulong ID { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Discriminator { get; set; }
        public string AvatarUrl { get; set; }
        public GuildUserStatus GuildUserStatus { get; set; }
    }
}
