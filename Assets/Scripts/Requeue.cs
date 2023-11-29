using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requeue : MonoBehaviour
{
    public Queue<Transform> monsterTrans;
    private  Transform target;
    public GameObject arrow;
    private void Awake()
    {
        monsterTrans = new Queue<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("触发检测器");
        if (other.CompareTag("monster"))
        {
            monsterTrans.Enqueue(other.transform);
            //print(monsterTrans.Count + "----------");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("monster"))
        {
            //monsterTrans.Dequeue();
            target = null;
        }
    }
    void Start()
    {
        monsterTrans.Clear();
        target = null;
    }
    private void OnEnable()
    {
        monsterTrans.Clear(); 
        target = null;
    }
    float time;
    // Update is called once per frame
    void Update()
    {
        if (!StateOneInfo.GetMe.isOver) { 
        time += Time.deltaTime;
        if (target == null)
        {
            if (monsterTrans.Count > 0)
            {
                target = monsterTrans.Dequeue();
            }
        }
        else
        {
            if (time > 0.8f) { 
            Debug.Log(target.name);
            Attack();
                time = 0;
            }
        }
        }
    }
    void Attack()
    {
        Debug.Log("attack()+++++");
        GameObject arrowss = Instantiate(arrow, transform);
        arrowss.transform.localPosition = Vector2.zero;
        arrowss.GetComponent<Arrow>().target = target;

    }
}
