using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommand<TRequest>
    {
        Task Execute(TRequest request);
    }

    public interface ICommand<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
