using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TrackManager : MonoBehaviour
{
    public GameObject[] trackPrefabs;

    public float zSpawn = 0;

    public float trackLenght = 30;

    public int numberOfTracks = 4;

    public Transform playerTransform;

    private List<GameObject> activeTracks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTracks; i++)
        {
            if(i==0)
                SpawnTrack(0);
            else
                SpawnTrack(Random.Range(0,trackPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTracks * trackLenght))
        {
            SpawnTrack(Random.Range(0,trackPrefabs.Length));
            DeleteTrack();
        } 
    }

    public void SpawnTrack(int trackIndex)
    {
        GameObject go = Instantiate(trackPrefabs[trackIndex], transform.forward * zSpawn, transform.rotation);
        activeTracks.Add(go);
        zSpawn += trackLenght;
    }

    private void DeleteTrack()
    {
        Destroy(activeTracks[0]);
        activeTracks.RemoveAt(0);
    }
}
