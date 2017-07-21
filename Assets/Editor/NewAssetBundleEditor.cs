using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewAssetBundleEditor : Editor {

	[MenuItem ("New AB Editor/Build AssetBundles")]

    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(
            AssetBundleConfig.ASSETBUNDLE_PATH.Substring(AssetBundleConfig.PROJECT_PATH.Length),
            BuildAssetBundleOptions.UncompressedAssetBundle |
            BuildAssetBundleOptions.CollectDependencies |
            BuildAssetBundleOptions.DeterministicAssetBundle,
            BuildTarget.StandaloneWindows64);
    }
}
