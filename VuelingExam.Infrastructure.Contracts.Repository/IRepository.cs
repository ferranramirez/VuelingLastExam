namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IRepository<T> : IRead<T>, ICreate<T>
    {
    }
}
