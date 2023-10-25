namespace ТИРТ
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.Title = "Тирт";
                Console.SetWindowPosition(0, 0);
                Console.SetWindowSize(146, 36);
                Menu.Control();

                Thread thread1 = new(Animation.Moved);
                thread1.Start();

                Make_an_order.Order();

                thread1.Join();
            }
        }
    }
}