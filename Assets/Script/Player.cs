using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの回転方向
public enum ROLLDIREC
{
    STOP,//停止
    RIGHT,//右回転
    LEFT//左回転
}

public class Player : MonoBehaviour
{
 

    //+++++++
    //変数
    //+++++++
    private ROLLDIREC RollDirec;//プレイヤーの回転方向

    private float SpinCnt;//回転量
    private float Spin = 5.0f;//一フレームの回転角度
    private float SpinMax = 90.0f;//最大回転量

    private Vector3 StopVec;//回転停止ベクトル

    public bool NowRotation = false; // true:回転中　false:回転してない

    // Start is called before the first frame update
    void Start()
    {
        RollDirec = ROLLDIREC.STOP;
        SpinCnt = 0;

        StopVec.x = 0;
        StopVec.y = 0;
        StopVec.z = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(("d")))
        {
           if(RollDirec== ROLLDIREC.STOP)
           {
                SpinCnt = 0;
                RollDirec = ROLLDIREC.RIGHT;

            }
        }
        else if (Input.GetKey(("a")))
        {
            if (RollDirec == ROLLDIREC.STOP)
            {
                SpinCnt = 0;
                RollDirec = ROLLDIREC.LEFT;
            }
        }

        if (RollDirec == ROLLDIREC.STOP)
        {
            NowRotation = false;
        }
        else
        {
            NowRotation = true;

        }
        PlayerRoll();
    }

    //プレイヤーを回転させる関数
    void PlayerRoll()
    {
        if(RollDirec== ROLLDIREC.RIGHT)
        {
            SpinCnt += Spin;
            transform.Rotate(0, 0, -Spin);
            this.GetComponent<Rigidbody>().angularVelocity = (StopVec);

            //回転終了
            if (SpinCnt>=SpinMax)
            {
                SpinCnt = 0;
                RollDirec = ROLLDIREC.STOP;
            }
        }
        else if (RollDirec == ROLLDIREC.LEFT)
        {
            this.GetComponent<Rigidbody>().angularVelocity = (StopVec);

            SpinCnt += Spin;
            transform.Rotate(0, 0, Spin);

            //回転終了
            if (SpinCnt >= SpinMax)
            {
                SpinCnt = 0;
                RollDirec = ROLLDIREC.STOP;
            }
        }
    }

    //速度修正
    void VecFix()
    {

    }
}
