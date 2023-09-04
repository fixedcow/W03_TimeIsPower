using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : DynamicObject
{
	[SerializeField] Animator anim;

	[Header("좀비 체력")]
    [SerializeField] private int maxHP;
    private int nowHP;

	[Header("좀비 움직임 관련")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float brazierSpace;
	private bool isZombieMove=true;
	private Vector3 brazierPosition; // 좀비 생성될때 가야할 화로 위치 받아오기
	private bool isZombieAttack;

	private void OnEnable()
    {
		nowHP = maxHP;
    }

	public void SetBrazierPosition(Vector3 pos)
    {
		brazierPosition = pos;
    }

	public void HitZombie(int _damage, GameObject _source)
	{
		if (nowHP <= 0)
		{
			Destroy(this.gameObject);
		}
		else
		{
			nowHP -= 1;
		}
	}


	private void moveZombie()
    {
        if (isZombieMove)
        {
			if(transform.position.x>= brazierPosition.x-brazierSpace
				&&transform.position.x<= brazierPosition.x + brazierSpace)
            {
				anim.SetBool("attack", false);
				isZombieMove = false;
				isZombieAttack = true;
            }

			
			if (brazierPosition.x >= transform.position.x)
			{
				
				transform.localScale = new Vector3(1, 1, 1);
				transform.Translate(moveSpeed, 0, 0);
			}
			else
			{
				
				transform.localScale = new Vector3(-1, 1, 1);
				transform.Translate(-moveSpeed, 0, 0);
				
			}
			anim.SetBool("move", true);
		}
        
	}

	private void attackZombie()
    {
        if (isZombieAttack)
        {
			anim.SetBool("attack", true);
		}
    }

    
	

    private void Update()
    {
		moveZombie();
		attackZombie();
    }

    public override void DestroyObject()
    {
		Destroy(this.gameObject);
    }

    public override void StopObject()
    {
		Destroy(this.gameObject);
	}
}
