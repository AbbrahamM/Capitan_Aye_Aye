using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GMLoadSave", menuName = "Scriptable Objects/Game Manager/Load&Save/GMLoadSave")]
public class GMLoadSave : ScriptableObject
{
    public void LoadData(string path)
    {
        Debug.Log("Path " + Application.persistentDataPath + "/"+path);

        if (File.Exists(Application.persistentDataPath + "/"+path))
        {
            using StreamReader reader = new(Application.persistentDataPath + "/" + path);
            string line = "";
            while (reader.Peek() >= 0)
            {
                line += reader.ReadLine();
            }
            reader.Close();
            byte[] bytes = Convert.FromBase64String(line);

            string read = Encoding.ASCII.GetString(bytes);
            

            Debug.Log("Readed Data " + read);

            GameManager.instance.GMSave = JsonUtility.FromJson<GMSave>(read);

            if (GameManager.instance.GMSave.dailyQuestOpend == null || GameManager.instance.GMSave.dailyQuestOpend.Length <= 0)
            {
                GameManager.instance.GMSave.dailyQuestOpend = new bool[GameManager.instance.GMSave.dailyQuestType.Length];
                for (int i = 0; i < GameManager.instance.GMSave.dailyQuestOpend.Length;i++)
                {
                    GameManager.instance.GMSave.dailyQuestOpend[i] = false;
                }
            }else if(GameManager.instance.GMSave.dailyQuestOpend.Length < GameManager.instance.GMSave.dailyQuestType.Length)
            {
                bool[] opened = new bool[GameManager.instance.GMSave.dailyQuestOpend.Length];
                GameManager.instance.GMSave.dailyQuestOpend.CopyTo(opened, 0);

                GameManager.instance.GMSave.dailyQuestOpend = new bool[GameManager.instance.GMSave.dailyQuestType.Length];

                opened.CopyTo(GameManager.instance.GMSave.dailyQuestOpend, 0);
                for (int i = opened.Length; i < GameManager.instance.GMSave.dailyQuestType.Length; i++)
                {
                    GameManager.instance.GMSave.dailyQuestOpend[i] = false;
                }
            }
            if (!GameManager.instance.GMSave.powerUps.Contains("Dash"))
            {
                string[] tmpPowerUps = new string[GameManager.instance.GMSave.powerUps.Length + 1];
                int[] tmpPowerUpsIndex = new int[GameManager.instance.GMSave.powerUpsIndex.Length + 1];
                GameManager.instance.GMSave.powerUps.CopyTo(tmpPowerUps, 0);
                GameManager.instance.GMSave.powerUpsIndex.CopyTo(tmpPowerUpsIndex, 0);
                tmpPowerUps[tmpPowerUps.Length - 1] = "Dash";
                tmpPowerUpsIndex[tmpPowerUpsIndex.Length - 1] = 0;

                GameManager.instance.GMSave.powerUps = new string[tmpPowerUps.Length];
                GameManager.instance.GMSave.powerUpsIndex = new int[tmpPowerUpsIndex.Length];

                tmpPowerUps.CopyTo(GameManager.instance.GMSave.powerUps, 0);
                tmpPowerUpsIndex.CopyTo(GameManager.instance.GMSave.powerUpsIndex, 0);
            }
            GameManager.instance.GMSave.dynamicQuest = false;
            Debug.Log("Data " + reader.ToString());
            ///GameManager.instance.GMSave.coinsToUse = 50;
        }
        
    }

    public void SaveData(string path)
    {
        if (File.Exists(Application.persistentDataPath + "/" + path))
        {
            File.Delete(Application.persistentDataPath + "/" + path);
        }

        Debug.Log("Data to save " + JsonUtility.ToJson(GameManager.instance.GMSave));
        byte[] bytes = Encoding.ASCII.GetBytes(JsonUtility.ToJson(GameManager.instance.GMSave));


        using StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + path);
        writer.Write(Convert.ToBase64String(bytes));
        writer.Close();
    }
}
