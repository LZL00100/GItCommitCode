    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCtr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Refresh()
    {
        GameObject pre = Resources.Load<GameObject>("StateButton");
        GameObject parent = GameObject.FindWithTag("Content");
        for (int i = 1; i < 13; i++)
        {
            GameObject obj = Instantiate(pre, parent.transform);
            obj.name = "Custom" + i.ToString();
            obj.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            obj.GetComponent<Button>().onClick.AddListener(() => { EnterScene(int.Parse(obj.transform.GetChild(0).GetComponent<Text>().text)); });
            if (! GameCtr.GetMe.customDic[i])//false状态未解锁
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
       GameCtr.GetMe.currentState = coustomID;
        SceneManager.LoadScene(coustomID);
    }
}
