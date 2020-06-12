using System.Collections.Generic;

namespace RubberWeb.Models.GrillBot
{
    public class GetUsersSimpleInfoBatchRequest
    {
        public List<ulong> UserIDs { get; set; }
    }
}
