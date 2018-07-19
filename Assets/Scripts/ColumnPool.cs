using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;                                 //The column game object.
    public int columnPoolSize = 5;                                  //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public float columnMin = -1.6f;                                   //Minimum y value of the column position.
    public float columnMax = 1.7f;                                  //Maximum y value of the column position.
    public float coeff = 1.5f;
    public float defaultX = 1.3f;
    public float defaultY = 1.6f;
    private GameObject[] columns;                                   //Collection of pooled columns.
    private int currentColumn = 0;                                  //Index of the current column in the collection.
    private Vector3 lastPosition;
    private Vector2 objectPoolPosition = new Vector2(1.3f, 1.6f);     //A holding position for our unused columns offscreen.);
    private float spawnYPosition;

    private float timeSinceLastSpawned;

    private GameObject player;
   
    void Start()
    {
        timeSinceLastSpawned = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        spawnYPosition = player.transform.position.y + player.GetComponent<PlayerController>().getSpeed() * coeff;
        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        objectPoolPosition = new Vector2(defaultX, defaultY);     //A holding position for our unused columns offscreen.);
        for (int i = 0; i < columnPoolSize; i++)
        {
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            columns[i].SetActive(false);
        }
    }


    //This spawns columns as long as the game is not over.
    void FixedUpdate()
    {
        timeSinceLastSpawned += Time.deltaTime;
        spawnYPosition = player.transform.position.y + PlayerController.player.getSpeed() * coeff;
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnXPosition = Random.Range(columnMin, columnMax);
            Column.numCreate += 1;
            columns[currentColumn].GetComponent<Column>().create = Column.numCreate;
            //...then set the current column to that position.
            columns[currentColumn].SetActive(true);
            columns[currentColumn].transform.position = new Vector3(spawnXPosition, spawnYPosition, -0.5f);
            
            

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }


}