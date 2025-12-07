using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private string loadDataPath;
    GMAppearanceFactor[] prefabs;
    [SerializeField] Transform yReference;
    [SerializeField] float spacingFactor = 0;
    [SerializeField] UnityEvent toDoBeforeSpawn;
    [SerializeField] UnityEvent toDoAfterSpawn;
    [SerializeField] bool fillAtTheBegginig = true;
    [SerializeField] bool setUpPowerUps = false;
    [SerializeField] Vector2 maxMin = new Vector2(0.5f, 1);
    [SerializeField] bool dynamicPath;
    [SerializeField] bool fullRandom = false;
    private SpriteRenderer spriteRenderer;
    private Dictionary<GMAppearanceFactor, List<GameObject>> objectPool = new();

    List<string> canAppear = new List<string>();

    [SerializeField]
    string dynamicPathID = string.Empty;    

    private void Awake()
    {
        if (loadDataPath != string.Empty && !dynamicPath)
        {
            PreFill(loadDataPath);
        }
        else if (dynamicPath)
        {
            Debug.Log("Dynamic Path " + SpriteManager.instance.GetDynamicPath(dynamicPathID));
            PreFill(SpriteManager.instance.GetDynamicPath(dynamicPathID));
        }
    }
    private void PreFill(string path)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GMAppearanceFactor[] prefabs = Resources.LoadAll<GMAppearanceFactor>(path); 
        Debug.Log("Prefabs " + prefabs.Length + " " + path);
        this.prefabs = new GMAppearanceFactor[prefabs.Length];
        int i = 0;
        foreach (GMAppearanceFactor pref in prefabs)
        {
            this.prefabs[i] = Instantiate(pref);
            Debug.Log("Pre fill name " +  pref.name.ToString());
            i++;
        }
        /*if (!setUpPowerUps)
        {
            foreach (var prefab in prefabs)
            {
                canAppear.Add(prefab.prefabReference.name);
            }
        }
        else
        {
            canAppear.Add("Banana");
        }*/

        foreach (var prefab in prefabs)
        {
            canAppear.Add(prefab.prefabReference.name);
        }
        StartCoroutine(Fill());
    }

    IEnumerator Fill()
    {
        yield return new WaitForEndOfFrame();
        FillPool();
        if(fillAtTheBegginig)
            ShowRandomObstacles();
    }

    public void AddCanAppear(string objectName)
    {
        if(!canAppear.Contains(objectName))
            canAppear.Add(objectName);
    }


    private void FillPool()
    {
        foreach (var prefab in prefabs) {
            if (canAppear.Contains(prefab.prefabReference.name))
            {
                float maxSize = spriteRenderer.bounds.max.x;
                float startPos = spriteRenderer.bounds.min.x;
                float fullSize = 0;
                int count = 0;
                if (!objectPool.ContainsKey(prefab))
                {
                    objectPool.Add(prefab, new List<GameObject>());
                }
                do
                {
                    GameObject g = Instantiate(prefab.prefabReference, transform);
                    fullSize = GetFullSize(g);
                    g.transform.position = new Vector3(startPos + g.GetComponent<SpriteRenderer>().bounds.size.x / 2, yReference.position.y, 0);
                    g.name = fullSize.ToString();
                    g.SetActive(false);
                    startPos += fullSize;
                    count++;

                    objectPool[prefab].Add(g);
                } while (startPos + (fullSize) < maxSize && count < prefab.maxCount);
            }
        }
    }

    public void ShowRandomObstacles()
    {
        if(spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        float startPosition = spriteRenderer.bounds.min.x;
        float finishPosition = spriteRenderer.bounds.max.x;
        float size = 0;
        //bool justOnece = false;
        do
        {
            float random = Random.Range(maxMin.x, maxMin.y);
            GMAppearanceFactor selectedRef = null;
            try
            {
                if (fullRandom)
                {
                    Debug.Log("Random " + random + " " + gameObject.name);
                    selectedRef = objectPool.Shuffle().First(e => e.Value.Count(e => !e.activeSelf) >= 1 && random <= e.Key.appearFactor).Key;
                }
                else
                {
                    Debug.Log("Random " + random + " " + gameObject.name);
                    selectedRef = objectPool.OrderBy(e => e.Key.appearFactor).First(e => e.Value.Count(e => !e.activeSelf) >= 1 && random <= e.Key.appearFactor).Key;
                }             
            }
            catch (InvalidOperationException)
            {
                try
                {
                    selectedRef = objectPool.OrderByDescending(e => e.Key.appearFactor).First(e => e.Key.forceToAppear && e.Value.Count(e => !e.activeSelf) >= 1).Key;
                }
                catch (InvalidOperationException) { 
                    if(objectPool.Count(e => e.Key.forceToAppear) > 0)
                    {
                        selectedRef = objectPool.First(e => e.Key.forceToAppear).Key;
                    }
                    break; 
                }
            }

            GameObject objToAppear = objectPool[selectedRef].First(e => !e.activeSelf);
            size = float.Parse(objToAppear.name);

            if (Random.value <= selectedRef.randomAppearShowFactor)
                objToAppear.SetActive(true);

            objToAppear.transform.position = new Vector3(startPosition + objToAppear.GetComponent<SpriteRenderer>().bounds.size.x / 2, yReference.position.y, 0);

            startPosition += size + spacingFactor;

            if(startPosition > finishPosition)
                objToAppear.SetActive(false);

        }while((startPosition + size) < finishPosition);
    }
    

    /*public void ShowFullRandomObstacles()
    {
        if (objectPool.Count <= 0)
            return;

        float maxSize = spriteRenderer.bounds.max.x;
        float startPos = spriteRenderer.bounds.min.x;
        float fullSize = 0;
        float lastFullSize = 0;
        int count = 0;
        List<GMAppearanceFactor> index = new List<GMAppearanceFactor>();
        foreach (GMAppearanceFactor r in objectPool.Keys)
        {
            index.Add(r);
        }
        do
        {
            float randomNumber = Random.Range(maxMin.x, maxMin.y);
            GameObject refObject = null;
            float randomShowFactor = 0;
            try
            {
                int randomIndex = Random.Range(0, index.Count);
                List<GameObject> objectsRefs = objectPool[index[randomIndex]];
                foreach (GameObject obj in objectsRefs) {
                    if (!obj.activeSelf)
                    {
                        refObject = obj; randomShowFactor = index[randomIndex].randomAppearShowFactor; break;
                    }
                }
            }
            catch (InvalidOperationException)
            {

                /*try
                {
                    refObject = objectPool.OrderByDescending(e => e.Key).First(e => e.Value.Count(e => !e.activeSelf) > 0).Value.First(e => !e.activeSelf) ?? objectPool.OrderBy(e => e.Key).First().Value.First(e => !e.activeSelf);
                    randomShowFactor = showFactor.OrderByDescending(e => e.Key).First(e => randomNumber <= e.Key).Value;
                }
                catch (InvalidOperationException) { }
            }

            if (refObject != null)
            {
                fullSize = float.Parse(refObject.name) + spacingFactor;
                if (count == 0)
                    startPos += fullSize / 2;
                else
                {
                    /*if (lastFullSize != fullSize)
                    {
                        startPos += lastFullSize;
                    }
                    else
                        startPos += fullSize;
                }

                refObject.transform.position = new Vector3(startPos, yReference.position.y, 0);

                if (Random.value <= randomShowFactor)
                    refObject.SetActive(true);

                lastFullSize = (fullSize);
            }
            else
            {
                startPos += lastFullSize*2;
                break;
            }

            count++;
        } while ((startPos + (fullSize * 2)) < maxSize);
    }*/


    private float GetFullSize(GameObject gP)
    {
        float size =0;

        /*if (gP.TryGetComponent(out SpriteRenderer sprite) ) { //&& sprite.color != new Color(0, 0, 0, 0)
            size = sprite.bounds.size.x;
        }

        for (int i = 0; i < gP.transform.childCount; i++)
        {
            if (gP.transform.GetChild(i).TryGetComponent(out SpriteRenderer sP))
            {
                size += sprite.bounds.size.x;
                size += Vector3.Distance(gP.transform.localPosition, sP.transform.localPosition);
            }
        }*/

        if (gP.transform.Find("Size") == null) {
            if (gP.TryGetComponent(out SpriteRenderer sprite))
            { //&& sprite.color != new Color(0, 0, 0, 0)
                size = sprite.bounds.size.x;
            }
        }
        else
        {
            if (gP.transform.Find("Size").TryGetComponent(out SpriteRenderer sprite))
            { //&& sprite.color != new Color(0, 0, 0, 0)
                size = sprite.bounds.size.x;
            }
        }

        return size;//size + spacingFactor;
    }

    private float GetHalfSize(GameObject gP)
    {
        float size = 0;

        if (gP.TryGetComponent(out SpriteRenderer sprite) && sprite.color != new Color(0, 0, 0, 0))
        {
            size = sprite.bounds.size.x/2;

            for (int i = 0; i < gP.transform.childCount; i++)
            {
                if (gP.transform.GetChild(i).TryGetComponent(out SpriteRenderer sP))
                {
                    size += sP.bounds.size.x;
                }
            }
        }

        return size;
    }

    public void IncreaseSpacingFactor()
    {
        spacingFactor = Mathf.Clamp(spacingFactor + SpriteManager.instance.DIFICULTYFACTOR,0,5);
    }

    public void DecreseSpacingFactor()
    {
        spacingFactor = Mathf.Clamp(spacingFactor - SpriteManager.instance.DIFICULTYFACTOR, 0, 5);
    }

    public void IncreaseMaxRandomNumber()
    {
        maxMin.y = Mathf.Clamp(maxMin.y + SpriteManager.instance.DIFICULTYFACTOR, 0.5f, 1);
    }
    public void DecreseMaxRandomNumber()
    {
        maxMin.y = Mathf.Clamp(maxMin.y - SpriteManager.instance.DIFICULTYFACTOR, 0.5f, 1);
    }

    public void IncreaseMinRandomNumber()
    {
        maxMin.x = Mathf.Clamp(maxMin.x + SpriteManager.instance.DIFICULTYFACTOR, 0, 0.5f);
    }
    public void DecreseMinRandomNumber()
    {
        maxMin.x = Mathf.Clamp(maxMin.x - SpriteManager.instance.DIFICULTYFACTOR, 0, 0.5f);
    }
    public void IncreaseRandomAppearFactor()
    {
        foreach (var factor in prefabs)
        {
            factor.appearFactor = Mathf.Clamp(factor.appearFactor + SpriteManager.instance.DIFICULTYFACTOR, factor.maxMin.x, factor.maxMin.y);
        }
    }

    public void DecreaseRandomAppearFactor()
    {
        foreach (var factor in prefabs)
        {
            factor.appearFactor = Mathf.Clamp(factor.appearFactor - SpriteManager.instance.DIFICULTYFACTOR, factor.maxMin.x, factor.maxMin.y);
        }
    }
    private void OnDisable()
    {
        foreach(var key in objectPool.Keys)
        {
            foreach(var obj in objectPool[key])
            {
                obj.SetActive(false);
            }
        }
    }

    public string LOADPATH
    {
        set { loadDataPath = value; }
    }
}
public static class DictionaryExtensions
{
    public static Dictionary<TKey, TValue> Shuffle<TKey, TValue>(
       this Dictionary<TKey, TValue> source)
    {
        System.Random r = new System.Random();
        return source.OrderBy(x => r.Next())
           .ToDictionary(item => item.Key, item => item.Value);
    }
}