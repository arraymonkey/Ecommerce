using Microsoft.EntityFrameworkCore;
 using System;
 using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using Microsoft.AspNetCore.Http;
 
 namespace ECommerce.Models
 {
     public class Cart
     {   
         public int CartId {get; set;}
         public Product Product {get; set;}
         public int ProductId {get; set;}
         public User User {get; set;}
         public int UserId {get; set;}
         public int Quantity {get; set;}
     }
 }