using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;

public class BluetoothController : MonoBehaviour
{
    public BluetoothHelper btHelper;
    public int frameRate = 60;
    private bool isConnecting;
    // Start is called before the first frame update
    
    void OnApplicationQuit()
    {
        btHelper.Disconnect();
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
    void Start()
    {
        Application.targetFrameRate = frameRate;
        try{
            BluetoothHelper.BLE = true;
            btHelper = BluetoothHelper.GetInstance();
            btHelper.OnConnected += OnConnected;
            btHelper.OnConnectionFailed += OnConnectionFailed;
            btHelper.OnScanEnded += OnScanEnded;

            // helper.setCustomStreamManager(new MyStreamManager()); //implement your own way of delimiting the messages
            //helper.setTerminatorBasedStream("\n"); //every messages ends with new line character
            btHelper.setFixedLengthBasedStream(1);
            btHelper.setDeviceName("JDY-08");
            btHelper.ScanNearbyDevices();

        } catch(Exception e) {
            Debug.LogError(e);
        }
    }
    
    void OnScanEnded(BluetoothHelper helper, LinkedList<BluetoothDevice> devices) {
        LinkedListNode<BluetoothDevice> node = devices.First;
        while (true)
        {
            if (node.Value.DeviceName == "JDY-08")
            {
                try{
                    helper.Connect();
                    isConnecting = true;
                } catch(Exception){
                    isConnecting = false;
                }
            }
            node = node.Next;
            if (node == null)
                return;
        }
    }
    
    void OnConnected(BluetoothHelper helper) {
        isConnecting = false;
        helper.StartListening();
    }

    void OnConnectionFailed(BluetoothHelper helper) {
        isConnecting = false;
    }
    
    void OnGUI () {
        if (btHelper.isConnected()) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Connected");
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Searching...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
