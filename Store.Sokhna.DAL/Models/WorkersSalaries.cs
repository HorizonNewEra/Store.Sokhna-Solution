using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class WorkersSalaries
    {
        [Key]
        public int WS_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم العامل")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر الساعه")]
        [DataType(DataType.Currency)]
        public float HourPrice { get; set; }
        [Required(ErrorMessage = "يجب ادخال عدد ساعات العمل")]
        public float HourCount { get; set; }
        public float Salary { get; set; }
    }
}
