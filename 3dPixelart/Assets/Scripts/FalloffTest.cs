using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloffTest : MonoBehaviour
{

    public Gradient FallOffGradient;

    // Start is called before the first frame update
    void Start()
    {
        Texture2D texture = FallOff(32,64);
        texture.filterMode = FilterMode.Point;
        texture.Apply();
        GetComponent<MeshRenderer>().material.mainTexture = texture; 
    }


    public Texture2D Circle(int cx, int cy, int r)
    {
        Texture2D tex = new Texture2D(32, 32);

        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {


            d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
            for (y = 0; y <= d; y++)
            {

                float pv = (Mathf.Sqrt(((0 - x) ^ 2) + ((0 - y) ^ 2))) / (Mathf.Sqrt(((0 - cx) ^ 2) + ((0 - cy) ^ 2)));
                Debug.Log(pv);
                Color col = new Color(pv, pv, pv, 1);

                px = cx + x;
                nx = cx - x;
                py = cy + y;
                ny = cy - y;

                tex.SetPixel(px, py, col);
                tex.SetPixel(nx, py, col);

                tex.SetPixel(px, ny, col);
                tex.SetPixel(nx, ny, col);

            }
        }

        return tex;

    }

    public Texture2D FallOff(int w, int h)
    {
        Texture2D texture = new Texture2D(w, h);

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                float newX = x - (w / 2), newY = y - (h / 2);

                float Xvalue = Mathf.Abs(newX)/w;
                float Yvalue = Mathf.Abs(newY)/h;

                float value = 1 - (Xvalue + Yvalue);

                Debug.Log(value);
                //Color color = new Color(value,value,value);
                Color color = FallOffGradient.Evaluate(value);
                texture.SetPixel(x, y, color);
            }
        }
        return texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
