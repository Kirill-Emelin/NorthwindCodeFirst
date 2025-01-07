namespace NorthwindCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("База данных создана, таблица Categories доступна.");
            }
        }
    }
}
