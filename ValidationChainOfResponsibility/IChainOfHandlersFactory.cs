namespace ValidationChainOfResponsibility
{
    public interface IChainOfHandlersFactory<TEntity>
        where TEntity : class
    {
        IValidationHandler<TEntity> Create();
    }
}
