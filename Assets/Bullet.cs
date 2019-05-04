using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float _speed;
	private Rigidbody _rigit;
	Transform _tran;
	private Character _parent;
	void Start () {
		_rigit=GetComponent<Rigidbody>();
		_tran=this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 v=_tran.forward*_speed*Time.deltaTime;
		_rigit.velocity=v;
	}
	private void OnTriggerEnter(Collider other) {
		string tag=other.gameObject.tag;
		GameObject obj =other.gameObject;
		if(tag==Constant.TAG_PLAYER && _parent.isEnemy())
		{

				Player p=obj.GetComponent<Player>();
				p.Hit(_parent.GetDamage());
		}
		else if(tag==Constant.TAG_ENEMY && _parent.isPlayer())
		{
				Enemy e=obj.GetComponent<Enemy>();
				e.Hit(_parent.GetDamage());
				//Destroy(gameObject);
		}
		else if(tag==Constant.TAG_WALL)
		{
			Destroy(gameObject);
		}
	}
	public void SetParent(Character parent)
	{
		this._parent=parent;
	}
	
}
