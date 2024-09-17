using UnityEngine;
public class AudioSpectrum : MonoBehaviour 
{
    public static int SV;
    public static float spectrumValue { get; private set; }
    [HideInInspector]
    public float[] m_audioSpectrum;
    public AudioSource source;
    private void Update()
    {
        SV = (int)spectrumValue;
        source.GetOutputData(m_audioSpectrum, 1);
        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 100;
        }
    }
    private void Start()
    {
        source.PlayScheduled(AudioSettings.dspTime+1000);
        m_audioSpectrum = new float[128];
    }
}