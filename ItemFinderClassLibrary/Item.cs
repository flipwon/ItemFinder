using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary
{
    public class Item
    {
        private string _name;
        public string Name { get; set; }

        private int _id;
        public int Id { get; set; }

        private string _description;
        public string Description { get; set; }

        private float _price;
        public float Price { get; set; }

        private bool _sale;
        public bool Sale { get; set; }

        private string _imagePath;
        public string ImagePath { get; set; }

        public Item(string name, int id, string description, float price, bool sale, string imagePath)
        {
            
        }
    }
}
