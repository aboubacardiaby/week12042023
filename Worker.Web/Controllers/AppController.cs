using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Globalization;
using Worker.Data.Entities;
using Worker.Web.Data;
using Worker.Web.Models;

namespace Worker.Web.Controllers
{
    public class AppController : Controller
    {
        private readonly WorkerDataContext _context;

        public AppController(WorkerDataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
           
           var models = new List<CustomerModelView>();

            var query = _context.tblCustomer           
                                     .ToList();           
                        
            foreach (var item in query)
            {
                var model = new CustomerModelView();
                model.CustomerId = item.CustId;
                model.CustomerName = string.Format("{0}, {1}", item.LastName, item.FirstName);
                model.Address = string.Format("{0} {1} {2}", item.Address, item.City, item.State);
                var cutloan = _context.tblloan.FromSqlRaw<Loan>(@"SELECT *                                                                                                                          
                                                          FROM [NBLDB].[dbo].[tblLoan]
                                                        Where CustId=@CustId", new SqlParameter("@CustId", item.CustId))
                                                    .ToList();
                foreach (var loan in cutloan)
                {
                    model.Loanumber = loan.LoanAmount.ToString();
                    model.LoanAmount = loan.LoanAmount.ToString();
                    model.LoanDate = loan.CreateDate;

                }
                models.Add(model);


            }
            return View(models);
        }
    }
}
