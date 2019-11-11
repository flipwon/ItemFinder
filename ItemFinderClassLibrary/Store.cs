using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary
{
    public class Store
    {
        private string _name;
        public string Name { get; set; }

        private int _id;
        public int Id { get; set; }

        private string _location;
        public string Location { get; set; }

        private string _mapPath;
        public string MapPath { get; set; }

        private List<Department> _departments;
        public List<Department> Departments { get; set; }

        public Store(string name, int id, string location, string mapPath, List<Department> departments)
        {
            
        }
    }
}
