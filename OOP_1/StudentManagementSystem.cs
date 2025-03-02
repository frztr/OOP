namespace OOP_1;

public class StudentManagementSystem
{
    private List<Student> StudentsList = new List<Student>();

    public bool AddStudent(Student student)
    {
        this.StudentsList.Add(student);
        return true;
    }

    public void RemoveStudent(Guid Id)
    {
        Student? st = this.StudentsList.FirstOrDefault(x => x.GUID == Id);
        if (st != null)
        {
            this.StudentsList.Remove(st);
            Console.WriteLine("Студент удален");
        }
        else
        {
            Console.WriteLine("Студент не найден");
        }
    }

    public void DisplayStudentsList()
    {
        StudentsList.ToList().ForEach(x => x.DisplayData());
    }

    public void FindStudents(
        string searchName,
        string searchLastName,
        string searchPatronymic,
        string searchGroup
        )
    {
        StudentsList.Where(x =>
        searchName.ToLower().Contains(x.Name.ToLower()) ||
        searchLastName.ToLower().Contains(x.Lastname.ToLower()) ||
        searchPatronymic.ToLower().Contains(x.Patronymic.ToLower()) ||
        searchGroup.ToLower().Contains(x.Group.ToLower())
        ).ToList().ForEach(x => x.DisplayData());
    }
}