namespace App.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(); //etkilenen satır sayısını dönecek
    }
}
