using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int menu, menu_dimension = 0;
            double[,] matrix;
            Ui ui = new Ui();
            bool ExitProgram = false;

            while (!ExitProgram)
            {
                menu = ui.SelectAction();
                switch (menu)
                {
                    case 1:
                        Status.status = 2;
                        matrix = new double[0,0];
                        while (Status.status == 2)
                        {
                            menu_dimension = ui.SelectDimension();
                            matrix = new double[menu_dimension, menu_dimension + 1];
                            matrix = ui.InputFile(menu_dimension);
                        }
                        work(menu_dimension, matrix);
                        break;
                    case 2:
                        menu_dimension = ui.SelectDimension();
                        matrix = new double[menu_dimension, menu_dimension + 1];
                        matrix = ui.InputMatrix(menu_dimension);
                        work(menu_dimension, matrix);
                        break;
                    case 3:
                        ExitProgram = true;
                        break;
                    default:
                        ui.Error(2);
                        break;
                }
            }
            ui.By();

        }

        static void work(int dimension, double[,]matrix)
        {
            double[,] start_matrix;
            double[] matrix_2;
            double[] result;
            double[,] triangularMatrix;
            double det;
            Determinant determinant = new Determinant();
            Ui ui = new Ui();
            double[] discrep;
            Discrepancies discrepancies = new Discrepancies();
            GaussMethodSelectionMainElement gauss = new GaussMethodSelectionMainElement();
            start_matrix = new double[dimension,dimension+1];
            for (int i = 0; i <= dimension - 1; i++)
            {
                for (int j = 0; j <= dimension; j++)
                    start_matrix[i,j] = matrix[i,j];
            }
            matrix_2 = new double[dimension];
            result = new double[dimension];
            triangularMatrix = new double[dimension,dimension+1];
            matrix_2 = gauss.MainGaussMethod(matrix, dimension,out result,out triangularMatrix);
            det = determinant.ComputationDeterminant(triangularMatrix,dimension);
            if (det != 0)
            {
                discrep   = new double[dimension];
                discrep = discrepancies.discrepancies(start_matrix,result,dimension);
                ui.output_result(matrix_2, dimension, discrep, start_matrix,triangularMatrix,det);
            }
            else
            {
                ui.OutputNoNumbResult(dimension,start_matrix);
            }
            
        }

    }
        
}