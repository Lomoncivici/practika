while (true)
{
    Console.WriteLine("1)угадай число");
    Console.WriteLine("2)Таблица умножения");
    Console.WriteLine("3)Вывод делителей числа");
    Console.WriteLine("ввыберите программу");
    int programm = Convert.ToInt32(Console.ReadLine());
    if (programm == 1)
    {
        Random rnd = new Random();

        int randomchislo = rnd.Next(100);

        Console.WriteLine("Угодай число от 1 до 100");
        //int a = Convert.ToInt32(Console.ReadLine());
        int a;
        do
        {
            a = Convert.ToInt32(Console.ReadLine());
            if (a == randomchislo)
            {
                Console.WriteLine("Вы угадали число! =)");
                Console.WriteLine("Ответ:" + randomchislo);
            }
            if (a < randomchislo)
            {
                Console.WriteLine("Вы не угодали =(\nчисло больше !");
            }
            else if (a > randomchislo)
            {
                Console.WriteLine("Вы не угодали =(\nчисло меньше !");
            }
        } while (randomchislo != a);
    }
    if (programm == 2)
    {
        var table = new int[11, 11];
        for (int i = 1; i < 11; ++i)
        {
            for (int j = 1; j < 11; ++j)
            {
                table[i, j] = i * j;
            }
        }
        for (int i = 1; i < 11; ++i)
        {
            for (int j = 1; j < 11; ++j)
            {
                Console.Write("{0, 4}", table[i, j]);
            }
            Console.WriteLine();
        }
    }
    if (programm == 3)
    {

    }
}
