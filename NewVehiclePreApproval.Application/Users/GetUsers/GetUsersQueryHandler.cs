using Dapper;
using NewVehiclePreApproval.Application.Abstractions.Data;
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Application.Users.GetUsers;
internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUsersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            select 
            	u.id AS ID,
            	u.name AS Name,
            	u.email AS Email,
            	d.name AS Dealership,
            	u.hashPassword AS Password, 
            	u.role AS Role, 
            	u.verificationType AS VerificationType,
            	u.isActive AS IsActive
            from users u
            join dealerships d on d.id = u.dealershipid;
            """;

        IEnumerable<UserResponse> users = await connection.QueryAsync<UserResponse>(sql);

        return Result.Success(users);
    }
}
