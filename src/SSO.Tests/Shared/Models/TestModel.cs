namespace SSO.Tests.Shared.Models
{
    public class TestModel<TProperty>
    {
        public TestModel(TProperty property)
        {
            Property = property;
        }

        public TProperty Property { get; set; }
    }
}
