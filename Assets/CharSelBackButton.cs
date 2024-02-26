using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelBackButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
