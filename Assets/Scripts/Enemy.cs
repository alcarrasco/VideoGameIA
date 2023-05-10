using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float radiusOfVision = 10f;
    [SerializeField] LayerMask player;

    FSM fsm;
    float currentTime;

	private void Start()
	{
        fsm = GetComponent<FSM>();

    }
	void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 0.5f)
        {
            var cols = Physics.OverlapSphere(transform.position, radiusOfVision, player); //El proyecto esta en 3D asi que no estoy usando Physics2D ni OverlapCircle


            if (cols.Length > 0)
            {
                fsm.player = cols[0].gameObject.GetComponent<Player>();

            }
            else fsm.player = null;

            currentTime = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiusOfVision);
	}
}
