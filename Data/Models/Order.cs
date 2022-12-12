using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop1.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введіть ім'я")]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле повинно мати не менше 3-ох літер")]
        public string name { get; set; }

        [Display(Name = "Введіть прізвище")]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле повинно мати не менше 3-ох літер")]
        public string surname { get; set; }


        [Display(Name = "Введіть адресу")]
        [StringLength(60)]
        [Required(ErrorMessage = "Поле повинно мати не менше 10-ох літер")]
        public string adress { get; set; }


        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле повинно мати не менше 10-ох літер")]
        public string phone { get; set; }


        [Display(Name = "Введіть електронну пошту")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Поле повинно мати не менше 5-и літер")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]

        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetail { get; set; }




    }
}
