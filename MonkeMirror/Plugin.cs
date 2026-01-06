using BepInEx;
using MonkeMirror.Tools;
using System.Threading.Tasks;
using UnityEngine;

namespace MonkeMirror
{
    [BepInPlugin(Constants.GUID, Constants.NAME, Constants.VERS)]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject _GSPrefab;

        void Awake() =>
            GorillaTagger.OnPlayerSpawned(async () => await SetupModel());

        async Task SetupModel()
        {
            try
            {
                _GSPrefab = await AssetLoader.LoadAsset<GameObject>("MonkeMirror");

                if (_GSPrefab == null)
                {
                    Debug.LogError("[GS]: Failed to load MonkeMirror prefab.");
                    return;
                }

                var gsInstance = Instantiate(_GSPrefab);
                gsInstance.SetActive(true);
                gsInstance.transform.position = new Vector3(-68.3047f, 11.29f, -83.1664f);
                gsInstance.transform.rotation = Quaternion.Euler(0f, 58.0552f, 0f);
            }
            catch (System.Exception e)
            {
                Debug.LogError("[GS]: Error setting up model.\n" + e);
            }
        }
    }

    public class Constants
    {
        public const string GUID = "goat.monkemirror";
        public const string NAME = "MonkeMirror";
        public const string VERS = "1.0.0";
    }
}
