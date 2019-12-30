using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    protected Animator m_animator;

    bool m_handIKActive = true;

    [SerializeField]
    Transform m_rightHandTransform;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (m_animator)
        {
                    m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    m_animator.SetIKPosition(AvatarIKGoal.RightHand, m_rightHandTransform.position);
        }
            //if the IK is not active, set the position and rotation of the hand and head back to the original position
        else
        {
                m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                m_animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                m_animator.SetLookAtWeight(0);
        }
        
    }
}
