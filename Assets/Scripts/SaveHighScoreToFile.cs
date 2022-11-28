using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveHighScoreToFile : MonoBehaviour
{
    
    public static void Save(HighScoreData data)
    {
        try
        {
            //convert data to json format 
            var json = JsonUtility.ToJson(data);
            //get a file path and a format to save in
            var path = Application.dataPath + "/HighScore.txt";
            //the class that writes the file
            var writer = new StreamWriter(path, false);
            //the code that saves the actual file
            writer.Write(json);
            //Always close a writer after your done with it
            writer.Close();
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e);
        }
    }

    public static HighScoreData Load()
    {
        try
        {
            //get a file path
            var path = Application.dataPath + "/HighScore.txt";
            //the class that reads the file
            var reader = new StreamReader(path);
            //reads the whole file at once
            var file = reader.ReadToEnd();
            var data = JsonUtility.FromJson<HighScoreData>(file);
            reader.Close();
            return data;
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("No file found " + e);
            return new HighScoreData();
        }
    }
}
