using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    [HideInInspector]
    public  int Hp=100;
    [HideInInspector]
    public  float Speed;
    
    Transform Points;
    List<Transform> points = new List<Transform>();
    [HideInInspector]
    private float MoveSpeed = 0.8f;
    Transform nextPoint;
    int index = 0;
    void Start()
    {
        Points = GameObject.Find("Points").transform;
        for (int i = 0; i < Points.childCount; i++)
        {
            points.Add(Points.GetChild(i));
        }
        nextPoint = points[0];
    }

    void Update()
    {
        if (StateOneInfo.GetMe.isOver)
        {
            MoveSpeed = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, MoveSpeed*Time.deltaTime);
        if (index<points.Count&&Vector3.Distance(transform.position,nextPoint.position)<0.001f)
        {
            nextPoint = points[index++];
        }
        if (Vector3.Distance(transform.position, points[points.Count - 1].position) < 0.1f )
        {
            this.gameObject.SetActive(false);
            StateOneInfo.GetMe.RefreshHeart(1);
        }
        
    }
    public void Beattack(int count)
    {
        Debug.Log(count);
        Hp -= count;//塔的攻击力
        Debug.Log(Hp+"/////"+Hp / 100f);
        //transform.Find("Blood").GetComponent<Image>().fillAmount = Hp / 100;
        transform.transform.GetChild(0).GetChild(1).GetComponent<Image>().fillAmount = Hp / 100f;
        if (Hp<=0)
        {
            GameObject per = Resources.Load<GameObject>("Monster2Died");
            GameObject obj= Instantiate(per);
            obj.transform.position = transform.position;
            Destroy(gameObject,0.1f);
        }
    }

}
