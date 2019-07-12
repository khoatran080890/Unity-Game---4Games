using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    UserInput userinput;
    [SerializeField]
    ScreenReaction screanreaction;
    // Start is called before the first frame update

    [SerializeField]
    AudioClip typingsound;

    enum Moment
    {
        Menu,
        PassWordTyping,
        FreeStyleTyping,
        Win,
    }
    Moment moment;

    void Awake()
    {
        moment = Moment.Menu;
    }

    void Start()
    {
        userinput.NeverChanged();


    }

    // Update is called once per frame
    void Update()
    {

        if (screanreaction.NotificationUserOption == 1 || screanreaction.NotificationUserOption == 2)
        {
            moment = Moment.PassWordTyping;
        }
        else if (screanreaction.NotificationUserOption == 3)
        {
            moment = Moment.FreeStyleTyping;
        }
        else if (screanreaction.NotificationUserOption == 4)
        {
            moment = Moment.Menu;
        }
        else if (screanreaction.NotificationUserOption == 4)
        {
            moment = Moment.Win;
        }


        if (moment == Moment.Menu)
        {
            userinput.TypedTextValue(); // Take value from keyboard
            screanreaction.CheckValueFromUserInput();
            userinput.TextShowedOnScreen(); // Show text typed from keyboard into screen
            screanreaction.CheckIfReset();
        }
        else if (moment == Moment.FreeStyleTyping)
        {
            userinput.TypedTextValue(); // Take value from keyboard
            userinput.TextShowedOnScreen(); // Show text typed from keyboard into screen
            Debug.Log(userinput._currentline);
            screanreaction.CheckIfReset();
        }
        else if (moment == Moment.PassWordTyping)
        {
            userinput.TypedTextValue(); // Take value from keyboard
            userinput.TextShowedOnScreen(); // Show text typed from keyboard into screen
            screanreaction.CheckIfReset();
            screanreaction.CheckIfWin();
        }
        else if (moment == Moment.Win)
        {
            userinput.TypedTextValue(); // Take value from keyboard
            userinput.TextShowedOnScreen(); // Show text typed from keyboard into screen
            screanreaction.CheckIfReset();
        }

        if (Input.inputString.Length > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(typingsound);
        }

    }
}
