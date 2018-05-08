using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TOWERANIMATION : MonoBehaviour {
    [SerializeField]
    private Animation m_aniDoingAnimation;
    private AudioSource m_audsrcAttack;
	// Use this for initialization
	void Start () {
        m_aniDoingAnimation = gameObject.GetComponent<Animation>();
        setTumblingAnimation();
        m_audsrcAttack = gameObject.GetComponent<AudioSource>();
    }
	

    public void setAttackAnimation(float fAttackSpeed)
    {
        m_aniDoingAnimation["attack_sword_02"].speed = 0.8f / fAttackSpeed * 2.0f;
        m_aniDoingAnimation.CrossFade("attack_sword_02",0.0f);
        m_audsrcAttack.Play();
    }
    public void setIdleAnimation()
    {
        m_aniDoingAnimation.CrossFadeQueued("idle@loop");
    }

    public void setTumblingAnimation()
    {
        m_aniDoingAnimation.CrossFade("tumbling");
        setIdleAnimation();

    }

}
