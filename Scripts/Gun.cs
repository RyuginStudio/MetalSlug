using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun
{
    public enum gunKind
    {
        handGun,
        shotGun,
    }

    public static gunKind holdGun = gunKind.shotGun;  //当前持枪	
    public int bombCapacity;    //弹容
    public float fireCodeTime;  //射击冷却时间
    public int damageValue;     //伤害值
    public GameObject bulletPrefab;	 //子弹预制件


    abstract public void init();  //枪支初始化
    abstract public void bulletTraject();  //弹道函数
    abstract public void bulletRemove();   //子弹回收

}
