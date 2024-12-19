using EvaluationTest.db.Models;
using EvaluationTest.Repo.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationTest.Repo.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDTO>> GetCustomerOrdersAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null, string sortOrder = "desc")
        {

           

            var query = _context.Orders
                .Where(o => o.customer_id == customerId) // Filter by customer ID
                .Include(o => o.Customer) // Include Customer details
                .Include(o => o.OrderProductMappings) // Include OrderProductMappings
                .ThenInclude(opm => opm.product) // Include Product details from OrderProductMappings
                .AsQueryable();



            // Apply filtering by date range (Optional)
            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(o => o.date_of_order >= startDate.Value && o.date_of_order <= endDate.Value);
            }
            else if (startDate.HasValue)
            {
                query = query.Where(o => o.date_of_order >= startDate.Value);
            }
            else if (endDate.HasValue)
            {
                query = query.Where(o => o.date_of_order <= endDate.Value);
            }

            // Apply sorting by date_of_order (either ascending or descending)
            if (sortOrder.ToLower() == "asc")
            {
                query = query.OrderBy(o => o.date_of_order);  
            }
            else
            {
                query = query.OrderByDescending(o => o.date_of_order);  
            }

            var orders = await query
                        .Include(o => o.Customer)
                        .Include(o => o.OrderProductMappings)
                        .ThenInclude(opm => opm.product) 
                        .Select(o => new OrderDTO
                        {
                             CustomerId  = o.customer_id,
                             CustomerName = o.Customer.customer_firstname +" "+ o.Customer.customer_lastname,
                             OrderId = o.order_id,
                             DateOfOrder = o.date_of_order,
                             Products = o.OrderProductMappings.Select(opm => new ProductDTO
                             {
                                    product_id = opm.product.product_id,
                                    product_name = opm.product.product_name,
                                    product_price = opm.product.product_price,
                                    product_code = opm.product.product_code,
                                    product_quantity = opm.product_quantity
                             }).ToList()

                        }).ToListAsync();


            return orders;  // Fetch filtered and sorted records
        }
    }

   
}
