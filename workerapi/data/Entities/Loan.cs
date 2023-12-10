using Worker.Data;
using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Worker.Data.Entities
{
    public  class Loan : BaseEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string LoanNumber { get; set; }
        public string LoanName { get; set; }
        public string LoanType { get; set; }
        public decimal LoanAmount { get; set; }

        public string CustId { get; set; }
        public Customer Customer { get; set; }       

        public ICollection<Payment> Payments { get; set; }

    }
}
