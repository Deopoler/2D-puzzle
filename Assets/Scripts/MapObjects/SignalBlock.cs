using UnityEngine;

public class SignalBlock : Signal
{
    public int signalNumber;

    public override void ReceiveSignal()
    {
        Debug.Log("Signal Received");
        gameObject.SetActive(true);
    }

    void Start()
    {
        GameObject.FindObjectOfType<SignalManager>().RegisterSignal(signalNumber, this);
        gameObject.SetActive(false);
    }
}
