﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletSpeed;
    public float BulletShootDistance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //子弹位置、朝向修正
        switch (Character.getInstance().CharacDirection)
        {
            case Character.Direction.lookLeft:
                {
                    float step = BulletSpeed * Time.deltaTime;
                    this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x - BulletShootDistance, this.transform.position.y, 0), step);
                    break;
                }

            case Character.Direction.lookRight:
                {
                    float step = BulletSpeed * Time.deltaTime;
                    this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x + BulletShootDistance, this.transform.position.y, 0), step);
                    break;
                }

            case Character.Direction.lookUp:
                {
                    float step = BulletSpeed * Time.deltaTime;
                    this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x, this.transform.position.y + BulletShootDistance, 0), step);
                    break;
                }
            case Character.Direction.lookDown:
                {
                    break;
                }

            case Character.Direction.squat:
                {
                    if (Character.getInstance().downBody.transform.rotation.y != 0) //0：左；非0：右
                    {
                        float step = BulletSpeed * Time.deltaTime;
                        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x + BulletShootDistance, this.transform.position.y, 0), step);

                    }
                    else
                    {
                        float step = BulletSpeed * Time.deltaTime;
                        this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, new Vector3(this.transform.position.x - BulletShootDistance, this.transform.position.y, 0), step);
                    }
                    break;
                }

        }
    }
}