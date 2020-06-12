using RubberWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubberWeb.Services
{
    public static class PaginationHelper
    {
        public static int CountSkipValue(PaginatedRequest request)
        {
            return (request.Page == 0 ? 0 : request.Page - 1) * request.Limit;
        }
    }
}
