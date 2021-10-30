using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ClickObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Rotate();
        base.Destiny();
    }


    new void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(particleDeath, transform.position, transform.rotation);
        WallAndHearth.DestroyHearth();
        Cursor.SetCursor(cursorOnExit, Vector2.zero, CursorMode.ForceSoftware);
        base.OnMouseDown();
    }


}
