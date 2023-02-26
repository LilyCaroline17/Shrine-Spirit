using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritScript : MonoBehaviour
{
    public float speed = 10;
    public Vector2 direction;

    // Start is called before the first frame update
    void Awake()
    {
        direction =Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //move();
    }

    private void OnMouseDown()
    {
        direction=getMousePos() - (Vector2)transform.position;
        direction.Normalize();
    }

    //when screen is tapped, spirit will move towards the location
    void move()
    {
        transform.position += new Vector3(direction.x * speed, direction.y * speed, 0.0f);
    }

    Vector2 getMousePos()
    { return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); }
    
}
