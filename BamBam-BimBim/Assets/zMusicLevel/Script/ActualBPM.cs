using UnityEngine;
public class ActualBPM : MonoBehaviour
{
    public float secPerBeat;
    public float value;
    public float posInTrack;
    public BPM bpm;
    private void Start()
    {
        bpm = BPM.instance;
        secPerBeat = 60 / bpm.songBpm;
    }
    void Update()
    {
        posInTrack += Time.deltaTime / secPerBeat;
        if(posInTrack>1)
        {
            posInTrack = 0;
            value++;
        }
        switch(value)
        {
            case > 1:
                value = 1;
                break;
            case <-1:
                value = -1;
                break;
        }
    }
}