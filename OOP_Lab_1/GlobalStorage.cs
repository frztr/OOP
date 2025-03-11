using System.Text.Json.Nodes;
namespace Lab_1;
using Newtonsoft.Json;

//Данные о курсах, студентах, преподавателях и дисциплинах нужно хранить в глобальных списках.
//Глобальное хранилище
public class GlobalStorage
{
    private static InitializationType initType = InitializationType.Json;

    private static CourseRepository courseRepository = new CourseRepository(initType);

    private static DisciplineRepository disciplineRepository = new DisciplineRepository(initType);

    private static LecturerRepository lecturerRepository = new LecturerRepository(initType);

    private static StudentRepository studentRepository = new StudentRepository(initType);
    private GlobalStorage()
    {

    }

    private static GlobalStorage storage;
    public static GlobalStorage GetStorage()
    {
        if (storage == null)
        {
            storage = new GlobalStorage();
        }
        return storage;
    }

    public List<T> GetList<T>()
    {
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                return studentRepository != null ? (List<T>)(object)studentRepository.list : new List<T>();
            case "Course":
                return courseRepository != null ? (List<T>)(object)courseRepository.list : new List<T>();
            case "Lecturer":
                return lecturerRepository != null ? (List<T>)(object)lecturerRepository.list : new List<T>();
            case "Discipline":
                return disciplineRepository != null ? (List<T>)(object)disciplineRepository.list : new List<T>();
            default:
                return null;
        }
    }

    public void SaveChanges()
    {
        Console.WriteLine("Синхронизация с базой данных");
        Task.Run(async () =>
        {
            await Task.WhenAll(
            courseRepository.SaveChanges(),
            studentRepository.SaveChanges(),
            lecturerRepository.SaveChanges(),
            disciplineRepository.SaveChanges());
        }).GetAwaiter().GetResult();
        Console.WriteLine("База данных синхронизирована");
    }
}