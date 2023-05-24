using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour2 : MonoBehaviour
{
    private float movementSpeed = 1.0f;
    private float rotationSpeed = 100.0f;
    private float stopDistance = 3.0f; // Distance from the target at which the character will stop
    private GameObject targetObject; // Object that the character will move towards
    private GameObject arrowClone;
    private bool doubleHit;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        targetObject=GameObject.Find("rounded-door");
        doubleHit=false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
       if (col.gameObject==arrowClone)
        {
            if(!doubleHit){
                Destroy(arrowClone);
                doubleHit=true;
            }
            else{
         Destroy(arrowClone); // Destruye el objeto que colisionó con el objeto actual
         Destroy(gameObject); // Destruye el objeto actual
        }
        }
    }
    void Update()
    {
        arrowClone=GameObject.Find("Arrow(Clone)");
        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.transform.position);

        // Check if the character is already close enough to the target
        if (distanceToTarget <= stopDistance)
        {
            // Stop moving and play idle animation
            transform.position = transform.position;
            anim.SetFloat("xSpeed", 0);
            anim.SetFloat("ySpeed", 0);
            return;
        }

        // Calculate the direction to the target
        Vector3 direction = (targetObject.transform.position - transform.position).normalized;

        // Rotate towards the target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        // Move towards the target
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        // Set animation parameters based on movement direction
        anim.SetFloat("xSpeed", direction.x);
        anim.SetFloat("ySpeed", direction.z);
    }
}
