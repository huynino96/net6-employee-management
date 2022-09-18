using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "navchar(250)")]
        [Required(ErrorMessage = "This is required field")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(10")]
        [DisplayName("Emp. Code")]
        public string EmpCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }
    }
}

