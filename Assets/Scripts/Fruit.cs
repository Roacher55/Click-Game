using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : ClickObject
{
    Sprite[] sprites;
    
    
    


    void Start()
    {
        RandomSprite();
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
        GameHelper.wynik = GameHelper.wynik + 1;
        base.OnMouseDown();
    }

    

    void RandomSprite()
    {
        sprites = Resources.LoadAll<Sprite>("Fruits");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
    
}
