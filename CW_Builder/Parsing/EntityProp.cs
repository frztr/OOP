public class EntityProp
{
    public string Modificator { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }

    public bool PK { get; set; } = false;

    public bool Identity { get; set; } = false;

    public int? HasMaxLength { get; set; } = null;

    public bool IsRequired { get; set; } = false;

    public bool Unique { get; set; } = false;

    public string? FK { get; set; } = null;

    public string? FK_Field { get; set; } = null;

    public string? Default { get; set; } = null;
}