using System.Collections.Generic;
using UnityEngine;
public class AudioSyncerDrop : AudioSyncer
{
    public GameObject prefab;
    public List<float> termsList = new List<float>();
    public float a;
    public float time;
    private void FixedUpdate() {
        a+=Time.deltaTime;
    }
    public override void OnBeat()
    {
        base.OnBeat();
        Instantiate(prefab, transform.position, new Quaternion(0, 0, 0, 0));
        time = a;
        termsList.Add(time);
    }
    public void OnBPM()
    {
        Instantiate(prefab, transform.position, new Quaternion(0, 0, 0, 0));
    }
}