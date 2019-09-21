namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
