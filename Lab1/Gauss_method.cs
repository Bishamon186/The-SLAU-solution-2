using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class GaussMethodSelectionMainElement
    {
        public double[] MainGaussMethod(double[,] sole, int dimension, out double[] result, out double[,] triangularMatrix)
            {
                int xCount, yCount, count = 0;
                int  maxIndexY = 0;
                bool continuationWork = true;
                
                while (count < dimension - 1 && continuationWork)
                {
                    continuationWork = mainElement(sole, dimension, count); //Вычисление главного элемента
                    maxIndexY = MainElement.maxIndexY;//Значение индекса максимального элемента
                    sole = ChangeLines(sole,count,maxIndexY,dimension); //Меняем строки местами
                    sole = CalculatingValues(sole,count,dimension); //Обнуление
                    count++;
                }
                
                if (continuationWork) 
                {
                    triangularMatrix = TriangularMatrix(dimension, sole); //Треугольная матрица    
                    result = BackPass(dimension, sole); // Обратный проход
                    Status.status = 0;
                    return result;
                }	
                else
                {
                    Status.status = 1;
                    result = new double[dimension];
                    triangularMatrix = new double[dimension,dimension];
                    return result;
                }                
            }
        private bool mainElement(double[,] sole, int dimension, int count) //Нахождение главного элемента и его индекса
            {
                int  yCount;
                bool continuationWork = true;
                double maxValue = 0;
                int maxIndexY = count;
                double[] max = new double[2];
                maxValue = sole[count,count];
                
                    for (yCount = count+1; yCount <= dimension - 1; yCount++)
                    {
                        if (maxValue < sole[yCount,count])
                        {
                            maxValue = sole[yCount,count];
                            maxIndexY = yCount;
                        }
                    }

                if (maxValue==0)
                {
                    continuationWork = false;
                }
                else
                {
                    MainElement.maxIndexY = maxIndexY;
                    MainElement.maxValue = maxValue;
                }
                return continuationWork;
            }

        private double[] BackPass(int dimension, double[,] sole) //Обратных ход
            {
                double[] result = new double[dimension];
                int yCount, xCount;
                double sum;
                result[dimension - 1] = sole[dimension - 1,dimension] / sole[dimension - 1,dimension - 1]; //находим значение последнего неизвестного 
                for (yCount = dimension - 2; yCount >= 0; yCount--)
                {
                    sum = 0;
                    for (xCount = dimension - 1; xCount >= yCount; xCount--)
                    {
                        sum += sole[yCount,xCount] * result[xCount];
                    }
                    result[yCount] = (sole[yCount,dimension] - sum) / sole[yCount,yCount];
                }
                return result;
            }

        private double[,] ChangeLines(double[,] sole,  int count, int maxIndexY, int dimension) //Меняем  строки  местами 
        {
            double tmp;
            int xCount;
            if (count != maxIndexY) 
            {
                for (xCount = count; xCount <= dimension; xCount++)
                {
                    tmp = sole[count,xCount];
                    sole[count,xCount] = sole[maxIndexY,xCount];
                    sole[maxIndexY,xCount] = tmp;
                }
            }
            return sole;
        }

        private double[,] CalculatingValues(double[,] sole, int count, int dimension)//Обнуление
        {
            int yCount;
            double Coeff;
            for (yCount = count + 1; yCount <= dimension - 1; yCount++) 
            {
                Coeff = -(sole[yCount,count] / sole[count,count]);
                for (int k =count ; k <= dimension; k++) 
                {     
                    sole[yCount, k] += sole[count, k] * Coeff;
                }
            }
            return sole;
        }

        private double[,]  TriangularMatrix(int dimension,double[,]sole) //треугольная матрица
        {
            double[,] triangularMatrix = new double[dimension,dimension+1];
            int yCount, xCount;
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension; xCount++)
                    triangularMatrix[yCount,xCount] = sole[yCount,xCount];
            }
            return triangularMatrix;
        }        
    }    
}