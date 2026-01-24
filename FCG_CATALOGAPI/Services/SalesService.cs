using AutoMapper;
using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Model;
using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;
using FCG_CATALOGAPI.Models.Enum;

namespace FCG_CATALOGAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public SalesService(ISalesRepository salesRepository, IMapper mapper, IGameService gameService)
        {
            _salesRepository = salesRepository;
            _mapper = mapper;
            _gameService = gameService;
        }

        public ServiceResult Add(SalesDto sales)
        {
            try
            {
                if (sales.Games.Count <= 0)
                    return ServiceResult.Fail("Preencha os jogos a serem adicionados na compra");

                if (sales.IdClient == null || sales.IdClient == 0)
                    return ServiceResult.Fail("Preencha o cliente relacionado a compra");

                var totalPrice = _gameService.GetValues(sales.Games);

                var sale = new Sales()
                {
                    PaymentMethod =3,
                    SaleDate = DateTime.Now,
                    IdClient = sales.IdClient,
                    IdPaymentStatus = PaymentStatus.Pendente,
                    TotalPrice = totalPrice
                };
                _salesRepository.Add(sale);

                var itens = new List<SalesItens>();
                foreach (var item in sales.Games)
                {
                    itens.Add(new SalesItens() { IdGames = item, IdSales = sale.IdSales });
                }
                _salesRepository.AddItens(itens);
                return ServiceResult.Ok(sale);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public List<SalesDto> GetByIdClient(int idCliente)
        {
            return _mapper.Map<List<SalesDto>>(_salesRepository.GetByIdClient(idCliente));
        }

        public List<SalesDto> GetByIdSale(int idSale)
        {
            return _mapper.Map<List<SalesDto>>(_salesRepository.GetByIdSales(idSale));
        }
    }
}
