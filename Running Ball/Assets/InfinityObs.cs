using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityObs : MonoBehaviour
{
    [SerializeField]
    public Vector3 vector;
    [SerializeField]
    public GameObject[] Prefabs;

    [SerializeField]
    public Ball ballplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(ballplayer.gameObject.transform.position, vector) < 50)
        {
            CreateInfinityObstacle();
        }
        
    }

    public void CreateInfinityObstacle()
    {
        vector = new Vector3(0.96f, 2.72f, vector.z + 10);
        Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], vector, Quaternion.identity);
    }
    
}
