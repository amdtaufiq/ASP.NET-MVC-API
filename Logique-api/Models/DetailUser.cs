using Logique_api.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Logique_api.Models
{
    public class DetailUser : BaseEntity
    {
        public Guid UserId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("DetailUserID")]
        public virtual User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public MembershipType MembershipType { get; set; }
        public decimal MembershipFee { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<AddressUser> AddressUsers { get; set; }
    }
}