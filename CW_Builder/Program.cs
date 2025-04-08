using System.Text.RegularExpressions;

AppContext.Init(args);
DirectoryInfo directoryInfo = new DirectoryInfo($"{AppContext.Get().ProjectPath}/Data/");
if (!directoryInfo.Exists)
{
    Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Data/");
    Console.WriteLine("Папка Data не была найдена, поэтому была создана.");
}

List<Entity> entities = new List<Entity>();
List<string> LayerTypes = new List<string>() { "Controller", "Service", "Repository" };

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
    //Parsing
    var fileText = File.ReadAllText($"{AppContext.Get().ProjectPath}/Data/{file.Name.Replace(".cs", "")}.cs");
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
    //Creating
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}");
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services/{entity.Name}");
    if (!Directory.Exists($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}"))
        Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}");

    string irepository, repository, iservice, service, controller;
    if (entity.Name != "User")
    {
        irepository = RepositoryInterfaceCreator.CreateRepository(entity);
        repository = RepositoryCreator.CreateRepository(entity);
        iservice = ServiceInterfaceCreator.CreateService(entity);
        service = ServiceCreator.CreateService(entity);
        controller = ControllerCreator.CreateController(entity);
    }
    else
    {
        irepository = UserRepositoryInterfaceCreator.CreateRepository(entity);
        repository = UserRepositoryCreator.CreateRepository(entity);
        iservice = UserServiceInterfaceCreator.CreateService(entity);
        service = UserServiceCreator.CreateService(entity);
        controller = UserControllerCreator.CreateController(entity);
    }

    File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}/I{entity.Name}Repository.cs", irepository);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}/{entity.Name}Repository.cs", repository);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Services/{entity.Name}/I{entity.Name}Service.cs", iservice);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Services/{entity.Name}/{entity.Name}Service.cs", service);
    File.WriteAllText($"{AppContext.Get().ProjectPath}/Controllers/{entity.Name}Controller.cs", controller);
    foreach (var layer in LayerTypes)
    {
        if (!Directory.Exists($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}"))
            Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}");
        string addDto, dto, dtoList, updateDto;
        if (entity.Name != "User")
        {
            addDto = AddDtoCreator.CreateDto(entity, layer);
            dto = DtoCreator.CreateDto(entity, layer);
            dtoList = DtoListCreator.CreateDto(entity, layer);
            updateDto = UpdateDtoCreator.CreateDto(entity, layer);
        }
        else{
            addDto = UserAddDtoCreator.CreateDto(entity, layer);
            dto = UserDtoCreator.CreateDto(entity, layer);
            dtoList = UserDtoListCreator.CreateDto(entity, layer);
            updateDto = UserUpdateDtoCreator.CreateDto(entity, layer);
            var userLoginDto = UserLoginDtoCreator.CreateDto(entity,layer);
            var userLoginResultDto = UserLoginResultDtoCreator.CreateDto(entity,layer);
            File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/UserLogin{layer}Dto.cs", userLoginDto);
            File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/UserLoginResult{layer}Dto.cs", userLoginResultDto);
        }

        File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/Add{entity.Name}{layer}Dto.cs", addDto);
        File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/{entity.Name}{layer}Dto.cs", dto);
        File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/{entity.Name}{layer}ListDto.cs", dtoList);
        File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/Update{entity.Name}{layer}Dto.cs", updateDto);
    }
}

var programCs = ProgramCsCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/Program.cs", programCs);
var appDbContextCs = AppDbContextCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/AppDbContext.cs", appDbContextCs);


