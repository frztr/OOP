namespace Lab_1;
public class Discipline : IEntity {
    public Guid Id {get;set;} = new Guid();
    public string Name {get;set;}

    public string Abbr {get;set;}

    public Lecturer Lecturer {get;set;}

    private Discipline(string name, string abbr,Lecturer lecturer){
        this.Name = name;
        this.Abbr = abbr;
        this.Lecturer = lecturer;
    }

    public static Discipline CreateNewDiscipline(string name, string abbr,Lecturer lecturer){
        return new Discipline(name,abbr,lecturer);
    }

    public void EditData(string name, string abbr,Lecturer lecturer){
        if(!String.IsNullOrEmpty(name)) Name = name;
        if(!String.IsNullOrEmpty(abbr)) Abbr = abbr;
        if(lecturer!=null) Lecturer = lecturer;
    }
}