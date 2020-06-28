using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Globalization;
using System.IO;


public class MenuController : MonoBehaviour
{
    string path = "Assets/Resources/level.txt";


  void Start () {

    }

  public void loadFirstLvl(){
      Debug.Log ("You have clicked the NewGameButton!");
      SceneManager.LoadScene("Level1");
  }
  public void QuitGame(){
    Debug.Log("Haha loser you quit. jk lov u <3");
    Application.Quit();
  }

  public void ResumeGame()
    {
        StreamReader inp_stm = new StreamReader(path);

        string inp_ln = inp_stm.ReadLine();
        string maxlvl = inp_ln.Trim();
        inp_stm.Close();

        Debug.Log("resumed!");
        SceneManager.LoadScene("Level" + maxlvl);
    }

    public void loadCredits(){
        Debug.Log ("You have clicked the CreditButton!");
        SceneManager.LoadScene("Credit");
    }
    public void loadMenu(){
        Debug.Log ("You have clicked the BackButton!");
        SceneManager.LoadScene("Menu");
    }
}
