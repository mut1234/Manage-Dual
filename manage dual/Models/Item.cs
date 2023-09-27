namespace manage_dual.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string ItemName{ get; set; }

        public int ItemAmount { get;}

        public string ItemType { get; set; }


        public DateTime ItemDateAddedToSystem { get; set; }// the date that when Item added to system


        public client client { get; set; }

        public int Client_Item_Id { get; set; }




    }


}
