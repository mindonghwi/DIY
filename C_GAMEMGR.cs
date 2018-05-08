using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class C_GAMEMGR : MonoBehaviour
{

    private C_GAMEMGR() { }


    private C_STAGEMGR m_cStageMgr;


    public GameObject m_goImposibleTile;
    public GameObject m_goPosibleTile;
    public GameObject m_goMovingPoint;
    public GameObject m_goParsingControl;

    private GameObject m_goMapHolder;
    private GameObject m_goTowerHolder;
    [HideInInspector]
    public GameObject turret;


    private C_INPUT m_cInput;
    private C_PLAYER m_cPlayer;
    private C_UI m_cUi;
    private C_GAMECOIN m_cGameCoin;


    private C_LOADDATA m_cLoadData;
    private GameObject m_goLoadData;
    private C_MYTOWERPROC m_cMyTowerProc;

    private C_SCENEMGR m_cSceneMgr;

    private C_GAMEOVER m_cGameOver;

    private GameObject m_goQuestionBox;

    private float m_fPerspectiveZoomSpeed = 0.1f;
    private float m_fOrthoZoomSpeed = 0.1f;
    private GameObject m_goMovingPointHolder;
    private GameObject m_goEnemyHolder;
    private void init()
    {
        m_cStageMgr = new C_STAGEMGR();
        m_cPlayer = GameObject.Find("Player").GetComponent<C_PLAYER>();

        m_QternCameraRotate = Camera.main.transform.rotation;
        m_goLoadData = GameObject.Find("LoadData");
        m_cLoadData = m_goLoadData.GetComponent<C_LOADDATA>();

        m_cGameCoin = m_cPlayer.gameObject.GetComponent<C_GAMECOIN>();


        m_cPlayer.init(PlayerPrefs.GetInt("StartResource"), 0, 30);


        Debug.Log(PlayerPrefs.GetInt("coinPrice") + "   " + PlayerPrefs.GetInt("StartResource") + "    " + PlayerPrefs.GetFloat("difficultyHp"));

        m_cStageMgr.init(m_goMovingPoint, m_goPosibleTile, m_goImposibleTile, m_cPlayer, m_cLoadData.getLoadNode(), PlayerPrefs.GetFloat("difficultyHp"));

        m_cGameCoin.init(PlayerPrefs.GetInt("coinPrice"));
        m_cGameCoin.FlututionCoin((m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>().getStageCount() + 1));


        m_cUi = new C_UI();
        m_cUi.init();
        //m_cUi.UpdateUi(m_cPlayer, m_cGameCoin,m_cInput);

        m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>().setPlayer(m_cPlayer);
        m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>().setDifficultyHp(PlayerPrefs.GetFloat("difficultyHp"));
        C_TOWERINFO.m_fUpgradeCount = 0;

        m_goMapHolder = GameObject.Find("MarsMaps");
        m_goTowerHolder = new GameObject();
        m_goTowerHolder.name = "TowerHolder";
        m_goTowerHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);
        m_cInput = GameObject.Find("UIEvent").GetComponent<C_INPUT>();
        m_cInput.load(m_cPlayer, m_cGameCoin, m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>(), m_goTowerHolder);
        //m_cMyTowerProc = GameObject.Find("TowerCreater").GetComponent<C_MYTOWERPROC>();
        m_cMyTowerProc = new C_MYTOWERPROC();
        m_cMyTowerProc.init();

        m_cSceneMgr = gameObject.GetComponent<C_SCENEMGR>();


        m_cGameOver = GameObject.Find("MainUiCanvas").transform.GetChild(5).GetComponent<C_GAMEOVER>();
        m_goQuestionBox = GameObject.Find("QuestionCanvas");
        m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().CloseQuestionBox();

        m_goEnemyHolder = GameObject.Find("EnemyHolder");
        m_goMovingPointHolder = GameObject.Find("MovingPoints");
    }


    // Use this for initialization
    void Start()
    {
        init();
        GameObject goTmpStartPoint=(GameObject)Instantiate(m_cLoadData.getLoadEffect().getEffect(C_LOADEFFECT.E_EFFECT.E_ENEMYBLAST), new Vector3(0.0f, 2.0f, 0.0f), Quaternion.identity);
        goTmpStartPoint.transform.parent = m_goEnvi.transform;
    }

    // Update is called once per frame
    void Update()
    {

        //////////////////////////////////////////////////////
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.touchCount == 1)
            {
                Vector2 vecPos = Input.GetTouch(0).position;    // 터치한 위치
                Vector3 vecTheTouch = new Vector3(vecPos.x, vecPos.y, 0.0f);    // 변환 안하고 바로 Vector3로 받아도 되겠지.

                Ray ray = Camera.main.ScreenPointToRay(vecTheTouch);    // 터치한 좌표 레이로 바꾸엉
                RaycastHit hit;    // 정보 저장할 구조체 만들고
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))    // 레이저를 끝까지 쏴블자. 충돌 한넘이 있으면 return true다.
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)    // 딱 처음 터치 할때 발생한다
                    {

                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Moved)    // 터치하고 움직이믄 발생한다.
                    {
                        // 또 할거 하고
                    }
                    else if (Input.GetTouch(0).phase == TouchPhase.Ended)    // 터치 따악 떼면 발생한다.
                    {
                        //합성
                        if (m_cInput.getIsMerge())
                        {
                            if (hit.transform.parent.parent == m_goTowerHolder.transform)
                            {
                                m_cMyTowerProc.upgradeTurret(hit, m_goTowerHolder, m_cLoadData, m_cInput);
                                //m_cMyProc.upgradeTurret(hit, m_goTowerHolder, m_cLoadTower, m_cInput);
                            }
                        }
                        //퍼즈
                        if (!m_cInput.getPause())
                        {
                            if (hit.transform.name == "StartHexagon")
                            {
                                m_cInput.startWave();
                            }
                        }
                        //생성
                        if (m_cPlayer.getGoid() >= 100)
                        {
                            if (m_cInput.getIsBuild())
                            {
                                if (hit.transform.parent == m_goMapHolder.transform)
                                {
                                    if (!hit.transform.gameObject.GetComponent<C_NODE>().m_goTower)
                                    {
                                        m_cPlayer.buyTower();
                                        m_cMyTowerProc.createTower(hit, m_goTowerHolder, m_cLoadData, m_cInput);
                                        //m_cMyProc.createTurret(hit, m_goTowerHolder, m_cLoadTower, m_cInput);
                                    }
                                }
                            }
                        }
                        if (m_cInput.getIsSell())
                        {
                            m_cPlayer.addGold(hit.transform.parent.gameObject.GetComponent<C_TOWER>().m_nLevel * 50);
                            m_cMyTowerProc.SellTower(hit);
                            m_cInput.offIsSell();
                        }

                        if (hit.transform.parent.parent == m_goTowerHolder.transform)
                        {
                            for (int i = 0; i < m_goTowerHolder.transform.childCount; i++)
                            {
                                if (hit.transform.parent != m_goTowerHolder.transform.GetChild(i))
                                {
                                    m_goTowerHolder.transform.GetChild(i).GetComponent<C_TOWERUI>().offUi();
                                }
                            }
                            m_cMyTowerProc.ActiveTowerUi(hit);

                        }
                    }

                }
            }
            

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                m_goQuestionBox.GetComponent<C_QUESTIONMESSAGEBOX>().setQuestionBox();
                m_cInput.setPuase();
            }
        
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.parent.parent == m_goTowerHolder.transform)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        hit.transform.parent.gameObject.GetComponent<C_TOWER>().m_goMyNode.GetComponent<C_NODE>().m_goTower = null;
                        Destroy(hit.transform.parent.gameObject);
                        m_cPlayer.addGold(50);
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        for (int i = 0; i < m_goTowerHolder.transform.childCount; i++)
                        {
                            if (hit.transform.parent != m_goTowerHolder.transform.GetChild(i))
                            {
                                m_goTowerHolder.transform.GetChild(i).GetComponent<C_TOWERUI>().offUi();
                            }
                        }
                        m_cMyTowerProc.ActiveTowerUi(hit);
                    }
                }
                if (m_cPlayer.getGoid() >= 100)
                {
                    if (m_cInput.getIsBuild())
                    {
                        if (hit.transform.parent == m_goMapHolder.transform)
                        {
                            if (Input.GetMouseButtonDown(0) && !hit.transform.gameObject.GetComponent<C_NODE>().m_goTower)
                            {
                                m_cPlayer.buyTower();
                                m_cMyTowerProc.createTower(hit, m_goTowerHolder, m_cLoadData, m_cInput);
                                //m_cMyProc.createTurret(hit, m_goTowerHolder, m_cLoadData.getLoadTower(), m_cInput);
                            }
                        }
                    }
                }
                if (m_cInput.getIsMerge())
                {
                    if (hit.transform.parent.parent == m_goTowerHolder.transform)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            m_cMyTowerProc.upgradeTurret(hit, m_goTowerHolder, m_cLoadData, m_cInput);
                            //m_cMyProc.upgradeTurret(hit, m_goTowerHolder, m_cLoadData.getLoadTower(), m_cInput);
                        }
                    }
                }
                if (m_cInput.getIsSell())
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        m_cPlayer.addGold(hit.transform.parent.gameObject.GetComponent<C_TOWER>().m_nLevel * 50);
                        m_cMyTowerProc.SellTower(hit);
                        m_cInput.offIsSell();
                    }
                }
                if (!m_cInput.getPause())
                {
                    if (hit.transform.name == "StartHexagon")
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            m_cInput.startWave();
                        }
                    }
                }


            }
        }

        // If there are two touches on the device...


        m_cUi.UpdateUi(m_cPlayer, m_cGameCoin, m_cInput);
        m_cUi.updataWave(m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>());
        gameOver();
    }

    private float m_fCameraMovingSpeed = 0.05f;
    private Vector2 vecNowPos;
    private Vector2 vecPrePos;
    private Vector3 vecMovePos;

    private Quaternion m_QternCameraRotate;
    public GameObject m_goEnvi;


    void LateUpdate()
    {

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                vecPrePos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                vecNowPos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
                vecMovePos = new Vector3(0, vecPrePos.x - vecNowPos.x,0) * m_fCameraMovingSpeed;

                m_goEnvi.transform.Rotate(vecMovePos);
                m_goMapHolder.transform.Rotate(vecMovePos);
                m_goTowerHolder.transform.Rotate(vecMovePos);
                m_goMovingPointHolder.transform.Rotate(vecMovePos);
                m_goEnemyHolder.transform.Rotate(vecMovePos);
                //Camera.main.transform.Translate(vecMovePos,Space.Self);
                moveLimit();

                vecPrePos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            }
        }
        else if (Input.touchCount == 2)
        {

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 vecTouchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 vecTouchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float fPrevTouchDeltaMag = (vecTouchZeroPrevPos - vecTouchOnePrevPos).magnitude;
            float fTouchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float fDeltaMagnitudeDiff = fPrevTouchDeltaMag - fTouchDeltaMag;

            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize += fDeltaMagnitudeDiff * m_fOrthoZoomSpeed;

                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 20.5f);
            }
            else
            {
                Camera.main.fieldOfView += fDeltaMagnitudeDiff * m_fPerspectiveZoomSpeed;

                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20.5f, 100.9f);
            }


        }

    }

    public C_LOADEFFECT getLoadEffect()
    {
        return m_cLoadData.getLoadEffect();
    }

    private void gameOver()
    {
        if (m_cPlayer.getHealth() == 0)
        {
            m_cGameOver.gameObject.SetActive(true);
            m_cGameOver.GameEnding(true);
        }
        if (m_cStageMgr.getEnemyWave().GetComponent<C_ENEMYWAVE>().getStageCount() > 60)
        {
            
            m_cGameOver.gameObject.SetActive(true);
            m_cGameOver.GameEnding(false);
            m_cInput.setPuase();
        }
    }

    private void moveLimit()
    {
        Vector2 vecTmp;
        vecTmp.x = Mathf.Clamp(transform.position.x, 0.0f, 30.0f);
        vecTmp.y = Mathf.Clamp(transform.position.y, 6.0f, 30.0f);

        transform.position = vecTmp;
    }

}