﻿using Azure;

namespace manage_dual.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int PaymentAmount { get; set; }

        public string PaymentType { get; set; }

        public int Payment_Client_id { get; set; }

        public client client { get; set; }

        public int ClientId { get; set; }



    }

}
