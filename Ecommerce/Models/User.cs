using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
   public class User : BaseEntity
    {   
        public int UserId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<PaymentMethod> PaymentMethods {get; set;}
        public List<ShippingAddress> ShippingAddresses {get; set;}

        public User()
        {
            PaymentMethods = new List<PaymentMethod>();
            ShippingAddresses = new List<ShippingAddress>();
        }
    }   
}