﻿namespace _089.RestaurantTutorial.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery {  get; set; }
        public string ContactPhone { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}
