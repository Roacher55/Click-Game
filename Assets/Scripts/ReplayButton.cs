using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : Button, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        orginalColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = "Zagraj Ponownie";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("SampleScene");
        GameHelper.wynik = 0;
        GameHelper.poziom = 0;
    }
}
