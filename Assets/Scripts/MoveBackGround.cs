using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    public float speed;
    private Vector2 targetPosition;
    public GameObject background;
    public float starPositionX;
    

    void Start()
    {
        starPositionX = transform.position.x;
        Destination();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        Loop();
    }

    void Destination()
    {
        if (transform.position.x < background.transform.position.x)
        {
            targetPosition = new Vector2(background.transform.position.x, 0);
        }
        else
        {
            targetPosition = new Vector2(-(background.transform.position.x), 0);
        }
    }

    void Loop()
    {
        if(transform.position.x == targetPosition.x)
        {
            transform.position = new Vector2(starPositionX, 0);
        }
    }

   
}
