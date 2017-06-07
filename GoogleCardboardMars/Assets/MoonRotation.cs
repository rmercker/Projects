using UnityEngine;
using System.Collections;

public class MoonRotation : MonoBehaviour {

    public GameObject MoonsPlanet;
    public int degreeOfRotationAroundPlanet;
    public int degreeOfRotationAroundSelf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.RotateAround(MoonsPlanet.transform.position, Vector3.up, Time.deltaTime * degreeOfRotationAroundPlanet);
        transform.Rotate(Vector3.up * Time.deltaTime * degreeOfRotationAroundSelf);

	}
}
