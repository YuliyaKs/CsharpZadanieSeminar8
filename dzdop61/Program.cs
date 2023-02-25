// Задача 61. Вывести первые N строк треугольника Паскаля.
// Сделать вывод в виде равнобедренного треугольника.

using System;
using static System.Console;

Clear();

Write("Введите размер треугольника Паскаля: ");
int size = int.Parse(ReadLine());

int[,] pascalTriangle = FillTriangle(size);
PrintArray(pascalTriangle);

// Метод для создания треугольника Паскаля.
int[,] FillTriangle(int triangleSize)// Параметры - количество строк (столбцов) квадратного массива.
{
    if (triangleSize % 2 == 0) triangleSize++;
    int[,] triangle = new int[triangleSize, triangleSize];
    int middle = triangleSize / 2;// Находим середину массива для координаты вершины треугольника.
    int k = middle;
    triangle[0, middle] = 1;

    for (int i = 2; i < triangleSize; i += 2)
    {
        k--;
        for (int j = k; j <= (middle + (middle - k)); j += 2)
        {
            if (j == 0 || j == triangleSize - 1) triangle[i, j] = 1;
            else
                triangle[i, j] = triangle[i - 2, j - 1] + triangle[i - 2, j + 1];// Заполняем треугольник целыми числами.
        }
    }
    return triangle;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (inArray[i, j] == 0) Write($"  ");
            else
            {
            Write($"{inArray[i, j]} ");
            }
        }
        WriteLine();
    }
}