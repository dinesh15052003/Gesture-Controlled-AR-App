using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomIN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
   
    // Update is called once per frame
    void Update()
    {       
        
    }
    void TaskOnClick()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("obj");
        Animator anim = obj.GetComponent<Animator>();
        
        //anim.SetTrigger("zoomin");
        //anim.ResetTrigger("zoomout");
    }
}
