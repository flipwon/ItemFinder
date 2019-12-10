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
        private List<Item> _itemList = new List<Item>();

        public Department(string name, int id, string description)
        {
            Name = name;
            StoreId = id;
            Description = description;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public int StoreId
        {
            get => _id;
            set => _id = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

    }
}
