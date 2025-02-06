using System.Data;

namespace NewVehiclePreApproval.Application.Abstractions.Data;
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
