using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{


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
}
