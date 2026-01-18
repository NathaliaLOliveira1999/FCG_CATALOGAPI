using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Model;
using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;

        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Sales> GetByIdSales(int idSales) => _context.Sales.Where(x => x.IdSales == idSales).ToList();
        public List<Sales> GetByIdClient(int idClient) => _context.Sales.Where(x => x.IdClient == idClient).ToList();

        public ServiceResult Add(Sales sale)
        {
            try
            {
                _context.Sales.Add(sale);
                _context.SaveChanges();
                return ServiceResult.Ok(sale);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir itens na biblioteca: " + ex.Message);
            }
        }
        public ServiceResult AddItens(List<SalesItens> salesItens)
        {
            try
            {
                _context.SalesItens.AddRange(salesItens);
                _context.SaveChanges();
                return ServiceResult.Ok(salesItens);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir itens na biblioteca: " + ex.Message);
            }
        }
    }
}
