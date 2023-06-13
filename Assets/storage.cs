using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class storage
{
    private string filePath;
    
    private void Storage(string filePath)
    {
        this.filePath = Application.persistentDataPath + "/storage/gamedata.save";
    }
}
