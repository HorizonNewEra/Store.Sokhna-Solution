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
    public class Equipments
    {
        [Key]
        public int Eq_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المهندس")]
        [ForeignKey(nameof(Engineer))]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        public Users? Engineer { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المعده")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر الساعه")]
        [DataType(DataType.Currency)]
        public float HourPrice { get; set; }
        [Required(ErrorMessage = "يجب ادخال عدد الساعات")]
        public float HourCount { get; set; }
        public float TotalPrice { get; set; }
        public string? DateOfAdding { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المورد")]
        public string? Importer { get; set; }
    }
}
