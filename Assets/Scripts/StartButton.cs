using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class StartButton : Button, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        orginalColor = gameObject.GetComponent<Image>().color;
        gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = "Start";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("SampleScene");
    }

}
