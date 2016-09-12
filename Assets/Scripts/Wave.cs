using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    public float amplitudeY;
    public  float omegaY;
    public float index;
    public int interval = 2;
    public int velocity = 0;
    private bool shouldUpdateSpeed;

    public GameObject Blade;
    // Use this for initialization
    void Start()
    {
        shouldUpdateSpeed = true;
    }

    public void Update()
    {
        if (Blade.activeSelf)
        {
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
                            velocity = 1;
                            break;
                        case 1:
                            velocity = -1;
                            break;
                        default:
                            velocity = 0;
                            break;
                    }
                }
            }
            else
            {
                shouldUpdateSpeed = true;
            }
            index += velocity * Time.deltaTime;
            float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
            transform.localPosition = new Vector3(0, y, 0);
        }
    }
}
