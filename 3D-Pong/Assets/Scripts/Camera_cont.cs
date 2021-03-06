﻿using UnityEngine;
using System.Collections;

public class Camera_cont : MonoBehaviour
{

    public GameObject player;
    public float angle;
    public float speed;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
