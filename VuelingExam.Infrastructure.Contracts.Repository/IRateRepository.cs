using VuelingExam.Infrastructure.DataModel;

namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IRateRepository : IReadAll<RateDM>, ICreate<RateDM>, IReadById<RateDM>
    {
    }
}
