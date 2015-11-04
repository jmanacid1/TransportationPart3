using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public static void FlyDirection() { 
        if (Input.GetKeyDown("up")) {
			GameController.up = true;
			GameController.down = false;
			GameController.left = false;
			GameController.right = false;
        }
        if (Input.GetKeyDown("down")) {
			GameController.up = false;
			GameController.down = true;
			GameController.left = false;
			GameController.right = false;
            
        }
        if (Input.GetKeyDown("left")) {
			GameController.up = false;
			GameController.down = false;
			GameController.left = true;
			GameController.right = false;
           
        }
        if (Input.GetKeyDown("right")) {
			GameController.up = false;
			GameController.down = false;
			GameController.left = false;
			GameController.right = true;
        }      
    }
}
 

   