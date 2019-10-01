using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopLayer.Repository;
namespace CoffeeShopLayer.Model
{
    public class Item
    {
        public string Name { set; get; }
        public int Price { set; get; }
        public string SearchName { set; get; }
        public int Id { set; get; }
    }
}
