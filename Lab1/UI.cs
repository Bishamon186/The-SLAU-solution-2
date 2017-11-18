using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    public class Ui {
        
        public  int SelectAction (){
            int selectedAction = 0;
            while (selectedAction == 0)
            {
                Console.WriteLine("Выберете действие:\n\t 1-Ввод матрицы из файла\n\t 2-Ввод матрицы вручную\n\t 3-Выход");
                try
                {
                    selectedAction = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Error(1);
                }
            }

            return selectedAction;
        }

        public void Error(int num)
        {
            switch (num)
            {
                    case 1:
                        Console.WriteLine("ERROR: Введите ЧИСЛО\n");
                        break;
                    case  2:
                        Console.WriteLine("ERROR: Выберете 1 или 2, или 3\n");
                        break;
                case  3:
                    Console.WriteLine("ERROR: Выберете размер матрицы в пределах [1;20]\n");
                    break;
                case  4:
                    Console.WriteLine("ERROR: Файл не поддерживает чтение\n");
                    break;
                case  5:
                    Console.WriteLine("ERROR: Введен неверный путь к файлу\n");
                    break;
                case  6:
                    Console.WriteLine("ERROR: Введен неверный размер матрицы\n");
                    break;
                    default:
                    
                        Console.WriteLine("Неизвестная ошибка");
                        break;
            }
        }
        
        public int SelectDimension (){
            int dimension = 0;
            int selectedDim = 0;
            while (selectedDim==0)
            {
                try
                {
                    Console.WriteLine("Введите размерность матрицы (от 1 до 20)\n");
                    dimension = Convert.ToInt32(Console.ReadLine());
                    if (dimension < 1 || dimension > 20)
                    {
                        Error(3);
                    }
                    selectedDim = 1;
                }
                catch (FormatException)
                {
                    Error(1);
                }
            }
            return dimension;
        }

        public double[,] InputMatrix (int dimension){
            int i,j;
            double [,] matrix ;
            int[] count = new int[dimension];
            matrix = new double[dimension,dimension+1];
            bool inputMatrix = false;
            

            while (!inputMatrix)
            {
                Console.WriteLine("Введите кэффиценты. Разделитель целой и дробной части - точка.\n");
                try
                {
                    for (int q = 0; q < dimension; q++)
                    {
                        count[q] = q;
                    }

                    for (i = 0; i <= dimension - 1; i++)
                    {
                        for (j = 0; j <= dimension; j++)
                        {
                            if (j != dimension)
                            {
                                Console.Write("X" + count[j] + " = ");

                            }
                            else
                            {
                                Console.Write("B" + " = ");

                            }
                            matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("");

                        }
                    }
                    inputMatrix = true;
                }
                catch (FormatException)
                {
                    Error(1);
                }
            }
            return matrix;
        }

        public void output_result(double[]result, int dimension, double[] discrep, double[,]start_matrix,double[,]triangularMatrix,double det) {
            int xCount;
            int yCount;
            int[] count = new int[dimension];
            for (int i = 0; i<=dimension-1;i++)
            {
                count[i]=i;
            }
                
            Console.WriteLine("\nИсходная матрица:");
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension ; xCount++)
                {
                    Console.Write("{0,10:f3}",start_matrix[yCount,xCount]);
                    Console.Write((" "));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Треугольная матрица:");
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension ; xCount++)
                {
                    Console.Write("{0,10:f3}",triangularMatrix[yCount,xCount]);
                    Console.Write(("          "));

                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Определитель:" + det);
            Console.WriteLine("");
            Console.WriteLine("Результат:");
            for (xCount = 0; xCount <= dimension-1; xCount++) {
                Console.WriteLine("X" + count[xCount]+ " = " + result[xCount]);
            }
            Console.WriteLine("Погрешность:");
            for (xCount = 0; xCount <= dimension-1; xCount++) {
                Console.WriteLine("X" + count[xCount]+ " = " + discrep[xCount]);
            }
        }

        public void OutputNoNumbResult(int dimension, double[,] start_matrix)
        
        {
            int xCount;
            int yCount;
            int[] count = new int[dimension];
            for (int i = 0; i<=dimension-1;i++)
            {
                count[i]=i;
            }
                
            Console.WriteLine("\nИсходная матрица:");
            for (yCount = 0; yCount <= dimension - 1; yCount++)
            {
                for (xCount = 0; xCount <= dimension ; xCount++)
                {
                    Console.Write("{0,10:f3}",start_matrix[yCount,xCount]);
                    Console.Write((" "));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Определитель матрицы = 0, следовательно решений нет или их бесконечно много\n");
            
        }

        public void By()
        {
            Console.WriteLine("Пока!");
        }

        public double[,] InputFile(int dem)
        {
            string fileName,line;
            string[] line2;
            int inputValue = 0;
            double[,] matrix = new double[dem,dem+1];
            double[,] rmatrix;
            char[] charr = new char[] {' '};
            while (inputValue==0)
            {
                try
                {
                    Console.WriteLine("Введите путь к файлу:");
                    fileName = Console.ReadLine();
                    StreamReader file = new StreamReader(fileName);

                    for (int i = 0; i < dem; i++)
                    {
                        line = file.ReadLine();
                        line2 = line.Split(charr);
                        for (int j = 0; j <= dem; j++)
                        {
                            matrix[i, j] = Convert.ToDouble(line2[j]);
                        }

                    }
                    inputValue = 1;
                }
                catch (ArgumentException)
                {
                    Error(4);
                }
                catch (FileNotFoundException)
                {
                    Error(5);
                }
                catch (IndexOutOfRangeException)
                {
                    Error(6);
                    inputValue = 2;
                }
               }
            if (inputValue == 2)
            {
                Status.status = 2;
            }
            else
            {
                Status.status = 0;
            }
            return matrix;
            
        }
    }
    
}