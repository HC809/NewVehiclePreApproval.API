using Microsoft.Data.SqlClient;

namespace NewVehiclePreApproval.Infrastructure.Exceptions;
public interface ISqlServerExceptionMapper
{
    SqlServerExceptionDetails Map(SqlException postgresException);
}
