using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Models
{
    public class ProductCategory
    {   
        public int ProductCategoryId { get; set; }
        public Product Product { get; set; }
        public int ProductId {get; set;}
        public Category Category { get; set; }
        public int CategoryId {get; set;}
    }
}