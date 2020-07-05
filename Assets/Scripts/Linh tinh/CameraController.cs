using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public Transform tf;

    public bool spawn;
    public bool combat;

    Vector3 spawnPos = new Vector3(15, 35, -23f);
    Vector3 combatPos = new Vector3(15f, 35f, -15f);

    private float slideSpeed = 0.125f;

    // private void Start()
    // {
    //     MoveToSpawnPos();
    // }

    private void FixedUpdate()
    {
        if (spawn)
        {
            StartCoroutine(MoveToSpawnPos());
        }
        else if (combat)
        {
            StartCoroutine(MoveToCombatPos());
        }
        // MoveToCombatPos();
    }

    public IEnumerator MoveToSpawnPos()
    {
        Vector3 finalPos = Vector3.Lerp(tf.position, spawnPos, slideSpeed);
        tf.position = finalPos;
        yield return new WaitForSeconds(3f);
        spawn = false;
    }

    public IEnumerator MoveToCombatPos()
    {
        Vector3 finalPos = Vector3.Lerp(tf.position, combatPos, slideSpeed);
        tf.position = finalPos;
        yield return new WaitForSeconds(3f);
        combat = false;
    }

    public void MoveToSpawn()
    {
        spawn = true;
        combat = false;
    }

    public void MoveToCombat()
    {
        spawn = false;
        combat = true;
    }
}