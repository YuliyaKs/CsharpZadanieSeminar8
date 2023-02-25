// Задача 60. Сформируйте трёхмерный массив из неповторяющихся
// двузначных чисел. Напишите программу, которая будет построчно 
// выводить массив, добавляя индексы каждого элемента.

using System;
using static System.Console;

Clear();

Write("Введите количество таблиц массива: ");
int tables = int.Parse(ReadLine());

Write("Введите количество строк массива: ");
int rows = int.Parse(ReadLine());

Write("Введите количество столбцов массива: ");
int columns = int.Parse(ReadLine());

int[] array1D = GetArrayOneRow(tables, rows, columns, 10, 99);// Задаем одномерный массив из неповторяющихся чисел.
WriteLine(String.Join(" ", array1D));
WriteLine();

int[,,] array3D = GetArray(tables, rows, columns, array1D);// Переводим одномерный масси в трехмерный массив.
PrintArray3D(array3D);

// Метод, в котором задаем одномерный массив из неповторяющихся чисел.
int[] GetArrayOneRow(int l, int m, int n, int min, int max)
{
    int size = l * m * n;
    int[] arrayOneRow = new int [size]; 
    for (int i = 0; i < size; i++)
    {
        arrayOneRow[i] = new Random().Next(min, max + 1);
    }
    for (int i = 1; i < size; i++)
    {
        for (int j = i - 1; j >= 0; j--)
        {
            if (arrayOneRow[i] == arrayOneRow[j])
            {
                arrayOneRow[i] = new Random().Next(min, max + 1);// Меняем повторяющиеся значения.
                j = i;
            }
        }
    }
    return arrayOneRow;
}

// Метод для перевода одномерного массива в трехмерный массив.
int[,,] GetArray(int l, int m, int n, int[] arrayOneRow)
{
    int a = 0;
    int[,,] result = new int[l, m, n];
    for (int i = 0; i < l; i++)
    {
        for (int j = 0; j < m; j++)
        {
            for (int k = 0; k < n; k++)
            {
                result[i, j, k] = arrayOneRow[a];
                a++;
            }    
        }
    }
    return result;
}

void PrintArray3D(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Write($"{inArray[i, j, k]}({i}, {j}, {k}) ");
            }
            WriteLine();        
        }
        WriteLine();
    }
}