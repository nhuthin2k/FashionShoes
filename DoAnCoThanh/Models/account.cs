using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    [Table("Accout")]
    public class Account
    {
        [Key]
        [DisplayName("tài khoản")]
        public string UserName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage ="không được vượt quá 20 kí tự")]
        [DisplayName("mật khẩu")]
        public string PassWord { get; set; }
        public string RoleID { get; set; }

    }
}