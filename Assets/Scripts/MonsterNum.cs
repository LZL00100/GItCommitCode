using UnityEngine;
using System.Collections;
public class MonsterNum : MonoBehaviour
{
    Transform endPoint;
    public GameObject[] PrefabHyp;
    Transform parent;
    [HideInInspector]
    public int count=0;
    private void Awake()
    {
        endPoint = GameObject.Find("CreatMonsterPoint").transform;
        parent = GameObject.Find("MonsterPool").transform;
    }
    void Start()
    {
        int group = GameCtr.GetMe.boshuDic[GameCtr.GetMe.currentState].groups;//获取当前关的波数
        StartCoroutine(Test02(group));
    }
    //num：一共产生多少波怪
    IEnumerator Test02(int num)
    {
        count = 0;
        while (count < num)
        {
            count++;
            int geshu = GameCtr.GetMe.boshuDic[GameCtr.GetMe.currentState].count;//获取当前关每波的个数
            yield return StartCoroutine(Test01(geshu, PrefabHyp[1]));
        //Debug.Log("第" + count + "怪产生结束");
        yield return new WaitForSeconds(2); //每波时间差
      //  Debug.Log("注意第" + (count + 1) + "波怪即将产生");
        }
        StateOneInfo.GetMe.isCreatOver = true;
     //   Debug.Log("GameOver");
    }
    IEnumerator Test01(int number, GameObject monsterPerfab)
    {
        int count = 0;
        while (count < number)
        {
          count++;
          yield return new WaitForSeconds(0.8f);//每个时间差
          GameObject monster= Instantiate(monsterPerfab, endPoint.position, Quaternion.identity);
            monster.name = "monster" + count.ToString();
          monster.transform.SetParent(parent);
        }
    }
}