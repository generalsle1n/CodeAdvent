using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2.model
{
    internal class SingleRound
    {
        internal OpponentGame Opponent { get; set; }
        internal YoureSelfGame YoureSelf { get; set; }
        internal int Score { get; set; }
        
        internal void CalculateScore()
        {
            switch (Opponent)
            {
                case OpponentGame.Rock:
                    if(YoureSelf == YoureSelfGame.Paper)
                    {
                        Score = (int)GameScoreEnd.Win + ParseEnumByteSharp();
                    }
                    else if(YoureSelf == YoureSelfGame.Rock){
                        Score = (int)GameScoreEnd.Draw + ParseEnumByteSharp();
                    }
                    else
                    {
                        Score = ParseEnumByteSharp();
                    }
                    break;
                case OpponentGame.Paper:
                    if (YoureSelf == YoureSelfGame.Scissors)
                    {
                        Score = (int)GameScoreEnd.Win + ParseEnumByteSharp();
                    }
                    else if (YoureSelf == YoureSelfGame.Paper)
                    {
                        Score = (int)GameScoreEnd.Draw + ParseEnumByteSharp();
                    }
                    else
                    {
                        Score = ParseEnumByteSharp();
                    }
                    break;
                case OpponentGame.Scissors:
                    if (YoureSelf == YoureSelfGame.Rock)
                    {
                        Score = (int)GameScoreEnd.Win + ParseEnumByteSharp();
                    }
                    else if (YoureSelf == YoureSelfGame.Scissors)
                    {
                        Score = (int)GameScoreEnd.Draw + ParseEnumByteSharp();
                    }
                    else
                    {
                        Score = ParseEnumByteSharp();
                    }
                    break;
            }
        }

        private int ParseEnumByteSharp()
        {
            return (int)Enum.Parse<GameScoreSharp>(YoureSelf.ToString());
        }
    }

    enum OpponentGame
    {
        Rock = 'A',
        Paper = 'B',
        Scissors = 'C'
    }

    enum YoureSelfGame
    {
        Rock = 'X',
        Paper = 'Y',
        Scissors = 'Z'
    }

    enum GameScoreSharp
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    enum GameScoreEnd
    {
        Loose = 0,
        Draw = 3,
        Win = 6
    }
}
