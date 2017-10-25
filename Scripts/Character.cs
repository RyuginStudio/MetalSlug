using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private static Character CharacInstance;

    public GameObject upBody;
    public GameObject downBody;
    public GameObject wholeBody;

    //数据
    public Vector3 upBodyPos;
    public float characSpeed;

    public enum Status  //状态
    {
        idle,
        move,
        jump
    }

    public enum Direction  //方向
    {
        lookLeft,
        lookRight,
        lookUp,
        lookDown,
        squat
    }

    public enum AttackMode //攻击模式
    {
        cut,
        shoot,
        grenade,
        disAttack
    }

    public Status CharacStatus;
    public Direction CharacDirection;
    public AttackMode CharacAttackMode;

    void Awake()
    {
        CharacInstance = this;
    }

    // Use this for initialization
    void Start()
    {
        characInit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Character getInstance()
    {
        return CharacInstance;
    }

    public void characInit()
    {
        CharacStatus = Status.idle;
        characSpeed = GameData.normalSpeed;
        CharacDirection = Direction.lookRight;
        CharacAttackMode = AttackMode.disAttack;

        upBodyPos = upBody.transform.position;
    }

    public void move(string moveStatus)  //角色移动
    {
        switch (moveStatus)
        {
            case "MoveLeft":
                {
                    if (downBody.transform.rotation.y != 0) //0：左；非0：右
                    {
                        upBody.transform.RotateAround(downBody.transform.position, Vector3.up, 180);  //锚点不是(0.5,0.5) 
                        downBody.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                    characSpeed = CharacDirection == Direction.squat ? GameData.squatSpeed : GameData.normalSpeed;
                    wholeBody.transform.Translate(Vector3.left * Time.deltaTime * characSpeed);

                    break;
                }

            case "MoveRight":
                {
                    if (downBody.transform.rotation.y == 0) //0：左；非0：右
                    {
                        upBody.transform.RotateAround(downBody.transform.position, Vector3.up, 180);
                        downBody.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    characSpeed = CharacDirection == Direction.squat ? GameData.squatSpeed : GameData.normalSpeed;
                    wholeBody.transform.Translate(Vector3.right * Time.deltaTime * characSpeed);

                    break;
                }
        }

    }

    public void squat()
    {
        if (CharacStatus == Status.idle)
        {
            var texture = (Texture2D)Resources.Load("Pictures/Character/downBody/squat/squat0");
            var sprite = Sprite.Create(texture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
            downBody.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        upBody.transform.position = new Vector3(upBody.transform.position.x, upBodyPos.y - 0.213f, upBody.transform.position.z);
    }

    //角色复原
    public void restore()
    {
        //上半身
        if (upBody.transform.position.y - downBody.transform.position.y < 0.6f)  //=>说明曾处于squat状态
        {
            var pos = upBody.transform.position;
            upBody.transform.position = new Vector3(pos.x, pos.y + 0.213f, pos.z);
        }

        //下半身
        if (CharacStatus == Status.idle)
        {
            var texture = (Texture2D)Resources.Load("Pictures/Character/downBody/normal/stand0");
            var sprite_downBody = Sprite.Create(texture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
            downBody.GetComponent<SpriteRenderer>().sprite = sprite_downBody;
        }

    }

    public void shoot()  //射击
    {
        //用什么枪 => 枪类（射击频率，装弹CD，动画等）近距离用刀

        //根据枪种类产生子弹（碰撞，位置，动画，轨迹，子弹伤害）

        switch (Gun.holdGun)
        {
            case Gun.gunKind.handGun:
                {
                    //Debug.Log("handGun");
                    break;
                }
            case Gun.gunKind.shotGun:
                {
                    //Debug.Log("shotGun");
                    GameObject.Find("SoundControler").GetComponent<AudioSource>().
                    PlayOneShot(GameData.getInstance().Effect_shotGun);

                    ShotGun.getInstance().bulletTraject();

                    break;
                }
        }
    }

    public void cut()  //砍
    {
        //近身武器

    }

}

