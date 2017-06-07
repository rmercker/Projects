using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {

    public GameObject planetsSun;
    public int degreeOfRotationAroundSun;
    public int degreeOfRotationAroundSelf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(planetsSun.transform.position, Vector3.up, Time.deltaTime * degreeOfRotationAroundSun);
        transform.Rotate(Vector3.up * Time.deltaTime * degreeOfRotationAroundSelf);

	}
}
