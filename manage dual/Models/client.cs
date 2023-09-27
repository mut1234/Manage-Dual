namespace manage_dual.Models
{
    public class client
    {
        public int clientId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public DateTime ClientDateAddedToSystem { get; set; }// the date that when client added to system

        public ICollection<Payment> Payment { get; set; } = new List<Payment>();

        public ICollection<Item> Item { get; set; } = new List<Item>();

        //public Item Items { get; set; }


    }
}
