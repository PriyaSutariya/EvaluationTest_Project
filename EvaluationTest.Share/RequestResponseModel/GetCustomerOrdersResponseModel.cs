using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EvaluationTest.Share.RequestResponseModel
{
    public class GetCustomerOrdersResponseModel<T>
    {
        public List<T> Data { get; set; }
        public int PageWise_Count { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

    }

}
