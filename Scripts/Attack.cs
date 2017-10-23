using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
			Debug.Log("attack~");
			Character.getInstance().CharacStatus = Character.Status.attack;
			Character.getInstance().shoot();
        }
    }
}
