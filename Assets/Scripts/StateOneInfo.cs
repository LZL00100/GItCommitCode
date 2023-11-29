using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateOneInfo : MonoBehaviour
{
    private static StateOneInfo _ins;
    public static StateOneInfo GetMe
    {
        get
        {
            return _ins;
        }
    }
    [HideInInspector]
    public int heart=3;
    public int money=120;
    private float time;
    public bool isCreatOver;
    public  bool isOver=false;
    private GameObject MonsterPool;
    public GameObject MonsterInit;
    private void Awake()
    {
        _ins = this;
    }
    void Start()
    {
        MonsterInit = GameObject.Find("MonsterInit");
        MonsterPool = GameObject.FindWithTag("MonsterPool");
        transform.GetChild(0).GetComponent<Text>().text = "X" + heart.ToString();
        transform.GetChild(1).GetComponent<Text>().text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            int group = GameCtr.GetMe.boshuDic[GameCtr.GetMe.currentState].groups;//获取当前关的波数
            transform.GetChild(2).GetComponent<Text>().text = string.Format("WAVE:{0}/{1}",
                MonsterInit.GetComponent<MonsterNum>().count,group
                );//显示波数
            time += Time.deltaTime;
            if (time >= 2)
            {
                RefreshMoney(5);
                time = 0;
            }
            if (isCreatOver)
            {
                if (MonsterPool.transform.childCount <= 0)
                {
                    StartCoroutine(GameOver("LevelComplete", "ChengGong"));
                    isOver = true;
                    int unlockCount = GameCtr.GetMe.currentState + 1;
                    GameCtr.GetMe.customDic[unlockCount] = true;
                    Debug.Log("游戏成功");
                }
            }
        }
    
    }
    IEnumerator GameOver(string childName,string sceneName)
    {
        yield return null;
        GameObject.FindWithTag("Canvas").transform.Find(childName).gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Debug.Log("跳转场景continue");
        SceneManager.LoadScene(sceneName);
    }
    public void RefreshHeart(int count)
    {
        heart -= count;
        transform.GetChild(0).GetComponent<Text>().text = "X" + heart.ToString();
        if (heart<=0)
        {
            StartCoroutine(GameOver("GameOver", "ShiBai"));
            isOver = true;
            Debug.Log("游戏结束");
        }
    }

    public void RefreshMoney(int count)
    {
        money += count;
        transform.GetChild(1).GetComponent<Text>().text = money.ToString();
    }
}
