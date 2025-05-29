using System.Diagnostics;
using GLib;
using GObject;
using Gtk;
using Newtonsoft.Json;

var app = Application.New("com.CW_Builder.CW_Builder", Gio.ApplicationFlags.FlagsNone);


app.OnActivate += (sender, args) =>
{
   Window window = new Window();
   window.Title = "CW_Builder";

   window.DefaultWidth = 700;
   window.DefaultHeight = 900;

   window.Application = (Application)sender;

   var box = Box.New(Orientation.Vertical, 10);
   box.Halign = Align.Center;
   box.Valign = Align.Center;

   Label hostLabel = new Label();
   hostLabel.SetText("Введите имя хоста");
   Entry hostEntry = new Entry();
   hostEntry.SetText("localhost");
   box.Append(hostLabel);
   box.Append(hostEntry);

   Label portLabel = new Label();
   portLabel.SetText("Введите порт");
   Entry portEntry = new Entry();
   portEntry.SetText("5432");
   box.Append(portLabel);
   box.Append(portEntry);

   Label dbLabel = new Label();
   dbLabel.SetText("Введите имя базы данных");
   Entry dbEntry = new Entry();
   dbEntry.SetText("DBName");
   box.Append(dbLabel);
   box.Append(dbEntry);

   Label hostnameLabel = new Label();
   hostnameLabel.SetText("Введите учётную запись пользователя");
   Entry hostnameEntry = new Entry();
   hostnameEntry.SetText("postgres");
   box.Append(hostnameLabel);
   box.Append(hostnameEntry);

   Label passwordLabel = new Label();
   passwordLabel.SetText("Введите пароль пользователя");
   Entry passwordEntry = new Entry();
   passwordEntry.SetText("postgres");
   box.Append(passwordLabel);
   box.Append(passwordEntry);

   Label fileLabel = new Label();
   fileLabel.SetText("Выберите файл скрипта с генерацией БД");
   Button fileDialogButton = Button.NewWithLabel("Выбрать файл");
   box.Append(fileLabel);
   box.Append(fileDialogButton);
   string scriptFile = "";
   fileDialogButton.OnClicked += (b, s) =>
   {
      var dialog = new FileChooserDialog();
      dialog.SetAction(FileChooserAction.Open);
      dialog.AddButton("Cancel", (int)ResponseType.Cancel);
      dialog.AddButton("Open", (int)ResponseType.Accept);
      dialog.OnResponse += (d, rs) =>
      {
         if (rs.ResponseId == -3)
         {
            scriptFile = ((FileChooserDialog)d).GetFile().GetParseName();
         }
         d.Close();

      };

      dialog.Show();
   };

   CheckButton fileRepoCheck = new CheckButton();
   fileRepoCheck.Label = "Добавить файловый репозиторий";
   box.Append(fileRepoCheck);

   Label extendedSearchLabel = new Label();
   extendedSearchLabel.SetText("Реализовать пагинацию и сортировку для перечисленных сущностей.\nФормат ввода: \"FirstEntity SecondItem\"");
   Entry extendedSearchView = new Entry();
   box.Append(extendedSearchLabel);
   box.Append(extendedSearchView);


   Button buttonWithLabel = Button.NewWithLabel("Далее");
   buttonWithLabel.OnClicked += (b, s) =>
   {
      ConsoleApp.Run(
         hostEntry.Text_,
         portEntry.Text_,
         dbEntry.Text_,
         hostnameEntry.Text_,
         passwordEntry.Text_,
         scriptFile,
         fileRepoCheck.Active,
         extendedSearchView.Text_
      );
      window.Close();
   };
   box.Append(buttonWithLabel);


   window.Child = box;

   window.Show();
};


app.RunWithSynchronizationContext(null);