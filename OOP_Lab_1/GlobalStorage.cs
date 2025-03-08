using Lab_1;

//Данные о курсах, студентах, преподавателях и дисциплинах нужно хранить в глобальных списках.
//Глобальное хранилище
public class GlobalStorage
{
    private static GlobalStorage storage;
    private List<Course> courses;
    private List<Discipline> disciplines;
    private List<Lecturer> lecturers;
    private List<Student> students;
    private GlobalStorage()
    {
        Course c1 = new Course(1);
        Course c2 = new Course(2);
        Course c3 = new Course(3);
        Course c4 = new Course(4);
        courses = new List<Course>(){
            c1,c2,c3,c4
        };
        disciplines = new List<Discipline>(){
        new Discipline("Объектно-ориентированное программирование", ""),
        new Discipline("Сети и телекоммуникации", ""),
        new Discipline("Экономика отрасли", ""),
        new Discipline("Иностранный язык", ""),
        new Discipline("Авиационные материалы и технологии", ""),
        new Discipline("Основы менеджмента", ""),
        new Discipline("Базы данных", ""),
        new Discipline("Математический анализ", ""),
        new Discipline("Компьютерная графика", ""),
        new Discipline("Информатика", "")};

        lecturers = new List<Lecturer>(){
        new Lecturer("Борис", "Новиков", 31, "Борисович", "нет"),
        new Lecturer("Александр", "Челпанов", 46, "Витальевич", "доцент по кафедре \"Моделирования систем и информационных технологий\""),
        new Lecturer("Ольга", "Степнова", 56, "Викторовна", "доцент по кафедре \"Экономика и управление\""),
        new Lecturer("Ирина", "Старчикова", 60, "Юрьевна", "нет"),
        new Lecturer("Игорь ", "Мамонов", 65, "Михайлович", "Доцент по кафедре \"Прикладная математика\""),
        new Lecturer("Светлана", "Курашова", 41, "Александровна", "нет"),
        new Lecturer("Павел", "Антонов", 30, "Алексеевич", "нет"),
        new Lecturer("Елена", "Каратаева", 25, "Сергеевна", "нет"),
        new Lecturer("Людмила", "Еременская", 65, "Ивановна", "нет"),
        new Lecturer("Юлия", "Егорова", 67, "Борисовна", @"
Доцент по кафедре «Прикладная математика»
Профессор по кафедре «Материаловедение и пластическая деформация металлов»")};

        students = new List<Student>(){
        new Student("Егор","Иванов",18,"Дмитриевич","ТСО-105Б-22",c1),
        new Student("Иван","Петров",19,"Данилович","ТСО-205Б-22",c2),
        new Student("Александр","Данилов",20,"Егорович","ТСО-305Б-22",c3),
        new Student("Дмитрий","Артёмов",21,"Иванович","ТСО-405Б-22",c4),
        new Student("Василий","Ильин",18,"Петрович","ТСО-105Б-22",c1),
        new Student("Петр","Иванов",19,"Александрович","ТСО-205Б-22",c2),
        new Student("Степан","Александров",20,"Ильич","ТСО-305Б-22",c3),
        new Student("Даниил","Васильев",21,"Алексеевич","ТСО-405Б-22",c4),
        new Student("Артём","Егоров",18,"Артёмович","ТСО-105Б-22",c1),
        new Student("Иван","Степанов",19,"Васильевич","ТСО-205Б-22",c2)};
    }

    public static List<T> GetList<T>()
    {
        if (storage == null)
            storage = new GlobalStorage();
        object list = null;
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                list = (object)storage.students;
                break;
            case "Course":
                list = (object)storage.courses;
                break;
            case "Lecturer":
                list = (object)storage.lecturers;
                break;
            case "Discipline":
                list = (object)storage.disciplines;
                break;
        }

        if (list != null)
        {
            return (List<T>)list;
        }

        return null;
    }
}