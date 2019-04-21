using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;

namespace ECommerce.Models
{
    public class Category : BaseEntity
    {   
        public int CategoryId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Category Name:")]
        [StringLength(255, MinimumLength = 2)]
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }
        
        public List <OrderProduct> Products {get; set;}

        public Category()
        {
            Products = new List<OrderProduct>();
        }
    }
}