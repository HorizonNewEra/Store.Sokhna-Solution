using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class Supplies_Outcome
    {
        [Key]
        public int SO_ID { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المهندس")]
        [ForeignKey(nameof(Engineer))]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        public Users? Engineer { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع التوريد")]
        public string? Type { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر الوحده و الكميه")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Required(ErrorMessage = "يجب ادخال الكميه")]
        public float Amount { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر الوحده")]
        public float CountPrice { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع القياس")]
        public string? PriceType { get; set; }
        public string? DateOfAdding { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المورد")]
        public string? Importer { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }

    }
}
