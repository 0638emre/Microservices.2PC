namespace Coordinator.Services.Abstraction;

public interface ITransactionService
{
    Task<Guid> CreateTransaction();
    Task PrepareServices(Guid transactionId);
    Task<bool> CheckReadyServices(Guid transactionId);
    Task Commit(Guid transactionId);
    Task<bool> CheckTransactionStateServices(Guid transactionId);
    Task Rollback(Guid transactionId);
}