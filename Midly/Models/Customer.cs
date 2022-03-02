using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Customer
    {
        public int  Id { get; set; }
        [Required(ErrorMessage="Please Your Name Is Required...")]
        [StringLength(255)]
        public string  Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; } 
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage ="Please Membership field is Required Too.,.,.,.,.")]
        public byte? MembershipTypeId { get; set; }  
        [Display(Name="Date of Birth")]
        [Min18IfYouMember]
        public DateTime? BirthDate { get; set; }
    }
}