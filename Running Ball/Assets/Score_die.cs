using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_die : MonoBehaviour
{
    [SerializeField]
    public Text text;
    [SerializeField]
    public Text dietext;

    public int ScoreIsShowed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dietext.text = text.text;
    }
}
