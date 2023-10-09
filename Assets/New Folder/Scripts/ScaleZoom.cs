using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ScaleZoom : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _zoomin;
    private bool _zoomout;
    public float scale;
    GameObject obj1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj1 = GameObject.FindGameObjectWithTag("obj1"))
        {
            if (obj1.transform.localScale.x < 0.2 && obj1.transform.localScale.y < 0.2 && obj1.transform.localScale.z < 0.2) 
            {
                obj1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            if (_zoomin)
            {
                obj1.transform.localScale += new Vector3(scale, scale, scale);
            }
            if (_zoomout)
            {
                obj1.transform.localScale -= new Vector3(scale, scale, scale);
            }
        }
    }
    public void OnPressZoomIn()
    {
        _zoomin = true;
    }
    public void OnReleaseZoomIn()
    {
        _zoomin = false;
    }
    public void OnPressZoomOut()
    {
        _zoomout = true;
    }
    public void OnReleaseZoomOut()
    {
        _zoomout = false;
    }
    
}
