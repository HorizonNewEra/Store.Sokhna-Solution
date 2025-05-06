using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Expenses
    {
        [Key]
        public int Exp_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المهندس")]
        [ForeignKey(nameof(Engineer))]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        public Users? Engineer { get; set; }
        [Required(ErrorMessage = "يجب ادخال المبلغ")]
        [DataType(DataType.Currency)]
        public float Value { get; set; }
        [Required(ErrorMessage = "يجب ادخال التفاصيل")]
        public string? Details { get; set; }
        public string? Note { get; set; }
        public string? DateOfAdding { get; set; }
    }
}
