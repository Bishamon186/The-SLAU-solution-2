namespace ConsoleApplication
{
    public class Discrepancies
    {
        public double[] discrepancies(double[,] smatrix, double[]res,  int dimension)
        {
            double[] B = new double[dimension];
            double[,] A = new double[dimension,dimension];
            double[] discrep = new double[dimension];
            double[] AX = new double[dimension];
            double sum;
            int yCount;
            int xCount;

            for (yCount = 0; yCount < dimension; yCount++) //вытаскиваем из матрицы свободные элементы
            {
                B[yCount] = smatrix[yCount,dimension];
            }
            
            for ( yCount = 0;  yCount< dimension; yCount++) //вытаскиваем из матрицы коэффиценты перед "х"
            {
                for ( xCount = 0; xCount < dimension; xCount++)
                {
                    A[yCount, xCount] = smatrix[yCount, xCount];
                }
               
            }

            for (yCount = 0; yCount < dimension; yCount++) //перемножаем матрицы с результатом и коэффицентами
            {
                sum = 0;
                for (xCount = 0; xCount < dimension; xCount++)
                {
                    sum += A[yCount, xCount] * res[xCount];
                        
                }
                AX[yCount] = sum;
            }

            for (yCount = 0; yCount < dimension; yCount++) //значение погрешности
            {
                discrep[yCount] = B[yCount] - AX[yCount];
            }

            return discrep;
        }
    }
}