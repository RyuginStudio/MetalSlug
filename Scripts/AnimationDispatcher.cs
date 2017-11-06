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
                    switch (Character.getInstance().CharacDirection)
                    {
                        case Character.Direction.lookUp:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_LookUp")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookDown:
                            {
                                break;
                            }
                        case Character.Direction.squat:
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                Character.getInstance().squat();

                                break;
                            }
                        default: //idle + normal
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                Character.getInstance().restore();

                                break;
                            }
                    }

                    break;
                }
            case Character.Status.move:
                {
                    switch (Character.getInstance().CharacDirection)
                    {
                        case Character.Direction.lookUp:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_LookUp")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookDown:
                            {
                                break;
                            }
                        case Character.Direction.lookLeft:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookRight:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.squat:
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Squat")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                Character.getInstance().squat();

                                break;
                            }
                        default: //idle + normal
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                        item.autoPlay = false;
                                    }
                                }

                                Character.getInstance().restore();

                                break;
                            }
                    }

                    break;
                }
            case Character.Status.idleAttack:
                {
                    switch (Character.getInstance().CharacDirection)
                    {
                        case Character.Direction.lookUp:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_LookUp")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_Normal" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }
                                        }
                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;
                                        if (item.Tag != "UB_Attack_ShotGun_LookNormal")
                                        {
                                            item.FramesIdx = 0;
                                        }
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookDown:
                            {
                                break;
                            }
                        case Character.Direction.squat:
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_Normal")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_LookUp" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }
                                        }
                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;

                                        if (item.Tag != "UB_Attack_ShotGun_LookUp")
                                        {
                                            item.FramesIdx = 0;
                                        }

                                    }
                                }

                                Character.getInstance().squat();

                                break;
                            }
                        default: //idle + normal
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_Normal")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_LookUp" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }

                                        }

                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;

                                        if (item.Tag != "UB_Attack_ShotGun_LookUp")
                                        {
                                            item.FramesIdx = 0;
                                        }
                                    }
                                }

                                Character.getInstance().restore();

                                break;
                            }

                    }
                    break;
                }
            case Character.Status.moveAttack:
                {
                    switch (Character.getInstance().CharacDirection)
                    {
                        case Character.Direction.lookUp:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_LookUp")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_Normal" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }
                                        }
                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;
                                        if (item.Tag != "UB_Attack_ShotGun_LookNormal")
                                        {
                                            item.FramesIdx = 0;
                                        }
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookDown:
                            {
                                break;
                            }
                        case Character.Direction.lookLeft:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_Normal")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_LookUp" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }

                                        }

                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;

                                        if (item.Tag != "UB_Attack_ShotGun_LookUp")
                                        {
                                            item.FramesIdx = 0;
                                        }
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.lookRight:
                            {
                                //动画
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_Normal")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_LookUp" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }

                                        }

                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;

                                        if (item.Tag != "UB_Attack_ShotGun_LookUp")
                                        {
                                            item.FramesIdx = 0;
                                        }
                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                    }
                                }

                                //逻辑
                                Character.getInstance().restore();

                                break;
                            }
                        case Character.Direction.squat:
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Attack_ShotGun_Normal")
                                    {
                                        //动画平稳过渡
                                        foreach (var t in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                        {
                                            if (t.Tag == "UB_Attack_ShotGun_LookUp" && t.FramesIdx != 0)
                                            {
                                                item.FramesIdx = t.FramesIdx;
                                                t.FramesIdx = 0; //清空值，否则动画卡死
                                            }
                                        }
                                        item.autoPlay = true;
                                    }
                                    else
                                    {
                                        item.autoPlay = false;

                                        if (item.Tag != "UB_Attack_ShotGun_LookUp")
                                        {
                                            item.FramesIdx = 0;
                                        }

                                    }
                                }

                                foreach (var item in Character.getInstance().downBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "DB_Move_Squat")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                    }
                                }

                                Character.getInstance().squat();

                                break;
                            }
                        default: //idle + normal
                            {
                                foreach (var item in Character.getInstance().upBody.GetComponents<AnimationPlayer>())
                                {
                                    if (item.Tag == "UB_Idle_Normal")
                                    {
                                        item.play();
                                    }
                                    else
                                    {
                                        item.FramesIdx = 0;
                                    }
                                }

                                Character.getInstance().restore();

                                break;
                            }
                    }

                    break;
                }





        }
    }
}