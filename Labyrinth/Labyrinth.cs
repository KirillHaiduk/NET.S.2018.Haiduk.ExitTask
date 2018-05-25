using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    /// <summary>
    /// Describes given 6x6 labyrinth
    /// </summary>
    public class Labyrinth
    {
        public Position[,] Positions;
        public Labyrinth()
        {
            this.Positions = new Position[6, 6];
                        
            Positions[0, 0] = new Position(false, true, false, false);
            Positions[0, 1] = new Position(false, true, false, true);
            Positions[0, 2] = new Position(false, false, true, true);
            Positions[0, 3] = new Position(false, true, true, false);
            Positions[0, 4] = new Position(false, false, false, true);
            Positions[0, 5] = new Position(false, true, true, false);
            Positions[1, 0] = new Position(true, true, false, false);
            Positions[1, 1] = new Position(true, false, false, true);
            Positions[1, 2] = new Position(false, true, true, false);
            Positions[1, 3] = new Position(true, false, false, true);
            Positions[1, 4] = new Position(false, false, true, true);
            Positions[1, 5] = new Position(true, false, true, false);
            Positions[2, 0] = new Position(true, true, false, false);
            Positions[2, 1] = new Position(false, true, false, true);
            Positions[2, 2] = new Position(true, false, true, false);
            Positions[2, 3] = new Position(false, true, false, false);
            Positions[2, 4] = new Position(false, true, false, true);
            Positions[2, 5] = new Position(false, true, true, false);
            Positions[3, 0] = new Position(true, true, false, false);
            Positions[3, 1] = new Position(true, true, false, true);
            Positions[3, 2] = new Position(false, true, true, false);
            Positions[3, 3] = new Position(true, true, false, true);
            Positions[3, 4] = new Position(true, false, true, false);
            Positions[3, 5] = new Position(true, true, false, false);
            Positions[4, 0] = new Position(true, true, false, false);
            Positions[4, 1] = new Position(true, false, false, false);
            Positions[4, 2] = new Position(true, false, false, true);
            Positions[4, 3] = new Position(true, true, true, false);
            Positions[4, 4] = new Position(false, true, false, false);
            Positions[4, 5] = new Position(true, true, false, false);
            Positions[5, 0] = new Position(true, false, false, true);
            Positions[5, 1] = new Position(false, false, true, true);
            Positions[5, 2] = new Position(false, false, true, true);
            Positions[5, 3] = new Position(true, false, true, false);
            Positions[5, 4] = new Position(true, false, false, true);
            Positions[5, 5] = new Position(true, false, true, true);
        }

        /// <summary>
        /// Generates sequence of positions to pass given labyrinth
        /// </summary>
        /// <param name="position">Current position in labyrinth</param>
        /// <param name="i">Index i of Position array</param>
        /// <param name="j">Index j of Position array</param>
        /// <returns>Sequence of labyrinth positions as way through it</returns>
        public IEnumerable<Position> Pass(Position position, int i, int j)
        {
            if (position.IsVisited)
            {
                yield break;
            }

            Positions[i, j].IsVisited = true;
            if (Positions[i, j].Top)
            {
                yield return Positions[i - 1, j];
                foreach (var p in Pass(Positions[i - 1, j], i - 1, j))
                {
                    yield return p;
                }
            }
            else if (Positions[i, j].Bottom)
            {
                yield return Positions[i + 1, j];
                foreach (var p in Pass(Positions[i + 1, j], i + 1, j))
                {
                    yield return p;
                }
            }
            else if (Positions[i, j].Left)
            {
                yield return Positions[i, j - 1];
                foreach (var p in Pass(Positions[i, j - 1], i, j - 1))
                {
                    yield return p;
                }
            }
            else
            {
                yield return Positions[i, j + 1];
                foreach (var p in Pass(Positions[i, j + 1], i, j + 1))
                {
                    yield return p;
                }
            }
        }

        #region Previous versions

        //public List<Position> LabyrinthPass()
        //{
        //    List<Position> list = new List<Position>();
        //    list.Add(Positions[0, 0]);
        //    Positions[0, 0].IsVisited = true;
        //    //foreach(var position in Positions)
        //    //{
        //    //    if(position.Top)
        //    //    {

        //    //    }
        //    //}
        //    for (int i = 0; i < Positions.Length; i++)
        //    {
        //        for (int j = 0; j < Positions.Length; j++)
        //        {
        //            if (Positions[i, j].Top)
        //            {
        //                Positions[i, j].Next = Positions[i - 1, j];
        //                list.Add(Positions[i - 1, j]);
        //                Positions[i - 1, j].IsVisited = true;
        //            }
        //            else if (Positions[i, j].Bottom)
        //            {
        //                Positions[i, j].Next = Positions[i + 1, j];
        //                list.Add(Positions[i + 1, j]);
        //                Positions[i + 1, j].IsVisited = true;
        //            }
        //            else if (Positions[i, j].Left)
        //            {
        //                Positions[i, j].Next = Positions[i, j - 1];
        //                list.Add(Positions[i, j - 1]);
        //                Positions[i, j - 1].IsVisited = true;
        //            }
        //            else
        //            {
        //                Positions[i, j].Next = Positions[i, j + 1];
        //                list.Add(Positions[i, j + 1]);
        //                Positions[i, j + 1].IsVisited = true;
        //            }
        //        }
        //    }
        //    return list;
        //}

        //public IEnumerable<Position> Pass(Position position)
        //{
        //    if(!position.IsVisited)
        //    {
        //        for (int i = 0; i < Positions.Length; i++)
        //        {
        //            for (int j = 0; j < Positions.Length; j++)
        //            {
        //                if (Positions[i, j].Top)
        //                {
        //                    Positions[i, j].Next = Positions[i - 1, j];
        //                    yield return Positions[i - 1, j];
        //                    yield return Pass(Positions[i - 1, j]).First();
        //                    Positions[i - 1, j].IsVisited = true;
        //                }
        //                else if (Positions[i, j].Bottom)
        //                {
        //                    Positions[i, j].Next = Positions[i + 1, j];
        //                    yield return Positions[i + 1, j];
        //                    yield return Pass(Positions[i + 1, j]).First();
        //                    Positions[i + 1, j].IsVisited = true;
        //                }
        //                else if (Positions[i, j].Left)
        //                {
        //                    Positions[i, j].Next = Positions[i, j - 1];
        //                    yield return Positions[i, j - 1];
        //                    yield return Pass(Positions[i, j - 1]).First();
        //                    Positions[i, j - 1].IsVisited = true;
        //                }
        //                else
        //                {
        //                    Positions[i, j].Next = Positions[i, j + 1];
        //                    yield return Positions[i, j + 1];
        //                    yield return Pass(Positions[i, j + 1]).First();
        //                    Positions[i, j + 1].IsVisited = true;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        yield break;
        //    }
        //}

        #endregion
    }
}
