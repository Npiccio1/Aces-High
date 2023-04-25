using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public Renderer background;
    public float verticalInput;
    public float speed = 5;
    public GameObject muzzlepoint;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(moveX, 0.0f, moveZ);
        Vector3 move = moveDir.normalized * speed * Time.deltaTime;
        transform.Translate(move);
        Vector2 texOffset = background.material.mainTextureOffset;
        texOffset += new Vector2(move.x, move.z) / 20;
        background.material.mainTextureOffset = texOffset;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch projectile from player
            Instantiate(projectilePrefab, muzzlepoint.transform.position, muzzlepoint.transform.rotation);
        }
    }
}
