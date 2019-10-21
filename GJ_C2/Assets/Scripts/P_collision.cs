using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

// attach this script to player ... hazards will respawn the player and crumble blocks will crumble on touch
// also assign the public objects to the GameObjects in unity!

public class P_collision : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public GameObject Crumble_tilemapGameObject; // remember to set this gameobject to the tilemap you want the player to destroy
    public GameObject Hazard_tilemapGameObject; // see above

    public Tile Crumble_phase1; // assign to crumbly_brick1 (tile)
    public Tile Crumble_phase2; // assign to crumbly_brick2 (tile)
    public Tile Crumble_phase3; // assign to crumbly_brick3 (tile)

    Tilemap tilemap;

    [SerializeField] private GameObject horse;

    private float sec_per_crumble = .3f; // second per crumbling transition

    void Start()
    {
        if (Crumble_tilemapGameObject != null)
        {
            tilemap = Crumble_tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Hazard_tilemapGameObject.name) // you may have to change the name of this depending on what the name of your spike tilemap is
        {
            player.transform.position = respawnPoint.transform.position; // "respawns" player
        }
        if (collision.gameObject.tag == "DropTile")
        {
            collision.gameObject.AddComponent<Rigidbody2D>();
        }
        if (collision.gameObject.name == horse.name)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == Crumble_tilemapGameObject.name) 
        {
            // deletes every crumble block the player touches
            Vector3 hitPosition = Vector3.zero;

            if (tilemap != null && Crumble_tilemapGameObject == collision.gameObject)
            {
                StartCoroutine("Delay_crumble", collision); // commences crumbling
            }
        }
    }

    IEnumerator Delay_crumble(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        foreach (ContactPoint2D hit in collision.contacts)
        {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            //Debug.Log((tilemap.GetTile(tilemap.WorldToCell(hitPosition)))); // crumble only noncrumbling bricks
            if (tilemap.GetTile(tilemap.WorldToCell(hitPosition)) != null)
            {
                if ((tilemap.GetTile(tilemap.WorldToCell(hitPosition)).name) == "crumbly_brick")
                {
                    yield return new WaitForSeconds(sec_per_crumble); // waits .01 second
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), Crumble_phase2); // 'animates' crumbling
                    yield return new WaitForSeconds(sec_per_crumble);
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), Crumble_phase3);
                    yield return new WaitForSeconds(sec_per_crumble);
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null); // destroys tile
                    yield return new WaitForSeconds(10);
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), Crumble_phase1);
                }
            }
        } 
    }
}