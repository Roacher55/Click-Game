using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColourWin : MonoBehaviour
{
    // Start is called before the first frame update
    private bool change = true;
    private bool isRunning = false;
    void Start()
    {
        this.gameObject.GetComponent<Text>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
            StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        isRunning = true;
        yield return new WaitForSeconds(1);
        if(change)
        {
            this.gameObject.GetComponent<Text>().color = Color.blue;
            change = !change;
        }
        else
        {
            this.gameObject.GetComponent<Text>().color = Color.red;
            change = !change;
        }
        isRunning = false;
    }
}
