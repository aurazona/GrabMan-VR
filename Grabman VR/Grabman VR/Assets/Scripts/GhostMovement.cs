using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //public Transform[] points;
    private UnityEngine.AI.NavMeshAgent nav;
    //private int destPoint;
    public GameObject self;
    //private float GhostY;
    //private float GhostW;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("VRCam").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //GhostY = self.transform.rotation.y;
        //GhostW = self.transform.rotation.w;
        //self.transform.rotation.Set(0, GhostY, 0, GhostW);
        //if (!nav.pathPending && nav.remainingDistance < 0.5f)
        //    GoToNextPoint();
        nav.SetDestination(player.position);
    }

    //void GoToNextPoint()
    //{
    //    if (points.Length == 0)
    //    {
    //        return;
    //    }
    //    nav.destination = points[destPoint].position;
    //    destPoint = (destPoint + 1) % points.Length;
    //}
}
