using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorOnEnter;
    public Texture2D cursorOnExit;
    private int tempPoziom;
    public float addSpeed;
    public float speed;
    public float targetPosition;
    public float rotationSpeed;
    public GameObject particleDeath;


    void Start()
    {
        tempPoziom = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Destiny();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOnEnter, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(cursorOnExit, Vector2.zero, CursorMode.ForceSoftware);
    }

   protected void OnMouseDown()
    {
        Cursor.SetCursor(cursorOnExit, Vector2.zero, CursorMode.ForceSoftware);
    }


    protected void Destiny()
    {
        MoveFaster();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPosition, -1), speed * Time.deltaTime);
    }
    void MoveFaster()
    {

        if (tempPoziom <= GameHelper.poziom)
        {
            tempPoziom = tempPoziom + 1;
            speed = speed + addSpeed;
        }
    }

    protected void Rotate()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.name == "Wall")
        {
            Destroy(gameObject);
            Instantiate(particleDeath, transform.position, transform.rotation);
        }
    }


}
