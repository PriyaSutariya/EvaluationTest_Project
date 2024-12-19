using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationTest.Share.RequestResponseModel
{
    public class GetCustomerOrdersRequestModel
    {
       
            public int CustomerId { get; set; }         
            public DateTime? Start_DateOfOrder { get; set; }   
            public DateTime? End_DateOfOrder { get; set; }     
            public string SortOrder { get; set; } = "desc"; 
            public int PageNumber { get; set; } = 1;   
            public int PageSize { get; set; } = 30;    
        

    }
}
