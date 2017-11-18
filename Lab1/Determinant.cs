namespace ConsoleApplication
{
    public class Determinant
    {
        public  double ComputationDeterminant(double[,] triangularMatrix,int dimension)
        {
            int Count;
            double determinant = 1;

            for (Count = 0; Count < dimension; Count++)
            {
                determinant *= triangularMatrix[Count, Count];
            }
            return determinant;
        }
    }
}