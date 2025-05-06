using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Workers
    {
        [Key]
        public int W_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم العامل")]
        public string? Name { get; set; }
    }
}
