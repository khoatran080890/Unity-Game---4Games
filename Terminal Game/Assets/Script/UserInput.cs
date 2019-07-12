using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    public Text text;

    public string _currentline = ""; // current line
    public List<string> _typedline = new List<string>(); // text saved from entered
    public List<string> _Neverchanged = new List<string>();

    public int[] checkline = new int[100];

    void Start()
    {
        //field.ActivateInputField();
        //Debug.Log(text.transform.position);
    }

    // Update is called once per frame
    public void NeverChanged()
    {
        _typedline.Add("Hello Agent Khoa");
        _typedline.Add("Please select level");
        _typedline.Add("1 for level 1\n2 for level 2\n3 for Freestyle typing");
    }

    public void ClearList()
    {
        _typedline.Clear();
        NeverChanged();
        Vector2 TextReset = new Vector2(649.0f, -548.5f);
        text.transform.position = TextReset;
    }

    public void TypedTextValue()
    {
        foreach (char c in Input.inputString) // return value we type from keyboard
        {
            if (c == (char)8)
            {
                if (_currentline.Length > 0)
                {
                    _currentline = _currentline.Remove(_currentline.Length - 1);
                }
                else
                {
                }
            }
            else if ((c == (char)10 || c == (char)13) && (_currentline == "" || _currentline == null))
            {
            }
            else if ((c == (char)10 || c == (char)13))
            {
                _typedline.Add(_currentline);
                _currentline = "";

                if ((_Neverchanged.Count + _typedline.Count) > 10 && ((_Neverchanged.Count + _typedline.Count) % 2 == 0))
                {
                    text.transform.position = new Vector2(text.transform.position.x, text.transform.position.y + 50.0f);
                }
            }

            else
            {
                _currentline += c;
            }
        }
    }

    public void TextShowedOnScreen()
    {
        if (_typedline.Count > 0)
        {
            text.text = string.Join("\n", _typedline.ToArray()) + "\n" + _currentline;
        }
        else
        {
            text.text = _currentline;
        }

    }

    // when we type enter
    public void DisplayTextTyped(string input)
    {
        //string firstline = text.text;
        //string newline = firstline + "\n" + input;
        //text.text = newline;
        //field.text = "";
        //field.ActivateInputField();
    }

    // when we typing
    public void DisplayTextTyping(string input)
    {
        //string firstline = text.text;
        //string newline = firstline + input;
        //text.text = newline;
        //// input = string is in field.text => delete field.text
        //field.text = "";
        //string firstline2 = newline;
        //string newline2 = firstline2;
        //text.text = newline2;

        //string firstline = text.text;
        //string newline = firstline + "\n" + input.Substring(input.Length - 1, 1);
        //text.text = newline;
        //field.text = "";
        //field.ActivateInputField();


    }
}

