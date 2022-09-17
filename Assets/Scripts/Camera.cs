using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject cam;
    private GameObject player;
    private Vector3 player_position;
    public float camera_y = 3.0f;
    public float camera_z = -12.0f;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        player_position = player.transform.position;
        player_position.y += camera_y;
        player_position.z += camera_z;
        cam.transform.position = player_position;
    }
}
