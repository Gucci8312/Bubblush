using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] objTarget = new GameObject[4];
    private Rigidbody Rigidbody;
    public bool[] Flag = new bool[4];

    public int _Cnt; //ぶつかった番号を記録用
    public bool StickFlag = false; // true:くっついてる　false:くっついてない

    private bool RotaFlag;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.GetComponent<Rigidbody>();
       
        //for (int Cnt = 0; Cnt < 4; Cnt++)
        //{
        //    Flag[Cnt] = objTarget[Cnt].GetComponent<Jet>().RockMove;
        //}
    }

    // Update is called once per frame
    void Update()
    {
       
        if (StickFlag)
        {
            if (Flag[_Cnt] == false)
            {
                //this.transform.position = new Vector3(objTarget[_Cnt].transform.position.x, objTarget[_Cnt].transform.position.y, 0);
                //this.transform.Rotate(new Vector3(0, 0, 1), Player.transform.rotation.z);

            }
        }
    }
    void FixedUpdate()
    {
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;

        for (int Cnt = 0; Cnt < 4; Cnt++)
        {
            Flag[Cnt] = objTarget[Cnt].GetComponent<Jet>().RockMove;
        }
        //RotaFlag = Player.GetComponent<Player>().NowRotation;
    }

    //// 衝突時
    //void OnCollisionEnter(Collision col)
    //{

    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("プレイヤー当たり");
    //        //Rigidbody.constraints = RigidbodyConstraints.None;

    //        // Rigidbody.isKinematic = true;
    //        // this.transform.parent = Player.transform;
    //    }

    //    for (int Cnt = 0; Cnt < 4; Cnt++)
    //    {
    //        if (col.gameObject == objTarget[Cnt])
    //        {
    //            Flag[Cnt] = true;
    //            Debug.Log(objTarget[Cnt]);
    //            Debug.Log("当たり");
    //        }
    //    }

    //    if (col.gameObject.tag == "Untagged")
    //    {

    //        Debug.Log("当たり");
    //    }
    //}


    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.tag == "Jet")
    //    {
    //        for (int Cnt = 0; Cnt < 4; Cnt++)
    //        {
    //            if (collision.gameObject == objTarget[Cnt])
    //            {
    //                if (!Flag[Cnt])
    //                {
    //                    Flag[Cnt] = true;
    //                    //Debug.Log(objTarget[Cnt]);
    //                    Debug.Log("当たり");
    //                }
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (!Player.GetComponent<Player>().NowRotation) //回転してないとき
        {
            if (!StickFlag) //くっついてないとき
            {
                if (Player.transform.rotation.z >= 350 && Player.transform.rotation.z <= 10 ||
                    Player.transform.rotation.z >= 80 && Player.transform.rotation.z <= 100 ||
                    Player.transform.rotation.z >= 170 && Player.transform.rotation.z <= 190 ||
                    Player.transform.rotation.z >= 260 && Player.transform.rotation.z <= 280)
                {
                    for (int Cnt = 0; Cnt < 4; Cnt++)
                    {
                        if (collision.gameObject.name == objTarget[Cnt].name) //当たったオブジェクト名がobjTargetで指定したものと同じだったら
                        {
                            if (Flag[Cnt])
                            {
                                _Cnt = Cnt;
                                StickFlag = true;
                                //Debug.Log(objTarget[Cnt]);
                                Debug.Log("当たり");

                                this.transform.parent = objTarget[_Cnt].transform; //親子関係にする

                            }
                        }
                    }
                }
            }
        }
    }
}
