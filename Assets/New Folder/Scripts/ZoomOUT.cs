using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomOUT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("obj");
        Animator anim = obj.GetComponent<Animator>();
        anim.SetTrigger("zoomout");
        anim.ResetTrigger("zoomin");
    }
}
