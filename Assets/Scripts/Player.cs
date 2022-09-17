using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    private float up_force = 300f;
    private bool is_ground = false;
    private bool is_walking = false;
    private bool is_attacking = false;
    /* private GameObject cam; */
    private Rigidbody rb;
    private Animator anim;

    /* private Vector3 camera_forward; */
    private Vector3 move_forward;
    private float input_horizontal;
    private float input_vertical;
    private Vector3 position_diff;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        /* cam = GameObject.FindGameObjectWithTag("MainCamera"); */
    }

    void Update()
    {

        is_walking = false;
        is_attacking = false;
        input_vertical = 0.0f;
        input_horizontal = 0.0f;
        /* camera_forward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized; */

        if (Input.GetKey("w"))
        {
            is_walking = true;
            input_vertical = 1.0f;
        }
        if (Input.GetKey("s"))
        {
            is_walking = true;
            input_vertical = -1.0f;
        }
        if (Input.GetKey("d"))
        {
            is_walking = true;
            input_horizontal = 1.0f;
        }
        if (Input.GetKey("a"))
        {
            is_walking = true;
            input_horizontal = -1.0f;
        }

        if (is_walking)
        {
            move_forward = Vector3.forward * input_vertical + Vector3.right * input_horizontal;
            position_diff = move_forward * speed * Time.deltaTime;
            transform.position += position_diff;
            transform.rotation = Quaternion.LookRotation(position_diff);
        }

        if (Input.GetKey("j"))
        {
            is_attacking = true;
        }

        if (is_ground == true)
        {
            if (Input.GetKey("space"))
            {
                is_ground = false;
                is_walking = false;
                rb.AddForce(new Vector3(0, up_force, 0));
            }
        }
        else
        {
            is_walking = false;
        }

        anim.SetBool("is_walking", is_walking);
        anim.SetBool("is_ground", is_ground);
        anim.SetBool("is_attacking", is_attacking);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Ground")
        {
            is_ground = true;
        }
    }

}
