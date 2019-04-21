using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;



namespace ECommerce.Models
{
   public class Order : BaseEntity
    {   
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public decimal Total {get; set;}
        public PaymentMethod PaymentMethod { get; set; }
        public int PaymentMethodId {get; set;}
        public ShippingAddress ShippingAddress { get; set; }
        public int ShippingAddressId {get; set;}
        public List<OrderProduct> Orders {get; set;}
        public Order()
        {
            Orders = new List<OrderProduct>();
        }
    }   
}