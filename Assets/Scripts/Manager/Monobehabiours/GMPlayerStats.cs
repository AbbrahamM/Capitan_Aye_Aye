using UnityEngine;
using UnityEngine.Events;

public class GMPlayerStats : MonoBehaviour
{
    float timeGliding = 0;
    
    bool glading = false;

    [SerializeField]
    UnityEvent<float> glidingTime;

    private void Update()
    {
         if(glading)
        {
            timeGliding += Time.deltaTime;
            glidingTime?.Invoke(timeGliding);
        }    
    }

    public bool GMPSGLIDING 
    {
        set { glading = value; }
    }

}
