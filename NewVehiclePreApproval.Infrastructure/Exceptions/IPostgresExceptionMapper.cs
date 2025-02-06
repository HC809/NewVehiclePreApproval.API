using Npgsql;

namespace NewVehiclePreApproval.Infrastructure.Exceptions;
public interface IPostgresExceptionMapper
{
    PostgresExceptionDetails Map(PostgresException postgresException);
}
