using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    GMDificulty mDificulty;


    List<GameObject> powerUps = new();

    ChallengeType challengeType = ChallengeType.Distance;
    GMSave gmSave = new GMSave();

    [SerializeField]
    UnityEvent toDoOnAwake;
    [SerializeField]
    UnityEvent toDoFirstOpen;
    [SerializeField]
    UnityEvent toDoOnStart;
    [SerializeField]
    UnityEvent toDoNotTodayDate;
    string dateFormat = "dd/MM/yyy";
    string todayDynamicQuest = string.Empty;
    private void Awake()
    {
        if (instance == null) {
            instance = this;
            toDoOnAwake?.Invoke();

            //Debug.Log("Save Data Load " + gmSave.startDate + " " +((gmSave.startDate == string.Empty)));

            if (gmSave.startDate == string.Empty)
            {
                gmSave.startDate = DateTime.Now.Date.ToString();
                gmSave.dailyQuestValue = new int[1];
                gmSave.dailyQuestType = new string[1];
                gmSave.dailyQuestComplited = new bool[1];
                gmSave.dailyQuestOpend = new bool[1];
                toDoFirstOpen?.Invoke();
                Debug.Log("Start Date 1 " +  gmSave.startDate);
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            GameManager.instance.GMPOERUPS.Clear();
        }
    }

    private void Start()
    {
        if(instance.GMSave.today == string.Empty)
        {
            instance.GMSave.today = DateTime.Now.Date.ToString();
        }
        Debug.Log("Readed Data " + LimpiarAmPm(instance.GMSave.today) + " " + DateTime.Now.Date);
        if ((DateTime.Now.Date) != DateTime.Parse(LimpiarAmPm(instance.GMSave.today)))
        {
            instance.GMSave.today = DateTime.Now.Date.ToString();
            toDoNotTodayDate?.Invoke();
        }

        toDoOnStart?.Invoke();
    }

    public static string LimpiarAmPm(string fechaTexto)
    {
        if (string.IsNullOrWhiteSpace(fechaTexto)) return fechaTexto;

        // --- Explicación del Regex ---
        // \s* -> Busca cero o más espacios antes del marcador.
        // [ap] -> Busca la letra 'a' O la letra 'p'.
        // \.?  -> Busca un punto opcional (puede estar o no).
        // \s* -> Busca espacios opcionales entre las letras (para casos como "a. m.").
        // m    -> Busca la letra 'm'.
        // \.?  -> Busca un punto final opcional.
        // $    -> Asegura que esto esté al final de la cadena.
        string patronRegex = @"\s*[ap]\.?\s*m\.?$";

        // RegexOptions.IgnoreCase: Hace que no importe si es mayúscula o minúscula.
        // Reemplazamos lo que encuentre por "" (cadena vacía).
        string resultado = Regex.Replace(fechaTexto, patronRegex, "", RegexOptions.IgnoreCase);

        // Trim() final para asegurar que no queden espacios raros al principio o final.
        return resultado.Trim();
    }

    public void SetUpDificultyM()
    {
        SetUpDificulty?.Invoke(mDificulty);
    }

    public GMDificulty GAMEDIFICULTY
    {
        get { return mDificulty; }
    }

    public List<GameObject> GMPOERUPS
    {
        get { return powerUps; }
    }

    public ChallengeType GMChallengeType
    {
        set{challengeType = value;}
        get { return challengeType; }
    }

    public string GMDateFormat
    {
        get { return dateFormat; }
    }

    public GMSave GMSave
    {
        set { gmSave = value; }
        get { return gmSave; }
    }

    public string ToDayDynamicQuiest
    {
        get { return todayDynamicQuest; }
        set { todayDynamicQuest = value; }
    }

    public static event Action<GMDificulty> SetUpDificulty;


}
