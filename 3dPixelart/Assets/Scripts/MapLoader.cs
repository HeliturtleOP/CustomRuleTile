using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{


    public RuleTileSO tile;

    public GameObject LevelHolder;

    private float xOffset, yOffset;

    public void LoadMap(string[,] map, Vector2 mapSize, Texture2D PremadeMap, TilesColor[] tilesColors)
    {

        xOffset = mapSize.x;
        yOffset = mapSize.y;

        GameObject fresh;

        for (int x = 1; x < mapSize.x ; x++)
        {
            for (int y = 1; y < mapSize.y ; y++)
            {
                //Debug.Log(map[x, y]);

                if (map[x, y].Contains("1"))
                {
                    for (int e = 0; e < tilesColors.Length; e++)
                    {
                        if (PremadeMap.GetPixel(x - 1, y - 1) == tilesColors[e].color)
                        {
                            tile = tilesColors[e].tile;
                            break;
                        }
                    }

                    

                    if (map[x, y] == "1")
                    {
                        Instantiate(tile.wall14, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                    }
                    else
                    {

                        switch (map[x, y])
                        {
                            //straight walls
                            case "1u":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1d":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1l":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1r":
                                fresh = Instantiate(tile.wall8, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //corners
                            case "1ul":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1ur":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dl":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1dr":
                                fresh = Instantiate(tile.wall1, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //paralels
                            case "1ud":
                                fresh = Instantiate(tile.wall9, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1lr":
                                fresh = Instantiate(tile.wall9, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            //U Walls
                            case "1udl":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1udr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            case "1ulr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dlr":
                                fresh = Instantiate(tile.wall10, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            //double corners
                            case "1ulz":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1ury":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dlx":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1drw":
                                fresh = Instantiate(tile.wall2, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //two corner single wall
                            case "1uzy":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dwx":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1lxz":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1rwy":
                                fresh = Instantiate(tile.wall11, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //stright wall left corner
                            case "1uy":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dx":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1lz":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1rw":
                                fresh = Instantiate(tile.wall13, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //straight wall right corner
                            case "1uz":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1dw":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1lx":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1ry":
                                fresh = Instantiate(tile.wall12, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //single inner corners
                            case "1w":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1x":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1y":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1z":
                                fresh = Instantiate(tile.wall3, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //opposite inner corners
                            case "1wz":
                                fresh = Instantiate(tile.wall7, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1xy":
                                fresh = Instantiate(tile.wall7, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            //double inner corners
                            case "1wx":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1wy":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1xz":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            case "1zy":
                                fresh = Instantiate(tile.wall4, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            //triple inner corners
                            case "1wxz":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 90, 0), LevelHolder.transform);
                                break;
                            case "1wxy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;
                            case "1wzy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                            case "1xzy":
                                fresh = Instantiate(tile.wall5, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), LevelHolder.transform);
                                break;
                            //all inner corners
                            case "1wxzy":
                                fresh = Instantiate(tile.wall6, new Vector3(x, 0, y), Quaternion.Euler(0, 0, 0), LevelHolder.transform);
                                break;

                            default:
                                fresh = Instantiate(tile.wall6, new Vector3(x, 0, y), Quaternion.Euler(0, -90, 0), LevelHolder.transform);
                                break;
                        }
                        fresh.name = map[x, y];
                    }

                }
            }
        }

    }

}
