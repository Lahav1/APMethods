namespace APMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(50, 20);
            board.AddElement(new Player(8, 19));
            board.AddElement(new Enemy(5, 10));
            board.AddElement(new Enemy(1, 1));
            board.AddElement(new Enemy(36, 11));
            board.Draw();
        }
    }
}
