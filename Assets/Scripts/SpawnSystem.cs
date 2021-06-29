using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSystem : MonoBehaviour
{
    //Variables
    public float timetoSpawnMODE;
    public float timetoSpawn;
    public float timetoSpawninLine;
    private float timetoSpawninLinePrivate;
    public float bigTime;
    public int bigLimit;

    private int setMode;
    private bool isinMode = false;
    public bool isWaitingMode = true;

    public RectTransform[] spawnPoints;
    public GameObject box;

    public GameObject[] boxPosSpawn;

    private Color[] basicColors = { new Color32(255, 242, 93, 255), new Color32(0, 202, 252, 255), new Color32(252, 103, 97, 255), new Color32(150, 51, 255, 255) };

    int spawn;
    int color, color1, color2, color3, color4;

    GameObject spawnedBox, spawnedBox1, spawnedBox2, spawnedBox3, spawnedBox4;

    private void Start()
    {
        timetoSpawninLinePrivate = timetoSpawninLine;
    }

    void Update()
    {
        if (timetoSpawnMODE <= 0)
        {
            //isinMode = false;

            if (isinMode == false)
            {
                setMode = Random.Range(1, 4);
                isinMode = true;
            }

            else if (isinMode)
            {
                if (setMode == 1)
                {
                    SelectandSpawnRandom();

                    if (isWaitingMode)
                    {
                        Debug.Log("Is in Random Mode");
                        StartCoroutine(TimeToNextMode(Random.Range(6,11)));
                        isWaitingMode = false;
                    }
                }
                else if (setMode == 2)
                {
                    SelectandSpawninLine();

                    if (isWaitingMode)
                    {
                        Debug.Log("Is in Line Mode");
                        StartCoroutine(TimeToNextMode(Random.Range(6,10)));
                        isWaitingMode = false;
                    }
                    //timetoSpawnMODE = Random.Range(7, 11);
                }
                else if (setMode == 3)
                {
                    SelectBigandSpawn();

                    if (isWaitingMode)
                    {
                        bigLimit = 2;
                        bigTime = 1;
                        Debug.Log("Is in Big Mode");
                        StartCoroutine(TimeToNextMode(8));
                        isWaitingMode = false;
                    }
                    //timetoSpawnMODE = Random.Range(9, 11);
                }
            }
            
        }

        else if (timetoSpawnMODE > 0)
        {
            timetoSpawnMODE -= Time.deltaTime;
        }

        //SelectandSpawnRandom();
        //SelectandSpawninLine();

        if (Input.GetKeyDown("space"))
        {
            SelectBigandSpawn();
        }

    }

    IEnumerator TimeToNextMode(float time)
    {
        yield return new WaitForSeconds(time);
        isinMode = false;
        yield return new WaitForSeconds(2f);
        isWaitingMode = true;
        timetoSpawnMODE = 0.5f;
    }



    // RANDOM SPAWNING MODES ---------------------------------------------------------------------------------------------------------------------

    // MODE 1: Random color boxes in random spawn points -------------------------

    public void SelectandSpawnRandom()
    {
        //Genera una caja de un color cada cierto tiempo

        if (timetoSpawn <= 0)
        {
            //Funcion que genera las cajas de un color aleatorio
            spawn = Random.Range(0, 4);  //Select random spawner
            color = Random.Range(0, 4);  //Select random color

            SelectandSpawn(spawn, color);


            //Debug.Log("Timer is working");
            timetoSpawn = Random.Range(0.5f, 1.0f);

        }
        else if (timetoSpawn > 0)
        {
            timetoSpawn -= Time.deltaTime;
        }
    }
    public void SelectandSpawn(int spawner, int color) 
    {
        //Spawner:  0 - More left    |   1 - Left    |   2 - Right   |   3 - More Right   |
        //Color     0 - Yellow    |   1 - Blue    |   2 - Red   |   3 - Purple  |

        //More Left Spawner
        if (spawner == 0)
        {
            //Spawn Basic Colors
            if (color == 0)
            {
                //Color Yellow
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 0;
            }
            else if (color == 1)
            {
                //Color Blue
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 1;
            }
            else if (color == 2)
            {
                //Color Red
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 2;
            }
            else if (color == 3)
            {
                //Color Purple
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 3;
            }

            //More colors or modes down
        }

        //Left Spawner
        else if (spawner == 1)
        {
            //Spawn Basic Colors
            if (color == 0)
            {
                //Color Yellow
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 0;
            }
            else if (color == 1)
            {
                //Color Blue
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 1;
            }
            else if (color == 2)
            {
                //Color Red
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 2;
            }
            else if (color == 3)
            {
                //Color Purple
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 3;
            }

            //More colors or modes down
        }

        //Right Spawner
        else if (spawner == 2)
        {
            //Spawn Basic Colors
            if (color == 0)
            {
                //Color Yellow
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 0;
            }
            else if (color == 1)
            {
                //Color Blue
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 1;
            }
            else if (color == 2)
            {
                //Color Red
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 2;
            }
            else if (color == 3)
            {
                //Color Purple
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 3;
            }

            //More colors or modes down
        }

        //More Right Spawner
        else if (spawner == 3)
        {
            //Spawn Basic Colors
            if (color == 0)
            {
                //Color Yellow
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 0;
            }
            else if (color == 1)
            {
                //Color Blue
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 1;
            }
            else if (color == 2)
            {
                //Color Red
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 2;
            }
            else if (color == 3)
            {
                //Color Purple
                spawnedBox = Instantiate(box, boxPosSpawn[spawner].GetComponent<RectTransform>().position, Quaternion.identity);
                spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                spawnedBox.GetComponent<Image>().color = basicColors[color];
                spawnedBox.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

                //Set the box color variable
                this.spawnedBox.GetComponent<BoxController>().setBoxColor = 3;
            }

            //More colors or modes down
        }

    }

    // --------------------------------------------------------------------------

    // MODE 2: Random color boxes in the 4 spawn points at the same time --------

    public void SelectandSpawninLine()
    {

        if (timetoSpawninLinePrivate <= 0)
        {
            // Box More Left ----------------------------------------------------------------------------------------------
            color1 = Random.Range(0, 4);

            spawnedBox1 = Instantiate(box, boxPosSpawn[0].GetComponent<RectTransform>().position, Quaternion.identity);
            spawnedBox1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            //Set random color on each instantiate
            spawnedBox1.GetComponent<Image>().color = basicColors[color1];
            spawnedBox1.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

            this.spawnedBox1.GetComponent<BoxController>().setBoxColor = color1;


            // Box Left -----------------------------------------------------------------------------------------------------
            color2 = Random.Range(0, 4);

            spawnedBox2 = Instantiate(box, boxPosSpawn[1].GetComponent<RectTransform>().position, Quaternion.identity);
            spawnedBox2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            //Set random color on each instantiate
            spawnedBox2.GetComponent<Image>().color = basicColors[color2];
            spawnedBox2.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

            this.spawnedBox2.GetComponent<BoxController>().setBoxColor = color2;

            // Box Right ------------------------------------------------------------------------------------------------------
            color3 = Random.Range(0, 4);

            spawnedBox3 = Instantiate(box, boxPosSpawn[2].GetComponent<RectTransform>().position, Quaternion.identity);
            spawnedBox3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            //Set random color on each instantiate
            spawnedBox3.GetComponent<Image>().color = basicColors[color3];
            spawnedBox3.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

            this.spawnedBox3.GetComponent<BoxController>().setBoxColor = color3;

            // Box More Right ---------------------------------------------------------------------------------------------------
            color4 = Random.Range(0, 4);

            spawnedBox4 = Instantiate(box, boxPosSpawn[3].GetComponent<RectTransform>().position, Quaternion.identity);
            spawnedBox4.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            //Set random color on each instantiate
            spawnedBox4.GetComponent<Image>().color = basicColors[color4];
            spawnedBox4.GetComponent<RectTransform>().localScale = box.GetComponent<RectTransform>().localScale;

            this.spawnedBox4.GetComponent<BoxController>().setBoxColor = color4;



            //Set the time to start instatntiating again -------------------------------------------------------------------------
            timetoSpawninLinePrivate = timetoSpawninLine;
        }
        else
        {
            timetoSpawninLinePrivate -= Time.deltaTime;
        }
    }

    // --------------------------------------------------------------------------

    // MODE 3: Big box with random color which you have to tap multiple times ----

    public void SelectBigandSpawn()
    {
       

        if (bigTime <= 0 && bigLimit > 0)
        {
            // Big Box in the middle of the screen
            color = Random.Range(0, 4);

            spawnedBox = Instantiate(box, boxPosSpawn[4].GetComponent<RectTransform>().position, Quaternion.identity);
            spawnedBox.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            //Set random color on each instantiate
            spawnedBox.GetComponent<Image>().color = basicColors[color];
            spawnedBox.GetComponent<RectTransform>().localScale = new Vector3(3.9f, 3.9f, 3.9f);

            this.spawnedBox.GetComponent<BoxController>().isBig = true;
            this.spawnedBox.GetComponent<BoxController>().setBoxColor = color;

            bigTime = 3.5f;
            bigLimit--;
        }

        else
        {
            bigTime -= Time.deltaTime;
        }
        
    }

    // --------------------------------------------------------------------------






}
