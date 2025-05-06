using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Sokhna.PL.Models
{
    public class SignUpViewModel
	{
		[Required(ErrorMessage = "يجب ادخال الرقم القومي")]
		public string Serial { get; set; }
		[Required(ErrorMessage = "يجب ادخال اسم مستخدم")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "يجب ادخال كلمه سر")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "يجب اعاده ادخال كلمه السر")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage ="كلمه السر غير متطابقه")]
		public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "يجب ادخال البريد الالكتروني")]
        [EmailAddress(ErrorMessage = "البريد الالكتروني خطأ")]
        public string Email { get; set; }
	}
}
