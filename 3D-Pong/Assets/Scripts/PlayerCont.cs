using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerCont : NetworkBehaviour {

    public int score;
    public float speed;

    public Scene scene;
    private NetworkStartPosition[] spawnPoints;

    private Rigidbody rb;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Main_Scene" && isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
        if (scene.name == "Main_Scene")
        {
            rb = GetComponent<Rigidbody>();

        }
        else if (scene.name == "3D-Pong")  //correct syntax!!!
        {
            score = 0;
        }
        // adding other scene score control
    }

    void FixedUpdate()
    {
        if (scene.name == "Main_Scene")
        {
           
        }
        if (scene.name == "Lobby")
        {

        }
    }




}
