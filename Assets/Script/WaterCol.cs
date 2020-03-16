using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterCol : MonoBehaviour
{
    Collider ObjectCoLLider;

    private bool WaterFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        ObjectCoLLider = GetComponent<Collider>();
        //ObjectCoLLider.isTrigger = false;
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (WaterFlag == true)
        {
            SceneManager.LoadScene("result");
        }
    }

    //当たって出ていったら実行
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water"))
        {
            WaterFlag = true;
            //SceneManager.LoadScene("result");

        }
    }

    //当たるたびに実行
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("water"))
        {
            WaterFlag = false;
            //SceneManager.LoadScene("result");

        }
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        ObjectCoLLider.isTrigger = true;
    //    }
    //    else
    //    {
    //        ObjectCoLLider.isTrigger = false;
    //    }
    //}
}
