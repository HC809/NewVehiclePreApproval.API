using Microsoft.Extensions.Configuration;
using NewVehiclePreApproval.Application.Abstractions.AppSettings;

namespace NewVehiclePreApproval.Infrastructure.AppSettings;
public class BusinessSettings : IBusinessSettings
{
    public Guid CofisaDealershipId { get; set; }
    public BusinessSettings(IConfiguration configuration)
    {
        var dealershipId = configuration["BusinessSettings:CofisaDealershipId"];

        if (string.IsNullOrEmpty(dealershipId))
        {
            throw new ArgumentNullException(nameof(dealershipId), "CofisaDealershipId cannot be null or empty.");
        }

        CofisaDealershipId = Guid.Parse(dealershipId);
    }
}
