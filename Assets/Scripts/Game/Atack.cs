using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Quaternion moveVec;

	public void Init( Quaternion in_Vec )
    {
        transform.rotation = in_Vec;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * speed * Time.deltaTime;

    }
}
