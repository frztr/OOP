namespace CW_Builder;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
         ApplicationConfiguration.Initialize();
        var window = new Form1();
        // Window window = new Window();
   window.Text = "CW_Builder";

   window.Width = 700;
   window.Height = 500;
    
//    window.Application = (Application)sender;

      var box = new TableLayoutPanel();
      box.Dock = DockStyle.Top;
      window.Controls.Add(box);
    //   box.FlowDirection = FlowDirection.TopDown;
      box.Width = window.Width;
      box.Height = window.Height;

   Label hostLabel = new Label();
   hostLabel.Text ="Введите имя хоста";
   TextBox hostTextBox = new TextBox();
   hostTextBox.Text="localhost";
   box.Controls.Add(hostLabel);
   box.Controls.Add(hostTextBox);

   Label portLabel = new Label();
   portLabel.Text = "Введите порт";
   TextBox portTextBox = new TextBox();
   portTextBox.Text = "5432";
   box.Controls.Add(portLabel);
   box.Controls.Add(portTextBox);

   Label dbLabel = new Label();
   dbLabel.Text = "Введите имя базы данных";
   TextBox dbTextBox = new TextBox();
   dbTextBox.Text = "DBName";
   box.Controls.Add(dbLabel);
   box.Controls.Add(dbTextBox);

   Label hostnameLabel = new Label();
   hostnameLabel.Text = "Введите учётную запись пользователя";
   TextBox hostnameTextBox = new TextBox();
   hostnameTextBox.Text = "postgres";
   box.Controls.Add(hostnameLabel);
   box.Controls.Add(hostnameTextBox);

   Label passwordLabel = new Label();
   passwordLabel.Text = "Введите пароль пользователя";
   TextBox passwordTextBox = new TextBox();
   passwordTextBox.Text = "postgres";
   box.Controls.Add(passwordLabel);
   box.Controls.Add(passwordTextBox);

   Label fileLabel = new Label();
   fileLabel.Text = "Выберите файл скрипта с генерацией БД";
   Button fileDialogButton = new Button();
   fileDialogButton.Text = "Выбрать файл";
   box.Controls.Add(fileLabel);
   box.Controls.Add(fileDialogButton);
   string scriptFile = "";
   fileDialogButton.Click += (b, s) =>
   {
      var dialog = new OpenFileDialog();
    //   dialog.AddButton("Cancel", (int)ResponseType.Cancel);
    //   dialog.AddButton("Open", (int)ResponseType.Accept);

    //   dialog.OnResponse += (d, rs) =>
    //   {
    //      if (rs.ResponseId == -3)
    //      {
    //         scriptFile = ((FileChooserDialog)d).GetFile().GetParseName();
    //      }
    //      d.Close();

    //   };

      var res = dialog.ShowDialog();
      if (res == DialogResult.OK){
        scriptFile = dialog.FileName;
      }
   };

   CheckBox fileRepoCheck = new CheckBox();
   fileRepoCheck.Text = "Добавить файловый репозиторий";
   box.Controls.Add(fileRepoCheck);

   Label extendedSearchLabel = new Label();
   extendedSearchLabel.Text = "Реализовать пагинацию и сортировку для перечисленных сущностей.\nФормат ввода: \"FirstEntity SecondItem\"";
   RichTextBox extendedSearchView = new RichTextBox();
   extendedSearchView.Width = 250;
   box.Controls.Add(extendedSearchLabel);
   box.Controls.Add(extendedSearchView);


   Button buttonWithLabel = new Button();
   buttonWithLabel.Text = "Далее";
   buttonWithLabel.Click += (b, s) =>
   {
      ConsoleApp.Run(
         hostTextBox.Text,
         portTextBox.Text,
         dbTextBox.Text,
         hostnameTextBox.Text,
         passwordTextBox.Text,
         scriptFile,
         fileRepoCheck.Checked,
         extendedSearchView.Text
      );
      window.Close();
   };
   box.Controls.Add(buttonWithLabel);
   foreach(var x in box.Controls){
    // if (x.GetType() == typeof(Label)
    // || x.GetType() == typeof(RichTextBox))
        ((Control)x).AutoSize = true;
   }

        window.Controls.Add(box);
        Application.Run(window);
    }    
}