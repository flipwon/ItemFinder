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
        private string _description;
        private float _price;
        private bool _sale;
        private int _rating;
        private string _imagePath;
        private Vector2 _location;
        
        public Item(string name, int id, string description, float price, 
            bool sale, string imagePath, Vector2 location, int rating = 0)
        {
            Name = name;
            Id = id;
            Description = description;
            Price = price;
            Sale = sale;
            Rating = rating;
            ImagePath = imagePath;
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

        public bool Sale
        {
            get => _sale;
            private set => _sale = value;
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
                if (!string.IsNullOrEmpty(value) && File.Exists(value))
                {

                    //Getting the extension of the file chosen
                    var fi = new FileInfo(value);
                    string ext = fi.Extension;

                    if ((Equals(ext, ".png") || Equals(ext, ".jpg") || 
                         Equals(ext, ".jpeg") || Equals(ext, ".gif"))){
                        _imagePath = value;
                    } else
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

        public Vector2 Location
        {
            get => _location;
            private set => _location = value;
        }

        public void ChangeLocation(Vector2 loc)
        {
            this.Location = loc;
        }

    }
}
