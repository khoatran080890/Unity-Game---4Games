using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("InfinityStageCreator");
        }
    }
    IEnumerator InfinityStageCreator ()
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 100);
    }
}
