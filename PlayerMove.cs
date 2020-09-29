using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movPow = 1000;

    Rigidbody rb_;
    Animator anim_;

    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        anim_ = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var mov = Input.GetAxis("Horizontal");
        bool atk = Input.GetKeyDown(KeyCode.Z);
        if (mov != 0)
        {
            if (mov > 0)
                transform.eulerAngles = new Vector3(0, 90, 0);
            else
                transform.eulerAngles = new Vector3(0, -90, 0);

            mov *= movPow;
            rb_.AddForce(new Vector3(mov, 0, 0), ForceMode.Acceleration);
        }

        anim_.SetBool("Run", mov != 0);
        anim_.SetBool("Attack", atk);
    }
}
