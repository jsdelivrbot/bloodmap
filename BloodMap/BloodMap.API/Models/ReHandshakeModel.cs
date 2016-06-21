using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodMap.API.Models
{
    public class ReHandshakeModel
    {
        public string SeriesIdentifier { get; set; }
        public string RefreshToken { get; set; }
        
    }
}