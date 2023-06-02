using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;
    public float life = 5;
    public Vector3 relativeDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("End", life);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.forward + relativeDirection) * speed * Time.deltaTime);

    }

    void End()
    {
        Destroy(gameObject);
    }

}
