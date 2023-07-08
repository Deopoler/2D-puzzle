using UnityEngine;

public class SignalDoor : Signal
{
    public int signalNumber;

    public override void ReceiveSignal()
    {
        Debug.Log("Signal Received");
        gameObject.SetActive(false);
    }

    void Start()
    {
        GameObject.FindObjectOfType<SignalManager>().RegisterSignal(signalNumber, this);
    }
}
