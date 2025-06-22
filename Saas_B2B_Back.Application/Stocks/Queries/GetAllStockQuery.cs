
using MediatR;

namespace Saas_B2B_Back.Application.Stocks.Queries
{
    public record class GetAllStockQuery:IRequest<List<StockResponse>>
    {
    }
}
