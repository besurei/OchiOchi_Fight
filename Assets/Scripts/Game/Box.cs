using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    private bool bFall = false;

    void Update()
    {

    }

    public void OnTriggerEnter( Collider in_Col)
    {
        if (in_Col.gameObject.tag == "Atack")
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", ColorDefine.COLOR_PINK );
            this.StartCoroutine( Fall() );
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);

        this.GetComponent<MeshRenderer>().enabled = false;
        Vector3 oldPos = this.transform.position;
        this.transform.position = new Vector3(0, 0, 0);
        this.GetComponent<Renderer>().material.SetColor("_Color", ColorDefine.COLOR_WHITE);

        yield return new WaitForSeconds(1.5f);

        this.GetComponent<MeshRenderer>().enabled = true;
        this.transform.position = oldPos;
        this.GetComponent<Renderer>().material.SetColor("_Color", ColorDefine.COLOR_WHITE);
    }
}
