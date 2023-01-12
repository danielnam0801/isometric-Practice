using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    List<Vector2> point = new List<Vector2>();

    [SerializeField]
    [Range(0f, 1f)]
    private float t = 0;

    public float spd;
    public float radiusA = 0.55f;
    public float radiusB = 0.45f;

    public GameObject master;
    public Vector3 objectPos;
    public bool isShootOn = false;

    ShootingManager shootingManager;
    private void Awake()
    {
        master = GameObject.Find("Player_Isometric_Witch").transform.GetChild(0).gameObject;
        shootingManager = GameObject.Find("ShootingManager").GetComponent<ShootingManager>();
    }
    private void Start()
    {
    }


    public void InstantiateInit(Vector3 objectPo)
    {
        objectPos = objectPo;

        point.Add(master.transform.position);
        point.Add(SetRandomBezierPointP2(master.transform.position));
        point.Add(SetRandomBezierPointP3(objectPos));
        point.Add(objectPos);

        transform.position = point[1];
    }

    private void Update()
    {
        RotateBullet();
        if (isShootOn)
        {
            if (t > 1)
            {
                isShootOn = false;
                shootingManager.CheckAllBulletArrived();
            }
            t += Time.deltaTime * spd;
            transform.position = MoveBezier();
        }
    }

    private void RotateBullet()
    {
        Vector3 dir = objectPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private Vector2 MoveBezier()
    {
        return new Vector2(
            FourPointBezier(point[0].x, point[1].x, point[2].x, point[3].x),
            FourPointBezier(point[0].y, point[1].y, point[2].y, point[3].y)
        );
    }

    private float FourPointBezier(float a, float b, float c, float d)
    {
        return Mathf.Pow(1 - t, 3) * a +
            Mathf.Pow(1 - t, 2) * 3 * t * b +
            Mathf.Pow(t, 2) * 3 * (1 - t) * c +
            Mathf.Pow(t, 3) * d;

    }

    private Vector2 SetRandomBezierPointP3(Vector2 origin)
    {
        return new Vector2(
            radiusA * Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad) + origin.x,
            radiusA * Mathf.Sin(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad) + origin.y);
    }

    private Vector2 SetRandomBezierPointP2(Vector2 origin)
    {
        return new Vector2(
            radiusB * Mathf.Cos(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad) + origin.x,
            radiusB * Mathf.Sin(UnityEngine.Random.Range(0, 360) * Mathf.Deg2Rad) + origin.y);
    }
}
