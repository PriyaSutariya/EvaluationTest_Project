using EvaluationTest.db.Models;
using EvaluationTest.Share.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationTest.Service.Abstract
{
    public interface IOrderService
    {
        Task<GetCustomerOrdersResponseModel<OrderDTO>> GetCustomerOrders(GetCustomerOrdersRequestModel requestModel);

    }
}
