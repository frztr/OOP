public interface IConverter<InType,OutType>{
    public OutType Convert(InType value);
}