using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Infrastructure.DataTypes
{
    public abstract class BaseListItemDetails<IdType>
    {
        public IdType? Id { get; set; }
    }
}
