using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Utils
{
    public class AddressableAsset<T> : IDisposable where T : UnityEngine.Object
    {
        AssetReference _reference;

        public T Asset { get; private set; }

        bool IsMonoBehaviour => typeof(T).IsSubclassOf(typeof(MonoBehaviour));

        public AddressableAsset(AssetReference reference)
        {
            _reference = reference;
        }

        AsyncOperationHandle _handle;

        public async UniTask<T> Load()
        {
            return IsMonoBehaviour? await LoadMonoBehaviour() : await LoadGeneric();
        }

        async UniTask<T> LoadMonoBehaviour() 
        {
            _handle = Addressables.LoadAssetAsync<GameObject>(_reference);
            await _handle.ToUniTask();
            GameObject rawAsset = (GameObject) _handle.Result;

            if(!rawAsset.TryGetComponent(out T result))
            {
                Release();
                throw new Exception($"[Error] {typeof(T)} Component was not found in the prefab {rawAsset.name}");
            }

            Asset = result;
            return Asset;
        }

        async UniTask<T> LoadGeneric()
        {
            _handle = Addressables.LoadAssetAsync<T>(_reference);
            await _handle.ToUniTask();
            Asset = (T)_handle.Result;
            return Asset;
        }

        public void Release()
        {
            Addressables.Release(_handle);
        }

        public void Dispose()
        {
            Release();
        }
    }

}
