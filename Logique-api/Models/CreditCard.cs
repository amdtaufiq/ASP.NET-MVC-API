using Logique_api.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Logique_api.Models
{
    public class CreditCard : BaseEntity
    {
        public Guid DetailUserID { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("DetailUserID")]
        public DetailUser DetailUser { get; set; }
        public string Number { get; set; }
        public CCType Type {get; set;}
    }
}