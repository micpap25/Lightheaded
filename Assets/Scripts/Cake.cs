using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake : MonoBehaviour, Collectable
{
    public int transitionTo;
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
        AsyncOperation async = SceneManager.LoadSceneAsync("Level" + transitionTo);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
