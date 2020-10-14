using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject cam;
    public float parallexEffect;
    private float actualStartPos;

    // Start is called before the first frame update
    void Start()
    {
        actualStartPos = transform.position.x;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = cam.transform.position.x * (1 - parallexEffect);
        float distance = cam.transform.position.x * parallexEffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if (temp + actualStartPos > (startpos + length))
        {
            startpos += length;
        }
        else if (temp + actualStartPos < startpos - length)
        {
            startpos -= length;
        }
    }
}
