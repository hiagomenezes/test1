using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
    public class Times
    {
        [Display(Name = "Id")]
        public int TimeId { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Cores { get; set; }
    }
}