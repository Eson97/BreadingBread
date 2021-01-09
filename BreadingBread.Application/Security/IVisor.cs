using MediatR;

namespace BreadingBread.Application.Security
{
    interface IVisor<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
