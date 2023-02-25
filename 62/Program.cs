// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4. 

using System; 
using static System.Console;

Clear();

Write("Введите значение порядка матрицы: ");
int matrixSize = int.Parse(ReadLine());

int[,] matrixNxN = FillMatrixSpirally(matrixSize);

PrintArray(matrixNxN);

// Метод спирально заполняет квадратную матрицу.
int[,] FillMatrixSpirally(int matrixOrder)
{
    int[,] matrix = new int[matrixOrder, matrixOrder];
    int value = 1;
    int i = 0;
    int j = 0;
    
    while (value <= matrixOrder * matrixOrder)
    {
        matrix[i, j] = value;
        value++;
        if (i <= j + 1 && i + j < matrixOrder - 1)
            j++;
        else if (i < j && i + j >= matrixOrder - 1)    
            i++;
        else if (i >= j && i + j > matrixOrder - 1)    
            j--;
        else i--;            
    }
    return matrix;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Write($"{inArray[i, j]:00} ");
        }
        WriteLine();
    }
}
