using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	GameObject[,] allCubes = new GameObject[16,9];
	// the x and y values for the cube
	public int x;
	public int y;
	
	GameController aGameController;
	// Use this for initialization
	void Start () {
		aGameController = GameObject.Find ("GameControllerObject").GetComponent <GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnMouseDown()
    {
        aGameController.ProcessClickedCube(this.gameObject, x, y);
    }
}


