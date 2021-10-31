using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursor;
    public GameObject fruit;
    public GameObject bomb;
    public GameObject health;
    public float fruitPositionY = 5;
    public float fruitPositionXminus = -11;
    public float fruitPositionXplus = 11;
    private bool isRunning = false;
    public float waitToSpawnFruit = 2;
    public static int wynik = 0;
    public Text wynikText;
    public Text poziomTekst;
    public static int poziom = 0;
    private int tempPoziom = 5;
    private int random;
    private bool pause = false;
    public GameObject maxHealth;
    private bool isMaxHealthColour = false;
    private bool changeColour = false;
    


    void Start()
    {
        maxHealth.SetActive(false);

        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Quit();
        PauseGame();
        wynikText.text = "Wynik: " + wynik;
        poziomTekst.text = "Poziom: " + poziom;
        UpPoziom();
        EndGame();
        if (!isRunning)
        {
            StartCoroutine(MyCoroutine());
        }

        
        MaxHealth();
    }

    void SpawnFruit()
    {
        random = Random.Range(0, 50);

        if (random <= 10)
        {
            Instantiate(bomb, new Vector2(Random.Range(fruitPositionXminus, fruitPositionXplus), fruitPositionY), transform.rotation);
        }
        else if ((10 < random) && (random <= 15) && (WallAndHearth.listHearth.Count <6))
        {
            Instantiate(health, new Vector2(Random.Range(fruitPositionXminus, fruitPositionXplus), fruitPositionY), transform.rotation);
        }
        else
        {
            Instantiate(fruit, new Vector2(Random.Range(fruitPositionXminus, fruitPositionXplus), fruitPositionY), transform.rotation);
        }
        
    }

    IEnumerator MyCoroutine()
    {
        isRunning = true;
        yield return new WaitForSeconds(waitToSpawnFruit);
        SpawnFruit();
        isRunning = false;
    }
    void UpPoziom()
    {
        if(wynik>=tempPoziom)
        {
            tempPoziom = wynik + 5;
            poziom = poziom + 1;

        }
    }

    void EndGame()
    {
        if (WallAndHearth.listHearth.Count <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    void PauseGame()
    {
        if (Input.GetKeyDown("space"))
        {
            pause = !pause;
        }
        if(pause == true)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    void MaxHealth()
    {
        if(WallAndHearth.listHearth.Count < 6)
        {
            maxHealth.SetActive(false);
        }
        else
        {
            maxHealth.SetActive(true);

            if (!isMaxHealthColour)
            {
                StartCoroutine(HealthCoroutine());
            }
        }
    }

    IEnumerator HealthCoroutine()
    {
        isMaxHealthColour = true;
        yield return new WaitForSeconds(1);
        if(changeColour == true)
        {
            maxHealth.GetComponent<Text>().color = Color.black;
            changeColour = !changeColour;
        }
        else
        {
            maxHealth.GetComponent<Text>().color = Color.red;
            changeColour = !changeColour;
        }
        isMaxHealthColour = false;
    }
     void Quit()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

}