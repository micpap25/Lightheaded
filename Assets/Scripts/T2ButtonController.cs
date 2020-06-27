using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T2ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.GetComponent<PlayerController>().numBalloons == 1)
        {
            transform.gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(true);
        }
    }

    public void Kill()
    {
        Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
    }
}
