using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2DFollow : MonoBehaviour
{
    [SerializeField]
    Vector3 moveDirection = new Vector3(0, 0, 0);

    [SerializeField]
    List<Transform> poses;

    public int state = 0;  // 0 for stay    1 for active

    [SerializeField]
    public Transform followTarget = null;

    Vector3 maxPos;
    Vector3 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
        maxPos = poses[0].position;
        minPos = poses[0].position;
        for (int i = 1; i < 2; ++i)
        {
            if (minPos.x > poses[i].position.x)
                minPos.x = poses[i].position.x;
            if (minPos.y > poses[i].position.y)
                minPos.y = poses[i].position.y;
            if (minPos.z > poses[i].position.z)
                minPos.z = poses[i].position.z;
            if (maxPos.x < poses[i].position.x)
                maxPos.x = poses[i].position.x;
            if (maxPos.y < poses[i].position.y)
                maxPos.y = poses[i].position.y;
            if (maxPos.z < poses[i].position.z)
                maxPos.z = poses[i].position.z;
        }
        //Debug.Log(maxPos);
        //Debug.Log(minPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1 && followTarget != null)
        {
            Vector3 tmp = followTarget.position - transform.position;
            transform.position += new Vector3(tmp.x * moveDirection.x, tmp.y * moveDirection.y, tmp.z * moveDirection.z);
            tmp = transform.position;
            if (tmp.x * moveDirection.x < minPos.x * moveDirection.x)
            {
                tmp.x = minPos.x;
            }
            if (tmp.x * moveDirection.x > maxPos.x * moveDirection.x)
            {
                tmp.x = maxPos.x;
            }

            if (tmp.y * moveDirection.y < minPos.y * moveDirection.y)
            {
                tmp.y = minPos.y;
            }
            if (tmp.y * moveDirection.y > maxPos.y * moveDirection.y)
            {
                tmp.y = maxPos.y;
            }

            if (tmp.z * moveDirection.z < minPos.z * moveDirection.z)
            {
                tmp.z = minPos.z;
            }
            if (tmp.z * moveDirection.z > maxPos.z * moveDirection.z)
            {
                tmp.z = maxPos.z;
            }
            transform.position = tmp;
        }
    }
    
    void StartFollow(Transform tmpFollowTarget)
    {
        followTarget = tmpFollowTarget;
        state = 1;
    }

}
