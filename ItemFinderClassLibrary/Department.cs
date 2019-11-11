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
        public string Name { get; set; }

        private int _id;
        public int Id { get; set; }

        private string _description;
        public string Description { get; set; }

        public Department(string name, int id, string description)
        {
            
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

        }

        public void DownvoteItem(Item item)
        {

        }

    }
}
