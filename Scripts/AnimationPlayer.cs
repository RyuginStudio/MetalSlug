/*
*特别注意：
*如果是attack的帧动画集合，一定要多放一帧 => 例如：如果动画由6张图片组成，则AnimationFrames的size要弄成7帧，第七帧依然存放第六张图片!
*不然，显示完最后一张图片后，不会等待delta time，因为状态直接改变了，最后一张图片立刻被改变状态后的动画第一帧给顶替掉了，故最后一帧看不到!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public List<Sprite> AnimationFrames;
    public int FramesIdx;
    public int RepeatIdx;  //二次循环起始图
    public float ScheduleUpdate;
    public float CurrentTime;
    public float DeltaTime;
    public bool autoPlay;
    public bool attackAnimation;
    public string Tag;  //区分多个脚本

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (autoPlay == true)
        {
            play();
        }
    }

    public void play()
    {
        CurrentTime = Time.time;

        if (CurrentTime - ScheduleUpdate > DeltaTime)
        {
            ScheduleUpdate = Time.time;

            this.GetComponent<SpriteRenderer>().sprite = AnimationFrames[FramesIdx];

            if (FramesIdx < AnimationFrames.Count - 1)
            {
                ++FramesIdx;
            }
            else
            {
                if (attackAnimation == true)
                {
                    this.autoPlay = false;
                    Attack.changeAttackMode();
                }

                FramesIdx = RepeatIdx;
            }
        }

    }

}
