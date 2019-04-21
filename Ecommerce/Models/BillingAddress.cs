using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;

namespace ECommerce.Models
{
    public class BillingAddress : BaseEntity
    {   
        public int BillingAddressId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address:")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "An address is required")]
        public string Address { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Address 2:")]
        public string Address2 { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "City:")]
        [StringLength(45, MinimumLength = 3)]
        [Required(ErrorMessage = "A city is required")]
        public string City { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "State:")]
        [Required(ErrorMessage = "A state is required")]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Zipcode:")]
        [StringLength(5)]
        [Required(ErrorMessage = "A zipcode is required")]
        public string ZipCode { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nickname (optional):")]
        public string Nickname { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Delivery Note (optional):")]
        public string DeliveryNote { get; set; }
        public List <PaymentMethod> PaymentMethods {get; set;}

        public BillingAddress()
        {
            PaymentMethods = new List<PaymentMethod>();
        }
    }
}