using Dapper;
using NewVehiclePreApproval.Application.Abstractions.Data;
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Application.Dealerships.GetDealerships;
internal sealed class GetDealershipsQueryHandler : IQueryHandler<GetDealershipsQuery, IEnumerable<DealershipResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetDealershipsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<DealershipResponse>>> Handle(GetDealershipsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                d.id AS Id,
                d.name AS Name,
                d.address AS Address,
                d.phonenumber AS PhoneNumber,
                d.email AS Email
            FROM
                dealerships AS d;
        """;

        IEnumerable<DealershipResponse> dealerships = await connection.QueryAsync<DealershipResponse>(sql);

        return Result.Success(dealerships);
    }
}
