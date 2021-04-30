using UnityEngine;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

using System;

public class LightsActuator : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "casa/cuarto/luz";
    public float turnOnLightHour = 19;
    public float turnOffLightHour = 7;
    private MqttClient client;
    string lastMessage;
    public GameObject light1;
    public GameObject light2;
    public GameObject dayText;
    public GameObject nightText;
    public GameObject naturalLight;
    volatile bool lightsState = false;
    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId);
        client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

    }

    // Update is called once per frame
    void Update()
    {
        if (lightsState == true){
            naturalLight.SetActive(false);
            light1.SetActive(true);
            light2.SetActive(true);
            dayText.SetActive(false);
            nightText.SetActive(true);
        }else{
            naturalLight.SetActive(true);
            light1.SetActive(false);
            light2.SetActive(false);
            dayText.SetActive(true);
            nightText.SetActive(false);
        }
    }

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
        float hour;
        float.TryParse(lastMessage, out hour);
        if(hour >= turnOnLightHour || hour <= turnOffLightHour){
            //acObject.SetActive(true);
            lightsState = true;
        } else if(hour > turnOffLightHour || hour < turnOnLightHour){
            //acObject.SetActive(false);
            lightsState = false;
        }
	}
}
