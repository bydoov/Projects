namespace GreenVsRed
{
    class Grid
    {
        private int _row;
        private int _column;
        public string[,] Body { get; set; }
        public Grid(int row, int column)
        {
            _row = row;
            _column = column;
            Body = new string[row, column];
        }
        public int getRow() { return _row; }
        public int getColumn() { return _column; }
    }
}
