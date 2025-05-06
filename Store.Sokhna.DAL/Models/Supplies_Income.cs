using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Supplies_Income
    {
        [Key]
        public int SI_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المهندس")]
        [ForeignKey(nameof(Engineer))]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        public Users? Engineer { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع التوريد")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "يجب ادخال المبلغ")]
        [DataType(DataType.Currency)]
        public float Value { get; set; }
        public string? DateOfAdding { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المورد")]
        public string? Importer { get; set; }
        public string? SupplyAdder { get; set; }
    }
}
