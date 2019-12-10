using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ItemFinderClassLibrary;
using ItemFinderClassLibrary.DAL;

namespace ItemFinderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetItems" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetItems.svc or GetItems.svc.cs at the Solution Explorer and start debugging.
    public class GetItems : IGetItems
    {
        List<Item> IGetItems.GetItems()
        {
            var itemDao = new ItemDao(Properties.Settings.Default.conString);
            var items = itemDao.GetItems();
            return items;
        }
    }
}
