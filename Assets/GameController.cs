using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public Airplane airplane;
    public GameObject cubePrefab;
    static int numCubes = 16;
    static int numRows = 9;
    public GameObject[,] allCubes = new GameObject[numCubes, numRows];
    float turnTime = 1.5f;
    float timeToAct = 0;
    int score = 0;
    int depotX = 15;
    int depotY = 0;
    public static bool up = false;
    public static bool down = false;
    public static bool left = false;
    public static bool right = false;
    // Use this for initialization
    void Start()
    {
        airplane = new Airplane();
        for (int h = 0; h < numRows; h++)
        {
            for (int i = 0; i < numCubes; i++)
            {
                allCubes[i, h] = (GameObject)Instantiate(cubePrefab, new Vector3(i * 2 - 14, h * 2, 10), Quaternion.identity);
                // these lines turn the location of the spanwed cubes into the x and y values used in CubeBehavior
                allCubes[i, h].GetComponent<CubeBehavior>().x = i;
                allCubes[i, h].GetComponent<CubeBehavior>().y = h;
            }
        }
        // tells the airplane to spawn in the upper left
        airplane.x = 0;
        airplane.y = 8;
        allCubes[0, 8].GetComponent<Renderer>().material.color = Color.red;
        allCubes[15, 0].GetComponent<Renderer>().material.color = Color.black;
    }
    // Update is called once per frame
    void Update()
    {
        Movement.FlyDirection();
        // sets the turn time and the various actions that take place during a turn
        if (Time.time > timeToAct)
        {
            timeToAct += turnTime;
            if (airplane.x == airplane.startingX && airplane.y == airplane.startingY)
            {
                airplane.cargo += 10;
            }
            if (airplane.cargo > airplane.cargoCapacity)
            {
                airplane.cargo = airplane.cargoCapacity;
            }
            if (airplane.x == depotX && airplane.y == depotY)
            {
                score += airplane.cargo;
                airplane.cargo = 0;
            }
			print("Your cargo is " + airplane.cargo);
			print("Your score is " + score);
			this.Fly(airplane.x, airplane.y);
        }
    }
    public void ProcessClickedCube(GameObject clickedCube, int x, int y)
    {
        // this says "if you click on an inactive airplane, that airplane becomes active"
        if (airplane.active == false && x == airplane.x && y == airplane.y)
        {
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
            clickedCube.GetComponent<Renderer>().material.color = Color.yellow;
            airplane.active = true;
        }
        // this says "if you click the active cube, deactivate it"
        else if (airplane.active == true && x == airplane.x && y == airplane.y)
        {
            clickedCube.GetComponent<Renderer>().material.color = Color.red;
            airplane.active = false;
        }
        // This turns the depot black after the player leaves it
        if (airplane.x != depotX || airplane.y != depotY)
        {
            allCubes[15, 0].GetComponent<Renderer>().material.color = Color.black;
        }
    }
    public void Fly(int x, int y)
    {
		// moves the airplane up 
        if (GameController.up == true && y < 8 && airplane.active)
        {
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
            airplane.x = x;
            airplane.y = y + 1;
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			GameController.up = false;
        }
		// moves the airplane down
		if (GameController.down == true && y > 0 && airplane.active)
        {
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			airplane.x = x;
            airplane.y = y - 1;
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			GameController.down = false;

        }
		// moves the airplane left
		if (GameController.left == true && x < 15 && airplane.active)
        {
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
            airplane.x = x - 1;
            airplane.y = y;
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			GameController.left = false;
        }
		// moves the airplane right
		if (GameController.right == true && x >= 0 && airplane.active)
        {
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
            airplane.x = x + 1;
            airplane.y = y;
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			GameController.right = false;
        }
    }
}
