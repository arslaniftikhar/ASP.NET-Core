using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProductModel
    {


        [DataType(DataType.Text)]
        [Display(Name = "Product ID")]
        [Required]
        public int ID { get; set; }

        //[DataType(DataType.Password)]
        //[Url]
        //[EmailAddress]
        //[MaxLength(500)]
        [Display(Name = "Product Discription")]
        [MinLength(5)]
        [Required]
        public string ProductDetails { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required]
        public int ProductPrice { get; set; }

    }
}
