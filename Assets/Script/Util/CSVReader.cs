using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

public class CSVReader : MonoBehaviourSingleton<CSVReader>
{
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";


    public List<Dictionary<string, object>> ReadNew(string file, Action<List<Dictionary<string, object>>> result)
    {
        string fileContent = "";

        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                {
                    string path = Application.streamingAssetsPath + "/" + file + ".csv";
                    StartCoroutine(Load(path, result));
                }
                break;
            case RuntimePlatform.IPhonePlayer:
                {
                    //string path = Application.streamingAssetsPath + "/" + file + ".csv";
                }
                break;
            default:
                {
                    //string path = "file://"+ Application.streamingAssetsPath + "/" + file + ".csv";
                    //StartCoroutine(Load(path, result));//

                    string path = Application.streamingAssetsPath + "/" + file + ".csv";
                    var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader fileStream = new StreamReader(fs, Encoding.Default);
                    fileContent = fileStream.ReadToEnd();
                    //Encoding fileEncoding = fileStream.CurrentEncoding;
                    fileStream.Close();

                    result(ParseData(fileContent));
                }
                break;
        }

        return null;
    }

    List<Dictionary<string, object>> ParseData(string fileContent)
    {
        var list = new List<Dictionary<string, object>>();
        var lines = Regex.Split(fileContent, LINE_SPLIT_RE);

        if (lines.Length <= 1)
            return list;

        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "")
                break;

            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                object finalvalue = value;
                int n;
                float f;

                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }

                entry[header[j]] = finalvalue;
            }

            list.Add(entry);
        }

        return list;
    }

    IEnumerator Load(string path, Action<List<Dictionary<string, object>>> result)
    {
        WWW data = new WWW(path);
        yield return data;

        Debug.Log(path);

        int euckrCodepage = 51949;
        Encoding utf8 = Encoding.UTF8;
        Encoding euckr = Encoding.GetEncoding(euckrCodepage);

        byte[] ansibytes = Encoding.Convert(euckr, utf8, data.bytes);
        string fileContent = utf8.GetString(ansibytes);


        result(ParseData(fileContent));
    }
}