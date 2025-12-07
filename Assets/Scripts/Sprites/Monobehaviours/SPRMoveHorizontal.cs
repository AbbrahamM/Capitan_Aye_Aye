using UnityEngine;
using UnityEngine.Events;

public class SPRMoveHorizontal : MonoBehaviour
{
    [Header("Movimiento Local")]
    public float velocidad = 2f;

    [Header("Rango Local")]
    public float rangoIzquierdo = -2f;
    public float rangoDerecho = 2f;

    private int direccion = 1;
    private Vector3 posicionInicialLocal;
    [SerializeField]
    UnityEvent moveRight;
    [SerializeField]
    UnityEvent moveLeft;
    void OnEnable()
    {
        // Guarda la posición local inicial relativa al padre
        posicionInicialLocal = transform.localPosition;
    }

    void Update()
    {
        if (!enabled)
            return;
        // Movimiento local horizontal
        transform.localPosition += Vector3.right * direccion * velocidad * Time.deltaTime;

        // Calcula desplazamiento desde la posición inicial
        float desplazamiento = transform.localPosition.x - posicionInicialLocal.x;

        // Reversión de dirección si se alcanza el límite
        if (desplazamiento >= rangoDerecho)
        {
            transform.localPosition = new Vector3(posicionInicialLocal.x + rangoDerecho, transform.localPosition.y, transform.localPosition.z);
            direccion = -1;
            moveLeft?.Invoke(); 
        }
        else if (desplazamiento <= rangoIzquierdo)
        {
            transform.localPosition = new Vector3(posicionInicialLocal.x + rangoIzquierdo, transform.localPosition.y, transform.localPosition.z);
            direccion = 1;
            moveRight?.Invoke();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 origen = transform.parent ? transform.parent.position : Vector3.zero;
        Gizmos.DrawLine(origen + Vector3.right * rangoIzquierdo, origen + Vector3.right * rangoDerecho);
    }

}
