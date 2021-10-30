using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallAndHearth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hearth;
    public static float hearthPositionX = -11;
    public static float hearthPositionY = 5;
    private int tempHearthCount = 3;
    public static List<GameObject> listHearth = new List<GameObject>();
    public static int listHearthCount;
    void Start()
    {
        StartHeart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartHeart()
    {
        while (tempHearthCount > 0)
        {
            AddHearth();
            tempHearthCount--;
        }
         listHearthCount = listHearth.Count -1;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.gameObject.name == "fruit(Clone)")
        {

            DestroyHearth();
        }
    }

    public static void  DestroyHearth()
    {
            Destroy(listHearth[listHearth.Count-1]);
            listHearth.RemoveAt(listHearth.Count-1);
            hearthPositionX = hearthPositionX - 1.5f;
    }

    public void  AddHearth()
    {
        if (WallAndHearth.listHearth.Count < 6)
        {
            listHearth.Add(Instantiate(hearth, new Vector3(hearthPositionX, hearthPositionY, -0.5f), transform.rotation));
            hearthPositionX = hearthPositionX + 1.5f;
        }
    }
}
