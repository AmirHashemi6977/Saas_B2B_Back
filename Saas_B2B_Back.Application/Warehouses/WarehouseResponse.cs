using Saas_B2B_Back.Domain.Entities;

namespace Saas_B2B_Back.Application.Warehouses
{
    public class WarehouseResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        
    }
}
