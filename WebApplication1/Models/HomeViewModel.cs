using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebApplication1.Models
{
    public class BowlingViewModel
    {
        public List<string> UserNames { get; set; }
    }
}