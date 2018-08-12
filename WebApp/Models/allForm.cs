using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AllForm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }//TextBox

        public string Email { get; set; }//Email Validation

        public int Age { get; set; }//Number Validation

        public int Gender { get; set; }//Radio button

        public string Standard { get; set; }//Dropdown1

        public string Division { get; set; }//Dropdown2 cascade

        public string Image { get; set; }//Image

        public DateTime birthdate { get; set; }//Date Picker

        public DateTime AcadmicStartDate { get; set; }//Start Date 

        public DateTime AcadmicEndDate { get; set; }//End Date

        public string Hobby { get; set; }//CheckBox

        public string  OtherActivity { get; set; }//MultipleSelect Dropdown

    }
}