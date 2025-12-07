using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class UIImage : MonoBehaviour
{
    Image _image;
    [SerializeField]
    int imageFillNumber = 1;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }


    public void FillImageNumber(float imageFillNumber)
    {
        //Debug.Log("Percentage " + imageFillNumber + "/" + this.imageFillNumber + "="+(imageFillNumber / this.imageFillNumber));
        _image.fillAmount = imageFillNumber/this.imageFillNumber;
    }

    public int FILLIMAGENUMBER
    {
        set { imageFillNumber = value; }
    }
}
