using Dapper.Application.Interfaces;

namespace Dapper.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ICarRepository productRepository,IBasketRepository basketRepository)
        {
            Cars = productRepository;
            Baskets = basketRepository;
        }
        public ICarRepository Cars { get; }
        public IBasketRepository Baskets { get; }

    }
}
