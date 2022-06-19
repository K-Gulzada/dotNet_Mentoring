using EntityFrameworkIntro.Entities;
using EntityFrameworkIntro.Interfaces;

namespace EntityFrameworkIntro.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory _factory;

        public OrderRepository(IDbContextFactory factory)
        {
            _factory = factory;
        }
        public void AddOrder(Order order)
        {
            using (var context = _factory.Create())
            {
                var newOrder = new Order
                {
                    Status = order.Status,
                    CreatedDate = order.CreatedDate,
                    UpdatedDate = order.UpdatedDate,
                    ProductId = order.ProductId
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            using (var context = _factory.Create())
            {
                var orderToDelete = context.Orders.SingleOrDefault(s => s.Id == order.Id);

                context.Orders.Remove(orderToDelete);

                context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            using (var context = _factory.Create())
            {
                var order = context.Orders.SingleOrDefault(s => s.Id == id);

                context.Orders.Remove(order);

                context.SaveChanges();
            }
        }

        public void BulkDeleteOrderById(List<int> ids)
        {
            using (var context = _factory.Create())
            {
                foreach (int id in ids)
                {
                    var order = context.Orders.SingleOrDefault(s => s.Id == id);

                    context.Orders.Remove(order);

                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (var context = _factory.Create())
            {
                return context.Orders.ToList();
            }
        }

        public Order GetOrder(int id)
        {
            using (var context = _factory.Create())
            {
                return context.Orders.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
