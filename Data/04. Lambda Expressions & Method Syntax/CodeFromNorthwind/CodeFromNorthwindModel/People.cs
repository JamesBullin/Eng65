using System;
using System.Collections.Generic;

namespace CodeFromNorthwindModel
{
    public partial class People
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public decimal? Height { get; set; }
        public bool? IsHappy { get; set; }
    }
}
