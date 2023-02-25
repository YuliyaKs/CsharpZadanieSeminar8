// Задача 56. Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

using System;
using static System.Console;

Clear();

Write("Введите количество строк массива: ");
int rows = int.Parse(ReadLine());

Write("Введите количество столбцов массива: ");
int columns = int.Parse(ReadLine());

int[,] array = GetArray(rows, columns, 0, 10);
PrintArray(array);

int index = FindMinSumRow(array);
WriteLine($"Номер строки с наименьшей суммой элементов: {index + 1} срока");

int[,] GetArray(int m, int n, int min, int max)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }

    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]} ");
        }
        WriteLine();
    }
}

// Метод возвращает индекс строки с наименьшей суммой элементов.
int FindMinSumRow(int[,] inArray)
{
    int indexMinSumRow = 0;// Индекс строки с наименьшей суммой элементов.
    int minSumRows = 0;// Наименьшая сумма элементов.
    int sumRows = 0;// Сумма элементов строки.
    for(int j = 0; j < inArray.GetLength(1); j++)
    {
        minSumRows += inArray[0, j];
    }
    for(int i = 1; i < inArray.GetLength(0); i++)
    {
        sumRows = 0;
        for(int j = 0; j < inArray.GetLength(1); j++)
        {
            sumRows += inArray[i, j];
        }
        if(sumRows < minSumRows) 
        {
            minSumRows = sumRows;
            indexMinSumRow = i;
        }    
    }
    return indexMinSumRow;
}