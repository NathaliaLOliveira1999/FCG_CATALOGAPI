using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Interfaces.Services
{
    public interface ISalesService
    {
        ServiceResult Add(SalesDto sales);
        List<SalesDto> GetByIdClient(int idCliente);
        List<SalesDto> GetByIdSale(int idSale);
    }
}
