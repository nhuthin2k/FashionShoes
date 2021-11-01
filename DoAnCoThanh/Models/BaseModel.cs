using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnCoThanh.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? ModifierTime { get; set; }
        public int? ModifierUser { get; set; }
    }
}