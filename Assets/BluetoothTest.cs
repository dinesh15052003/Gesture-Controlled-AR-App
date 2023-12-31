﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BluetoothTest : MonoBehaviour
{
    public Text deviceName;
    public Text dataToSend;
    private bool IsConnected;
    public static string dataRecived = "";
    public GameObject tmpText;
    TMP_Text txt;
    
    // Start is called before the first frame update
    void Start()
    {
        IsConnected = false;
        BluetoothService.CreateBluetoothObject();
        txt = tmpText.GetComponent<TMP_Text>();
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (IsConnected) {
            try
            {
               string datain =  BluetoothService.ReadFromBluetooth();
                if (datain.Length > 1)
                {
                    dataRecived = datain;
                    print(dataRecived);
                    txt.text = dataRecived;
                }

            }
            catch (Exception e)
            {

            }
        }
        
    }

    public void StartButton()
    {
        if (!IsConnected)
        {
            print(deviceName.text.ToString());
            IsConnected =  BluetoothService.StartBluetoothConnection(deviceName.text.ToString());
        }
    }

    public void SendButton()
    {
        if (IsConnected && (dataToSend.ToString() != "" || dataToSend.ToString() != null))
        {
            BluetoothService.WritetoBluetooth(dataToSend.text.ToString());
        }
    }


    public void StopButton()
    {
        if (IsConnected)
        {
            BluetoothService.StopBluetoothConnection();
        }
        Application.Quit();
    }
}
