using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    public GameObject ballplayer;
    void Start()
    {
        ballplayer = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if ((ballplayer.transform.position.z - gameObject.transform.position.z) > 15)
        {
            DestroyObjectMethod();
        }
    }
    public void DestroyObjectMethod ()
    {
            Destroy(gameObject);
    }
}
