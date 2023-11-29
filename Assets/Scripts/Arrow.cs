using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int attackF = 25;
    public Transform target=null;
    public bool isrotate;
    private Vector3 pos;
    void Start()
    {
        
    }

    void Update()
    {
        if (isrotate)
        {
            transform.Rotate(Vector3.forward, 10);
            FaAxe();
        }
        else { 
        FaArrow();
        }
    }
    public void FaAxe()
    {
        if (target != null)
        {
            pos = target.position;
            transform.position = Vector3.MoveTowards(transform.position, target.position, 5f * Time.deltaTime);
            if (Vector2.Distance(target.position, transform.position) <= 0.5f)
            {
                Debug.Log("攻击");
                target.GetComponent<Monster>().Beattack(attackF);
                DestroyImmediate(gameObject);
            }
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, pos, 5f * Time.deltaTime);
            if (Vector2.Distance(pos, transform.position) <= 0.5f)
            {
                DestroyImmediate(gameObject);
            }
        }
    }
    public void FaArrow()
    {
        if (target!=null)
        {
            pos = target.position;
            Vector3 v = target.position - transform.position;
            v.z = 0;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
            transform.rotation = rotation;
            transform.position = Vector3.MoveTowards(transform.position, target.position, 5f*Time.deltaTime);
            if (Vector2.Distance(target.position,transform.position)<=0.5f)
            {
                Debug.Log("攻击");
                target.GetComponent<Monster>().Beattack(attackF);
                DestroyImmediate(gameObject);
            }
        }
        else
        {
            Vector3 v = pos - transform.position;
            v.z = 0;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, v);
            transform.rotation = rotation;
            transform.position = Vector3.MoveTowards(transform.position, pos, 5f * Time.deltaTime);
            if (Vector2.Distance(pos, transform.position) <= 0.5f)
            {
                DestroyImmediate(gameObject);
            }
        }
        
    }
    
}
