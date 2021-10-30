using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class EndButton : Button, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        orginalColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = "Wyjdü";
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }


}
