using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CharacterControl();  //每帧都调用会不会有性能问题(考虑事件驱动？)
    }

    void CharacterControl()
    {
        if ((!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            Character.getInstance().CharacStatus = Character.Status.idle;

            if (Character.getInstance().downBody.transform.rotation.y == 0) //0：左；非0：右
                Character.getInstance().CharacDirection = Character.Direction.lookLeft;
            else
                Character.getInstance().CharacDirection = Character.Direction.lookRight;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Character.getInstance().CharacStatus = Character.Status.move;
            Character.getInstance().CharacDirection = Character.Direction.lookLeft;
            Character.getInstance().move("stand_MoveLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Character.getInstance().CharacStatus = Character.Status.move;
            Character.getInstance().CharacDirection = Character.Direction.lookRight;
            Character.getInstance().move("stand_MoveRight");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Character.getInstance().CharacDirection = Character.Direction.lookUp;
        }
        else if (Input.GetKey(KeyCode.S)) //下蹲与lookDown两个功能
        {
            if (Character.getInstance().CharacStatus != Character.Status.jump)
            {
                Character.getInstance().CharacDirection = Character.Direction.squat;
            }
            else
            {

            }
        }
    }
}
