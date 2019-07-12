using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    public Point ConnectToPoint;

    // Start is called before the first frame update
    [SerializeField]
    public GameObject BallPlayer;

    [SerializeField]
    public MenuManeger menumanager;

    [SerializeField]
    AudioClip damage;
    [SerializeField]
    AudioClip point;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Auto move forward
        MovingForward();
        TakeRightLeftUserInput();
        ConnectToPoint.text.text = ConnectToPoint.ScoreIsShowed.ToString();
    }

    public void MovingForward()
    {
        BallPlayer.transform.position = new Vector3(BallPlayer.transform.position.x, BallPlayer.transform.position.y, BallPlayer.transform.position.z + 0.15f);
    }
    public void TakeRightLeftUserInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            BallPlayer.transform.position = new Vector3(BallPlayer.transform.position.x - 0.15f, BallPlayer.transform.position.y, BallPlayer.transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            BallPlayer.transform.position = new Vector3(BallPlayer.transform.position.x + 0.15f, BallPlayer.transform.position.y, BallPlayer.transform.position.z);
        }


        if (BallPlayer.transform.position.x > 5.0f)
        {
            BallPlayer.transform.position = new Vector3(5.0f, BallPlayer.transform.position.y, BallPlayer.transform.position.z);
        }
        if (BallPlayer.transform.position.x < -5.0f)
        {
            BallPlayer.transform.position = new Vector3(-5.0f, BallPlayer.transform.position.y, BallPlayer.transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            GetComponent<AudioSource>().PlayOneShot(point);
            ConnectToPoint.ScoreIsShowed++;
        }
        if (other.gameObject.tag == "Obs")
        {
            GetComponent<AudioSource>().PlayOneShot(damage);
            menumanager.Playing_Die();
        }
    }
}
