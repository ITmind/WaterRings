using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //transform.rotation = Quaternion.Euler(Physics.gravity);
        //GUITextPlane.text = Input.acceleration.ToString();
        if (SystemInfo.supportsGyroscope)
        {
            Physics.gravity = new Vector3(Input.acceleration.x*9.81f,Input.acceleration.y*9.81f,-Input.acceleration.z*9.81f);
        }
	}
}
