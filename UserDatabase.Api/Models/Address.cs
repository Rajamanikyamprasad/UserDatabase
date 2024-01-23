using System.ComponentModel.DataAnnotations;

namespace UserDatabase.Api.Models
{
    public class Address
    {
        [Key]
        public Guid address_id { get; set; }

        public string customer_name { get; set; }
        public string phone_number { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string address_type { get; set; }

        public Guid customer_id { get; set; }

    }
}
