using App.PhoneNoDetection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.PhoneNoDetection.ViewModel
{
    public class PhoneDetectionvM
    {

        [Required(ErrorMessage = "Enter Text!")]
        public string PhoneNo { get; set; }
        public string msg { get; set; }
        public List<PhoneNoDetails> phoneNoDetails { get; set; }
    }
}