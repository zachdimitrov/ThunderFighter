﻿namespace ThunderFighter
{
    using ThunderFighter.Enums;

    public class ScoreBoard
    {
        public ScoreBoard()
        {
        }

        public int Score { get; set; }

        public int HighestScore { get; set; }

        public int Lives { get; set; }

        public GameLevel Level { get; set; }
    }
}