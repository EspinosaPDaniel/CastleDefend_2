using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHit : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == arrow)
        {
            Destroy(arrow); // Destruye el objeto que colisionó con el objeto actual
            Destroy(gameObject); // Destruye el objeto actual
             Debug.Log("HIT");
        }
    }
}
