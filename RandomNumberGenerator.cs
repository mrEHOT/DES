using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    static class RandomNumberGenerator
    {
        static private List<int> relativePrime = new List<int>(); // Список взаимно простых с mod чисел, меньше mod
        static private List<int> simpleDivs = new List<int>(); // Простые делители mod


        private static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            return GCD(b % a, a);
        } // Реализация алгоритма Евклида

        private static void GetPrimeNumbers(int mod)
        {
            for (int i = mod; i >= 2; i--)
            {
                if ((GCD(i, mod) == 1) && (i < mod))
                    relativePrime.Add(i);
            }
        } // Выполняем поиск взаимно простых с mod чисел

        private static void GetSimpleDivs(int mod)
        {
            for (int i = 2; i < Math.Sqrt(mod) + 1e-5;)
            {
                if (mod % i == 0)
                {
                    bool check = true;
                    foreach (int div in simpleDivs)
                        if (i == div)
                        {
                            check = false;
                            break;
                        }

                    if (check)
                        simpleDivs.Add(i);

                    mod /= i;
                }
                else
                {
                    ++i;
                }
            }
        } // Поиск всех простых делителей числа mod

        private static void GenerateNumbers(int mod, int c, int a, int x, List<int> numbers, int numberOfItems)
        {
            numbers.Add(x);

            for (int i = 1; i < numberOfItems; i++)
            {
                x = (a * x + c) % mod;
                numbers.Add(x);
            }
        } // Линейный конгруэнтный метод

        public static List<int> GetNumbersForKey(int numberOfItems, int mod)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            //  Вызываем функцию для поиска всех чисел взаимнопростых с mod (< mod)
            if (relativePrime.Count == 0)
                GetPrimeNumbers(mod);
            else
            {
                relativePrime.Clear();
                GetPrimeNumbers(mod);
            }

            // Вызываем функцию для поиска всех простых делителей mod (фактически факторизация)
            if (simpleDivs.Count == 0)
                GetSimpleDivs(mod);
            else
            {
                simpleDivs.Clear();
                GetSimpleDivs(mod);
            }

            int c = relativePrime[random.Next(0, relativePrime.Count)]; // Выбираем случайное приращение "c" взаимно простое с mod

            int a = 0;
            while (true)
            {
                bool check = false;
                a = 1;

                while (true)
                {
                    foreach (int div in simpleDivs)
                        a *= div;

                    int maxValue = mod / a;
                    if (maxValue * a + 1 >= mod)
                        a = a * (random.Next(1, maxValue - 1)) + 1;
                    else
                        a = a * (random.Next(1, maxValue)) + 1;

                    foreach (int i in simpleDivs)
                    {
                        if ((a - 1) % i != 0)
                            break;

                        check = true;
                    }

                    if (check)
                        break;
                } // Проверка на кратность b = a - 1 всем простым делителям mod

                if (mod % 4 == 0) // Если mod кратен 4
                {
                    if ((a - 1) % 4 == 0) // то и b = a - 1 
                        break;
                }
                else
                {
                    if (check)
                        break;
                }
            } // Выбор "a" и его проверка на соответствие условиям

            int x = random.Next(0, mod); // Выбираем случайное начальное значение

            GenerateNumbers(mod, c, a, x, numbers, numberOfItems); // Обращаемся к ГПСЧ с заданными параметрами

            return numbers; // Возвращаем набор случайных чисел в байтовом представлении
        } // Генерация указанного числа ПСЧ
    }
}
