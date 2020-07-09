using System;

namespace MatrixSearch
{
    class Search : GenerateMatrix
    {
        private static int size;
        private static char[,] matrix = new char[size, size];
        private char[] Input { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Direction { get; set; }

        public Search(char[] input)
        {
            Input = input;
            size = Size;
            matrix = Matrix;
        }

        public bool SearchString()
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (matrix[i, j] == Input[0])
                    {
                        Row = i + 1;
                        Col = j + 1;
                        if (Check(i, j))
                            return true;
                    }

            return false;
        }

        private bool Check(int row, int col)
        {
            int countR = 1,
                countL = 1,
                countB = 1,
                countT = 1;
            int rPlus = row,
                rMinus = row;
            int cPlus = col,
                cMinus = col;

            for (int i = 1; i < Input.Length; i++)
            {
                if (CheckNext(row, ++cPlus, countR))
                {
                    countR++;
                    Direction = "right";
                }

                if (CheckNext(row, --cMinus, countL))
                {
                    countL++;
                    Direction = "left";
                }

                if (CheckNext(++rPlus, col, countB))
                {
                    countB++;
                    Direction = "bottom";
                }

                if (CheckNext(--rMinus, col, countT))
                {
                    countT++;
                    Direction = "top";
                }
            }

            return (countR == Input.Length
                 || countL == Input.Length
                 || countB == Input.Length
                 || countT == Input.Length);
        }

        private bool CheckNext(int row, int col, int count)
        {
            try
            {
                return matrix[row, col] == Input[count];
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

    }
}