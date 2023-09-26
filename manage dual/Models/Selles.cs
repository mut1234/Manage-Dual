namespace manage_dual.Models
{
    public class selles
    {
        public int salle_id { get; set; }

        public string selleName{ get; set; }

        public int selleAmount { get;}

        public string selleType { get; set; }

        public int salesClient { get; set; }

        public client client { get; set; }

        public int ClientForeignKey { get; set; }

    }


}
