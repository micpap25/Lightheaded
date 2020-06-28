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

    public void Kill()
    {
        Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
    }
}
