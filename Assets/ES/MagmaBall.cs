using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaBall : DynamicObject
{
    [SerializeField] private GameObject player;
    [SerializeField] float guideSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float destroyMagmaTime;
    private float timer;
    [SerializeField] private Rigidbody2D rigid;

    private void Start()
    {
		player = GameManager.instance.GetPlayer().gameObject;
    }
    private void GuideToPlayer()
    {
		if (timer <= destroyMagmaTime)
		{
			Vector2 dir = transform.right;
			Vector2 targetDir = player.transform.position - transform.position;
			Vector3 crossVec = Vector3.Cross(dir, targetDir);
			float inner = Vector3.Dot(Vector3.forward, crossVec);
			float saveAngle = inner + transform.rotation.eulerAngles.z;
			transform.rotation = Quaternion.Euler(0, 0, saveAngle * rotateSpeed);

			float moveDirAngle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
			Vector2 moveDir = Vector2.zero;
			moveDir = new Vector2(Mathf.Cos(moveDirAngle), Mathf.Sin(moveDirAngle));
			rigid.velocity = moveDir * guideSpeed;
			timer += Time.deltaTime;
		}
		else
		{
			GetComponent<ParticleSystem>().Stop();
			GetComponent<CircleCollider2D>().enabled = false;
			Invoke("DestroyObject", 10f);
		}
	}

	

    private void Update()
    {
        GuideToPlayer();
    }

    public override void DestroyObject()
    {
		//DynamicObjectManager.instance.DeleteObjects(this);
		Destroy(this.gameObject);
	}

    public override void StopObject()
    {
		GetComponent<ParticleSystem>().Stop();
		GetComponent<CircleCollider2D>().enabled = false;
		Invoke("DestroyObject", 10f);
	}
}


