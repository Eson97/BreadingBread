using MediatR;

namespace BreadingBread.Application.Security
{
    interface IProductorRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
