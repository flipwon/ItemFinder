using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary
{
    public class Department
    {
        private string _name;
        private int _id;
        private string _description;

        public Department(string name, int id, string description)
        {
            Name = name;
            Id = id;
            Description = description;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public Item SearchItem(string name)
        {
            return null;
        }

        public void AddItem(Item item)
        {
            
        }

        public Item EditItem(Item item)
        {
            return null;
        }

        public bool DeleteItem(Item item)
        {
            return true;
        }

        public void UpvoteItem(Item item)
        {
            item.Rating++;
        }

        public void DownvoteItem(Item item)
        {
            item.Rating--;
        }

    }
}
