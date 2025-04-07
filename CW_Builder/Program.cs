using System.Text.RegularExpressions;
using Newtonsoft.Json;

AppContext.Init(args);
DirectoryInfo directoryInfo = new DirectoryInfo($"{AppContext.Get().ProjectPath}/Entities/");
if (!directoryInfo.Exists)
{
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Entities/");
    Console.WriteLine("Папка Entites не была найдена, поэтому была создана.");
}

List<Entity> entities = new List<Entity>();

if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories"))
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services"))
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Controllers"))
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Controllers");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/DTO"))
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/DTO");

foreach (var file in directoryInfo.GetFiles())
{
    var fileText = File.ReadAllText($"{AppContext.Get().ProjectPath}/Entities/{file.Name.Replace(".cs","")}.cs");
    var entityName = Regex.Match(fileText, @"public class ([\w]+)").Value.Replace("public class ", "");
    var entityBody = new Regex(@"((public class ([\w]+)[\W]{1}[\\{]{1})|([\\{]{1} get; set; [\\}]{1})|([\\}]{1}))+").Replace(
    Regex.Match(fileText, @"public class ([\w]+)[\W]{1}[\\{]{1}[\w\W]+[\\}]{1}").Value, "");
    var props = Regex.Matches(entityBody, @"\w+ \w+ \w+");
    var entProps = props.ToList().Select(x =>
    {
        var s = x.Value.Split(" ");
        return new EntityProp()
        {
            Modificator = s[0],
            Type = s[1],
            Name = s[2]
        };
    });

    Entity entity = new Entity()
    {
        Name = entityName,
        Props = entProps.ToList()
    };
    entities.Add(entity);
    Console.WriteLine(JsonConvert.SerializeObject(entity));
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}");
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services/{entity.Name}");
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}");

    var irepository = RepositoryInterfaceCreator.CreateRepository(entity);
    var repository = RepositoryCreator.CreateRepository(entity);
    var iservice = ServiceInterfaceCreator.CreateService(entity);
    var service = ServiceCreator.CreateService(entity);
    var controller = ControllerCreator.CreateController(entity);
    var addDto = AddDtoCreator.CreateDto(entity);
    var dto = DtoCreator.CreateDto(entity);
    var dtoList = DtoListCreator.CreateDto(entity);
    var updateDto = UpdateDtoCreator.CreateDto(entity);

    File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}/I{entity.Name}Repository.cs", irepository);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}/{entity.Name}Repository.cs", repository);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Services/{entity.Name}/I{entity.Name}Service.cs", iservice);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Services/{entity.Name}/{entity.Name}Service.cs", service);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Controllers/{entity.Name}Controller.cs", controller);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/Add{entity.Name}Dto.cs", addDto);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{entity.Name}Dto.cs", dto);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{entity.Name}ListDto.cs", dtoList);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/Update{entity.Name}Dto.cs", updateDto);
}

var programCs = ProgramCsCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/Program.cs", programCs);
var appDbContextCs = AppDbContextCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/AppDbContext.cs", appDbContextCs);


