namespace MicroServices.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = false)]
    public class MPTable : System.Attribute
    {
        string Name;
        public double Version;

        public MPTable(string name)
        {
            Name = name;
        }

        public string GetName() => Name;
    }
}
