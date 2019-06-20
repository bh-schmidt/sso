namespace SSO.Infra.ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>();
    }
}
