using MediatR;

namespace BreadingBread.Application.Security
{
    interface IUserRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

    }
}
