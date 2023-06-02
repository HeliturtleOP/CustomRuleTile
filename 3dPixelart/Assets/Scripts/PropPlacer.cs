using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPlacer : MonoBehaviour
{
    public GameObject[] props;

    public int amount = 3;

    public int odds = 10;

    string[,] mapCopy;


    public void Place(string[,] map, Vector2Int mapSize)
    {
        //for (int x = 0; x < mapSize.x + 2; x++)
        //{
        //    for (int y = 0; y < mapSize.y + 2; y++)
        //    {
        //        if (map[x,y] != "0")
        //        {
        //            if (Random.Range(0, odds) == 0)
        //            {
        //                Instantiate(props[Random.Range(0,props.Length)], new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), transform);
        //            }
        //        }
        //    }
        //}


        mapCopy = (string[,])map.Clone();

        for (int i = 0; i < amount; i++)
        {

            int x = Random.Range(1, mapSize.x );
            int y = Random.Range(1, mapSize.y );

            print(x.ToString() + "," + y.ToString());

            if (mapCopy[x, y] == "1")
                {
                   mapCopy[x, y] = "2";
                   Instantiate(props[Random.Range(0, props.Length)], new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0), transform);
                }
            else
            {
                i--;
            }
        }



    }

}
