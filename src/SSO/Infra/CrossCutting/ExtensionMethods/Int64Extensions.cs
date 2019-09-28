namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class Int64Extensions
    {
        public static bool IsZero(this long value)
        {
            return value == 0;
        }
    }
}
