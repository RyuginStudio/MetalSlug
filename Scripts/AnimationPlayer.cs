﻿//其子类都是动画相关，动画与逻辑要分开处理

using System.Collections;
using System.Collections.Generic;
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
                autoPlay = false;
                FramesIdx = RepeatIdx;
            }           
        }

    }

}
