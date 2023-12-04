using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Worker.Web.Models
{
    public class CustomerModelView
    {
        [Required]
        public string CustomerId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Amount")]        
        public string LoanAmount { get; set; }
        [DisplayName("Loan Number")]
        public string Loanumber { get; set; }
        [DisplayName("Approval Date")]
        public DateTime LoanDate { get; set; }
    }
}
