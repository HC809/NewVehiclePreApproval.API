using MediatR;
using NewVehiclePreApproval.Domain.Abstractions;


namespace NewVehiclePreApproval.Application.Abstractions.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }
