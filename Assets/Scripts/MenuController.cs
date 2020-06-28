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
    function Awake() {
    allAudioSources = FindObjectsOfType(AudioSource) as AudioSource[];
}

function StopAllAudio() {
    for(var audioS : AudioSource in allAudioSources) {
        audioS.Stop();
    }

  public void loadFirstLvl(){
      Debug.Log ("You have clicked the NewGameButton!");
      StopAllAudio();
      SceneManager.LoadScene("Level1");
  }
  public void QuitGame(){
    Debug.Log("Haha loser you quit. jk lov u <3");
    StopAllAudio();
    Application.Quit();
  }

  public void ResumeGame()
    {
        StreamReader inp_stm = new StreamReader(path);

        string inp_ln = inp_stm.ReadLine();
        string maxlvl = inp_ln.Trim();
        inp_stm.Close();

        Debug.Log("resumed!");
        StopAllAudio();
        SceneManager.LoadScene("Level" + maxlvl);
    }

    public void loadCredits(){
        Debug.Log ("You have clicked the CreditButton!");
        StopAllAudio();
        SceneManager.LoadScene("Credit");
    }
    public void loadMenu(){
        Debug.Log ("You have clicked the BackButton!");
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        foreach(GameObject mus in music)
        {
            Destroy(mus);
        }
        SceneManager.LoadScene("Menu");
    }
}
