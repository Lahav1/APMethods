using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Levels
{
    class LevelFactory
    {
        private Board board;

        public LevelFactory(Board board)
        {
            this.board = board;
        }

        public Level GetLevel(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    return new EasyLevel(board);
                case 2:
                    return new MediumLevel(board);
                case 3:
                    return new HardLevel(board);
                default:
                    return new EasyLevel(board);
            }
        }
    }
}
