using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController( ICustomerServices customerServices ) 
        {
            _customerServices = customerServices ?? throw new ArgumentNullException(nameof(customerServices));
        }

       
    }
}
