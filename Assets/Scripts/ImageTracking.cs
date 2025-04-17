using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTracking : MonoBehaviour
{

    [SerializeField] List<GameObject> prefabsToSpawn = new List<GameObject>();
    // [SerializeField]
    private ARTrackedImageManager _trackedImageManager;

    // [SerializeField]
    // private GameObject prefabToInstantiate;
    private Dictionary<string, GameObject> _arObjects; 

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private void Start(){
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        if(_trackedImageManager == null) return;
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        _arObjects = new Dictionary<string, GameObject>();
        SetUpSceneElements();
    }
    private void OnDestroy(){
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void SetUpSceneElements(){
        foreach(var prefab in prefabsToSpawn){
            var arObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            arObject.name = prefab.name;
            arObject.gameObject.SetActive(false);
            _arObjects.Add(arObject.name, arObject);

        }
    }
    // private void OnEnable()
    // {
    //     _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    // }

    // private void OnDisable()
    // {
    //     _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    // }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // var newPrefab = Instantiate(prefabToInstantiate, trackedImage.transform.position, trackedImage.transform.rotation);
            // newPrefab.transform.parent = trackedImage.transform;
            // spawnedPrefabs[trackedImage.referenceImage.name] = newPrefab;
            UpdateTrackedImages(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateTrackedImages(trackedImage);

            // if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out var prefab))
            // {
            //     prefab.SetActive(trackedImage.trackingState == TrackingState.Tracking);
            // }
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            if (_arObjects.TryGetValue(trackedImage.referenceImage.name, out var arObject))
            {
                arObject.SetActive(false);
            }
            // UpdateTrackedImages(trackedImage.Value);
            // if (spawnedPrefabs.TryGetValue(trackedImage.referenceImage.name, out var prefab))
            // {
            //     Destroy(prefab);
            //     spawnedPrefabs.Remove(trackedImage.referenceImage.name);
            // }
        }
    }

    private void UpdateTrackedImages(ARTrackedImage trackedImage){
        if(trackedImage == null) return;
        
        if (trackedImage.trackingState == TrackingState.Limited || trackedImage.trackingState == TrackingState.None)
        {
            if (_arObjects.TryGetValue(trackedImage.referenceImage.name, out var arObject))
            {
                arObject.SetActive(false);
            }
            return;
        }
    if (_arObjects.TryGetValue(trackedImage.referenceImage.name, out var trackedObject))
        {
        trackedObject.SetActive(true);
        trackedObject.transform.position = trackedImage.transform.position;
        trackedObject.transform.rotation = trackedImage.transform.rotation;
        }

    }
}
