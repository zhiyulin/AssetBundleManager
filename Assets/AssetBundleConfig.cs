using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleConfig : MonoBehaviour {

    // assetbundle打包路径
    public static string ASSETBUNDLE_PATH = Application.dataPath +
        "/StreamingAssets/AssetBundle/";

    // 资源地址
    public static string APPLICATION_PATH = Application.dataPath + "/";

    // 工程地址
    public static string PROJECT_PATH =
        APPLICATION_PATH.Substring(0, APPLICATION_PATH.Length - 7);

    // AssetBundle存放的文件夹名
    public static string ASSETBUNDLE_FILENAME = "AssetBundle";

    // AssetBundle打包的后缀名
    public static string SUFFIX = ".unity3d";



    // manifest文件后缀
    public static string MANIFEST_SUFFIX = ".manifest";
}
