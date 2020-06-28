using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ReturnToMenu());
        }
    }

    private IEnumerator Restart()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!async.isDone)
        {
            yield return null;
        }
    }
    private IEnumerator ReturnToMenu()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Menu");
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
