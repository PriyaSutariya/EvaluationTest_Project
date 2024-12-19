using AutoMapper;
using EvaluationTest.db.Models;
using EvaluationTest.Repo.Abstract;
using EvaluationTest.Repo.Concrete;
using EvaluationTest.Service.Abstract;
using EvaluationTest.Share.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationTest.Service.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _order_repository;
        //private readonly IMapper _mapper;
        public OrderService(IOrderRepository order_repository) 
        {
           // this._mapper = mapper;
            this._order_repository = order_repository;
        }
        public async Task<GetCustomerOrdersResponseModel<OrderDTO>> GetCustomerOrders(GetCustomerOrdersRequestModel requestModel)
        {
            GetCustomerOrdersResponseModel<OrderDTO> response = new GetCustomerOrdersResponseModel<OrderDTO>();
            try
            {
               
                // Ensuring that the page size does not exceed the maximum limit
                var pageSize = Math.Min(requestModel.PageSize, 100);

                // Fetch filtered and sorted data from the repository
                var customer_orders = await _order_repository.GetCustomerOrdersAsync(requestModel.CustomerId, requestModel.Start_DateOfOrder, requestModel.End_DateOfOrder  , requestModel.SortOrder);

                // Apply pagination logic
                var pagedData = customer_orders
                    .Skip((requestModel.PageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                //var map = _mapper.Map<List<CustomerOrderData>>(pagedData);

                response.Data = pagedData;
                response.PageWise_Count = pagedData.Count();
                response.TotalCount = customer_orders.Count();
                response.PageSize = pageSize;
                response.PageNumber = requestModel.PageNumber;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               
            }

            return response;
        }

    }
}
