using System.ComponentModel.DataAnnotations;

namespace RMASystem.BL
{
    public class RetailCustomerAddDto
    {
        [Required]
        [Display(Name = "Mobile No")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }=string.Empty;


        [Required]
        [Display(Name = "Customer Code")]
        public string Code { get; set; }=string.Empty;


        [Display(Name = "Customer Address")]
        public string Address { get; set; }=string.Empty;


        [Display(Name = "Email")]
        public string Email { get; set; }=string.Empty;


        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }=string.Empty;
    }
}