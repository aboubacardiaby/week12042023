using Worker.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Worker.Data.Entities
{ 
    public partial class Customer : BaseEntity
    {
        public Customer()
        {
            this.Loans = new HashSet<Loan>();
        }

        [Key]
        public string CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public  ICollection<Loan> Loans { get; set; }
    }
}