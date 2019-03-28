namespace VuelingExam.Infrastructure.Contracts.Repository
{
    public interface IReadBySku<out T>
    {
        T ReadBySku(string id);
    }
}