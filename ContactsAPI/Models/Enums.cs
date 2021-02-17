using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Models
{
    public enum ContactInfoType : byte
    {
        Phone = 0,
        Email = 1,
        Location = 2
    }
}
