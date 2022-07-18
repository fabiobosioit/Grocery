namespace Grocery.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class HiddenAttribute: Attribute
    {

    }
}
