using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(14, MinimumLength= 14,ErrorMessage ="الرقم القومي يجب ان يكون مكون من 14 رقم")]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "ادخل الاسم رباعي")]
        [StringLength(300,MinimumLength =10,ErrorMessage ="يجب ان لا يقل الاسم كامل عن 10 احرف")]
        public string FullName { get; set; }
        public string? Job { get; set; }
        public string? DateofEmployed { get; set; }
        [MaxLength(1)]
        public string? Deleted { get; set; }
        [Required(ErrorMessage = "رقم الهاتف غير صحيح")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="رقم الهاتف مكون من 11 رقم")]
        [Phone(ErrorMessage ="رقم الهاتف خطأ")]
        public string? Phone { get; set; }
    }
}
