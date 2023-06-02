using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
   
public class LevelGenerator : MonoBehaviour
{
    public RuleTileSO tile;    

    public GameObject TileMap;
    GameObject fresh;

    public Vector2Int mapSize = new Vector2Int(20, 20);

    public string[,] map;

    // Start is called before the first frame update
    //void Start()
    //{                      
    //    GenerateMap();
    //    SetEdges();
    //    LoadMap();
    //}

    public void GenerateMap()
    {

        map = new string[mapSize.x + 2, mapSize.y + 2];

        for (int x = 0; x < mapSize.x+2; x++)
        {
            for (int y = 0; y < mapSize.y+2; y++)
            {
                map[x, y] = "0";
            }
        }

        for (int x = 1; x < mapSize.x+1; x++)
        {
            for (int y = 1; y < mapSize.y+1; y++)
            {
                if (Random.Range(0,3)!=0)
                    map[x, y] = "1";

            }
        }

        Debug.Log(map);
    }

    public void SetEdges()
    {
        for (int x = 0; x < mapSize.x + 2; x++)
        {
            for (int y = 0; y < mapSize.y + 2; y++)
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

                    if (map[x,y] == "1l")
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

                    if (map[x,y] == "1")
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
    }

    public void LoadMap()
    {
        for (int x = 1; x < mapSize.x+1; x++)
        {
            for (int y = 1; y < mapSize.y+1; y++)
            {
                Debug.Log(map[x, y]);

                if (map[x,y].Contains("1"))
                {
                    if (map[x, y] == "1")
                    {
                        Instantiate(tile.wall14, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                    }
                    else
                    {                        

                        switch (map[x, y])
                        {
                            //straight walls
                            case "1u":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0,180,0), TileMap.transform);
                                break;
                            case "1d":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1l":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1r":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //corners
                            case "1ul":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1ur":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1dl":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1dr":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //paralels
                            case "1ud":
                                fresh = Instantiate(tile.wall9, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1lr":
                                fresh = Instantiate(tile.wall9, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            //U Walls
                            case "1udl":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1udr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1ulr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1dlr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //double corners
                            case "1ulz":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1ury":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1dlx":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1drw":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //two corner single wall
                            case "1uzy":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1dwx":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1lxz":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1rwy":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //stright wall left corner
                            case "1uy":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1dx":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1lz":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1rw":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //straight wall right corner
                            case "1uz":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1dw":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1lx":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1ry":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //single inner corners
                            case "1w":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1x":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1y":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1z":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //opposite inner corners
                            case "1wz":
                                fresh = Instantiate(tile.wall7, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1xy":
                                fresh = Instantiate(tile.wall7, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            //double inner corners
                            case "1wx":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1wy":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1xz":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            case "1zy":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            //triple inner corners
                            case "1wxz":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), TileMap.transform);
                                break;
                            case "1wxy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;
                            case "1wzy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                            case "1xzy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), TileMap.transform);
                                break;
                            //all inner corners
                            case "1wxzy":
                                fresh = Instantiate(tile.wall6, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), TileMap.transform);
                                break;

                            default:
                                fresh = Instantiate(tile.wall6, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), TileMap.transform);
                                break;
                        }
                        fresh.name = map[x, y];
                    }

                }
            }
        }
    }

    public void ClearLevel()
    {
        int childs = TileMap.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(TileMap.transform.GetChild(i).gameObject);
        }


        TileMap.GetComponent<Tilemap>().ClearAllTiles();
    }

}
