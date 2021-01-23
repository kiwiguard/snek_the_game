using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    public GameObject TailPrefab; // Tail prefab
    public GameObject borderTopPrefab;
    public GameObject borderBottomPrefab;
    public GameObject borderLeftPrefab;
    public GameObject borderRightPrefab;
    public float speed = 0.2f;

    // Current Movement Direction
    // by default the snake moves to the right
    Vector2 dir = Vector2.right;
    Vector2 moveVector;
    List<Transform> tail = new List<Transform>();  // Keeps track of tail

    // Did snake eat?
    bool ate = false;

    //bools to prevent snake from moving the direct opposite, gets handled in Update
    bool vertical = false;
    bool horizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        // Moves Snake every 300ms
        InvokeRepeating("Move", 0.3f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the snake in new direction from key input
        if (Input.GetKey(KeyCode.RightArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            dir = Vector2.right;
        }  
        else if (Input.GetKey(KeyCode.DownArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            dir = -Vector2.up; // '-up' means down :)
        }  
        else if (Input.GetKey(KeyCode.LeftArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            dir = -Vector2.right; // '-right' means left :)
        }   
        else if (Input.GetKey(KeyCode.UpArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            dir = Vector2.up;
        }
        moveVector = dir / 3f;
    }

    // Handles trigger when snake eats
    void OnTriggerEnter2D(Collider2D coll)
    {
        //if (coll.name.StartsWith("FoodPrefab"))
        if (coll.tag == "Obstacle")
        {
            //Todo: GameOver Screen
            CancelInvoke("Move"); //Stops movement
            FindObjectOfType<GameManager>().GameOver();
        } 
        else
        {
            ate = true; // set ate bool to true
            Destroy(coll.gameObject); // destroy food
            Score.AddScore(); // calls add score function from GameManager
        }
    }

    // Moves the snake
    void Move()
    {
        // Save current position
        Vector2 v = transform.position;
        // Move head
        transform.Translate(dir);

        if(ate)
        {
            if(speed > 0.001)
            {
                speed = speed - 0.001f; // speeds up snake with each bite
            }
            // Load prefab into the world
            GameObject g = (GameObject)Instantiate(TailPrefab,
                                                    v,
                                                    Quaternion.identity);
            // Keep track of it in our tail list
            tail.Insert(0, g.transform);
            Debug.Log(speed); // log current speed
            // Reset the flag
            ate = false;
        }

        if (tail.Count > 0)
        {   // Moves the last tail element to where head previously was
            tail.Last().position = v;

            // Add to front of list, remove from back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
