using UnityEngine;
using UnityEngine.Events;

public class GMTextToFloat : MonoBehaviour
{
    [SerializeField]
    UnityEvent<float> textToFloat;
    public void TextToFloat(string text)
    {
        if(float.TryParse(text, out float number)){

            textToFloat?.Invoke(number);
        }
    }
}
