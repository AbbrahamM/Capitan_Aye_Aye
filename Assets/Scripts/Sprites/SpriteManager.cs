using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    [SerializeField]
    private List<DynamicPaths> dynamicPaths = new();

    private float dificultyFactor = 1f;
    List<string> onlyOnce = new List<string>();
    
    public bool tmpLoaded = false;
    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string GetDynamicPath(string ID)
    {
        return dynamicPaths.First(e => e.dynamicPathID.Equals(ID)).dynamicPath;
    }

    public void AddDynamicPath(DynamicPaths dynamic)
    {
        dynamicPaths.Add(dynamic);
    }

    public void ClearDynamicPaths()
    {
        dynamicPaths.Clear();
    }

    public float DIFICULTYFACTOR
    {
        set { dificultyFactor = value; Debug.Log("Factor " + dificultyFactor); } 
        get { return dificultyFactor; }
    }

    public bool TMPLOADED
    {
        get { return tmpLoaded; }
        set { tmpLoaded = value; }
    }
    public List<string> ONLUONCE
    {
        get { return onlyOnce; }
    }
}
[System.Serializable]
public class DynamicPaths
{
    public string dynamicPathID = string.Empty;
    public string dynamicPath = string.Empty;   
}
