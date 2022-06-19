using Models;
using Models.enums;

namespace Dapper_API.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetById(int id);

        Task Create(OrderDTO order);
        Task Update(OrderDTO order, int id);
        Task Delete(int id);
        Task<List<Order>> GetOrderByCreatedDateMonth(string month);
        Task<List<Order>> GetByStatus(Status status);
        Task BulkDeleteOrderById(List<int> ids);
    }
}
