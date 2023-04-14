using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    static partial class BaseArrays
    {
        public static char[] cChars = { '@', '#', '$', '%', '&', '*', 'B', 'H', 'G', 'R', 'Z' };
        public static char[] cFigureIds = { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };
        public static Dictionary<char, int> nFigureMaxRotationState = new Dictionary<char, int>()
        {
            ['O'] = 1,
            ['I'] = 2,
            ['S'] = 2,
            ['Z'] = 2,
            ['L'] = 4,
            ['J'] = 4,
            ['T'] = 4
        };
        public static KeyValuePair<char, List<Point>> FigPoints(char cFig, int nRotateState, int nFigMid, int nY = 0)
        {
            var pFigsPoints = new Dictionary<char, Dictionary<int, List<Point>>>()
            {
                ['O'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                ##
                                ##
                             
                            */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2)
                        }
                },
                ['I'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                #
                                #
                                #
                                #
                             
                            */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid, nY + 3),
                            new Point(nFigMid ,nY + 4)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             
                                ####
                             
                            */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid + 2, nY + 1),
                            new Point(nFigMid + 3, nY + 1)
                        }
                },
                ['S'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                 ##
                                ##
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid - 1, nY + 2),
                            new Point(nFigMid, nY + 2)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             
                                #
                                ##
                                 #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid + 1, nY + 3)
                        }
                },
                ['Z'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                ##
                                 ##
                             
                             */
                            new Point(nFigMid - 1, nY + 1),
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             
                                 #
                                ##
                                #
                             
                             */
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid, nY + 3)
                        }
                },
                ['L'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                #
                                #
                                ##
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid, nY + 3),
                            new Point(nFigMid + 1, nY + 3)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             
                                ###
                                #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid + 2, nY + 1),
                            new Point(nFigMid, nY + 2)
                        },
                    [3] =
                        new List<Point>()
                        {
                            /*
                             
                                ##
                                 #
                                 #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid + 1, nY + 3)
                        },
                    [4] =
                        new List<Point>()
                        {
                            /*
                             
                                  #
                                ###
                             
                             */
                            new Point(nFigMid + 2, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid + 2, nY + 2)
                        }
                },
                ['J'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                 #
                                 #
                                ##
                             
                             */
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid, nY + 3),
                            new Point(nFigMid + 1, nY + 3)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             
                                #
                                ###
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid + 2, nY + 2)
                        },
                    [3] =
                        new List<Point>()
                        {
                            /*
                             
                                ##
                                #
                                #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid, nY + 3)
                        },
                    [4] =
                        new List<Point>()
                        {
                            /*
                             
                                ###
                                  #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid + 2, nY + 1),
                            new Point(nFigMid + 2, nY + 2)
                        }
                },
                ['T'] = new Dictionary<int, List<Point>>()
                {
                    [1] =
                        new List<Point>()
                        {
                            /*
                             
                                ###
                                 #
                             
                             */
                            new Point(nFigMid - 1, nY + 1),
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid, nY + 2)
                        },
                    [2] =
                        new List<Point>()
                        {
                            /*
                             * 
                                 #
                                ##
                                 #
                             
                             */
                            new Point(nFigMid + 1, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid + 1, nY + 3)
                        },
                    [3] =
                        new List<Point>()
                        {
                            /*
                             
                                 #
                                ###
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid - 1, nY + 2),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2)
                        },
                    [4] =
                        new List<Point>()
                        {
                            /*
                              
                                #
                                ##
                                #
                             
                             */
                            new Point(nFigMid, nY + 1),
                            new Point(nFigMid, nY + 2),
                            new Point(nFigMid + 1, nY + 2),
                            new Point(nFigMid, nY + 3)
                        },
                }
            };
            return new KeyValuePair<char, List<Point>>(cFig, pFigsPoints[cFig][nRotateState]);
        }
    }
}
