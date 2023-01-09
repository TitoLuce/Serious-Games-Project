using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    //Movement speed
    private float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-movementSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, movementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0, -movementSpeed * Time.deltaTime));
        }
    }
}
