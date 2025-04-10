public class EntityProp
{
    public string Modificator { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }

    public bool PK { get; set; } = false;

    public bool Identity { get; set; } = false;

    public int? HasMaxLength { get; set; } = null;

    public bool IsRequired { get; set; } = false;
}