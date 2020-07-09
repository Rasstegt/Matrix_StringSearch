using System;
using System.Collections.Generic;

namespace MatrixSearch
{
    class GenerateMatrix
    {
        private static int size;
        private static char[,] matrix = new char[size, size];
        List<string> outputCollection = new List<string>();
        public int Size { get { return size; } set { size = value; } }
        public char[,] Matrix { get { return matrix; } set { matrix = value; } }

        public GenerateMatrix() { }
        public GenerateMatrix(int size)
        {
            Size = size;
        }

        public void MakeMatrix()
        {
            Random r = new Random();
            Matrix = new char[Size, Size];
            int rNum;
            outputCollection.Add("\n");
            for (int row = 0; row < Size; row++)
            {
                outputCollection.Add("\t");
                for (int col = 0; col < Size; col++)
                {
                    rNum = r.Next(65, 90);
                    Matrix[row, col] = Convert.ToChar(rNum);
                    outputCollection.Add(String.Format("{0}\t", Matrix[row, col]));
                }
                outputCollection.Add("\n");
            }
        }

        public string PrintMatrix()
        {
            string output = "";
            foreach (var unpack in outputCollection)
                output += unpack;

            return output;
        }
    }
}
