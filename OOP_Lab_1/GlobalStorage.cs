using Lab_1;

//Данные о курсах, студентах, преподавателях и дисциплинах нужно хранить в глобальных списках.
//Глобальное хранилище
public class GlobalStorage
{
    private static GlobalStorage storage;
    private List<Course> courses = Course.Entities;
    private List<Discipline> disciplines = Discipline.Entities;
    private List<Lecturer> lecturers = Lecturer.Entities;
    private List<Student> students = Student.Entities;
    private GlobalStorage()
    {
        Course c1 = new Course(1);
        Course c2 = new Course(2);
        Course c3 = new Course(3);
        Course c4 = new Course(4);
        courses.AddRange(new List<Course>(){
            c1,c2,c3,c4
        });
        
        Discipline.AddNew("Объектно-ориентированное программирование", "");
        Discipline.AddNew("Сети и телекоммуникации", "");
        Discipline.AddNew("Экономика отрасли", "");
        Discipline.AddNew("Иностранный язык", "");
        Discipline.AddNew("Авиационные материалы и технологии", "");
        Discipline.AddNew("Основы менеджмента", "");
        Discipline.AddNew("Базы данных", "");
        Discipline.AddNew("Математический анализ", "");
        Discipline.AddNew("Компьютерная графика", "");
        Discipline.AddNew("Информатика", "");

        Lecturer.AddNew("Борис", "Новиков", 31, "Борисович", "нет");
        Lecturer.AddNew("Александр", "Челпанов", 46, "Витальевич", "доцент по кафедре \"Моделирования систем и информационных технологий\"");
        Lecturer.AddNew("Ольга", "Степнова", 56, "Викторовна", "доцент по кафедре \"Экономика и управление\"");
        Lecturer.AddNew("Ирина", "Старчикова", 60, "Юрьевна", "нет");
        Lecturer.AddNew("Игорь ", "Мамонов", 65, "Михайлович", "Доцент по кафедре \"Прикладная математика\"");
        Lecturer.AddNew("Светлана", "Курашова", 41, "Александровна", "нет");
        Lecturer.AddNew("Павел", "Антонов", 30, "Алексеевич", "нет");
        Lecturer.AddNew("Елена", "Каратаева", 25, "Сергеевна", "нет");
        Lecturer.AddNew("Людмила", "Еременская", 65, "Ивановна", "нет");
        Lecturer.AddNew("Юлия", "Егорова", 67, "Борисовна", @"
Доцент по кафедре «Прикладная математика»
Профессор по кафедре «Материаловедение и пластическая деформация металлов»");

        Student.AddNew("Егор","Иванов",18,"Дмитриевич","ТСО-105Б-22",c1);
        Student.AddNew("Иван","Петров",19,"Данилович","ТСО-205Б-22",c2);
        Student.AddNew("Александр","Данилов",20,"Егорович","ТСО-305Б-22",c3);
        Student.AddNew("Дмитрий","Артёмов",21,"Иванович","ТСО-405Б-22",c4);
        Student.AddNew("Василий","Ильин",18,"Петрович","ТСО-105Б-22",c1);
        Student.AddNew("Петр","Иванов",19,"Александрович","ТСО-205Б-22",c2);
        Student.AddNew("Степан","Александров",20,"Ильич","ТСО-305Б-22",c3);
        Student.AddNew("Даниил","Васильев",21,"Алексеевич","ТСО-405Б-22",c4);
        Student.AddNew("Артём","Егоров",18,"Артёмович","ТСО-105Б-22",c1);
        Student.AddNew("Иван","Степанов",19,"Васильевич","ТСО-205Б-22",c2);
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