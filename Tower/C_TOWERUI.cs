using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.U2D;

public class C_TOWERUI : MonoBehaviour {

    [SerializeField]
    private bool m_bIsClick = false;
    [SerializeField]
    private GameObject m_goLoadUi;
    private GameObject m_goUi;

    [SerializeField]
    private Text m_txtDms;
    [SerializeField]
    private Text m_txtTas;
    [SerializeField]
    private Text m_txtDtc;
    private Text m_txtName;
    private Image m_imgTower;
    

    public void OnMouseDown()
    {
        if (!m_bIsClick)
        {
            m_bIsClick = true;
        }
        else
        {
            m_bIsClick = false;
        }
    }

    void Awake()
    {
        m_goLoadUi = (GameObject)Resources.Load("TowerUUI");
        m_goUi = Instantiate(m_goLoadUi);//, transform.position + new Vector3(0.0f, 4.0f, 0.0f), Quaternion.identity);
        m_goUi.GetComponent<CanvasGroup>().alpha = 0.0f;
        m_goUi.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //m_goUi.transform.Rotate(60.0f, -40.0f, 0.0f);
        //m_goUi.GetComponent<RectTransform>().localPosition = new Vector3(550.0f, 200.0f, 0.0f);


        m_txtDms = m_goUi.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>();
        m_txtDtc = m_goUi.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
        m_txtTas = m_goUi.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>();
        m_txtName = m_goUi.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        m_imgTower = m_goUi.transform.GetChild(0).GetChild(2).GetComponent<Image>();
        

    }

    void Start()
    {
        GameObject goUiHolder = GameObject.Find("UiHolder");

        m_goUi.transform.SetParent(goUiHolder.transform);

        m_goUi.GetComponent<RectTransform>().anchorMax = new Vector2(1.0f, 1.0f);
        m_goUi.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 0.0f);

        m_goUi.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, 0.0f);
        m_goUi.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, 0.0f);
        m_goUi.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
        if (m_bIsClick)
        {
            m_goUi.GetComponent<CanvasGroup>().alpha = 1.0f;
            m_goUi.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            m_goUi.GetComponent<CanvasGroup>().alpha = 0.0f;
            m_goUi.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        
    }
    void OnDestroy()
    {
        Destroy(m_goUi);
    }

    public bool getIsClick()
    {
        return m_bIsClick;
    }
    public void TurnIsClock()
    {
        if (!m_bIsClick)
        {
            m_bIsClick = true;
        }
        else
        {
            m_bIsClick = false;
        }
    }

    public void offUi()
    {
        m_bIsClick = false;
    }

    public void SetText(float fStriking, float fDownrange, float AttackSpeed)
    {
        m_txtDms.text = "데미지:" + fStriking.ToString("N1");
        m_txtDtc.text = "사정거리:" + fDownrange.ToString("N1");
        m_txtTas.text = "공격속도:" + AttackSpeed.ToString("N1");
        m_txtDtc.fontSize = m_txtDms.fontSize;
        m_txtTas.fontSize = m_txtDms.fontSize;

        m_txtName.text = gameObject.name;
        //m_txtName.text = gameObject.name.Substring(2);

        Sprite[] m_spTowerImage = Resources.LoadAll<Sprite>("TowerSelect");
        int nIndex = int.Parse(m_txtName.text.Substring(5));
        if (nIndex < 24)
        {
            m_imgTower.sprite = m_spTowerImage[nIndex];
        }
        else
        {
            m_imgTower.sprite = m_spTowerImage[24];
        }
    }
}
