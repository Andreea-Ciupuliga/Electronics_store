using Electronics_store.DTOs;

namespace Electronics_store.Services.OrderProductRelationService
{
    public interface IOrderProductRelationService
    {
        public void CreateOrderProductRelation(OrderProductRelationRegisterDTO orderProductRelation);

    }
}