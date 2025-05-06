using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Importers
    {
        [Key]
        public int Imp_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المورد")]
        public string? Name { get; set; }
    }
}
