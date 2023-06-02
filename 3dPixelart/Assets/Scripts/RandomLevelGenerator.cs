using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public int width = 100;
    public int height = 100;

    public int dockLength = 10;

    public float noiseScale = 20;

    public Gradient colors;
    public Gradient FallOffGradient;

    private Texture2D falloff;

    private float offsetX = 0;
    private float offsetY = 0;

    public Texture2D GenerateTexture()
    {
        falloff = FallOff(width, height);
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);

        //Texture2D baseTexture = new Texture2D(width, height);

        Texture2D texture = Initialize(width + dockLength, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);

                color = ApplyFallOff(x, y, color);

                color = ClipTexture(color);

                texture.SetPixel(x, y, color);
            }
        }

        //add dock
        Debug.Log("y = " + height / 2);

        for (int x = texture.width-1; x > 0; x--)
        {
            Debug.Log("x = " + x);
            Debug.Log(texture.GetPixel(x, height / 2));

            if(texture.GetPixel(x, height/2) == Color.black)
            {
                texture.SetPixel(x, height / 2, Color.red);
            }
            else
            {
                break;
            }
        }

        texture.filterMode = FilterMode.Point;


        texture.Apply();
        return texture;
    }

    public Texture2D Initialize(int w, int h)
    {
        Texture2D texture = new Texture2D(w,h);

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                texture.SetPixel(x, y, Color.black);
            }
        }

        return texture;
    }

    public Color ApplyFallOff(int x, int y,Color color)
    {        
        return falloff.GetPixel(x, y) * color;
    }


    public Texture2D FallOff(int w, int h)
    {
        Texture2D texture = new Texture2D(w, h);

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                float newX = x - (w / 2), newY = y - (h / 2);

                float value = 1 - ((Mathf.Abs(newX) / w) + (Mathf.Abs(newY) / h));

                Color color = FallOffGradient.Evaluate(value);
                texture.SetPixel(x, y, color);
            }
        }
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * (width/noiseScale) + offsetX;
        float yCoord = (float)y / height * (height/noiseScale) + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

    Color ClipTexture(Color color)
    {
        return colors.Evaluate(color.r);
    }

}