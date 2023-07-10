using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private Queue<GameObject> bullets = new Queue<GameObject>();
    private MeshRenderer renderer;
    private BoxCollider collider;

    public void InitAmmo(GameObject ammo, int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            GameObject spawnedBullet = Instantiate(ammo);

            HideObject(spawnedBullet);
            bullets.Enqueue(spawnedBullet);
        }
    }

    public void OnShoot(float speed)
    {
        GameObject currentBullet = bullets.Dequeue();
        currentBullet.transform.position = transform.position;

        ShowObject(currentBullet);

        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * speed);

        bullets.Enqueue(currentBullet);
    }

    private void HideObject(GameObject spawnedBullet)
    {

        renderer = spawnedBullet.GetComponent<MeshRenderer>();
        collider = spawnedBullet.GetComponent<BoxCollider>();


        renderer.enabled = false;
        collider.enabled = false;
    }
    private void ShowObject(GameObject spawnedBullet)
    {

        renderer = spawnedBullet.GetComponent<MeshRenderer>();
        collider = spawnedBullet.GetComponent<BoxCollider>();

        renderer.enabled = true;
        collider.enabled = true;
    }
}
