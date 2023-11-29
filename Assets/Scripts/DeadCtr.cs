using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCtr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Destroy()
    {
        Destroy(gameObject, 0.1f);
    }
}
