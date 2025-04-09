public class Entity
{
    public string Name { get; set; }

    public List<EntityProp> Props { get; set; }

    public bool ExtendedSearch { get; set; } = false;
}