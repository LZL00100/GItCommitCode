using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100,mask);
            
            if (hit.collider != null)
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red);
                //Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("tower"))
            {
             //   Debug.Log("++++++");
                if (hit.collider.transform.GetChild(0).gameObject.activeSelf)
                    hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                else
                    hit.collider.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (hit.collider.CompareTag("tower2"))
            {
                if (StateOneInfo.GetMe.money>=50)//判断钱是否足够
                {
                        //  Debug.Log("---------");
                    StateOneInfo.GetMe.RefreshMoney(-50);
                    hit.collider.transform.parent.parent.parent.GetChild(1).gameObject.SetActive(true);
                    hit.collider.transform.parent.gameObject.SetActive(false);
                    hit.collider.transform.parent.parent.gameObject.SetActive(false);
                }
            }
                if (hit.collider.CompareTag("tower1"))
            {
                if (StateOneInfo.GetMe.money>=30)//判断钱是否足够
                {
                        //  Debug.Log("---------");
                    StateOneInfo.GetMe.RefreshMoney(-30);
                    hit.collider.transform.parent.parent.parent.GetChild(2).gameObject.SetActive(true);
                    hit.collider.transform.parent.gameObject.SetActive(false);
                    hit.collider.transform.parent.parent.gameObject.SetActive(false);
                }
            }
            if (hit.collider.CompareTag("destower"))
            {

                hit.collider.transform.parent.parent.parent.GetChild(0).gameObject.SetActive(true);
                hit.collider.transform.parent.gameObject.SetActive(false);
                hit.collider.transform.parent.parent.gameObject.SetActive(false);
                    //金币加五
            }
            }
        }
    }
  
}
