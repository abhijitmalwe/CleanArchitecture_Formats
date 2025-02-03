using PdsCleanAppCore.Common.Interfaces;

namespace PdsCleanAppInfrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
