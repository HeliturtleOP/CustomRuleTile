using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuleEncoder : MonoBehaviour
{

    public string[,] SetEdges(string[,] map, Vector2 mapSize)
    {
        for (int x = 0; x < mapSize.x ; x++)
        {
            for (int y = 0; y < mapSize.y ; y++)
            {
                if (map[x, y] == "1")
                {
                    if (map[x, y - 1] == "0")
                    {
                        map[x, y] += "u";
                    }


                    if (map[x, y + 1] == "0")
                    {
                        map[x, y] += "d";
                    }


                    if (map[x + 1, y] == "0")
                    {
                        map[x, y] += "l";
                    }


                    if (map[x - 1, y] == "0")
                    {
                        map[x, y] += "r";
                    }

                    if (map[x, y].Contains("u") && !map[x, y].Contains("d"))
                    {
                        if (!map[x, y].Contains("r"))
                        {
                            //z
                            if (map[x - 1, y + 1] == "0")
                            {
                                map[x, y] += "z";
                            }
                        }

                        if (!map[x, y].Contains("l"))
                        {
                            //y
                            if (map[x + 1, y + 1] == "0")
                            {
                                map[x, y] += "y";
                            }
                        }

                    }

                    if (map[x, y].Contains("d") && !map[x, y].Contains("u"))
                    {
                        if (!map[x, y].Contains("l"))
                        {
                            //w
                            if (map[x + 1, y - 1] == "0")
                            {
                                map[x, y] += "w";
                            }
                        }

                        if (!map[x, y].Contains("r"))
                        {
                            //x
                            if (map[x - 1, y - 1] == "0")
                            {
                                map[x, y] += "x";
                            }
                        }
                    }

                    if (map[x, y] == "1l")
                    {
                        //xz
                        if (map[x - 1, y - 1] == "0")
                        {
                            map[x, y] += "x";
                        }

                        if (map[x - 1, y + 1] == "0")
                        {
                            map[x, y] += "z";
                        }

                    }

                    if (map[x, y] == "1r")
                    {
                        //wy
                        if (map[x + 1, y - 1] == "0")
                        {
                            map[x, y] += "w";
                        }

                        if (map[x + 1, y + 1] == "0")
                        {
                            map[x, y] += "y";
                        }

                    }

                    if (map[x, y] == "1")
                    {
                        if (map[x + 1, y - 1] == "0")
                        {
                            map[x, y] += "w";
                        }

                        if (map[x - 1, y - 1] == "0")
                        {
                            map[x, y] += "x";
                        }

                        if (map[x - 1, y + 1] == "0")
                        {
                            map[x, y] += "z";
                        }

                        if (map[x + 1, y + 1] == "0")
                        {
                            map[x, y] += "y";
                        }



                    }

                }
            }
        }


        //GetComponent<MapLoader>().LoadMap(map, mapSize);
        return map;

    }

}
