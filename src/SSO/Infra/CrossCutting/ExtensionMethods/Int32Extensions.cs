namespace SSO.Infra.CrossCutting.ExtensionMethods
{
    public static class Int32Extensions
    {
        public static bool IsZeroOrLess(this int value)
        {
            return value < 1;
        }
    }
}
