using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SPRSpawnSprite : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();
    [SerializeField]
    Vector3 offset = Vector3.zero;
    List<GameObject> posibleObjects = new();
    public void Spawn()
    {
        GameObject g = posibleObjects[Random.Range(0, posibleObjects.Count)];
        
        g.transform.localPosition = Vector3.zero + offset;
        g.SetActive(true);
    }

    private void Awake()
    {
        foreach (var obj in prefabs) { 
            posibleObjects.Add(Instantiate(obj,transform));
            posibleObjects.Last().SetActive(false);
        }
    }


}
