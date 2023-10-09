using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class BTReceive : MonoBehaviour
{
    // Start is called before the first frame update
    String deviceName = "HC-05";
    private bool IsConnected;
    public static string dataReceived = "";

    SerialPort serialPort = new SerialPort("COM4", 9600);
    public GameObject obj;
    TMP_Text tmp_text;
    ScaleZoom scaleZoom;
    string text;
    string[] flags;
    bool flag1; // for button press 0 - btn pressed
    bool flag2; // for zoom 0 - zoomout
    void Start()
    {
        scaleZoom = FindObjectOfType<ScaleZoom>();
        tmp_text = obj.GetComponent<TMP_Text>();

        IsConnected = false;
        BluetoothService.CreateBluetoothObject();
    }

    // Update is called once per frame
    void Update()
    {
        // Reading data from SerialPort in PC

        //try
        //{
        //    if (!serialPort.IsOpen)
        //    {
        //        serialPort.Open();
        //        serialPort.ReadTimeout = 1000;
        //    }
        //}catch(System.Exception e) { Debug.Log(e); }
        //text = serialPort.ReadLine();
        //Debug.Log(text);
        //tmp_text.text = text;

        // 0 0 - Zoom In
        // 0 1 - Zoom Out
        // 1 x - Do Nothing

        if (!IsConnected)
        {
            IsConnected = BluetoothService.StartBluetoothConnection(deviceName);
            tmp_text.text = "Connection Status - "+IsConnected.ToString();
        }
        else
        {
            try
            {
                string datain = BluetoothService.ReadFromBluetooth();
                if (datain.Length > 1)
                {
                    dataReceived = datain;
                    print(dataReceived);
                    tmp_text.text = dataReceived;
                }
            } catch (Exception e) { }

            flags = dataReceived.Split(',');
            Debug.Log(flag1);
            Debug.Log(flag2);
            if (flags[0]=="0" && flags[1]=="0")
            {
                tmp_text.text = dataReceived + " - Zoom In";
                scaleZoom.OnPressZoomIn();
                scaleZoom.OnReleaseZoomOut();
            }
            else if(flags[0] == "0" && flags[1] == "1")
            {
                tmp_text.text = dataReceived + " - Zoom Out";
                scaleZoom.OnPressZoomOut();
                scaleZoom.OnReleaseZoomIn();
            }
            else
            {
                scaleZoom.OnReleaseZoomIn();
                scaleZoom.OnReleaseZoomOut();
            }
        }
    }

}
