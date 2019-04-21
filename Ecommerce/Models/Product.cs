using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;



namespace ECommerce.Models
{
   public class Product : BaseEntity
    {   
        public int ProductId { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Product Name:")]
        [StringLength(255, MinimumLength = 2)]
        [Required(ErrorMessage = "A name is required")]
        public string Name { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Product Description:")]
        [StringLength(255, MinimumLength = 2)]
        [Required(ErrorMessage = "A description is required")]
        public string Description { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "The price needs to be in d.cc format")]
        [Display(Name = "Product Price:")]
        [Required(ErrorMessage = "A price is required")]
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        
        public List<ProductCategory> Categorys {get; set;}
        public List<Image> Images {get; set;}
        public List<OrderProduct> Orders {get; set;}

        public Product()
        {
            Categorys = new List<ProductCategory>();
            Images = new List<Image>();
            Orders = new List<OrderProduct>();
        }
    }   
}