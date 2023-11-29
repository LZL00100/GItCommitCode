using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public static MonsterBase Instance;
    public static int BoCount = 5;
    private void Awake()
    {
        Instance = this;
    }
    public struct MonstersData
    {
        public int Hp;
        public float monsterSpeed;
        public float monsterWaitTime;
    }
    public MonstersData[] monsterDatas = new MonstersData[BoCount];//几波怪物
    private void Start()
    {
        for (int i = 0; i < monsterDatas.Length; i++)
        {
            monsterDatas[i].Hp = 100;
            monsterDatas[i].monsterSpeed = i * 0.2f + 3f;
            monsterDatas[i].monsterWaitTime = i * 0.2f + 3f;
        }
    }



}
