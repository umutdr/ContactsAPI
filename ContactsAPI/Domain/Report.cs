using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Domain
{
    public class Report
    {
        public string Location { get; set; }

        public int LocationCount { get; set; }

        public int ContactCount { get; set; }

        public int ContactPhoneCount { get; set; }
    }
}
