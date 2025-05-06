using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Sokhna.PL.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني")]
        [EmailAddress(ErrorMessage = "البريد الالكتروني خطأ")]
        public string Email { get; set; }
    }
}
