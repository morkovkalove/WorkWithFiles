/*
ЗАДАНИЕ 1
Напишите программу, которая чистит нужную нам папку от файлов
и папок, которые не использовались более 30 минут/
На вход программа принимает путь до папки. 

При разработке постарайтесь предусмотреть возможные ошибки (нет прав доступа, папка по заданному адресу не существует, передан некорректный путь)
и уведомить об этом пользователя.
 */


DirectoryInfo directory = new DirectoryInfo(@"C:\Users\мвидео\Desktop\Kawaiki");
try
{
    if (directory.Exists)
    {
        Delete(directory);
    }
    else
    {
        Console.WriteLine("Doesn't exist!");
    }
}
catch (Exception ex)
{
    if (ex is UnauthorizedAccessException)
    {
        Console.WriteLine("No access rights");
    }

}

static void Delete(DirectoryInfo dirSpace)
{
    foreach (FileInfo file in dirSpace.GetFiles())
    {
        var thirty = DateTime.Now - file.LastAccessTime;
        if (thirty > TimeSpan.FromMinutes(30))
        {
            file.Delete();
        }
    }

    foreach (DirectoryInfo folder in dirSpace.GetDirectories())
    {
        Delete(folder);
        folder.Delete();
    }
}

