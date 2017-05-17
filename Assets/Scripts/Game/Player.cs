using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class Player : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject prefAtack;

    private InputDevice joystick;
    private bool bOnPlayArea = false;
    private bool bFall = false;

    // Use this for initialization
    void Awake () {

        joystick = InputManager.Devices[0];

	}
	
	// Update is called once per frame
	void Update () {

        Move();
        Atack();
        //Jump();
    }

    void Move()
    {
        //transform.position += new Vector3(joystick.LeftStickX, 0, joystick.LeftStickY) * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(joystick.DPadX, 0, joystick.DPadY) * moveSpeed * Time.deltaTime;
        if (joystick.DPad)
        {
            transform.rotation = Quaternion.LookRotation(transform.position +
                (Vector3.right * joystick.DPadX) +
                (Vector3.forward * joystick.DPadY)
                - transform.position);

            // 走るモーション再生
            animator.SetBool("bool_Run", true);

        }
        else
        {   // 走るモーション停止
            animator.SetBool("bool_Run", false);
        }
    }

    void Jump()
    {
        if( Input.GetButtonDown("Jump") )
        {
            animator.SetTrigger("trigger_Jump");
        }
    }

    void Atack()
    {
        if( Input.GetButtonDown("Jump"))
        {
            GameObject atack = Instantiate(prefAtack, this.transform.FindChild("SponePos").position, Quaternion.identity);
            atack.GetComponent<Atack>().Init(this.transform.rotation);
        }
    }

    public void Fall()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
