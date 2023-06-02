using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TilesColor
{
    public RuleTileSO tile;
    public Color color;
}

public class MapInterpreter : MonoBehaviour
{

    public TilesColor[] tilesColors;

    public Texture2D mapTexture;

    //private string[,] map;

    public void MapToArray()
    {

        string[,] tempMap;

        mapTexture = GetComponent<RandomLevelGenerator>().GenerateTexture();

        for (int i = 0; i < tilesColors.Length; i++)
        {
            //get basic rendition of map as string
            tempMap = ReadTextureMap(tilesColors[i].color);

            //encode map with rules for rule tile
            tempMap = GetComponent<RuleEncoder>().SetEdges(tempMap, new Vector2Int(mapTexture.width + 1, mapTexture.height + 1));

            //load objects into scene
            GetComponent<MapLoader>().LoadMap(tempMap, new Vector2Int(mapTexture.width + 1, mapTexture.height + 1), mapTexture, tilesColors);
        }

        transform.position -= new Vector3(mapTexture.width / 2, 0, mapTexture.height / 2);

    }

    public void ClearLevel()
    {
        GetComponent<MeshFilter>().sharedMesh.Clear();

        int childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private string[,] InitializeArray()
    {
        string[,] tempMap = new string[mapTexture.width + 2, mapTexture.height + 2];

        for (int x = 0; x < mapTexture.width + 2; x++)
        {
            for (int y = 0; y < mapTexture.height + 2; y++)
            {
                tempMap[x, y] = "0";
            }
        }

        return tempMap;

    }

    private string[,] ReadTextureMap(Color color)
    {
        string[,] tempMap;

        tempMap = InitializeArray();

        for (int x = 0; x < mapTexture.width ; x++)
        {
            for (int y = 0; y < mapTexture.height ; y++)
            {
                if (mapTexture.GetPixel(x,y) == color)
                {
                    tempMap[x + 1, y + 1] = "1";
                }
            }
        }

        return tempMap;

    }

}
