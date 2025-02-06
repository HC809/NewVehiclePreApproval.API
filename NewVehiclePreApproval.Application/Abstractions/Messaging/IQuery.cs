using MediatR;
using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Application.Abstractions.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
