using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CAMERAMOVING : MonoBehaviour {

    private float m_fCameraMovingSpeed = 0.01f;
    private Vector2 vecNowPos;
    private Vector2 vecPrePos;
    private Vector3 vecMovePos;
    private float m_fPerspectiveZoomSpeed = 0.01f;
    private float m_fOrthoZoomSpeed = 0.01f;

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
                vecMovePos = new Vector3(vecPrePos.x - vecNowPos.x, 0, vecPrePos.y - vecNowPos.y) * m_fCameraMovingSpeed;

                Camera.main.transform.Translate(vecMovePos, Space.Self);

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

    private void moveLimit()
    {
        Vector2 vecTmp;
        vecTmp.x = Mathf.Clamp(transform.position.x, 0.0f, 30.0f);
        vecTmp.y = Mathf.Clamp(transform.position.y, 6.0f, 30.0f);

        transform.position = vecTmp;
    }

}
