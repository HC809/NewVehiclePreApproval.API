using NewVehiclePreApproval.Application.Abstractions.Messaging;

namespace NewVehiclePreApproval.Application.Users.GetUsers;
public sealed record GetUsersQuery() : IQuery<IEnumerable<UserResponse>>;
