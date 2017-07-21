using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NewAssetBundleLoad : MonoBehaviour {

    // 总manifest
    private static AssetBundleManifest manifest = null;
    // 资源名--包名
    private static Dictionary<string, string> aabRelaDic = new Dictionary<string, string>();
    // 包名--包
    private static Dictionary<string, AssetBundle> abDic = new Dictionary<string, AssetBundle>();
    // 资源名--资源路径
    private static Dictionary<string, string> nameUrlRelaDic = new Dictionary<string, string>();

    public static void Init()
    {
        // 加载总manifest 
        if(manifest == null)
        {
            AssetBundle manifestBundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH +
                AssetBundleConfig.ASSETBUNDLE_FILENAME);
            
            manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
        }
        if (manifest != null)
        {
            string[] abNameArr = manifest.GetAllAssetBundles();
            // 从总manifest获得所有assetbundle包名 作为key存入字典
            foreach(string str in abNameArr)
            {
                //abDic.Add(str, null);
               // StringBuilder sb = new StringBuilder();
                //sb.Append(str).Append(AssetBundleConfig.MANIFEST_SUFFIX);
                
                AssetBundle bundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + str);
                //abDic.Add(str, bundle);
                abDic.Add(bundle.name, bundle);

                //foreach(KeyValuePair<string,AssetBundle> a in abDic)
                //{
                //    Debug.Log(a.Key + " " + a.Value);
                //}

                string[] sss = bundle.GetAllAssetNames();
                foreach(string s in sss)
                {
                    Debug.Log("str:" + str + " s:" + s);
                    //abDic.Add(s, bundle);
                    
                   // if(!abDic.ContainsKey(bundle.name))
                    

                    int index = s.LastIndexOf("/");
                    //    //if (index == -1)
                    //    //    index = abName.Length;


                    string realName = s.Substring(index + 1);
                    int index2 = realName.LastIndexOf(".");
                    realName = realName.Substring(0, index2);
                    nameUrlRelaDic.Add(realName, s);
                    aabRelaDic.Add(realName, bundle.name);
                    //Debug.Log("realName:" + realName);
                }
            }

            //foreach(KeyValuePair<string,string> dp in nameRelaDic)
            //{
            //    Debug.Log("dp:" + dp.Key + " v:" + dp.Value);
            //}
        }

        Debug.Log("==================== abDic ==============================");
        foreach (KeyValuePair<string, AssetBundle> dp in abDic)
        {
            Debug.Log("dp:" + dp.Key + " v:" + dp.Value);
        }

        Debug.Log("======================= nameUrlRelaDic ===========================");

        foreach (KeyValuePair<string, string> dp in nameUrlRelaDic)
        {
            Debug.Log("dp:" + dp.Key + " v:" + dp.Value);
        }

        Debug.Log("======================= aabRelaDic ===========================");


        foreach (KeyValuePair<string, string> dp in aabRelaDic)
        {
            Debug.Log("dp:" + dp.Key + " v:" + dp.Value);
        }
    }

    public static Object LoadObj(string objName)
    {
        //string realName;
        //nameUrlRelaDic.TryGetValue(objName, out realName);
        //Debug.Log("name:" + objName + " realName:" + realName);

        objName = objName.ToLower();

        Object obj = null;

        //AssetBundle ab;
        //abDic.TryGetValue(realName, out ab);

        //if (ab == null)
        //    ab = LoadBundle(objName);

        //obj = ab.LoadAsset(realName);

        // 通过资源名得到资源路径
        string url;
        nameUrlRelaDic.TryGetValue(objName, out url);
        if (url == null)
            return null;
        // 通过资源名得到包名
        string abName;
        aabRelaDic.TryGetValue(objName, out abName);
        if (abName == null)
            return null;

        // 通过包名得到包
        AssetBundle ab;
        abDic.TryGetValue(abName, out ab);
        if (ab == null)
            ab = LoadBundle(abName);

        obj = ab.LoadAsset(objName);

        return obj;
    }

    public static AssetBundle LoadBundle(string abName)
    {
        // 加载总manifest 
        //if (manifest == null)
        //{
        //    AssetBundle manifestBundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH +
        //        AssetBundleConfig.ASSETBUNDLE_FILENAME);

        //    manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
        //}
        //else
        //{

        //}

       

        AssetBundle bundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH +
                    abName);

        if (abDic.ContainsKey(abName))
            abDic[abName] = bundle;
        else
            abDic.Add(abName, bundle);

        return bundle;

        //if(abDic.ContainsKey("objName"))
    }

    public static void Clear()
    {
        foreach(KeyValuePair<string,AssetBundle> ab in abDic)
        {
            if(ab.Value != null)
            ab.Value.Unload(true);
        }
    }

    //public static AssetBundle LoadAB(string abPath)
    //{
    //    if (abDic.ContainsKey(abPath) == true)
    //        return abDic[abPath];
    //    if(manifest == null)
    //    {
    //        AssetBundle manifestBundle = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH +
    //            AssetBundleConfig.ASSETBUNDLE_FILENAME);
    //        manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
    //    }
    //    if(manifest != null)
    //    {
    //        // 获取依赖文件列表
    //        string[] cubedepends = manifest.GetAllDependencies(abPath);

    //        for(int index = 0; index < cubedepends.Length; index++)
    //        {
    //            LoadAB(cubedepends[index]);
    //        }

    //        // 加载资源
    //        abDic[abPath] = AssetBundle.LoadFromFile(AssetBundleConfig.ASSETBUNDLE_PATH + abPath);

    //        return abDic[abPath];
    //    }
    //    return null;
    //}

    //public static Object LoadGameObject(string abName)
    //{
    //    string abPath = abName + AssetBundleConfig.SUFFIX;

    //    //int index = abName.LastIndexOf("/");
    //    //if (index == -1)
    //    //    index = abName.Length;
        

    //    //string realName = abName.Substring(index + 1, abName.Length - index - 1);

    //    //Debug.Log(realName);
        
    //    LoadAB(abPath);
    //    Debug.Log("abPath : " + abPath);
    //    Debug.Log("abName : " + abName);
    //    if(abDic.ContainsKey(abPath) && abDic[abPath] != null)
    //    {
    //        //return abDic[abPath].LoadAsset(realName);
    //        return abDic[abPath].LoadAsset(abName);
    //    }
    //    return null;
    //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abName">具体资源名称</param>
        /// <returns></returns>
    public static Object LoadGameObject(string abName)
    {
        //LoadAB(abName + AssetBundleConfig.SUFFIX);

        foreach (KeyValuePair<string,AssetBundle> ab in abDic)
        {
            Debug.Log("ab : " + ab + " " + "ab.v : " + ab.Value + " " + ab.GetHashCode());
        }

        return null;
    }
}
