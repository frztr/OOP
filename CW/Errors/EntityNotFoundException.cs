using Newtonsoft.Json;

public class EntityNotFoundException<T>: Exception{
    
    private object obj;
    public EntityNotFoundException(){

    }

    public EntityNotFoundException(object obj){
        this.obj = obj;
    }
    public override string Message => $@"Сущность {typeof(T).Name}{(obj != null?$" c {JsonConvert.SerializeObject(obj)}":"")} не найдена.";

    
}