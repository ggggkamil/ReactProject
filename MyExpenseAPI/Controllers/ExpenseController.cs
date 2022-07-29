
using MyExpenseAPI.Models;
using System.Web.Http;

namespace MyExpenseAPI.Controllers

{
    
    public class ExpenseController : ApiController
    {
        [HttpGet]
        public ExpenseModel GetExpense()
        {
            return new ExpenseModel();
        }
    }
}
