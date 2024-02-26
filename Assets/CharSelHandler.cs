using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelHandler : MonoBehaviour
{
    
    public string p1 = "";
    public string p2 = "";

    public int mode = 0;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setThing(string selected)
    {
        if (mode == 0)
        {
            p1 = selected;
            GameObject.Find("Instr").GetComponent<TextMeshProUGUI>().text = "Player 2 Select Character";
            mode = 1;
        }
        else if (mode == 1)
        {
            mode = 2;
            p2 = selected;
            GameObject.Find("Instr").GetComponent<TextMeshProUGUI>().text = "Press Start Button";
            button.SetActive(true);

        }
    }

    public void loadMM()
    {
        mode = 0;
        SceneManager.LoadScene(0);
    }

    public void loadGame()
    {
        mode = 0;
        SceneManager.LoadScene(2);
    }

    // Handle hover text/lore
    public TextMeshProUGUI loreText;
    public string defaultHoverText = "Hover over a character";
    
    public void changeHoverText(string text)
    {
        loreText.text = text;
    }

    public void resetHoverText()
    {
        loreText.text = defaultHoverText;
    }
}
