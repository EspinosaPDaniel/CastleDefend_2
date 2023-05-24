using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    private Door door;
    // Start is called before the first frame update
    void Start()
    
    {
        door = FindObjectOfType<Door>();
        StartCoroutine(InflictDamage());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator InflictDamage(){
         while(true){
            yield return new WaitForSeconds(10);
            door.currentHealth-=damage;
        }

    }
}
