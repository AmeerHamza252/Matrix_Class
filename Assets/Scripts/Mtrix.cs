using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    int numRows;
    int numColumns;
    List<List<float>> matrixDataList;
    //int[,] array ;

    void InitalizeList()
    {
        matrixDataList = new List<List<float>>();
    }
    public Matrix(int[,] array2D)
    {
        ArrayToList(array2D);
        InitalizeList();
    }
    public Matrix(int row, int col)
    {
        numRows = row;
        numColumns = col;
    }

    public void ArrayToList(int[,] array)
    {
        numRows = array.GetLength(0);
        numColumns = array.GetLength(1);
        matrixDataList = new List<List<float>>();
        for (int row = 0; row < numRows; row++)
        {
            matrixDataList.Add(new List<float>());
            for (int col = 0; col < numColumns; col++)
            {
                matrixDataList[row].Add(array[row, col]);
            }
        }
    }


    public void SetElement(int rowIndex, int colIndex, int value)
    {
        if (rowIndex < matrixDataList.Count && colIndex < matrixDataList[1].Count)
        {
            matrixDataList[rowIndex][colIndex] = value;
        }
        else
        {
            Debug.LogError("No. of Row or Col does not exist");
        }
    }

    public float GetElement(int rowIndex, int colIndex)
    {
        if (rowIndex < matrixDataList.Count && colIndex < matrixDataList[0].Count)
        {
            float value = matrixDataList[rowIndex][colIndex];
            return value;
        }
        else
        {
            Debug.LogError("No. of Row or Col does not exist");
            return 0;
        }
    }

    public bool IsRowSame(int rowNumber)
    {
        bool isrowsame = true;
        for (int i = 0; i < numRows; i++)
        {
            if (matrixDataList[rowNumber][i] != matrixDataList[rowNumber][i + 1])
            {
                isrowsame = false;
            }
        }
        return isrowsame;
    }

    public bool IsColSame(int colNumber)
    {
        bool iscolsame = true;
        for (int i = 0; i < numRows; i++)
        {
            if (matrixDataList[colNumber][i] != matrixDataList[colNumber][i + 1])
            {
                iscolsame = false;
            }
        }
        return iscolsame;
    }
     public bool IsDiagonalSame()
    {
        bool isdiagonalsame = true;
        InitalizeList();
        for (int i = 0; i < numRows; i++)
        {
            matrixDataList.Add(new List<float>());
            for (int j = i; j <= i; j++)
            {
                if (matrixDataList[i][j] != matrixDataList[i + 1][j + 1])
                {
                    isdiagonalsame = false;
                }
            }
        }
        return isdiagonalsame;
    }
     public bool IsInverseDiagonalSame()
    {
        bool isinversediagonalsame = true;
        InitalizeList();
        for (int i = 0; i < numRows; i++)
        {
            matrixDataList.Add(new List<float>());
            for (int j = numColumns - i - 1; j <= numColumns - i - 1; j++)
            {
                if (matrixDataList[i][j] != matrixDataList[i + 1][j - 1])
                {
                    isinversediagonalsame = false;
                }
            }
        }
        return isinversediagonalsame;
    }

    public void SetMatrix(int num)
    {
        InitalizeList();
        for (int i = 0; i < numRows; i++)
        {
            matrixDataList.Add(new List<float>());
            for (int j = 0; j < numColumns; j++)
            {
                matrixDataList[i].Add(num);
            }
        }
    }

    public void SetRow(int rowNum, int num)
    {
        if (rowNum < numRows)
        {
            for (int i = 0; i < numRows; i++)
            {
                matrixDataList[rowNum][i] = num;
            }
        }
        else
        {
            Debug.Log("Row cannot be setted");
        }
    }

    public void SetCol(int colNum, int num)
    {
        if (colNum < numColumns)
        {
            for (int i = 0; i < numColumns; i++)
            {
                matrixDataList[i][colNum] = num;
            }
        }
        else
        {
            Debug.Log("Column cannot be setted");
        }
    }
     public void SetDiagonal(int num)
    {
        InitalizeList();
        for (int i = 0; i < numRows; i++)
        {
            matrixDataList.Add(new List<float>());
            for (int j = i; j <= i; j++)
            {
                matrixDataList[i][j] = num;
            }
        }
    }

    public void SetInverseDiagonal(int num)
    {
        InitalizeList();
        for (int i = 0; i < numRows; i++)
        {
            matrixDataList.Add(new List<float>());
            for (int j = numColumns - i - 1; j <= numColumns - i - 1; j++)
            {
                matrixDataList[i][j] = num;
            }
        }
    }
    public float[] GetRow(int rowNum)
    {
        if (rowNum < numRows)
        {
            float[] Array = new float[rowNum];
            for (int i = 0; i < numRows; i++)
            {
                Array[i] = matrixDataList[rowNum][i];
            }
            return Array;
        }
        else
        {
            Debug.Log("Row cannot be get");
            return null;
        }
    }
    public float[] GetCol(int colNum)
    {
        if (colNum < numColumns)
        {
            float[] Array = new float[colNum];
            for (int i = 0; i < numColumns; i++)
            {
                Array[i] = matrixDataList[colNum][i];
            }
            return Array;
        }
        else
        {
            Debug.Log("Row cannot be get");
            return null;
        }
    }

    public void SwapRows(int row1, int row2)
    {
        if (row1 < numRows && row2 < numRows)
        {
            for (int i = 0; i < numRows; i++)
            {
                float temp = matrixDataList[row1][i];
                matrixDataList[row1][i] = matrixDataList[row2][i];
                matrixDataList[row2][i] = temp;
            }
        }
        else
        {
            Debug.Log("Row Swaping is not possible");
        }
}
 public void SwapCols(int col1, int col2)
    {
        if (col1 < numColumns && col2 < numColumns)
        {
            for (int i = 0; i < numColumns; i++)
            {
                float temp = matrixDataList[col1][i];
                matrixDataList[col1][i] = matrixDataList[col2][i];
                matrixDataList[col2][i] = temp;
            }
        }
        else
        {
            Debug.Log("Column Swaping is not possible");
        }
    }
}