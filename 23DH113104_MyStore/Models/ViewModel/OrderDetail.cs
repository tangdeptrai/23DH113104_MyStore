﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23DH113104_MyStore.Models.ViewModel
{
    public class OrderDetail

        {
            public int ID { get; set; }
            public int ProductID { get; set; }
            public int OrderID { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public Nullable<decimal> TotalPrice { get; set; }
            public virtual Order Order { get; set; }
            public virtual Product Product { get; set; }
        }
    }
