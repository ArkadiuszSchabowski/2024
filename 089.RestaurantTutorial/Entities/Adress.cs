﻿namespace _089.RestaurantTutorial.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street {  get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}