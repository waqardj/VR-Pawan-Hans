using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CsvReadWrite : Singleton<CsvReadWrite>
{

    public List<string[]> rowDataScore = new List<string[]>();
    public List<string[]> rowDataAnalytics = new List<string[]>();
    string folderPathScore,folderPathAnalytics;
    string filePath_Score,filePath_Analytics;


    // Use this for initialization
    void Start()
    {
        folderPathScore = getPath(csvType.score);
        folderPathAnalytics = getPath(csvType.analytics);

        filePath_Score = folderPathScore + "Score.csv";
        filePath_Analytics = folderPathAnalytics + "Analytics.csv";
        StartCoroutine(CreateOrEditScore("Name","Id","Score"));
        StartCoroutine(CreateOrEditAnalytics("Name", "Id", "PBO","CKMF","PMF","CHMF"));// Change field 
    }

    public void SaveScore(string Name, string Id, string Score)
    {
        StartCoroutine(CreateOrEditScore(Name, Id, Score));
    }

    public void SaveAnalytics(string Name, string Id, string PBO,string CKMF,string PMF,string CHMF)
    {
        StartCoroutine(CreateOrEditAnalytics(Name, Id,PBO,CKMF,PMF,CHMF));
    }

    /// <summary>
    /// If file exist edit the data or if not create a new file
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateOrEditScore(string Name,string Id,string Score)
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = Name;
        rowDataTemp[1] = Id;
        rowDataTemp[2] = Score;
        


        
        if (!Directory.Exists(folderPathScore))
        {
            //Debugger.instance.AddLog("dIRECTORY nOT EXIST");
            rowDataScore.Add(rowDataTemp);
            Directory.CreateDirectory(folderPathScore);
            while (!Directory.Exists(folderPathScore))
            {
                yield return null;
            }

            string[][] output = new string[rowDataScore.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataScore[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter outStream = System.IO.File.CreateText(filePath_Score);
            outStream.WriteLine(sb);
            outStream.Close();

        }
        else
        {
            //Debugger.instance.AddLog("dIRECTORY EXIST");

            rowDataScore.Clear();
            string[] lines = File.ReadAllLines(filePath_Score);
            foreach(string line in lines)
            {
                if(line.Contains(","))
                {
                    string[] filed = line.Split(',');
                    rowDataScore.Add(filed);
                    //print(filed[0]);
                }
            }
            //print(rowDataScore.Count);
            bool alreayexist = false;
            for (int i = 0; i < rowDataScore.Count; i++)
            {
                string[] row = rowDataScore[i];
                if(row[1]==Id)
                {
                    row[2] = Score;
                    row[0] = Name;
                    rowDataScore[i] = row;
                    alreayexist = true;

                }
            }
            if(!alreayexist)
                rowDataScore.Add(rowDataTemp);
            
            string[][] output = new string[rowDataScore.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataScore[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter myStream = new StreamWriter(filePath_Score, false);
            myStream.Write(sb);
            myStream.Close();

        }
        yield return new WaitForEndOfFrame();

    }

    IEnumerator CreateOrEditAnalytics(string Name, string Id, string PBO,string CKMF,string PMF,string CHMF)
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[6];
        rowDataTemp[0] = Name;
        rowDataTemp[1] = Id;
        rowDataTemp[2] = PBO;
        rowDataTemp[3] = CKMF;
        rowDataTemp[4] = PMF;
        rowDataTemp[5] = CHMF;




        if (!Directory.Exists(folderPathAnalytics))
        {
            //Debugger.instance.AddLog("dIRECTORY nOT EXIST Analytics");
            rowDataAnalytics.Add(rowDataTemp);
            Directory.CreateDirectory(folderPathAnalytics);
            while (!Directory.Exists(folderPathAnalytics))
            {
                yield return null;
            }

            string[][] output = new string[rowDataAnalytics.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataAnalytics[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter outStream = System.IO.File.CreateText(filePath_Analytics);
            outStream.WriteLine(sb);
            outStream.Close();

        }
        else
        {
            //Debugger.instance.AddLog("dIRECTORY EXIST Analytics");

            rowDataAnalytics.Clear();
            string[] lines = File.ReadAllLines(filePath_Analytics);
            foreach (string line in lines)
            {
                if (line.Contains(","))
                {
                    string[] filed = line.Split(',');
                    rowDataAnalytics.Add(filed);
                    //print(filed[0]);
                }
            }
            //print(rowDataAnalytics.Count);
            bool alreayexist = false;
            for (int i = 0; i < rowDataAnalytics.Count; i++)
            {
                string[] row = rowDataAnalytics[i];
                if (row[1] == Id)
                {
                    row[2] = PBO;
                    row[3] = CKMF;
                    row[4] = PMF;
                    row[5] = CHMF;
                    row[0] = Name;
                    rowDataAnalytics[i] = row;
                    alreayexist = true;

                }
            }
            if (!alreayexist)
                rowDataAnalytics.Add(rowDataTemp);

            string[][] output = new string[rowDataAnalytics.Count][];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = rowDataAnalytics[i];
            }

            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimiter, output[index]));

            StreamWriter myStream = new StreamWriter(filePath_Analytics, false);
            myStream.Write(sb);
            myStream.Close();

        }
        yield return new WaitForEndOfFrame();

    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(csvType type)
    {
        if(type==csvType.score)
        {
#if UNITY_EDITOR
            return Application.dataPath + "/CSV_Score/";
#elif UNITY_ANDROID
        return Application.persistentDataPath + "/CSV_Score/";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
        }
        else if(type==csvType.analytics)
        {
#if UNITY_EDITOR
            return Application.dataPath + "/CSV_Analytics/";
#elif UNITY_ANDROID
        return Application.persistentDataPath + "/CSV_Analytics/";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
        }
        else
        {
            return "none";
        }

    }
}
enum  csvType
{
    score,
    analytics

}
