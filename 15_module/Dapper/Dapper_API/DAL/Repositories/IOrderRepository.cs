using Models;
using Models.enums;

namespace Dapper_API.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetOrders();
        Task<OrderEntity> GetById(int id);
        Task Create(Order order);
        Task Update(Order order, int id);
        Task Delete(int id);
        Task<List<OrderEntity>> GetOrderByCreatedDateMonth(string month);
        Task<List<OrderEntity>> GetByStatus(Status status);
        Task BulkDeleteOrderById(List<int> ids);
    }
}
