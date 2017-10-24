using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float currentTime;
    public float coldTimeUpdate;

    void Awake()
    {

    }

    void Update()
    {

    }

    public enum gunKind
    {
        handGun,
        shotGun,
    }

    public static gunKind holdGun = gunKind.shotGun;  //当前持枪
    public bool admitShoot;
    public int bombCapacity;    //弹容
    public float fireColdTime;  //射击冷却时间
    public float bulletDestoryTime; //子弹销毁时间
    public int damageValue;     //伤害值
    public GameObject bulletPrefab;	 //子弹预制件


    public void bulletTraject()  //弹道函数
    {

    }
    public void bulletDestory()   //子弹回收
    {

    }

}
