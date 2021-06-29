using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public int setBoxColor;
    public ColorButtonSelecter colorButton;
    private int colorBtn;
    public float mySpeed; 
    public bool isBig = false;
    int bigDecreassing;


    private void Start()
    {
        //Finds the gameobject with the ColotButtonSelecter
        colorButton = GameObject.FindGameObjectWithTag("colorBtn").GetComponent<ColorButtonSelecter>();

        mySpeed = colorButton.boxSpeed;

        bigDecreassing = 10;
    }

    private void FixedUpdate()
    {
        FallingSpeed(mySpeed);
    }


    private void Update()
    {

        //Always get the index of the button selected
        colorBtn = colorButton.setColorButton;

        //Destroy box if gets out the limits
        DestroyBoxIfGetsOutOfScreen();
    }

    //Functions that read the collide by touching the box and destoy it if he color btn and the color box are the same
    public void DestroyBoxByCorrectColor()
    {

        if(this.setBoxColor == colorBtn)
        {
            if (isBig)
            {
                this.GetComponent<RectTransform>().localScale -= new Vector3(0.3f, 0.3f, 0.3f);
                bigDecreassing--;

                if (bigDecreassing <= 0)
                {

                    Destroy(this.gameObject);
                }
            }

            else
            {
                Destroy(this.gameObject);
            }
           
        }

        

    }

    public void FallingSpeed(float speed)
    {
        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * speed);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector3.down * speed);
    }

    //Function to debug, it have to be changed by DESTROY WHEN THE BOX GETS THE DANGER ZONE
    public void DestroyBoxIfGetsOutOfScreen()
    {
        if(this.gameObject.GetComponent<RectTransform>().position.y <= -500)
        {
            Destroy(this.gameObject);
        }
    }


}
