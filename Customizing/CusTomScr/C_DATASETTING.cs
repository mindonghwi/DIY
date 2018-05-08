using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_DATASETTING : MonoBehaviour {

    private Slider[] m_arSliderData;
    private Text[] m_arTxtSliderData;
    private Button[] m_arBtnMinus;
    private Button[] m_arBtnPlus;

    private float[] m_fStrikingForGrade;
    private float[] m_fAttackSpeedForGrade;
    private float[] m_fTargetCountForGrade;
    private float[] m_fDownRangeForGrade;

    private int[] m_nTargetCountPointForGrade;

    private int m_nSAPointCount;
    private int m_nTDPointCount;

    private int m_nOldStrkingValue;
    private int m_nOldAttackSpeedValue;
    private int m_nOldTargetCountValue;
    private int m_nOldDownRangeForValue;

    public enum E_DATANUM
    {
        E_GRADE = 0,
        E_STRIKING,
        E_ATTACKSPEED,
        E_TAGETCOUNT,
        E_DOWNRANGE,
        E_MAX,
    }

    // Use this for initialization
    void Start () {

        m_arBtnMinus = new Button[(int)E_DATANUM.E_MAX];
        m_arBtnPlus = new Button[(int)E_DATANUM.E_MAX];
        m_arSliderData = new Slider[(int)E_DATANUM.E_MAX];
        m_arTxtSliderData = new Text[(int)E_DATANUM.E_MAX];

        settingUi();

        m_fAttackSpeedForGrade = new float[4];
        m_fDownRangeForGrade = new float[4];
        m_fStrikingForGrade = new float[4];
        m_fTargetCountForGrade = new float[4];

        m_nTargetCountPointForGrade = new int[4];

        settingData();

    }
	public void settingData()
    {
        for (int i = 0; i < 4; i++)
        {
            m_fAttackSpeedForGrade[i] = -0.0092f;
            m_fDownRangeForGrade[i] = 0.02f * (float)(i + 1);
            m_fTargetCountForGrade[i] = 0.02f * (i + 1);
            m_nTargetCountPointForGrade[i] = (int)(1.0f / m_fTargetCountForGrade[i]);
        }
        m_fStrikingForGrade[0] = 1.2f;
        m_fStrikingForGrade[1] = 2.5f;
        m_fStrikingForGrade[2] = 4.5f;
        m_fStrikingForGrade[3] = 8.0f;

        m_nSAPointCount = 100;
        m_nTDPointCount = 100;
    }
    private void settingUi()
    {
        for (int i = 6; i < 9; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        m_arSliderData[(int)E_DATANUM.E_GRADE] = GameObject.Find("GradeSliderSlider").GetComponent<Slider>();
        m_arTxtSliderData[(int)E_DATANUM.E_GRADE] = GameObject.Find("GradeNum").transform.GetChild(0).GetComponent<Text>();
        m_arBtnMinus[(int)E_DATANUM.E_GRADE] = GameObject.Find("MinusG").GetComponent<Button>();
        m_arBtnPlus[(int)E_DATANUM.E_GRADE] = GameObject.Find("PlusG").GetComponent<Button>();

        m_arSliderData[(int)E_DATANUM.E_STRIKING] = GameObject.Find("StrikingSliderSlider").GetComponent<Slider>();
        m_arTxtSliderData[(int)E_DATANUM.E_STRIKING] = GameObject.Find("StrikingNum").transform.GetChild(0).GetComponent<Text>();
        m_arBtnMinus[(int)E_DATANUM.E_STRIKING] = GameObject.Find("MinusS").GetComponent<Button>();
        m_arBtnPlus[(int)E_DATANUM.E_STRIKING] = GameObject.Find("PlusS").GetComponent<Button>();

        m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED] = GameObject.Find("AttackSpeedSliderSlider").GetComponent<Slider>();
        m_arTxtSliderData[(int)E_DATANUM.E_ATTACKSPEED] = GameObject.Find("AttackSpeedNum").transform.GetChild(0).GetComponent<Text>();
        m_arBtnMinus[(int)E_DATANUM.E_ATTACKSPEED] = GameObject.Find("MinusA").GetComponent<Button>();
        m_arBtnPlus[(int)E_DATANUM.E_ATTACKSPEED] = GameObject.Find("PlusA").GetComponent<Button>();

        m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT] = GameObject.Find("TargetCountSliderSlider").GetComponent<Slider>();
        m_arTxtSliderData[(int)E_DATANUM.E_TAGETCOUNT] = GameObject.Find("TagetCountNum").transform.GetChild(0).GetComponent<Text>();
        m_arBtnMinus[(int)E_DATANUM.E_TAGETCOUNT] = GameObject.Find("MinusT").GetComponent<Button>();
        m_arBtnPlus[(int)E_DATANUM.E_TAGETCOUNT] = GameObject.Find("PlusT").GetComponent<Button>();

        m_arSliderData[(int)E_DATANUM.E_DOWNRANGE] = GameObject.Find("DownRangeSliderSlider").GetComponent<Slider>();
        m_arTxtSliderData[(int)E_DATANUM.E_DOWNRANGE] = GameObject.Find("DownRangeNum").transform.GetChild(0).GetComponent<Text>();
        m_arBtnMinus[(int)E_DATANUM.E_DOWNRANGE] = GameObject.Find("MinusD").GetComponent<Button>();
        m_arBtnPlus[(int)E_DATANUM.E_DOWNRANGE] = GameObject.Find("PlusD").GetComponent<Button>();

        closeSettingUi();
    }
    private void closeSettingUi()
    {
        for (int i = 6; i < 9; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SettingSliderForGrade()
    {
        m_arTxtSliderData[(int)E_DATANUM.E_GRADE].text = m_arSliderData[(int)E_DATANUM.E_GRADE].value.ToString();

        m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].minValue = 1;
        m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].maxValue = 1 + (int)(100.0f * m_fTargetCountForGrade[(int)m_arSliderData[(int)E_DATANUM.E_GRADE].value - 1]);
        Debug.Log(m_fTargetCountForGrade[(int)m_arSliderData[(int)E_DATANUM.E_GRADE].value-1] );
    }
    public void SettingSLiderStrikingnAttackSpeed()
    {

        if (m_nSAPointCount < m_arSliderData[(int)E_DATANUM.E_STRIKING].value + m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED].value)
        {
            m_arSliderData[(int)E_DATANUM.E_STRIKING].value = m_nOldStrkingValue;
            m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED].value = m_nOldAttackSpeedValue;
        }
        else
        {
            m_arTxtSliderData[(int)E_DATANUM.E_STRIKING].text = m_arSliderData[(int)E_DATANUM.E_STRIKING].value.ToString();
            m_arTxtSliderData[(int)E_DATANUM.E_ATTACKSPEED].text = m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED].value.ToString();

            m_nOldStrkingValue = (int)m_arSliderData[(int)E_DATANUM.E_STRIKING].value;
            m_nOldAttackSpeedValue = (int)m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED].value;
        }
    }
    public float getStrikingRealValue(int nGrade)
    {
        return m_fStrikingForGrade[nGrade] * (float)m_arSliderData[(int)E_DATANUM.E_STRIKING].value;
    }
    public float getAttackSpeedRealValue(int nGrade)
    {
        return 1.0f + m_fAttackSpeedForGrade[nGrade] * (float)m_arSliderData[(int)E_DATANUM.E_ATTACKSPEED].value;
    }
    public int getSALeftPt()
    {
        return m_nSAPointCount - m_nOldStrkingValue - m_nOldAttackSpeedValue;
    }
    public int getGrade()
    {
        return (int)m_arSliderData[((int)E_DATANUM.E_GRADE)].value - 1;
    }
    public void SettingSliderTargetCountnDownRange()
    {

        if (m_nTDPointCount < m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].value * m_nTargetCountPointForGrade[(int)m_arSliderData[(int)E_DATANUM.E_GRADE].value -1] + m_arSliderData[(int)E_DATANUM.E_DOWNRANGE].value)
        {
            m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].value = m_nOldTargetCountValue;
            m_arSliderData[(int)E_DATANUM.E_DOWNRANGE].value = m_nOldDownRangeForValue;
        }
        else
        {
            m_arTxtSliderData[(int)E_DATANUM.E_TAGETCOUNT].text = m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].value.ToString();
            m_arTxtSliderData[(int)E_DATANUM.E_DOWNRANGE].text = m_arSliderData[(int)E_DATANUM.E_DOWNRANGE].value.ToString();

            m_nOldTargetCountValue = (int)m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].value;
            m_nOldDownRangeForValue = (int)m_arSliderData[(int)E_DATANUM.E_DOWNRANGE].value;
        }
    }

    public float getDownRangeRealValue(int nGrade)
    {
        return 3.0f + m_fDownRangeForGrade[nGrade] * (float)m_arSliderData[(int)E_DATANUM.E_DOWNRANGE].value;
    }
    public int getTargetCount()
    {
        return (int)m_arSliderData[(int)E_DATANUM.E_TAGETCOUNT].value;
    }
    public int getTDLeftPt()
    {
        return m_nTDPointCount - m_nOldTargetCountValue * m_nTargetCountPointForGrade[(int)m_arSliderData[(int)E_DATANUM.E_GRADE].value - 1] - m_nOldDownRangeForValue;
    }

    public void plusButton(int nIndex)
    {
        m_arSliderData[nIndex].value += 1;
    }
    public void minusButton(int nIndex)
    {
        m_arSliderData[nIndex].value -= 1;
    }
}
