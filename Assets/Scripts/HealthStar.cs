using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStar : ClickObject
{

    public GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        base.Rotate();
        base.Destiny();
    }

    // Update is called once per frame
    new void OnMouseDown()
    {
      
     
        Destroy(gameObject);
        Instantiate(particleDeath, transform.position, transform.rotation);
        AddHearth();
        base.OnMouseDown();



    }

    public void AddHearth()
    {
        if(WallAndHearth.listHearth.Count < 6)
            { 
        WallAndHearth.listHearth.Add(Instantiate(heart, new Vector3(WallAndHearth.hearthPositionX, WallAndHearth.hearthPositionY, -0.5f), new Quaternion(0,0,0, 0)));
        WallAndHearth.hearthPositionX = WallAndHearth.hearthPositionX + 1.5f;
            }
    }
}
    

