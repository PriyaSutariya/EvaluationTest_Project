using EvaluationTest.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using EvaluationTest.Share.RequestResponseModel;
using EvaluationTest.Service.Abstract;

namespace EvaluationTest.Controllers
{
    public class CustomerOrderController : Controller
    {
        private IOrderService _orderService;
        public CustomerOrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        [Route("CustomerOrder/getOrder")]
        public async Task<IActionResult> GetOrders([FromQuery] GetCustomerOrdersRequestModel requestModel)
        {
            try
            {
                var result = await _orderService.GetCustomerOrders(requestModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
