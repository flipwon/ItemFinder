using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary
{
    public class Item
    {
        private string _name;
        private int _id;
        private int _departmentId;
        private string _description;
        private float _price;
        private string _location;

        public Item(int departmentId, string name, string location, 
            string description = "No description available.", float price = -1)
        {
            Name = name;
            DepartmentId = departmentId;
            Description = description;
            Price = price;
            Location = location;
        }


        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public int DepartmentId
        {
            get => _departmentId;
            private set => _departmentId = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public float Price
        {
            get => _price;
            private set => _price = value;
        }


        public string Location
        {
            get => _location;
            private set => _location = value;
        }

        public void ChangeLocation(string loc)
        {
            this.Location = loc;
        }

    }
}
