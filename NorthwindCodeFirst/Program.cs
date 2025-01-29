namespace NorthwindCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Таблица Categories создана с нужной структурой!");
            }
        }
    }
}
