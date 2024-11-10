using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace _23DH113104_MyStore.Models.ViewModel
{
    public class HomeProductVM
    {
        //tiêu chí đẻ search theo tên, mô tả sản phẩm
        //hoặc loại sản phẩm
        public string SearchTerm { get; set; }

        //các thuộc tính hỗ trợ phân trang
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        //danh sách nổi bật
        public List<Product> FeaturedProducts { get; set; } = new List<Product>();

        //danh sách sane phẩm phân trang
        public PagedList.IPagedList<Product> NewProducts { get; set; }
    }
}