using System.Text.Json.Nodes;
namespace Lab_1;
using Newtonsoft.Json;

//Данные о курсах, студентах, преподавателях и дисциплинах нужно хранить в глобальных списках.
//Глобальное хранилище
public class GlobalStorage
{
    private static InitializationType initType = InitializationType.Json;

    private CourseRepository courseRepository = new CourseRepository(initType);

    private DisciplineRepository disciplineRepository = new DisciplineRepository(initType);

    private LecturerRepository lecturerRepository = new LecturerRepository(initType);

    private StudentRepository studentRepository = new StudentRepository(initType);
    private GlobalStorage()
    { }

    private static GlobalStorage storage;
    public static GlobalStorage GetStorage()
    {
        if (storage == null)
        {
            storage = new GlobalStorage();
            Task.Run(async () =>
            {
                await storage.courseRepository.Init();
                await Task.WhenAll(
                    storage.disciplineRepository.Init(),
                    storage.lecturerRepository.Init(),
                    storage.studentRepository.Init()
                );
            }).GetAwaiter().GetResult();
        }
        return storage;
    }

    public List<T> GetList<T>()
    {
        switch (typeof(T).Name.ToString())
        {
            case "Student":
                return (List<T>)(object)studentRepository.list;
            case "Course":
                return (List<T>)(object)courseRepository.list;
            case "Lecturer":
                return (List<T>)(object)lecturerRepository.list;
            case "Discipline":
                return (List<T>)(object)disciplineRepository.list;
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