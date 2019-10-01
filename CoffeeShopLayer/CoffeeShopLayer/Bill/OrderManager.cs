using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopLayer.Repository;
using CoffeeShopLayer.Model;
namespace CoffeeShopLayer.Bill
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public DataTable ShowOrder()
        {
            return _orderRepository.ShowOrder();
        }
        public DataTable SearchOrder(Item _item)
        {
            return _orderRepository.SearchOrder(_item);
        }
        public bool AddInfo(Item _item)
        {
            return _orderRepository.AddInfo(_item);
        }
        public bool UpdateItem(Item _item)
        {
            return _orderRepository.UpdateItem(_item);
        }
        public bool DeleteItem(Item _item)
        {
            return _orderRepository.DeleteItem(_item);
        }
    }
}
