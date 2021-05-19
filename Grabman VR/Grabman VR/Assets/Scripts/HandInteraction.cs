using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour
{
    private BoxCollider handCollider;
    // Start is called before the first frame update
    void Start()
    {
        handCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            gameScript.score++;
        }
    }
}
