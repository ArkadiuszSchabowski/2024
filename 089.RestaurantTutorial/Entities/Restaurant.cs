﻿namespace _089.RestaurantTutorial.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery {  get; set; }
        public string ContantPhone { get; set; }
        public string ContactEmail {  get; set; }
        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}