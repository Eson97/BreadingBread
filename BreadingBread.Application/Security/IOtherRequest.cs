using MediatR;

namespace BreadingBread.Application.Security
{
    interface IOtherRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
