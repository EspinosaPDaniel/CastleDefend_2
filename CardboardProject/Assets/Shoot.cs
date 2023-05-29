using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow;
    public Transform spawnPoint;
    public float shotForce = 1000;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if(Time.time>shotRateTime){
                GameObject newArrow;
                newArrow=Instantiate(arrow, spawnPoint.position,Quaternion.Euler(spawnPoint.rotation.x,spawnPoint.rotation.y+90f,spawnPoint.rotation.z));
                newArrow.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
                shotRateTime=Time.time+shotRate;
                Destroy(newArrow,2);
            }
            }
        }
    
        //if(Input.GetKeyDown(KeyCode.F)){
          //  if(Time.time>shotRateTime){
            //    GameObject newArrow;
              //newArrow.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*shotForce);
               // shotRateTime=Time.time+shotRate;
               // Destroy(newArrow,2);
            //}
        //}
    }
}
