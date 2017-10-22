//idle状态被细化为：lookUp、normal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : AnimationParent
{
    public override void play()
    {
        CurrentTime = Time.time;

        if (CurrentTime - ScheduleUpdate > DeltaTime)
        {
            ScheduleUpdate = Time.time;

            this.GetComponent<SpriteRenderer>().sprite = AnimationFrames[FramesIdx];

            FramesIdx = FramesIdx < AnimationFrames.Count - 1 ? ++FramesIdx : FramesIdx = RepeatIdx;
        }

    }

    // Use this for initialization 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
