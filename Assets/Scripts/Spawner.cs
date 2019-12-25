using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Spawner : MonoBehaviour {

    public GameObject SpawnSpherePerfab;
    public float Height = 15f;
    public float DispersionX = 2f;
    public float DispersionZ = 0f;
    public float BubleMaxRadius = 1f;
    public int MaxBubles = 6;

    public float BubleRadius = 2f;

    // Use this for initialization
	void Start () {
	
	}

    public void Spawn()
    {

        //просто пустим луч и применим силу в точке касания

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
        if (Physics.SphereCast(transform.position, BubleRadius, transform.TransformDirection(Vector3.up), out hit, Height, 1 << 8))
        {
            var rig = hit.transform.GetComponent<Rigidbody>();
            if (rig != null)
            {
                var direction = rig.position - transform.position;
                rig.AddForceAtPosition(direction * 10, hit.point, ForceMode.Impulse);
                //Debug.Log("set force");
            }
        }

        //int numBubles = Random.Range(3, MaxBubles);
        //Debug.Log(numBubles);
        //for (int i = 0; i < numBubles; i++)
        //{
        //    GameObject buble = (GameObject)Instantiate(SpawnSpherePerfab);
        //    buble.transform.position = transform.position;
        //    buble.transform.parent = transform;
        //    var spCol = buble.GetComponent<SphereCollider>();
        //    spCol.radius = Random.Range(0.1f, BubleMaxRadius);
        //    Vector3 dest = transform.position + Vector3.up * Height + Vector3.left * Random.Range(-DispersionX, DispersionX) + Vector3.forward * Random.Range(-DispersionZ, DispersionZ);
        //    HOTween.To(buble.transform, 3f, new TweenParms().Prop("position", dest).Ease(EaseType.Linear).SpeedBased(true).OnComplete(TweenComplite, buble));
        //}
        
            
        
    }

    private void TweenComplite(TweenEvent p_callbackData)
    {
        if (p_callbackData.parms[0] != null)
        {
            Destroy((GameObject)p_callbackData.parms[0]);
        }
    }

    void OnDrawGizmos()
    {
        //return;
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, BubleRadius);
        for (int i = 0; i < Height; i++)
        {
            Gizmos.DrawWireSphere(transform.position + Vector3.up*i, BubleRadius);
        }
        
    }
}
