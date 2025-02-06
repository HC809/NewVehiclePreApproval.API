using MediatR;
using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Application.Abstractions.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand { }

public interface IBaseCommand { }
