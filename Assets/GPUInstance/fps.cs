using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class fps : MonoBehaviour {
    
    public static fps instance { get; private set; }
    // Use this for initialization
    public float fpsMeasuringDelta = 0.5f;
    GUIStyle m_HeadStyle = new GUIStyle();
    Rect m_ShowRect;
    public int FontSize = 40;
    private float timePassed;
    private int m_FrameCount = 0;
    private float m_FPS = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform.root);
        instance = this;
        m_HeadStyle.fontSize = FontSize;
        m_HeadStyle.normal.textColor = Color.red;
        m_ShowRect = new Rect(0, 0, Screen.width, FontSize);
        Application.targetFrameRate = 120;
    }
    private void Start()
    {
        timePassed = 0.0f;
    }

    private void Update()
    {
        m_FrameCount = m_FrameCount + 1;
        timePassed = timePassed + Time.deltaTime;

        if (timePassed > fpsMeasuringDelta)
        {
            m_FPS = m_FrameCount / timePassed;

            timePassed = 0.0f;
            m_FrameCount = 0;
        }
    }
    private void OnGUI()
    {        
        GUI.Label(m_ShowRect, "FPS: " + m_FPS.ToString("0.0"), m_HeadStyle);
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
