using EvaluationTest.db.Models;
using EvaluationTest.Repo.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationTest.Repo.Abstract
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetCustomerOrdersAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null, string sortOrder = "desc");

    }
}
