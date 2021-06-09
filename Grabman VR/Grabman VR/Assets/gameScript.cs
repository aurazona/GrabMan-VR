using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameScript : MonoBehaviour
{
    static public int score = 0;
    bool playerWon = false;
    public GameObject self;
    public Transform WinTele;
    Vector3 WinTelePos;
    public GameObject[] orbs;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        WinTelePos = GameObject.FindGameObjectWithTag("WinTele").transform.position;
        orbs = GameObject.FindGameObjectsWithTag("Orb");
    }

    // Update is called once per frame
    void Update()
    {
        orbs = GameObject.FindGameObjectsWithTag("Orb");
        if ((orbs.Length == 0) && playerWon == false)
        {
            self.transform.position = WinTelePos;
            playerWon = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("dead lmao");
            Destroy(floor);
            Scene scene = SceneManager.GetActiveScene();
            Thread.Sleep(3000);
            SceneManager.LoadSceneAsync(scene.name);
        }
    }
}
