using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    [SerializeField] GameObject bullet;
    public float coolTime = 3f;

    public bool canSkill = true;

    Vector3 InputPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (canSkill)
            {
                canSkill = false;
                StartCoroutine("FireBallShoot");
                StartCoroutine("CoolTimeCheck");
            }
        }
    }

    public void OnFireBallSkillClick()
    {
        if (canSkill)
        {
            canSkill = false;
            StartCoroutine("FireBallShoot");
            StartCoroutine("CoolTimeCheck");
        }
    }

    IEnumerator FireBallShoot() { 
        for(int i = 0; i < 10; i++)
        {
            GameObject bu = Instantiate(bullet);
            bu.GetComponent<Bezier>().InstantiateInit(InputPos);
            bullets.Add(bu);

            yield return new WaitForSeconds(0.05f);
        }
        foreach( GameObject bullet in bullets)
        {
            bullet.GetComponent<Bezier>().isShootOn = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator CoolTimeCheck()
    {
        yield return new WaitForSeconds(coolTime);
        canSkill = true;
    }

    public void DestroyAllBullet()
    {
        foreach(GameObject bullet in bullets)
        {
            if (bullet != null) Destroy(bullet);
        }
        bullets.Clear();
    }


}
