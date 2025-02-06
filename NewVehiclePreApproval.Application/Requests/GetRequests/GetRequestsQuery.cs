using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Requests.GetRequests;
public sealed record GetRequestsQuery() : IQuery<IEnumerable<RequestResponse>>;