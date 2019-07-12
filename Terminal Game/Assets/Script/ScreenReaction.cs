using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReaction : MonoBehaviour
{
    [SerializeField]
    public UserInput userinput;

    public int NotificationUserOption = 0;
    
    // moment = Moment.Menu => activate
    public void CheckValueFromUserInput()
    {
        if (userinput._typedline[userinput._typedline.Count - 1] == "1")
        {
            userinput._typedline.Add("Welcome to level 1");
            userinput._typedline.Add("Who is the most handsome ?? - ****");
            NotificationUserOption = 1;
        }
        else if (userinput._typedline[userinput._typedline.Count - 1] == "2")
        {
            userinput._typedline.Add("Welcome to level 2");
            userinput._typedline.Add("who is the superhero die in EndGame? - *******");
            NotificationUserOption = 2;
        }
        else if (userinput._typedline[userinput._typedline.Count - 1] == "3")
        {
            userinput._typedline.Add("Type whatever you want");
            NotificationUserOption = 3;
        }
        else if (userinput._typedline[userinput._typedline.Count - 1] != "1" && userinput._typedline[userinput._typedline.Count - 1] != "2" && userinput._typedline[userinput._typedline.Count - 1] != "3" && userinput._typedline.Count > 3)
        {
            userinput.ClearList();
        }
        
    }

    public void CheckIfReset()
    {
        if (userinput._typedline[userinput._typedline.Count - 1] == "clear")
        {
            userinput.ClearList();
            NotificationUserOption = 4;
        }
    }

    public void CheckIfWin()
    {
        if (userinput._typedline[userinput._typedline.Count - 1] == "Khoa" && NotificationUserOption == 1)
        {
            userinput._typedline.Add("CORRECT ! YOU WIN !!!!!");
            NotificationUserOption = 5;
        }
        if (userinput._typedline[userinput._typedline.Count - 1] == "ironman" && NotificationUserOption == 2)
        {
            userinput._typedline.Add("CORRECT ! YOU WIN !!!!!");
            NotificationUserOption = 5;
        }
    }
}
