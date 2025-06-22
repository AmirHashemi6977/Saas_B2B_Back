
using MediatR;

namespace Saas_B2B_Back.Application.Stocks.Queries
{
    public record class GetStockByIdQuery : IRequest<StockResponse>
    {
        public int Id { get; set; }
        public GetStockByIdQuery(int id)
        {
            Id = id;
        }
    }
}
