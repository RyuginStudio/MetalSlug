using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDispatcher : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dispatchAnimation();
    }


    //根据角色状态派遣动画
    void dispatchAnimation()
    {
        switch (Character.getInstance().CharacStatus)
        {
            case Character.Status.idle:
                {
                    //上半身
                    if (Character.getInstance().CharacDirection != Character.Direction.lookUp && Character.getInstance().CharacDirection != Character.Direction.lookDown)
                    {
                        foreach (var item in Character.getInstance().upBody.GetComponents<IdleAnimation>())
                        {
                            if (item.Tag == "normal")
                            {
                                item.play();
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }
                    else if (Character.getInstance().CharacDirection == Character.Direction.lookUp)
                    {
                        foreach (var item in Character.getInstance().upBody.GetComponents<IdleAnimation>())
                        {
                            if (item.Tag == "lookUp")
                            {
                                item.play();
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }

                    //下半身
                    Character.getInstance().restore();

                    if (Character.getInstance().CharacDirection == Character.Direction.squat)
                    {
                        Character.getInstance().squat();
                    }

                    break;
                }

            case Character.Status.move:
                {
                    //上半身
                    if (Character.getInstance().CharacDirection != Character.Direction.lookUp && Character.getInstance().CharacDirection != Character.Direction.lookDown)
                    {
                        //位置修正
                        if (Character.getInstance().upBody.transform.position.y - Character.getInstance().downBody.transform.position.y < 0.6f)  //=>说明曾处于squat状态
                        {
                            var pos = Character.getInstance().upBody.transform.position;
                            Character.getInstance().upBody.transform.position = new Vector3(pos.x, pos.y + 0.213f, pos.z);
                        }

                        foreach (var item in Character.getInstance().upBody.GetComponents<IdleAnimation>())
                        {
                            if (item.Tag == "normal")
                            {
                                item.play();
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }
                    else if (Character.getInstance().CharacDirection == Character.Direction.lookUp)
                    {
                        //位置修正
                        if (Character.getInstance().upBody.transform.position.y - Character.getInstance().downBody.transform.position.y < 0.6f)  //=>说明曾处于squat状态
                        {
                            var pos = Character.getInstance().upBody.transform.position;
                            Character.getInstance().upBody.transform.position = new Vector3(pos.x, pos.y + 0.213f, pos.z);
                        }

                        foreach (var item in Character.getInstance().upBody.GetComponents<IdleAnimation>())
                        {
                            if (item.Tag == "lookUp")
                            {
                                item.play();
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }

                    //下半身

                    if (Character.getInstance().CharacDirection == Character.Direction.lookLeft || Character.getInstance().CharacDirection == Character.Direction.lookRight || Character.getInstance().CharacDirection == Character.Direction.lookUp)
                    {
                        foreach (var item in Character.getInstance().downBody.GetComponents<MoveAnimation>())
                        {
                            if (item.Tag == "normal")
                            {
                                item.play();
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }
                    else if (Character.getInstance().CharacDirection == Character.Direction.squat)
                    {
                        foreach (var item in Character.getInstance().downBody.GetComponents<MoveAnimation>())
                        {
                            if (item.Tag == "squat")
                            {
                                item.play();
                                Character.getInstance().upBody.transform.position = new Vector3(Character.getInstance().upBody.transform.position.x, Character.getInstance().upBodyPos.y - 0.213f, Character.getInstance().upBody.transform.position.z);
                            }
                            else
                            {
                                item.FramesIdx = 0;
                            }
                        }
                    }

                    break;
                }
            case Character.Status.attack:
                {
                    break;
                }
        }
    }
}
