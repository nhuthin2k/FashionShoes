using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class GioHang
    {
        public HangHoa hangHoa { get; set; }
        public int SoLuong { get; set; }
        public float tongTien()
        {
            return (this.hangHoa.Gia * this.SoLuong);
        }
    }
}