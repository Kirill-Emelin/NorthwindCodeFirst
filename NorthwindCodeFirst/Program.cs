namespace NorthwindCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем контекст и базу данных
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureDeleted(); // удаляет базу, если существует
                context.Database.EnsureCreated(); // создает новую базу
                Console.WriteLine("Таблица Categories создана с нужной структурой!");
            }
        }
    }
}
