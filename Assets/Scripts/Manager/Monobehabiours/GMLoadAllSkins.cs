
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GMLoadAllSkins : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    GMSkins skins = new();
    Dictionary<string, RuntimeAnimatorController> animators = new();
    Dictionary<string, float> prices = new();

    [SerializeField]
    List<Sprite> icons = new();
    [SerializeField]
    UnityEvent toDoWhenBuy;
    [SerializeField]
    UnityEvent<float> fillPrice;
    [SerializeField]
    UnityEvent<GameObject> toDoWhenUse;
    [SerializeField]
    UnityEvent<GameObject> toDoWhenFilled;
    [SerializeField]
    GameObject margin;

    private void OnEnable()
    {
        Debug.Log("Skin Path " + Application.streamingAssetsPath + "/Skins.json");
        StartCoroutine(ReadSkins());
    }

    private IEnumerator ReadSkins()
    {
        using (UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(Application.streamingAssetsPath + "/Skins.json"))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to load file: " + www.error);
            }
            else
            {
                string jsonText = www.downloadHandler.text;
                skins = JsonUtility.FromJson<GMSkins>(jsonText);
                Debug.Log(" " + skins.SKINS.Count + " skins.");
            }
        }

        int count = 0;
        int current = 0;
        Sprite []sprites = Resources.LoadAll<Sprite>("Sprites/carteles/");
        Debug.Log("Spritres Loaded = " + sprites.Length);
        foreach (Sprite sprite in sprites) { 
            Debug.Log("Sprite Name " + sprite.name.Replace("_0",string.Empty));
        }

        foreach (Skin skin in skins.SKINS) {
            if(count <= 0)
            {
                transform.GetChild(count).GetComponent<Image>().sprite = sprites.First(e=>e.name.Replace("_0", string.Empty) == skin.Icon);
                transform.GetChild(count).gameObject.name = skin.Name;
            }
            else
            {
                GameObject objRef = Instantiate(transform.GetChild(0).gameObject,transform);
                objRef.GetComponent<Image>().sprite = sprites.First(e => e.name.Replace("_0", string.Empty) == skin.Icon);
                objRef.name = skin.Name;
            }

            string folder = skins.SKINS.First(e => e.Name.Equals(skin.Name)).Name;
            string controller = skins.SKINS.First(e => e.Name.Equals(skin.Name)).Anim;
            animators.Add(skin.Name, Resources.Load<RuntimeAnimatorController>("Animators/" + folder + "/UI/" + controller+"UI"));

            transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[2];
            transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = skin.Cost.ToString();
            if (GameManager.instance.GMSave.unlockedSkins.Contains(skin.Name)){
                transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[0];
                transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
            }
            if (GameManager.instance.GMSave.currentSkin.Equals(skin.Name))
            {
                transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[1];
                transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
                current = count;
            }
            prices.Add(skin.Name, skin.Cost);
            count++;
            yield return null;
        }
        Instantiate(margin, transform);
        /*for (int i = 0; i < gameObject.transform.childCount; i++) {

            if (GameManager.instance.GMSave.unlockedSkins.Contains(gameObject.transform.GetChild(i).name))
            {
                transform.GetChild(i).transform.Find("InjectUse").gameObject.SetActive(true);
            }
            if (!GameManager.instance.GMSave.currentSkin.Equals(gameObject.transform.GetChild(i).name) && !GameManager.instance.GMSave.unlockedSkins.Contains(gameObject.transform.GetChild(i).name))
            {
                transform.GetChild(i).transform.Find("InjectBuy").gameObject.SetActive(true);
                CanBeBought(transform.GetChild(i));
            }
        }*/
        yield return new WaitForEndOfFrame();
        Debug.Log("Current Selected " + current + " " + transform.GetChild(current).gameObject.name); 
        toDoWhenFilled?.Invoke(transform.GetChild(current).gameObject);
        //SetAnimator(transform.Find(GameManager.instance.GMSave.currentSkin));
    }

    public void RefillButtons()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/carteles/");
        int count = 0;
        int current = 0;
        foreach (Skin skin in skins.SKINS)
        {
            transform.GetChild(count).GetComponent<Image>().sprite = sprites.First(e => e.name.Replace("_0", string.Empty) == skin.Icon);
            transform.GetChild(count).gameObject.name = skin.Name;
            

            string folder = skins.SKINS.First(e => e.Name.Equals(skin.Name)).Name;
            string controller = skins.SKINS.First(e => e.Name.Equals(skin.Name)).Anim;
            

            transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[2];
            transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = skin.Cost.ToString();

            if (GameManager.instance.GMSave.unlockedSkins.Contains(skin.Name))
            {
                transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[0];
                transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
            }
            if (GameManager.instance.GMSave.currentSkin.Equals(skin.Name))
            {
                transform.GetChild(count).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icons[1];
                transform.GetChild(count).transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
                current = count;
            }
            count++;
        }


        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).transform.Find("InjectBuy").gameObject.SetActive(false);
            transform.GetChild(i).transform.Find("InjectUse").gameObject.SetActive(false);
            transform.GetChild(i).transform.Find("CabBeBought").gameObject.SetActive(false);
        }

        //SetAnimator(transform.Find(GameManager.instance.GMSave.currentSkin));
        toDoWhenUse?.Invoke(transform.GetChild(current).gameObject);
        ActivateActions(transform.GetChild(current).transform);
    }

    public void ActivateActions(Transform button)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            button.Find("InjectBuy").gameObject.SetActive(false);
            button.Find("InjectUse").gameObject.SetActive(false);
            button.Find("CabBeBought").gameObject.SetActive(false);
            button.Find("InUse").gameObject.SetActive(false);
        }
        if (GameManager.instance.GMSave.unlockedSkins.Contains(button.name) || !GameManager.instance.GMSave.currentSkin.Equals(button.name))
        {
            button.Find("InjectUse").gameObject.SetActive(true);
        }
        if (!GameManager.instance.GMSave.currentSkin.Equals(button.name) && !GameManager.instance.GMSave.unlockedSkins.Contains(button.name))
        {
            button.Find("InjectBuy").gameObject.SetActive(true);
            CanBeBought(button);
        }

        if (GameManager.instance.GMSave.currentSkin.Equals(button.name))
        {
            button.Find("InUse").gameObject.SetActive(true);
        }
    }
    public void SetAnimator(Transform _transform)
    {
        Debug.Log("Skin " + _transform.name);
        animator.runtimeAnimatorController = animators[_transform.name];
        animator.Play(0);
    }

    public void ReturnCurrentSkin()
    {
        animator.runtimeAnimatorController = animators[GameManager.instance.GMSave.currentSkin];
        animator.Play(0);
    }

    public void Buy(Transform _transform)
    {
        Debug.Log("Bought " + prices[_transform.name] + " " + GameManager.instance.GMSave.coinsToUse);
        if (GameManager.instance.GMSave.coinsToUse - prices[_transform.name] >= 0)
        {
            Debug.Log("Bought " + prices[_transform.name] +" "+ GameManager.instance.GMSave.coinsToUse);
            GameManager.instance.GMSave.coinsToUse -= (int)prices[_transform.name];
            string[] currentSkins = new string[GameManager.instance.GMSave.unlockedSkins.Length + 1];

            GameManager.instance.GMSave.unlockedSkins.CopyTo(currentSkins, 0);
            currentSkins[currentSkins.Length - 1] = _transform.name;

            GameManager.instance.GMSave.unlockedSkins = new string[currentSkins.Length];
            currentSkins.CopyTo(GameManager.instance.GMSave.unlockedSkins, 0);
            toDoWhenBuy?.Invoke();

            Debug.Log("Bought " + GameManager.instance.GMSave.coinsToUse);
        }
    }

    public void Use(Transform _transform)
    {
        GameManager.instance.GMSave.currentSkin = _transform.name;
        Debug.Log("Current Skin " + GameManager.instance.GMSave.currentSkin);
        //toDoWhenUse?.Invoke(transform.GetChild(current).gameObject);
    }

    public void GetSkinPrice(Transform _transform)
    {
        fillPrice?.Invoke(prices[_transform.name]);
    }
    public void CanBeBought(Transform _transform)
    {
        _transform.GetChild(3).gameObject.SetActive(true);
        Debug.Log("Prices " + prices[_transform.name] + " " + GameManager.instance.GMSave.coinsToUse+ " "+ (GameManager.instance.GMSave.coinsToUse - prices[_transform.name] < 0));
        if (GameManager.instance.GMSave.coinsToUse - prices[_transform.name] < 0)
        {
            _transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        for (int i = 1; i < transform.childCount; i++)
        { 
            Destroy(transform.GetChild(i).gameObject);
        }
        animators.Clear();
        prices.Clear();
    }
}
