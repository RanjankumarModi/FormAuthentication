//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentAuthentication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(40, ErrorMessage = "Can't accept more than 40 characters")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Name")]
        [MinLength(3, ErrorMessage = "Name should contains atleast 3 Characters")]
        public string Name { get; set; }
        public Nullable<int> Roll { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(40, ErrorMessage = "Can't accept more than 40 characters")]
       
        [MinLength(6, ErrorMessage = "Address should contains atleast 6 Characters")]
        public string Address { get; set; }
    }
}
