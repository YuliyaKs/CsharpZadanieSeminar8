// Задача 58. Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.

using System;
using static System.Console;

Clear();

Write("Введите количество строк матрицы 1: ");
int rows1 = int.Parse(ReadLine());
Write("Введите количество столбцов матрицы 1: ");
int columns1 = int.Parse(ReadLine());

Write("Введите количество строк матрицы 2: ");
int rows2 = int.Parse(ReadLine());
Write("Введите количество столбцов матрицы 2: ");
int columns2 = int.Parse(ReadLine());

int[,] matrix1 = GetMatrix(rows1, columns1, 1, 9);
PrintMatrix(matrix1);
WriteLine();

int[,] matrix2 = GetMatrix(rows2, columns2, 1, 9);
PrintMatrix(matrix2);
WriteLine();

int[,] matrixProduct = MatrixMultiplication(matrix1, matrix2);
PrintMatrix(matrixProduct);

int[,] GetMatrix(int m, int n, int min, int max)
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

void PrintMatrix(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            Write($"{inMatrix[i, j]} ");
        }
        WriteLine();
    }
}

// Метод умножает матрицу 1 на матрицу 2.
int[,] MatrixMultiplication(int[,] inMatrix1, int[,] inMatrix2)
{
    if(inMatrix1.GetLength(1) != inMatrix2.GetLength(0))
    {
        WriteLine($"Матрицу 1 нельзя умножить на матрицу 2");
        return inMatrix1;
    }
    int[,] matrixMult1on2 = new int[inMatrix1.GetLength(0), inMatrix2.GetLength(1)];// Задаем новую матрицу - произведение матриц.
    for(int i = 0; i < inMatrix1.GetLength(0); i++)
    {
        for(int j = 0; j < inMatrix2.GetLength(1); j++)
        {
            for(int k = 0; k < inMatrix2.GetLength(0); k++)
                {
                    matrixMult1on2[i, j] += inMatrix1[i, k] * inMatrix2[k, j];// Выполняем произведение матриц и заполняем новую матрицу.
                }
        }
    }    
    return matrixMult1on2;
}