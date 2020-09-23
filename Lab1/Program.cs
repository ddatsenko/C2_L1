using System;
using System.Globalization;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab work #1, task 1");
            Console.WriteLine("");
            Console.Write("Enter the number of rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of columns: ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            int[,] arr = new int[n, m];
            int max = 0;
            Console.Write("Enter 1 to fill the array manually or 2 to fill it with random numbers from 0 to 10: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the elements of the array, pressing Enter after entering {0} elements in each row: ", m);
                Console.WriteLine("");
                for (int i = 0; i < n; i++)
                {
                    string s = Console.ReadLine();
                    Console.WriteLine("");
                    int j = 0;
                    foreach (int v in s.Split(' ').Select(v => Convert.ToInt32(v)))
                    {
                        arr[i, j++] = v;
                    }
                }
            }
            else if (choice == 2)
            {
                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        arr[i, j] = r.Next(0, 10);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("The created array:");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write(string.Format("{0} ", arr[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
            }
            SwapFirstAndMinElements(arr, n, m);
            DetectIndexOfTheRowWithMaxFirstElement(arr, m, n, max);
            CopyTheRow(arr, n, max);
            Console.ReadKey();
        }
        static void SwapFirstAndMinElements(int[,] arr, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                int minm = arr[i, 0];
                int temp = arr[i, 0];
                int minIndexI = 0; int minIndexJ = 0;
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] <= minm)
                    {
                        minm = arr[i, j];
                        minIndexI = i;
                        minIndexJ = j;
                    }
                }
                arr[i, 0] = arr[minIndexI, minIndexJ];
                arr[minIndexI, minIndexJ] = temp;
            }
            Console.WriteLine("The array with swapped first and minimum elements in each row of the array:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
        static int DetectIndexOfTheRowWithMaxFirstElement(int[,] arr, int m, int n, int max)
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (arr[j, 0] > arr[j + 1, max])
                    {
                        max = j;
                    }
                }
            }
            int max2 = max;
            Console.WriteLine("Index of the row with the largest first element is {0}", max + 1);
            return max2;
        }
        static void CopyTheRow(int[,] arr, int n, int max2)
        {
            int[] arr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr2[i] = arr[max2, i];
            }
            Console.WriteLine("");
            Console.WriteLine("The created array:");
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                Console.Write(string.Format("{0} ", arr2[i]));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
            Console.WriteLine("The reversed array:");
            Array.Reverse(arr2);
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                Console.Write(string.Format("{0} ", arr2[i]));
            }
        }
    }
}