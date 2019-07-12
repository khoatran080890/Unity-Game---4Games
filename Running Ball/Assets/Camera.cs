using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject ballplayer;
    // Start is called before the first frame update
    void Start()
    {
        CameraFollowBall();
    }

    // Update is called once per frame
    void Update()
    {
        // Auto move forward
        CameraFollowBall();
    }

    public void CameraFollowBall()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, ballplayer.transform.position.y + 5.0f, ballplayer.transform.position.z - 5.0f);
    }
}
