namespace Notes.Persistence
{
    public class DbInitializer
    {
        //В начале работы с приложением метод будет проверять, существует ли база данных
        //Если нет, будет создавать
        public static void Initialize(NotesDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}