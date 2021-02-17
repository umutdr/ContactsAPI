using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Domain
{
    public class ContactInfo
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Contact))]
        public Guid ContactId { get; set; }

        public ContactInfoType Type { get; set; }

        public string Content { get; set; }

        public Contact Contact { get; set; }

    }
}
