using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("dead lmao");
            Destroy(floor);
            Scene scene = SceneManager.GetActiveScene();
            Thread.Sleep(3000);
            SceneManager.LoadSceneAsync(scene.name);
        }
    }
}
