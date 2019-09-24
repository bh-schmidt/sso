namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class LongExtensions
    {
        public static bool IsZero(this long value)
        {
            return value == 0;
        }
    }
}
