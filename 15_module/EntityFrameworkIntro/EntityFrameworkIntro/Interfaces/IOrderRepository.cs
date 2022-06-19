using EntityFrameworkIntro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkIntro.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);

        Order GetOrder(int id);

        IEnumerable<Order> GetAll();

        void DeleteOrder(Order order);

        void DeleteOrder(int id);
        void BulkDeleteOrderById(List<int> ids);
    }
}
