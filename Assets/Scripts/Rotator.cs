using UnityEngine;
using System.Collections;
using System;

public class Rotator : MonoBehaviour {

    public int rotSpeedMultiplier = -30;
    public int interval = 2;
    public int rotSpeed = 0;
    private bool shouldUpdateSpeed;

    public GameObject Blade;

	// Use this for initialization
	void Start () {
        shouldUpdateSpeed = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Blade.activeSelf) {
            if ((int)(Time.time) % interval == 0)
            {
                if (shouldUpdateSpeed)
                {
                    shouldUpdateSpeed = false;
                    int rand = UnityEngine.Random.Range(0, 6);
                    Debug.Log("Random number: " + rand);
                    switch (rand)
                    {
                        case 0:
                            if (transform.rotation.eulerAngles.y < 210)
                            {
                                rotSpeed = 1;
                            } else
                            {
                                rotSpeed = -1;
                            }
                            break;
                        case 1:
                            if (transform.rotation.eulerAngles.y > 0)
                            {
                                rotSpeed = -1;
                            } else
                            {
                                rotSpeed = 1;
                            }
                            break;
                        default:
                            rotSpeed = 0;
                            break;
                    }
                }
            }
            else
            {
                shouldUpdateSpeed = true;
            }
            transform.Rotate(new Vector3(0, rotSpeed * rotSpeedMultiplier, 0) * Time.deltaTime);
        }
	}
}
