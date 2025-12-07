using System.Collections.Generic;
using UnityEngine;

public class GMAddPowerUp : MonoBehaviour
{
    [SerializeField]
    List<GameObject> powrUps = new();
    private void Awake()
    {
        foreach (GameObject t in powrUps)
        {
            GameManager.instance.GMPOERUPS.Add(t);
        }
        Debug.Log("I execute");
    }

    private void OnDestroy()
    {
        GameManager.instance.GMPOERUPS.Clear();
    }
}
