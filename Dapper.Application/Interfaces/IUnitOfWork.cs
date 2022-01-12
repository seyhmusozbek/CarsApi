using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        IBasketRepository Baskets { get; }

    }
}
