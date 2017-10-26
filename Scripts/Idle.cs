//idle状态被细化为：lookUp、normal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
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
            if (Character.getInstance().CharacAttackMode == Character.AttackMode.disAttack)
            {
                Character.getInstance().CharacStatus = Character.Status.idle;
            }

        }

        if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            if (Character.getInstance().downBody.transform.rotation.y != 0) //0：左；非0：右
            {
                Character.getInstance().CharacDirection = Character.Direction.lookRight;
            }
            else
            {
                Character.getInstance().CharacDirection = Character.Direction.lookLeft;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            Character.getInstance().CharacDirection = Character.Direction.lookUp;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Character.getInstance().CharacDirection = Character.Direction.squat;
        }
    }

}
