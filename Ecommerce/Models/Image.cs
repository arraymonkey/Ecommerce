using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ECommerce.Models;

namespace ECommerce.Models
{
    public class Image : BaseEntity
    {   
        public int ImageId { get; set; }
        public Product Product { get; set; }
        public int ProductId {get; set;}
        public string Url { get; set; }
    }
}