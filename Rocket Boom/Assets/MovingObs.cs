using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObs : MonoBehaviour
{
    [SerializeField]
    Vector3 movedirection;    [Range(-1, 1)]
    [SerializeField]    float changenumber;    Vector3 startposition;

    void Start()    {        startposition = gameObject.transform.position;    }
    void Update()    {        changenumber = Mathf.Sin(Time.time * Mathf.PI * 0.2f);        gameObject.transform.position = startposition + movedirection * changenumber;    }
}
