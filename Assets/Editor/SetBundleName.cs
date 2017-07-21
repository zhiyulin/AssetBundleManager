using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetBundleName : Editor {

    [MenuItem("SetBundleName/SetBundleName")]

    static void Go()
    {
        Object[] selects = Selection.objects;
        foreach(Object selected in selects)
        {
            Debug.Log(selected.name);
            string path = AssetDatabase.GetAssetPath(selected);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            selected.name = selected.name+"*"+asset.assetBundleName
                + asset.assetBundleVariant  ;
        }
    }
}

public class ResetBundleName : Editor{
    [MenuItem("SetBundleName/ResetBundleName")]

    static void Go (){
        Object[] selects = Selection.objects;
        foreach (Object selected in selects)
        {
            Debug.Log(selected.name);
            string path = AssetDatabase.GetAssetPath(selected);
            AssetImporter asset = AssetImporter.GetAtPath(path);
            selected.name = asset.assetBundleName
                + asset.assetBundleVariant + "_" + selected.name;
        }
    }
}
