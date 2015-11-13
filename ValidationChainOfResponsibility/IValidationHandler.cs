namespace ValidationChainOfResponsibility
{
    public interface IValidationHandler<in TEntity> 
        where TEntity: class 
    {
        ValidationHandlerResult Validate(TEntity entity);
    }
}
