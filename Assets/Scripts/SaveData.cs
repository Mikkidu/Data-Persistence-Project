using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveData : MonoBehaviour
{

    public static SaveData Instance;
    public Score bestScore = new Score();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    public class Score
    {
        public string bestPlayerName = "Nobody";
        public int bestScore = 0;
        public string lastPlayer = "Nobody";

        public void Save()
        {
            bestPlayerName = lastPlayer;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore()
    {
        Score data = bestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestScore = JsonUtility.FromJson<Score>(json);
        }
    }

}
