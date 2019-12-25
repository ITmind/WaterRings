using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Spawner Spawner1;
    public Spawner Spawner2;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Spawner1.Spawn();
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            Spawner2.Spawn();
        }
	}
}
