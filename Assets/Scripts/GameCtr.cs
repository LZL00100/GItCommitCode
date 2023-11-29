using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtr : MonoBehaviour
{
    private static GameCtr _ins ;
    public static GameCtr GetMe {
        get { return _ins; }
    }
    public struct MonsterGroupInfo
    {
        public int groups;
        public int count;
        public MonsterGroupInfo(int groups,int count)
        {
            this.groups = groups;
            this.count = count;
        }
    }
    public Dictionary<int, bool> customDic;
    public int currentState;
    public Dictionary<int, MonsterGroupInfo> boshuDic;//放每个场景 波数和每波个数的信息
    private int customs;//关卡数
    private void Awake()
    {
        if (_ins==null)
        {
            customDic = new Dictionary<int, bool>();
            boshuDic = new Dictionary<int, MonsterGroupInfo>();
            boshuDic.Add(1, new MonsterGroupInfo(5, 4));//第一关 5波 每波4个
            boshuDic.Add(2, new MonsterGroupInfo(10, 6));//第一关 10波 每波6个
            boshuDic.Add(3, new MonsterGroupInfo(10, 9));//第一关 10波 每波9个
            for (int i = 1; i < 13; i++)
            {
                customDic.Add(i, false);
            }
            customDic[1] = true;
            _ins = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
       // Refresh();
    }

    public void Refresh()
    {
        GameObject pre = Resources.Load<GameObject>("StateButton");
        GameObject parent = GameObject.FindWithTag("Content");
        for (int i = 1; i < 13; i++)
        {
            GameObject obj= Instantiate(pre, parent.transform);
            obj.name = "Custom" + i.ToString();
            obj.transform.GetChild(0).GetComponent<Text>().text=i.ToString();
            obj.GetComponent<Button>().onClick.AddListener(() => { EnterScene(int.Parse(obj.transform.GetChild(0).GetComponent<Text>().text)); });
            if (!customDic[i])//false状态未解锁
            {
                obj.GetComponent<Button>().interactable = false;
                obj.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                obj.GetComponent<Button>().interactable = true;
                obj.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
    public void EnterScene(int coustomID)
    {
        Debug.Log(coustomID);
        currentState = coustomID;
        SceneManager.LoadScene(coustomID);
    }
    void Update()
    {
        
    }
}
