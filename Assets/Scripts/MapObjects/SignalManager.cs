using System.Collections.Generic;
using UnityEngine;

public class SignalManager : MonoBehaviour
{
    public List<List<Signal>> signals;

    public void SendSignal(int signalNumber)
    {
        foreach (var signal in signals[signalNumber])
        {
            signal.ReceiveSignal();
        }
    }

    public void RegisterSignal(int signalNumber, Signal signal)
    {
        while (signals.Count <= signalNumber)
        {
            signals.Add(new List<Signal>());
        }
        signals[signalNumber].Add(signal);
    }

    void Awake()
    {
        signals = new List<List<Signal>>();
    }
}
