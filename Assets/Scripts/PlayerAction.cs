using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    float h;
    float v;
    private float speed = 0.01f;
    private Vector2 vector;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if(h!=0 || v != 0)
        {
            vector.Set(h, v);
            if (vector.x != 0)
            {
                transform.Translate(vector.x * speed, 0, 0);
            } else if (vector.y != 0)
            {
                transform.Translate(0, vector.y * speed, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        
    }
}
