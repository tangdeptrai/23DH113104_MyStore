using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23DH113104_MyStore.Models.ViewModel
{
    public class ProductSearchVM
    {
        //tiêu chí để search theo tên, mô tả sp
        //hoặc loại sản phẩm
        public string SearchTerm { get; set; }
        public List<Product> Products { get; set; }
    }
}