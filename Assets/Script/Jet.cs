using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    private GameObject Player;//プレイヤー

    private Vector2 PlayerPos;
    private Vector2 JetPos;
    private Vector2 MoveVec;
    public bool RockMove;

    float gosa = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = transform.root.gameObject;//プレイヤーを捜査
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (RockMove)
        {
            PlayerPos = Player.transform.position;
            JetPos = this.transform.position;

            MoveVec = PlayerPos - JetPos;

            Player.GetComponent<Rigidbody>().AddForce(MoveVec * 6);


            //Debug.Log(MoveVec);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!Player.GetComponent<Player>().NowRotation)
        {
            if (collision.gameObject.tag == "Cap")
            {
                if (!collision.GetComponent<CapMove>().StickFlag)
                {
                    if (Player.transform.localEulerAngles.z >= 360 - gosa && Player.transform.localEulerAngles.z <= 0 + gosa ||
                                Player.transform.localEulerAngles.z >= 90 - gosa && Player.transform.localEulerAngles.z <= 90 + gosa ||
                                Player.transform.localEulerAngles.z >= 180 - gosa && Player.transform.localEulerAngles.z <= 180 + gosa ||
                                  Player.transform.localEulerAngles.z >= 270 - gosa && Player.transform.localEulerAngles.z <= 270 + gosa)
                    {       //プレイヤーが正方形のような状態なら
                        RockMove = false;
                    }
                    else if (Player.transform.localEulerAngles.z >= 45 - gosa && Player.transform.localEulerAngles.z <= 45 + gosa ||
                                   Player.transform.localEulerAngles.z >= 135 - gosa && Player.transform.localEulerAngles.z <= 135 + gosa ||
                                   Player.transform.localEulerAngles.z >= 225 - gosa && Player.transform.localEulerAngles.z <= 225 + gosa ||
                                      Player.transform.localEulerAngles.z >= 315 - gosa && Player.transform.localEulerAngles.z <= 315 + gosa)
                    {       //プレイヤーがひし形のような状態なら
                        if (collision.transform.rotation.z != 0)    //傾いているなら
                        {
                            RockMove = false;
                        }
                    }
                }
            }
        }
    }
}

