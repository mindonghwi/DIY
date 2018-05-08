using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MOVESTARTBUTTON : MonoBehaviour {

    private Vector3 m_vecMoveSpeed;
    private float m_fTurn;
    private bool m_bTurnControl;

	// Use this for initialization
	void Start () {
        m_vecMoveSpeed = new Vector3(0.0f,2.0f,0.0f);
        m_fTurn = -1.0f;
        m_bTurnControl = false;
    }
	
	// Update is called once per frame
	void Update () {
        MovingButton();
    }

    private void MovingButton()
    {
        if (GetComponent<Transform>().localPosition.y > 0.01f && !m_bTurnControl)
        {
            m_vecMoveSpeed *= m_fTurn;
            m_bTurnControl = true;
        }
        else if (GetComponent<Transform>().localPosition.y < -0.02f && m_bTurnControl)
        {

            m_vecMoveSpeed *= m_fTurn;
            m_bTurnControl = false;
        }

        transform.position += m_vecMoveSpeed * Time.deltaTime;
    }
}
