using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMCounter", menuName = "Scriptable Objects/Game Manager/Counter")]
public class GMCounter : ScriptableObject
{
    [SerializeField]
    int counter = 0;
    [SerializeField]
    UnityEvent<int> getCounter;
    public void Add(int counter)
    {
        this.counter += counter;
        Debug.Log("Add Counter " + this.counter + " " + name);
        getCounter?.Invoke(this.counter);
    }

    public void AddNoGetCounter(int counter)
    {
        this.counter += counter;
        Debug.Log("Add Counter " + this.counter + " " + name);
    }

    public void Substract(int counter)
    {
        this.counter -= counter;
        getCounter?.Invoke(this.counter);
    }

    public void GetCounter()
    {
        getCounter?.Invoke(this.counter);
    }

    public void ResetCounter()
    {
        counter = 0;
        Debug.Log("Add Counter Reset " + this.counter + " " + name);
        getCounter?.Invoke(this.counter);
    }
    public int COUNTER { set { counter = value; Debug.Log("I set i " + value); } }
}
