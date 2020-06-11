using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubberWeb.Entity
{
    [Table("bot_karma")]
    public class KarmaItem
    {
        [Key]
        [Column("member_ID")]
        public string MemberID { get; set; }

        [Column("karma")]
        public int Karma { get; set; }

        [Column("positive")]
        public int Positive { get; set; }

        [Column("negative")]
        public int Negative { get; set; }
    }
}
