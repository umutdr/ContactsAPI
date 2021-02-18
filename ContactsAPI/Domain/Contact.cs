using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Domain
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(OwnerUser))]
        public string OwnerUserId { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        public IdentityUser OwnerUser { get; set; }

        public ICollection<ContactInfo> ContactInfos { get; set; }

    }
}
