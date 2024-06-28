using System;

class Program {
    public static void Main(string[] args) {

        int m = UI.askInteger("Введите число строк в массивах", 1, int.MaxValue);
        int n = UI.askInteger("Введите максимальное число элементов в строках", 1, int.MaxValue);

        Tests T = new Tests(20);
        T.RunTest<int>(T.poolInt, m, n);
        T.RunTest<double>(T.poolDouble, m, n);
        T.RunTest<char>(T.poolChar, m, n);
        T.RunTest<string>(T.poolString, m, n);
        T.RunTest<IntArr>(T.poolArrInt, m, n);

        DoubleTask(T.poolDouble, m, n);
    }

    public static bool isMultipleOf(double A, double B) {
        double eps = 0.1e-6;
        // Console.WriteLine(Math.IEEERemainder(A, B));
        return Math.Abs(Math.IEEERemainder(A, B)) < eps;
    }

    public static void DoubleTask(double[] pool, int m, int n) {

        JaggedArray<double> C = new JaggedArray<double>(m);
        C.FillRandom(pool, n);

        double min = double.PositiveInfinity;
        List<double> L;
        for (int i = 0; i < C.Length; i++) {
            if (C[i] != null) {
                min = Math.Min(min, C[i].Min());
            }
        }
        Console.WriteLine($"Исходный массив C:\n{C}");
        Console.WriteLine($"Минимальный элемент в массиве C = {min}");
        if (min != 0) {
            for (int i = 0; i < C.Length; i++) {
                if (C[i] != null) {
                    L = C[i].ToList();
                    L.RemoveAll(x => isMultipleOf(x, min));
                    C[i] = L.ToArray();
                }
            }
        } else {
            Console.WriteLine("Минимальныый элемент 0. Ничего не делаем.");
        }

        Console.WriteLine($"Изменённый массив C:\n{C}");
    }
}