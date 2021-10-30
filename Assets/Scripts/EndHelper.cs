using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndHelper : MonoBehaviour
{
    public Text wynik;
    public Text najlepszyWynikTekst;
    // Start is called before the first frame update
    void Start()
    {
        if (GameHelper.wynik > PlayerPrefs.GetInt("najlepszywynik"))
        {
            PlayerPrefs.SetInt("najlepszywynik", GameHelper.wynik);
        }
        wynik.text = "Twój wynik " + GameHelper.wynik +" !!!";
        najlepszyWynikTekst.text = "Najlpeszy wynik dotychczas " + PlayerPrefs.GetInt("najlepszywynik") + " !!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
