using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Infrastructure.DataTypes
{
    public class Page<ListItemType, IdType> where ListItemType : BaseListItem<IdType>
    {
        public string? OrderBy { get; set; }
        public SortDirection OrderByDirection { get; set; }

        public List<ListItemType>? Items { get; set; }
    }
}
