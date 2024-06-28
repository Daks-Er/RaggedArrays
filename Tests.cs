class Tests {
    public int[] poolInt;
    public char[] poolChar;
    public double[] poolDouble;
    public string[] poolString;
    public IntArr[] poolArrInt;

    public Tests(int x) {
        poolInt = new int[x];
        poolChar = new char[x];
        poolDouble = new double[x];
        poolString = new string[x];
        poolArrInt = new IntArr[x];
        int i;
        for (i = 0; i < poolInt.Length; i++) poolInt[i] = i;
        for (i = 0; i < poolChar.Length; i++) poolChar[i] = (char)(i + 65);
        for (i = 0; i < poolDouble.Length; i++) poolDouble[i] = (i + 1) / 10.0;
        for (i = 0; i < poolString.Length; i++) {
            poolString[i] = $"{(char)(65 + i)}{(char)(97 + i)}{(char)(90 - i)}";
        }
        for (i = 0; i < poolArrInt.Length; i++) {
            int l = poolArrInt.Length / 4;
            poolArrInt[i] = new IntArr(l);
            for (int j = 0; j < l; j++) {
                poolArrInt[i][j] = i * l + j;
            }
        }
    }

    public void RunTest<T>(T[] pool, int m, int n) {

        int i, c, u;
        T t;
        T[] newLine;

        Console.WriteLine(" >>> Начало серии тестов.");
        Console.WriteLine(" >>> Используемый пул значений:");
        for (i = 0; i < pool.Length; i++)
            Console.Write($"{pool[i]} ");
        Console.WriteLine();

        JaggedArray<T> A = new JaggedArray<T>(m);
        A.FillRandom(pool, n);

        Console.WriteLine(" >>> Сформирован следующий массив:");
        Console.WriteLine(A);

        c = Rand.rnd.Next(1, n);
        newLine = new T[c];
        for (i = 0; i < c; i++) newLine[i] = pool[ Rand.rnd.Next(pool.Length) ];

        Console.WriteLine(" >>> Вставляем новую строку в начало массива:");
        A.Prepend(newLine);
        Console.WriteLine(A);

        Console.WriteLine(" >>> Вставляем новую строку в конец массива:");
        A.Append(newLine);
        Console.WriteLine(A);

        Console.WriteLine(" >>> Вставляем новую строку по индексу:");
        u = UI.askInteger("Введите позицию для вставки", 0, A.Length);
        A.Insert(newLine, u);
        Console.WriteLine(A);

        Console.WriteLine(" >>> Удаляем из массива строку по индексу:");
        u = UI.askInteger("Введите индекс удаляемой строки", 0, A.Length);
        A.Remove(u);
        Console.WriteLine(A);

        Console.WriteLine(" >>> Поиск заданного элемента в массиве:");
        t = pool[ Rand.rnd.Next(pool.Length) ];
        Console.WriteLine($"Массив содержит элемент {t}? {A.Contains(t)}");

        Console.WriteLine(" >>> Сортировка массива по возрастанию:");
        A.Sort(false);
        Console.WriteLine(A);

        Console.WriteLine(" >>> Переворачивание массива:");
        A.Reverse();
        Console.WriteLine(A);

        Console.WriteLine(" >>> Очистка массива:");
        A.Clear();
        Console.WriteLine(A);

        Console.WriteLine(" >>> Конец серии тестов.");
        Console.ReadLine();
    }
}