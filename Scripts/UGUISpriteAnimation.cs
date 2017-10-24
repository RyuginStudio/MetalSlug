﻿//用法：将代码加载到Image物体上，将需要播放的图片动画每一帧放到SpriteFrame数组中，就可以进行播放了
//来源：http://blog.csdn.net/beihuanlihe130/article/details/54289036
//修改：vszed

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Image))]
public class UGUISpriteAnimation : MonoBehaviour
{
    //private Image ImageSource;
    private int mCurFrame = 0;
    private float mDelta = 0;

    public float FPS = 5;
    public List<Sprite> SpriteFrames;
    public bool IsPlaying = false;
    public bool Foward = true;
    public bool AutoPlay = false;
    public bool Loop = false;

    public int FrameCount
    {
        get
        {
            return SpriteFrames.Count;
        }
    }

    void Awake()
    {
        //ImageSource = GetComponent<Image>();
    }

    void Start()
    {
        if (AutoPlay)
        {
            Play();
        }
        else
        {
            IsPlaying = false;
        }
    }

    private void SetSprite(int idx)
    {
        this.GetComponent<SpriteRenderer>().sprite = SpriteFrames[idx];
        //ImageSource.sprite = SpriteFrames[idx];  //=>网络版本的错误
        //该部分为设置成原始图片大小，如果只需要显示Image设定好的图片大小，注释掉该行即可。
        //ImageSource.SetNativeSize();
    }

    public void Play()
    {
        IsPlaying = true;
        Foward = true;
    }

    public void PlayReverse()
    {
        IsPlaying = true;
        Foward = false;
    }

    void Update()
    {
        if (!IsPlaying || 0 == FrameCount || FrameCount == mCurFrame)  //修改：播完动画后销毁
        {
            Character.getInstance().CharacAttackMode = Character.AttackMode.disAttack;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("ShotGunBullet")); //这里需要修改 子弹不该在此销毁
            Debug.Log("destory");
            return;
        }

        mDelta += Time.deltaTime;
        if (mDelta > 1 / FPS)
        {
            mDelta = 0;
            if(Foward)
            {
                mCurFrame++;
            }
            else
            {
                mCurFrame--;
            }

            if (mCurFrame >= FrameCount)
            {
                if (Loop)
                {
                    mCurFrame = 0;
                }
                else
                {
                    IsPlaying = false;
                    return;
                }
            }
            else if (mCurFrame<0)
            {
                if (Loop)
                {
                    mCurFrame = FrameCount-1;
                }
                else
                {
                    IsPlaying = false;
                    return;
                }          
            }

            SetSprite(mCurFrame);
        }
    }

    public void Pause()
    {
        IsPlaying = false;
    }

    public void Resume()
    {
        if (!IsPlaying)
        {
            IsPlaying = true;
        }
    }

    public void Stop()
    {
        mCurFrame = 0;
        SetSprite(mCurFrame);
        IsPlaying = false;
    }

    public void Rewind()
    {
        mCurFrame = 0;
        SetSprite(mCurFrame);
        Play();
    }
}