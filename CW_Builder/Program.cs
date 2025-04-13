﻿using System.Diagnostics;

AppContext.Init(args);
List<string> commands = new List<string>(){
"new webapi --force",
"add package Microsoft.AspNetCore.Authentication.JwtBearer",
"add package Microsoft.AspNetCore.Identity",
"add package Microsoft.AspNetCore.Identity.EntityFrameworkCore",
"add package Microsoft.AspNetCore.Mvc.NewtonsoftJson",
"add package Microsoft.AspNetCore.OpenApi",
"add package Microsoft.EntityFrameworkCore.Design",
"add package Newtonsoft.Json",
"add package Npgsql.EntityFrameworkCore.PostgreSQL",
"add package Swashbuckle.AspNetCore",
"add package AutoMapper",
"new tool-manifest --force",
"tool install --local dotnet-ef"
};
commands.ForEach(x =>
{
   Process p = new Process();
   p.StartInfo.UseShellExecute = true;
   p.StartInfo.WorkingDirectory = $"{AppContext.Get().ProjectPath}";
   p.StartInfo.FileName = $"dotnet";
   p.StartInfo.Arguments = x;
   p.Start();
   p.WaitForExit();
});


if (File.Exists($"{AppContext.Get().ProjectPath}/init.sql"))
{
   var read = File.ReadAllText($"{AppContext.Get().ProjectPath}/init.sql");
   SQLParser.Parse(read);
}

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
         File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/UserLogin{layer}Dto.cs", userLoginDto);
         File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/UserLoginResult{layer}Dto.cs", userLoginResultDto);
      }

      File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/Add{entity.Name}{layer}Dto.cs", addDto);
      File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/{entity.Name}{layer}Dto.cs", dto);
      File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/{entity.Name}{layer}ListDto.cs", dtoList);
      File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/Update{entity.Name}{layer}Dto.cs", updateDto);
      File.WriteAllText($"{AppContext.Get().ProjectPath}/DTO/{entity.Name}/{layer}/{entity.Name}Query{layer}Dto.cs", queryDto);
   }
}

var programCs = ProgramCsCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/Program.cs", programCs);
var appDbContextCs = AppDbContextCreator.Create(entities.ToArray());
File.WriteAllText($"{AppContext.Get().ProjectPath}/AppDbContext.cs", appDbContextCs);
var appSettingsCs = AppSettingsCreator.Create();
File.WriteAllText($"{AppContext.Get().ProjectPath}/appsettings.Development.json", appSettingsCs);
var appConfig = AppConfigCsCreator.Create();
File.WriteAllText($"{AppContext.Get().ProjectPath}/AppConfig.cs", appConfig);

if (args.Contains("-file"))
{
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Repositories/File"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Repositories/File");
   if (!Directory.Exists($"{AppContext.Get().ProjectPath}/wwwroot/Files"))
      Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/wwwroot/Files");
   var ifilerepository = FileRepositoryCreator.CreateInterface();
   File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/File/IFileRepository.cs", ifilerepository);
   var filerepository = FileRepositoryCreator.CreateClass();
   File.WriteAllText($"{AppContext.Get().ProjectPath}/Repositories/File/FileRepository.cs", filerepository);
}

if (!Directory.Exists($"{AppContext.Get().ProjectPath}/Errors")) Directory.CreateDirectory($"{AppContext.Get().ProjectPath}/Errors");
CopyCreator.CopyFilesRecursively("./Errors", $"{AppContext.Get().ProjectPath}/Errors");

