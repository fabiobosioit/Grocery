using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Infrastructure.DataTypes
{
    public class Page<ListItemType, IdType> where ListItemType : BaseListItem<IdType>
    {
        public int ItemCount { get; set; } = 0;
        public int PageCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 0;
        public string? OrderBy { get; set; }
        public SortDirection OrderByDirection { get; set; }
        public List<ListItemType>? Items { get; set; }
    }
}
