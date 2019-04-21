using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
   public class BaseEntity
    {  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt {get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt {get; set;}
    }
   
}