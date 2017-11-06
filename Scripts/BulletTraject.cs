/*
**时间：2017年11月06日14:50:45
**作者：vszed
**功能：目前能够实现一般子弹的运动轨迹（后续追加追踪导弹运动轨迹）
**使用方法：挂载到任意子弹预制件中，子弹速度和运行距离在面板中设定好
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTraject : MonoBehaviour
{
    public float BulletSpeed;
    public float BulletShootDistance;
    public Character.Direction BulletDirection; //由具体的枪传进来


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //子弹位置、轨迹更新
        switch (BulletDirection)
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
        }
    }
}
