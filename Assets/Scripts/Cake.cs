using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
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
        string path = "Assets/Resources/level.txt";
        if (File.Exists(path))
        {
            StreamReader rd= new StreamReader(path);
            highestLevel = rd.Read();
            rd.Close();
        }
        if (highestLevel < transitionTo)
        {
            using (TextWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(transitionTo);
                writer.Close();
            }
        }

        AsyncOperation async = SceneManager.LoadSceneAsync("Level" + transitionTo);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
