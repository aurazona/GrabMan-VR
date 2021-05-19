using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScaler : MonoBehaviour
{

    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] handModel = GameObject.FindGameObjectsWithTag("Hand");

        foreach (var hand in handModel)
        {
            hand.transform.localScale = new Vector3(0.09323937f, 0.09323937f, 0.09323937f);
            Debug.Log("hand scaled");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
