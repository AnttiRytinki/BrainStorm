using System.Windows.Forms;
using static BrainStorm.Enums;

namespace BrainStorm
{
    public class BoardHandler
    {
        public GameState GameState { get; set; }

        public BoardHandler(GameState gameState)
        {
            GameState = gameState;
        }

        /// <summary>
        /// Returns true if text can fit anywhere on the board
        /// </summary>
        public bool CanAddToBoard(string text)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (TryAddToBoard(x, y, Direction.Horizontal, text, true))
                        return true;

                    if (TryAddToBoard(x, y, Direction.Vertical, text, true))
                        return true;
                }
            }

            return false;
        }

        //public bool CanAddToBoard(string text)
        //{
        //    bool canAdd;

        //    for (int i = 0; i < 100; i++)
        //    {
        //        Random rnd = new Random();
        //        int x = rnd.Next(0, 9);
        //        int y = rnd.Next(0, 9);
        //        Direction direction = Helpers.RandDirection();

        //        try
        //        {
        //            canAdd = TryAddToBoard(x, y, direction, text, true);
        //        }
        //        catch
        //        {
        //            continue;
        //        }

        //        if (canAdd)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //public bool AddToBoard(string text)
        //{
        //    bool success;

        //    for (int i = 0; i < 100; i++)
        //    {
        //        Random rnd = new Random();
        //        int x = rnd.Next(0, 9);
        //        int y = rnd.Next(0, 9);
        //        Direction direction = Helpers.RandDirection();

        //        try
        //        {
        //            success = TryAddToBoard(x, y, direction, text, false);
        //        }
        //        catch
        //        {
        //            continue;
        //        }

        //        if (success)
        //        {
        //            GameState.WordList.Add(new Word(x, y, text, direction));

        //            return true;
        //        }
        //    }

        //    return false;
        //}

        /// <summary>
        /// Add text randomly on board, returns false if text doesn't fit
        /// </summary>
        public bool AddToBoard(string text)
        {
            if (CanAddToBoard(text) == false)
                return false;

            Word cand = GetRandomPlacementPossibility(text);

            TryAddToBoard(cand.X, cand.Y, cand.Direction, text, false);
            GameState.WordList.Add(cand);

            return true;
        }

        public bool TryAddToBoard(int x, int y, Direction direction, string text, bool test)
        {
            try
            {
                if (direction == Direction.Horizontal)
                {
                    if (BoardSpaceRightIsEmpty(x, y, text.Length))
                    {
                        if (!test)
                            PutStringInBoardRight(x, y, text);

                        return true;
                    }

                    else
                        return false;
                }

                if (direction == Direction.Vertical)
                {
                    if (BoardSpaceDownIsEmpty(x, y, text.Length))
                    {
                        if (!test)
                            PutStringInBoardDown(x, y, text);

                        return true;
                    }

                    else
                        return false;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private List<Word> GetAllPossibleWordPlacements(string text)
        {
            var possibilites = new List<Word>();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (TryAddToBoard(x, y, Direction.Horizontal, text, true))
                        possibilites.Add(new Word(x, y, text, Direction.Horizontal));

                    if (TryAddToBoard(x, y, Direction.Vertical, text, true))
                        possibilites.Add(new Word(x, y, text, Direction.Vertical));
                }
            }

            return possibilites;
        }

        private Word GetRandomPlacementPossibility(string text)
        {
            var allPossibilities = GetAllPossibleWordPlacements(text);
            int randIdx = Helpers.RandInt(0, allPossibilities.Count - 1);

            return allPossibilities[randIdx];
        }

        private void PutStringInBoardRight(int x, int y, string text)
        {
            for (int X = x; X < (text.Length + x); X++)
            {
                GameState.Board[y] = Helpers.ReplaceAt(GameState.Board[y], X, text[X - x]);
            }
        }

        private bool BoardSpaceRightIsEmpty(int x, int y, int length)
        {
            for (int X = x; X < (length + x); X++)
            {
                if (GameState.Board[y][X] != (char)32)
                    return false;
            }

            return true;
        }

        private void PutStringInBoardDown(int x, int y, string text)
        {
            for (int Y = y; Y < (text.Length + y); Y++)
            {
                GameState.Board[Y] = Helpers.ReplaceAt(GameState.Board[Y], x, text[Y - y]);
            }
        }

        private bool BoardSpaceDownIsEmpty(int x, int y, int length)
        {
            for (int Y = y; Y < (length + y); Y++)
            {
                if (GameState.Board[Y][x] != (char)32)
                    return false;
            }

            return true;
        }
    }
}
