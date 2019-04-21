using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;

namespace ECommerce.Models
{
    public class PaymentMethod : BaseEntity
    {
        public int PaymentMethodId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Credit card number:")]
        [StringLength(19, MinimumLength = 16)]
        [Required(ErrorMessage = "A credit number is required")]
        public string CreditCardNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiration date:")]
        [Required(ErrorMessage = "A date is required")]
        public User User { get; set; }

        public int UserId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public int BillingAddressId { get; set; }
        public List<Order> Orders { get; set; }

        public PaymentMethod()
        {
            Orders = new List<Order>();
        }
    }
}