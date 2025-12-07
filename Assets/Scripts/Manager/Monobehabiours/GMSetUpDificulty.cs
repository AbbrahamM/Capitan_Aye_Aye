using System.Collections;
using UnityEngine;

public class GMSetUpDificulty : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(AfterFrame());
    }

    IEnumerator AfterFrame()
    {
        yield return new WaitForEndOfFrame();
        GameManager.instance.SetUpDificultyM();
    }
}
