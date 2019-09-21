namespace Api.Infra.CrossCutting.IoC.ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>();
    }
}
