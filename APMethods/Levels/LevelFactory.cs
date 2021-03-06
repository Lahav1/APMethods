using APMethods.GameBoard;
using System;
using System.Collections.Generic;
using System.Text;

namespace APMethods.Levels
{
    class LevelFactory
    {
        private Board board;
        private Player player;

        public LevelFactory(Board board, Player player)
        {
            this.board = board;
            this.player = player;
        }

        public Level GetLevel(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    return new EasyLevel(board, player);
                case 2:
                    return new MediumLevel(board, player);
                case 3:
                    return new HardLevel(board, player);
                default:
                    return new EasyLevel(board, player);
            }
        }
    }
}
