using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;

    void Awake()
    {
        instance = this;
    }

    public static GameData getInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Effect数据
    public AudioClip Effect_shotGun;

    //预制件数据
    public GameObject Prefab_bulletPrefab;

    //角色数值
    public static float normalSpeed = 4.0f;
    public static float squatSpeed = 1.5f;
}
