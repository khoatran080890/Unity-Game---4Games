using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    [SerializeField]
    GameObject StartMenu;
    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject DieMenu;
    [SerializeField]
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        StartMenu.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
        DieMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Playing_PauseButton()
    {
        StartMenu.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
        DieMenu.gameObject.SetActive(false);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Playing_Die()
    {
        StartMenu.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(false);
        DieMenu.gameObject.SetActive(true);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void Pause_PlayButton()
    {
        StartCoroutine(StartGame(3.0f));
    }
    public void Pause_ResetButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Die_ResetButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Die_Ads()
    {
        StartCoroutine(StartGame(3.0f));
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 2.5f);
    }

    IEnumerator StartGame (float waittime)
    {
        StartMenu.gameObject.SetActive(true);
        PauseMenu.gameObject.SetActive(false);
        DieMenu.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(waittime);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }
}
