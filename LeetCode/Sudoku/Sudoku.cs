using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Sudoku
{
    public class Sudoku
    {
        private Grid[] originalSudoku = new Grid[] { new Grid(), new Grid(), new Grid(), new Grid(), new Grid(), new Grid(), new Grid(), new Grid(), new Grid() };

        private bool isCalculated
        {
            get
            {
                foreach(var grid in originalSudoku)
                    if(grid.IsDone() == false)
                        return false;
                return true;
            }
        }

        public Sudoku(char[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    int gridIndex = i / 3 * 3 + j / 3;
                    int index = j % 3 + 3 * (i % 3);
                    char c = board[i, j];
                    originalSudoku[gridIndex][index] = new Slot(c, c != '.');
                }
            }

            bool trimmed = true;
            while(trimmed)
            {
                trimmed = false;
                foreach(var grid in originalSudoku)
                    trimmed |= grid.Trim();

                for(int i = 0; i < originalSudoku.Length; i += 3)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        var s1 = originalSudoku[i].GetRow(j);
                        var s2 = originalSudoku[i + 1].GetRow(j);
                        var s3 = originalSudoku[i + 2].GetRow(j);
                        Line line = new Line(s1, s2, s3);
                        trimmed |= line.Trim();
                    }
                }

                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        var s1 = originalSudoku[i].GetColumn(j);
                        var s2 = originalSudoku[i + 3].GetColumn(j);
                        var s3 = originalSudoku[i + 6].GetColumn(j);
                        Line line = new Line(s1, s2, s3);
                        trimmed |= line.Trim();
                    }
                }
            }
            
            if(!isCalculated)
            {
                // using backtracking to solve？
            }
        }

        public char[,] TransformDataFormat()
        {
            char[,] res = new char[9, 9];

            for(int i = 0; i < 9; i++)
            {
                int r = i / 3 * 3;
                var r1 = originalSudoku[r].GetRow(i % 3);
                for(int j = 0; j < r1.Length; j++)
                    res[i, j] = r1[j].Value;

                var r2 = originalSudoku[r + 1].GetRow(i % 3);
                for(int j = 0; j < r2.Length; j++)
                    res[i, j + 3] = r2[j].Value;

                var r3 = originalSudoku[r + 2].GetRow(i % 3);
                for(int j = 0; j < r3.Length; j++)
                    res[i, j + 6] = r3[j].Value;
            }

            return res;
        }
        public override string ToString()
        {
            var res = TransformDataFormat();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < res.GetLength(0); i++)
            {
                for(int j = 0; j < res.GetLength(1); j++)
                    sb.Append(res[i, j].ToString().PadLeft( j % 3 == 0 ? 3: 2));

                sb.AppendLine();
                if(i % 3 == 2)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

    }

    public class Line
    {
        private Slot[] slots;
        public Line(Slot[] slots)
        {
            this.slots = slots;
        }

        public Line(Slot[] s1, Slot[] s2, Slot[] s3)
        {
            slots = new Slot[9];

            Array.Copy(s1, 0, slots, 0, 3);
            Array.Copy(s2, 0, slots, 3, 3);
            Array.Copy(s3, 0, slots, 6, 3);
        }

        public bool Trim()
        {
            bool changed = false;
            for(int i = 0; i < slots.Length; i++)
                if(slots[i].Confirmed)
                    for(int j = 0; j < slots.Length; j++)
                        changed |= slots[j].RemoveInvalid(slots[i].Value);
            return changed;
        }
    }

    public class Slot
    {
        public Slot(char v, bool confirmed = false)
        {
            Value = v;
            Confirmed = confirmed;
            PossibleValues.Remove(v);
        }
        public char Value { get; set; }
        public bool Confirmed { get; private set; }
        public HashSet<char> PossibleValues = new HashSet<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });

        public bool RemoveInvalid(char c)
        {
            if(Confirmed)
                return false;

            bool changed = PossibleValues.Remove(c);

            if(PossibleValues.Count <= 0)
                throw new Exception("This sudoku have no result, please check in the input");

            if(PossibleValues.Count == 1)
            {
                Confirmed = true;
                Value = PossibleValues.First();
            }

            return changed;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class Grid
    {
        private Slot[] slots = new Slot[9];
        public Grid() { }

        public Slot this[int index]
        {
            get
            {
                if(index < 0 || index >= 9)
                    throw new Exception();

                return slots[index];
            }
            set
            {
                if(index < 0 || index >= 9)
                    throw new Exception();

                slots[index] = value;
            }
        }

        public bool Trim()
        {
            bool changed = false;
            for(int i = 0; i < slots.Length; i++)
                if(slots[i].Confirmed)
                    for(int j = 0; j < slots.Length; j++)
                        changed |= slots[j].RemoveInvalid(slots[i].Value);

            return changed;
        }

        public Slot[] GetRow(int row)
        {
            Slot[] arr = new Slot[3];
            Array.Copy(slots, row * 3, arr, 0, 3);
            return arr;
        }

        public Slot[] GetColumn(int column)
        {
            Slot[] arr = new Slot[3];
            for(int i = 0; i < 3; i++)
                arr[i] = slots[column + i * 3];

            return arr;
        }

        public bool IsDone()
        {
            foreach(var slot in slots)
                if(slot.Confirmed == false)
                    return false;

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < slots.Length; i += 3)
                sb.AppendLine(string.Format("{0} {1} {2} ", slots[i], slots[i + 1], slots[i + 2]));

            return sb.ToString();
        }
    }
}
