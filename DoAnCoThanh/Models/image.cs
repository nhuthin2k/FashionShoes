using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
    
{
   [Table("image")]
    public class image
    {
        [Key]
        public int maSP { get; set; }
        public string TenAnh { get; set; }
        public virtual HangHoa HangHoa { get; set; }
    }
}