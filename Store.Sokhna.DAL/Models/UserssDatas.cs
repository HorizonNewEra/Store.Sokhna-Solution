using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.DAL.Models
{
    public class UserssDatas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "nvarchar(14)")]
        public string SSN { get; set; }
        public string FullName { get; set; }
        public string? password { get; set; }
    }
}
