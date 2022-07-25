using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Infrastructure.DataTypes
{
    public class PageParameters
    {
        public int Page { get; set; } = 1;
        public string? OrderBy { get; set; }
        public string? FilterText { get; set; }
        public SortDirection OrderByDirection { get; set; }

    }
}
