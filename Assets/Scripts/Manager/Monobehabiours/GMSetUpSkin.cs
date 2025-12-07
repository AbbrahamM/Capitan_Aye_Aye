using System.Collections;
using System.Linq;
using UnityEngine;
[RequireComponent (typeof(Animator))]
public class GMSetUpSkin : MonoBehaviour
{
    Animator animator;

    GMSkins skins = new();
    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

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
                Debug.Log("Loaded " + skins.SKINS.Count + " skins.");
            }
        }


        string folder = skins.SKINS.First(e=>e.Name.Equals(GameManager.instance.GMSave.currentSkin)).Name;
        string controller = skins.SKINS.First(e => e.Name.Equals(GameManager.instance.GMSave.currentSkin)).Anim;

        RuntimeAnimatorController animatorController = Resources.Load<RuntimeAnimatorController>("Animators/" + folder+"/"+controller);
        Debug.Log("Animator " + Application.dataPath+ "/Assets"+ "/Animators/" + folder + "/" + controller + " " + (animatorController.name));

        animator.runtimeAnimatorController = animatorController;
    }

    public void ResetSkin()
    {
        StartCoroutine(ReadSkins());
    }
}
