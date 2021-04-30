using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using UnityEngine.UI;
using TMPro;

using System;

public class LightSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string lightsTopic = "casa/cuarto/luz";
    public float reportRate = 5f;
    public float hourValue = 12f;
    public float minutesValue = 0f;
	private MqttClient client;
    private float reportTimer;
    public TextMeshPro hourText;
    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!client.IsConnected){
            Debug.LogWarning("No conectado");
            return;
        }
        if((reportTimer += Time.deltaTime) >= reportRate){
            Debug.Log($"sending to topic {lightsTopic}, value: {hourValue}");
            string message = hourValue.ToString();
			client.Publish(lightsTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer = 0f;
        }
        string minutos = minutesValue.ToString();
        if(minutesValue<10){
            minutos = "0" + minutesValue.ToString();
        }
        hourText.text = "Hora actual: " + hourValue.ToString() + ":" + minutos;
    }
}
