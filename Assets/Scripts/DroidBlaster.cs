using UnityEngine;
using System.Collections;

public class DroidBlaster : MonoBehaviour {

    public GameObject blastPrefab;
    public GameObject target; //thing to look at
    public float force = 2000.0f;

    public GameObject Blade;

    // Use this for initialization
    void Start () {
        StartCoroutine(FireTimer());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public IEnumerator FireTimer()
    {

        while (true){ 
            Fire();
            yield return new WaitForSeconds(3f); //waits three seconds
        }

    }

    public void Fire()
    {
        if (Blade.activeSelf)
        {
            transform.LookAt(target.transform.position); //change transform to look at player
                                                         //Instantiate(prefab, vector(should represent current position), vector(pointed at player))
            GameObject blast = (GameObject)Instantiate(blastPrefab,
                                                   transform.position,
                                                   transform.rotation);
            blast.transform.LookAt(target.transform.position);

            // Based on a stack overflow question
            // http://answers.unity3d.com/comments/946790/view.html
            //Quaternion q = blast.transform.rotation;
            //q.eulerAngles = new Vector3(0f, transform.rotation.eulerAngles.y, 0f);
            //blast.transform.rotation = q;


            blast.GetComponent<Rigidbody>().AddForce(target.transform.position - blast.transform.position);

        }
    }
}

