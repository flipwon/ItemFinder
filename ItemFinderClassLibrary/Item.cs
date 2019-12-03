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
        private int _rating;
        private string _imagePath;
        private string _location;
        
        public Item(string name, int departmentId, string description, float price, 
            string imagePath, string location)
        {
            Name = name;
            DepartmentId = departmentId;
            Description = description;
            Price = price;
            //ImagePath = imagePath;
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

        public int Rating
        {
            get => _rating;
            set => _rating = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            private set
            {

                //Validation checking for the inputted value
                if (!string.IsNullOrEmpty(value) /*&& File.Exists(value)*/)
                {

                    //Getting the extension of the file chosen
                    var fi = new FileInfo(value);
                    string ext = fi.Extension;

                    if ((Equals(ext, ".png") || Equals(ext, ".jpg") ||
                         Equals(ext, ".jpeg") || Equals(ext, ".gif")))
                    {
                        _imagePath = value;
                    }
                    else
                    {
                        throw new Exception("Invalid File Extension! " +
                                            "Please use .png, .jpg, .gif!");
                    }
                }
                else
                {
                    throw new Exception("Invalid File Path!");
                }
            }
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
