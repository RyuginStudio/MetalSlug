using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻击是瞬发的事情

public class Attack : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Character.getInstance().CharacAttackMode == Character.AttackMode.disAttack)
        {
            //这里需要判断具体的攻击模式：砍|射击(需要改进)
            Character.getInstance().CharacAttackMode = Character.AttackMode.shoot;
            Character.getInstance().shoot();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Character.getInstance().CharacDirection = Character.Direction.lookUp;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            Character.getInstance().CharacDirection = Character.Direction.squat;
        }

    }
}
