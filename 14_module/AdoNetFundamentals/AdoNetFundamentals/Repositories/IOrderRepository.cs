using AdoNetFundamentals.Entities;

namespace AdoNetFundamentals.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        void AddOrder(DateTime createdDate, DateTime updatedDate, string status, int productId);
        void UpdateOrder(string columnName, string value, int id);
        void DeleteOrderById(int id);
        void BulkDeleteOrderById(List<int> ids);
        List<Order> GetOrderByCreatedDateMonth(string month);
        List<Order> GetOrderByStatus(string statusvalue);
        List<Order> GetOrderByStatusUsingAdapter(string statusvalue);

    }
}
