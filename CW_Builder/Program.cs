using System.Diagnostics;

AppContext.Init(args);
// List<List<string>> commands = new List<List<string>>(){
//    new List<string>(){"dotnet","new sln --force","/"},
//    new List<string>(){"dotnet","new classlib --name Shared --force","/"},
//    // new List<string>(){"rm","./Shared/Class1.cs","/"},
//    new List<string>(){"dotnet",@"add package Newtonsoft.Json",@"/Shared"},
//    new List<string>(){"dotnet","build","/Shared"},
//    new List<string>(){"dotnet","new classlib --name Data --force","/"},
//    // new List<string>(){"rm","./Data/Class1.cs","/"},
//    new List<string>(){"dotnet",@"add package Microsoft.EntityFrameworkCore.Design",@"/Data"},
//    new List<string>(){"dotnet",@"add package Npgsql.EntityFrameworkCore.PostgreSQL",@"/Data"},
//    new List<string>(){"dotnet","build","/Data"},
//    new List<string>(){"dotnet","new classlib --name Repositories --force","/"},
//    // new List<string>(){"rm","./Repositories/Class1.cs","/"},
//    new List<string>(){"dotnet","add reference ../Shared/Shared.csproj","/Repositories"},
//    new List<string>(){"dotnet","add reference ../Data/Data.csproj","/Repositories"},
//    new List<string>(){"dotnet",@"add package Microsoft.EntityFrameworkCore.Design",@"/Repositories"},
//    new List<string>(){"dotnet",@"add package Npgsql.EntityFrameworkCore.PostgreSQL",@"/Repositories"},
//    new List<string>(){"dotnet",@"add package AutoMapper",@"/Repositories"},
//    new List<string>(){"dotnet",@"add package Swashbuckle.AspNetCore",@"/Repositories"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Identity",@"/Repositories"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Identity.EntityFrameworkCore",@"/Repositories"},
//    new List<string>(){"dotnet","build","/Repositories"},
//    new List<string>(){"dotnet","new classlib --name Services --force","/"},
//    // new List<string>(){"rm","./Services/Class1.cs","/"},
//    new List<string>(){"dotnet","add reference ../Shared/Shared.csproj","/Services"},
//    new List<string>(){"dotnet","add reference ../Repositories/Repositories.csproj","/Services"},
//    new List<string>(){"dotnet",@"add package AutoMapper",@"/Services"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Authentication.JwtBearer",@"/Services"},
//    new List<string>(){"dotnet",@"add package Microsoft.Extensions.Logging",@"/Services"},
//    new List<string>(){"dotnet","build","/Services"},
//    new List<string>(){"dotnet",@"new webapi --name ""Web API"" --force","/"},
//    new List<string>(){"dotnet","add reference ../Shared/Shared.csproj","/Services"},
//    new List<string>(){"dotnet","add reference ../Services/Services.csproj","/Web API"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Authentication.JwtBearer",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Identity",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Identity.EntityFrameworkCore",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.Mvc.NewtonsoftJson",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Microsoft.AspNetCore.OpenApi",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Newtonsoft.Json",@"/Web API"},
//    new List<string>(){"dotnet",@"add package Swashbuckle.AspNetCore",@"/Web API"},
//    new List<string>(){"dotnet",@"add package AutoMapper",@"/Web API"},
//    new List<string>(){"dotnet",@"new tool-manifest --force",@"/Web API"},
//    new List<string>(){"dotnet",@"tool install --local dotnet-ef",@"/Web API"},
//    new List<string>(){"dotnet","build","/Web API"},
//    new List<string>(){"dotnet",@"sln add Data","/"},
//    new List<string>(){"dotnet",@"sln add Repositories","/"},
//    new List<string>(){"dotnet",@"sln add Services","/"},
//    new List<string>(){"dotnet",@"sln add ""Web API""","/"}
// };
// commands.ForEach(x =>
// {
//    Process p = new Process();
//    p.StartInfo.UseShellExecute = true;
//    p.StartInfo.WorkingDirectory = $"{AppContext.Get().ProjectPath}{x[2]}";
//    p.StartInfo.FileName = x[0];
//    p.StartInfo.Arguments = x[1];
//    p.Start();
//    p.WaitForExit();
// });

new List<string>(){
   "Shared/Class1.cs",
   "Data/Class1.cs",
   "Repositories/Class1.cs",
   "Services/Class1.cs"
}.ForEach(x =>
{
   if (File.Exists($"{AppContext.Get().ProjectPath}/{x}"))
   {
      File.Delete($"{AppContext.Get().ProjectPath}/{x}");
   }
});

if (File.Exists($"{AppContext.Get().ProjectPath}/init.sql"))
{
   var read = File.ReadAllText($"{AppContext.Get().ProjectPath}/init.sql");
   SQLParser.Parse(read.ToLower());
}

DirectoryInfo directoryInfo = new DirectoryInfo($"{AppContext.Get().ProjectPath}/Data/Data/");
if (!directoryInfo.Exists)
{
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Data/Data/");
   Console.WriteLine("Папка Data/Data не была найдена, поэтому была создана.");
}

List<Entity> entities = new List<Entity>();
List<string> LayerTypes = new List<string>() { "Controller", "Service", "Repository" };

if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Web API/Controllers"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Web API/Controllers");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/DTO"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/DTO");
if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services/DTO"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services/DTO");

foreach (var file in directoryInfo.GetFiles())
{
   //Parsing
   var entity = EntityParser.Parse(file);
   entities.Add(entity);
}

var exsearch = args.ToList().IndexOf("-extendedsearch");
if (exsearch != -1)
{
   exsearch++;
   while (exsearch < args.Length && !args[exsearch].Contains("-"))
   {
      entities.FirstOrDefault(x => x.Name == args[exsearch]).ExtendedSearch = true;
      exsearch++;
   }
}

foreach (var entity in entities)
{
   //Creating
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/{entity.Name}");
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Services/{entity.Name}"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Services/{entity.Name}");
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Web API/Controllers/{entity.Name}"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Web API/Controllers/{entity.Name}");

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
   File.WriteAllText($"{AppContext.Get().ProjectPath}/Web API/Controllers/{entity.Name}/{entity.Name}Controller.cs", controller);

   foreach (var layer in LayerTypes)
   {
      string dtoPath = $"{AppContext.Get().ProjectPath}{(layer == "Controller" ? @"/Web API" : "")}/{SQLParser.FixManyEnds($"{layer}s")}/{entity.Name}/DTO";
      if (!Directory.Exists($"{dtoPath}"))
         Directory.CreateDirectory($"{dtoPath}");

      string addDto, dto, dtoList, updateDto, queryDto;
      if (entity.Name != "User")
      {
         addDto = AddDtoCreator.CreateDto(entity, layer);
         dto = DtoCreator.CreateDto(entity, layer);
         dtoList = DtoListCreator.CreateDto(entity, layer);
         updateDto = UpdateDtoCreator.CreateDto(entity, layer);
         queryDto = QueryDtoCreator.CreateDto(entity, layer);
      }
      else
      {
         addDto = UserAddDtoCreator.CreateDto(entity, layer);
         dto = UserDtoCreator.CreateDto(entity, layer);
         dtoList = UserDtoListCreator.CreateDto(entity, layer);
         updateDto = UserUpdateDtoCreator.CreateDto(entity, layer);
         queryDto = QueryDtoCreator.CreateDto(entity, layer);
         var userLoginDto = UserLoginDtoCreator.CreateDto(entity, layer);
         var userLoginResultDto = UserLoginResultDtoCreator.CreateDto(entity, layer);
         File.WriteAllText($"{dtoPath}/UserLogin{layer}Dto.cs", userLoginDto);
         File.WriteAllText($"{dtoPath}/UserLoginResult{layer}Dto.cs", userLoginResultDto);
      }
      File.WriteAllText($"{dtoPath}/Add{entity.Name}{layer}Dto.cs", addDto);
      File.WriteAllText($"{dtoPath}/{entity.Name}{layer}Dto.cs", dto);
      File.WriteAllText($"{dtoPath}/{entity.Name}{layer}ListDto.cs", dtoList);
      File.WriteAllText($"{dtoPath}/Update{entity.Name}{layer}Dto.cs", updateDto);
      File.WriteAllText($"{dtoPath}/{entity.Name}Query{layer}Dto.cs", queryDto);
   }
}

var programCs = ProgramCsCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/Web API/Program.cs", programCs);
var appDbContextCs = AppDbContextCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/AppDbContext.cs", appDbContextCs);
var appSettingsCs = AppSettingsCreator.Create();
File.WriteAllText($"{AppContext.Get().ProjectPath}/Web API/appsettings.Development.json", appSettingsCs);
var appConfig = AppConfigCsCreator.Create();
File.WriteAllText($"{AppContext.Get().ProjectPath}/Shared/AppConfig.cs", appConfig);

if (args.Contains("-file"))
{
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/File"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/File");
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Web API/wwwroot/Files"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Web API/wwwroot/Files");
   var ifilerepository = FileRepositoryCreator.CreateInterface();
   File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/File/IFileRepository.cs", ifilerepository);
   var filerepository = FileRepositoryCreator.CreateClass();
   File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/File/FileRepository.cs", filerepository);
}

if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Shared/Errors"))
   Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Shared/Errors");
CopyCreator.CopyFilesRecursively("./Errors", $"{AppContext.Get().ProjectPath}/Shared/Errors");

