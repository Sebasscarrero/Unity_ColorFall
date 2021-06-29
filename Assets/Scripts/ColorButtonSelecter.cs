using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonSelecter : MonoBehaviour
{
    //Color     0 - Yellow    |   1 - Blue    |   2 - Red   |   3 - Purple  |

    public int setColorButton;
    public RectTransform[] colorButtons;

    public float boxSpeed;

    private void Update()
    {
        //Increase Speed
        boxSpeed += Time.deltaTime * 1;
    }

    public void ButtonPressedProperties(int colorBtn) //To scale the buttons when selected
    {
        if(colorBtn == 0)
        {
            //Small scale by pressed
            colorButtons[0].localScale = new Vector3(.8f, .8f, .8f);

            //Other buttons are normal scale
            colorButtons[1].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[2].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[3].localScale = new Vector3(1f, 1f, 1f);
        } 
        else if (colorBtn == 1)
        {
            //Small scale by pressed
            colorButtons[1].localScale = new Vector3(.8f, .8f, .8f);

            //Other buttons are normal scale
            colorButtons[0].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[2].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[3].localScale = new Vector3(1f, 1f, 1f);
        }
        else if (colorBtn == 2)
        {
            //Small scale by pressed
            colorButtons[2].localScale = new Vector3(.8f, .8f, .8f);

            //Other buttons are normal scale
            colorButtons[0].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[1].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[3].localScale = new Vector3(1f, 1f, 1f);
        }
        else if (colorBtn == 3)
        {
            //Small scale by pressed
            colorButtons[3].localScale = new Vector3(.8f, .8f, .8f);

            //Other buttons are normal scale
            colorButtons[1].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[2].localScale = new Vector3(1f, 1f, 1f);
            colorButtons[0].localScale = new Vector3(1f, 1f, 1f);
        }
    }

    //Functions that set the color by the button pressed

    public void SetYellowBox()
    {
        setColorButton = 0;
        ButtonPressedProperties(setColorButton);
    }

    public void SetBluewBox()
    {
        setColorButton = 1;
        ButtonPressedProperties(setColorButton);
    }

    public void SetRedBox()
    {
        setColorButton = 2;
        ButtonPressedProperties(setColorButton);
    }

    public void SetPurpleBox()
    {
        setColorButton = 3;
        ButtonPressedProperties(setColorButton);
    }
}
