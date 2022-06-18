using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Logique_api.Models
{
    public class AddressUser : BaseEntity
    {
        public Guid DetailUserID { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual DetailUser DetailUser { get; set; }
        public string Address { get; set; }
    }
}