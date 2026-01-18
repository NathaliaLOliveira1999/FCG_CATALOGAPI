using FCG_CATALOGAPI.Model;
using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Interfaces.Repositories
{
    public interface ISalesRepository
    {
        List<Sales> GetByIdClient(int idClient);
        List<Sales> GetByIdSales(int idSales);
        ServiceResult Add(Sales sale); 
        ServiceResult AddItens(List<SalesItens> salesItens);
    }
}
