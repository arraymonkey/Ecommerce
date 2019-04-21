using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Models
{
    public class OrderProduct
    {   
        public int OrderProductId { get; set; }
        public Product Product { get; set; }
        public int ProductId {get; set;}
        public Order Order { get; set; }
        public int OrderId {get; set;}

        public int Quantity {get; set;}

        public decimal ProductTotal {get; set;}
    }
}