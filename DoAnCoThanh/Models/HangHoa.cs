using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class HangHoa
    {
        [DisplayName("Tên sản phẩm")]
        public string TenSp { get; set; }
        [Key] 
        [DisplayName("Mã sản phẩm")]
        public int MaSp { get; set; }
        [StringLength(20)]
        [DisplayName("mã nhà cung cấp")]
        public string NhaCungCap { get; set; }
        [DisplayName("Giá ")]
        public int Gia { get; set; }
        [DisplayName("giá cũ")]
        public int GiaCu { get; set; }
        public float KM { get; set; }

        public string LoaiGiay { get; set; }
        public string KieuDang { get; set; }
        public string KieuLot { get; set; }
        public string KieuDe { get; set; }
        public string DoCao  { get; set; }
        public string CoGiay { get; set; }
        [DisplayName("Chất liệu")]
        public string ChatLieu { get; set; }
        [DisplayName("Số lượng")]
        public string SoLuong { get; set; }
        public string Size { get; set; }
        public string HinhAnh { get; set; }

        public ICollection<image> images { get; set; }

        internal object ViewDetails(int maSp)
        {
            throw new NotImplementedException();
        }
        /* public void  KhuyenMai(){
    if (GiaCu>Gia)
    {
        KM = ((GiaCu - Gia) / GiaCu) * 100;
    }
}*/
    }
}
