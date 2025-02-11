using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Dealerships.GetDealerships;
public sealed record GetDealershipsQuery() : IQuery<IEnumerable<DealershipResponse>>;
