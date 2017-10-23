using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            Character.getInstance().CharacStatus = Character.Status.idle;
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Character.getInstance().CharacStatus = Character.Status.move;
            Character.getInstance().move("MoveLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Character.getInstance().CharacStatus = Character.Status.move;
            Character.getInstance().move("MoveRight");
        }

    }
}
