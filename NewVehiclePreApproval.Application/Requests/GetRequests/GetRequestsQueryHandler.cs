using Dapper;
using NewVehiclePreApproval.Application.Abstractions.Data;
using NewVehiclePreApproval.Application.Abstractions.Messaging;
using NewVehiclePreApproval.Domain.Abstractions;

namespace NewVehiclePreApproval.Application.Requests.GetRequests;
internal sealed class GetRequestsQueryHandler : IQueryHandler<GetRequestsQuery, IEnumerable<RequestResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetRequestsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IEnumerable<RequestResponse>>> Handle(GetRequestsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                r.id AS Id,
                r.status AS Status,
                r.created_at AS CreatedAt,
                r.rejection_reason AS RejectionReason,
                r.seller_information_dealership AS Dealership,
                r.seller_information_vendor_name AS VendorName,
                r.client_information_full_name AS FullName,
                r.client_information_email AS Email,
                r.client_information_phone_number AS PhoneNumber,
                r.client_information_dni AS Dni,
                r.client_information_rtn AS Rtn,
                r.client_information_estimated_monthly_income AS EstimatedMonthlyIncome,
                r.client_information_state AS State,
                r.client_information_city AS City,
                r.client_information_home_address AS HomeAddress,
                r.client_information_work_or_business_name AS WorkOrBusinessName,
                r.client_information_work_or_business_description AS WorkOrBusinessDescription,
                r.client_information_work_or_business_address AS WorkOrBusinessAddress,
                r.vehicle_information_brand AS Brand,
                r.vehicle_information_model AS Model,
                r.vehicle_information_year AS Year,
                r.vehicle_information_type AS Type,
                r.vehicle_information_price AS Price
            FROM
                requests AS r;
        """;

        IEnumerable<RequestResponse> requests = await connection.QueryAsync<RequestResponse, SellerResponse, ClientResponse, VehicleResponse, RequestResponse>(
            sql, (request, seller, client, vehicle) =>
            {
                return new RequestResponse
                {
                    Id = request.Id,
                    Status = request.Status,
                    RejectionReason = request.RejectionReason,
                    CreatedAt = request.CreatedAt,
                    SellerInformation = seller,
                    ClientInformation = client,
                    VehicleInformation = vehicle
                };
            },
            splitOn: "Dealership,FullName,Brand");

        return Result.Success(requests);
    }
}
