using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    enum State
    {
        Playing,
        Dying
    }

    State state = State.Playing;

    [SerializeField]
    AudioClip launching;
    [SerializeField]
    AudioClip explosion;
    [SerializeField]
    ParticleSystem boom;

    int currentScene;
    int maxScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        maxScene = SceneManager.sceneCountInBuildSettings - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Dying)
        {

            return;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Finish();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!gameObject.GetComponent<AudioSource>().isPlaying) // make sound not stack the layer
            {
                gameObject.GetComponent<AudioSource>().Play(); // trường hợp đã add component audiosource
            }
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 100.0f, 0));
            gameObject.GetComponent<AudioSource>().PlayOneShot(launching);
        }
        else
        {

            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.Rotate(new Vector3(0, 0, 10));
        }
        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.Rotate(new Vector3(0, 0, -10));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Invoke("Finish", 1.0f);
                break;
            case "Obs":
                gameObject.GetComponent<AudioSource>().Stop();
                gameObject.GetComponent<AudioSource>().PlayOneShot(explosion);
                boom.gameObject.SetActive(true);
                boom.Play();
                state = State.Dying;
                Invoke("Die", 2.0f);
                break;
            default:
                break;
        }
    }

    private void Finish()
    {
        state = State.Playing;
        if (currentScene == maxScene)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }

    }
    private void Die()
    {
        state = State.Playing;
        SceneManager.LoadScene(currentScene);
    }
}
