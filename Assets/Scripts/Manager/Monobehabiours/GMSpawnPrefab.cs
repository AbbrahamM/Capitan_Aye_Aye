using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GMSpawnPrefab : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    List<GameObject> prefabs = new();
    [SerializeField]
    bool isPrefab = true;
    int i = 0;
    public void SpawnPrefab()
    {
        if (isPrefab)
        {
            prefabs.Add(Instantiate(prefab, transform));
            Debug.Log("how many times do i enter here ");
        }
        else
        {
            if (i == 0)
            {
                prefab.SetActive(true);
            }
            else
            {
                prefabs.Add(Instantiate(prefab, transform));
            }
            i++;
        }
    }

    public void SpawnPrefaTransfomParent()
    {
        GameObject obj = Instantiate(prefab, transform.parent,false);
        obj.transform.position = transform.position;
        Debug.Log("how many times do i enter here " + gameObject.name);
    }

    private void OnDisable()
    {
        
            foreach (GameObject prefab in prefabs)
            {
                Destroy(prefab);
            }

            prefabs.Clear();

        if (!isPrefab)
        {
            prefab.gameObject.SetActive(false);
            i = 0;
        }
    }

    public void ResetObjects()
    {

        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }

        prefabs.Clear();

        if (!isPrefab)
        {
            prefab.gameObject.SetActive(false);
            i = 0;
        }
    }
}
