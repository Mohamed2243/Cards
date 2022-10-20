﻿using System.ComponentModel.DataAnnotations;

namespace CardApi.Model
{
    public class  Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardNumber { get; set; }
        public int CardOlderName { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int cvc { get; set; }
    }
}