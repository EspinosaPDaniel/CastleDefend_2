using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paladinHit : MonoBehaviour
{
    private GameObject paladin;
    private GameObject paladinClone;
    private string killeableTag="Killeable";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject objectToDestroy = GameObject.FindGameObjectWithTag(killeableTag);
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Destroy(gameObject);
            }
    }
}
