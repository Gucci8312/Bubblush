using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームスタートボタンが押されたときに実行する
    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");//シーンを読み込む
    }

    //ゲームタイトルボタンが押されたときに実行する
    public void GameTitle()
    {
        SceneManager.LoadScene("title");//シーンを読み込む
    }

    //ゲーム終了ボタンが押されたときに実行する
    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//再生モードを解除する
#else
            Application.Quit();//アプリケーションを終了する
#endif
    }
}
