using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake : MonoBehaviour, Collectable
{
    public int transitionTo;
    private int highestLevel;
    // Start is called before the first frame update

    public void FixedUpdate()
    {
     //visual stuff while not collected, floating up and down, particles
    }
    public void collide()
    {
        StartCoroutine(Load());
        //Visual stuff for loading!
    }

    private IEnumerator Load()
    {
        string path = Directory.GetCurrentDirectory() + "/level.txt";
        using (TextWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine(transitionTo);
            writer.Close();
        }
        if (transitionTo == 6)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("Thankyou");
            while (!async.isDone)
            {
                yield return null;
            }
        }
        else
        {
            AsyncOperation async = SceneManager.LoadSceneAsync("Level" + transitionTo);
            while (!async.isDone)
            {
                yield return null;
            }
        }
    }
}
