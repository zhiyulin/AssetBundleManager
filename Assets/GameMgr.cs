using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    // abName ab
    public Dictionary<string, AssetBundle> abDic = new Dictionary<string, AssetBundle>();
    // resName abName
    public Dictionary<string, string> nameDic = new Dictionary<string, string>();

    private static AssetBundleManifest manifest = null;
    // 测试的加载位置
    // Torch_red
    Vector3 pos = new Vector3(-0.366f, -0.81f, -0.23f);
    // cube_green
    Vector3 pos2 = new Vector3(-0.35f, -0.554625f, -2.661f);
    // Torch_green
    Vector3 pos3 = new Vector3(-1.01f, -0.81f, -0.23f);
    // cube_white
    Vector3 pos4 = new Vector3(-2.08f, -0.554f, -2.661f);

	// Use this for initialization
	void Start () {
         
        StartCoroutine(init());
    }

    IEnumerator init()
    {
        

        NewAssetBundleLoad.Init();
        yield return new WaitForSecondsRealtime(2);
        //NewAssetBundleLoad.Clear();
        Object a = NewAssetBundleLoad.LoadObj("BG@2x");
        Debug.Log(a);

        //NewAssetBundleLoad.Clear();

        Object a2 = NewAssetBundleLoad.LoadObj("bg_b@2x");
        Debug.Log(a2);

        //NewAssetBundleLoad.Clear();


        yield return new WaitForSecondsRealtime(2);
        Object cubeGreenObj = NewAssetBundleLoad.LoadObj("cube_green");
        Debug.Log(cubeGreenObj);
        GameObject.Instantiate(cubeGreenObj);

        yield return new WaitForSecondsRealtime(2);

        Object Torch_redObj = NewAssetBundleLoad.LoadObj("torch_red");
        GameObject.Instantiate(Torch_redObj);

        yield return new WaitForSecondsRealtime(2);
        Object Torch_green = NewAssetBundleLoad.LoadObj("torch_green");
        GameObject.Instantiate(Torch_green);

        yield return new WaitForSecondsRealtime(2);
        Object Torch_green2 = NewAssetBundleLoad.LoadObj("torch_green");
        GameObject.Instantiate(Torch_green2);

        yield return new WaitForSecondsRealtime(2);

        Object cube_white = NewAssetBundleLoad.LoadObj("cube_white");
        GameObject.Instantiate(cube_white);

        Resources.UnloadUnusedAssets();

        //NewAssetBundleLoad.Clear();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
