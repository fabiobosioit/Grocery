using System;

namespace Logic.Models
{
   interface IWareHouseMovement
   {
      public int Quantity { get; set; }
      public DateTime DateMovement { get; set; }

   }

}