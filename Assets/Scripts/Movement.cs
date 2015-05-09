using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float movespeed;
    public int player = 1;
    public int dir = 1;
    public GameObject explosion;
    public AudioSource exp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) && player == 1) {
            this.transform.position += Vector3.left * movespeed * Time.deltaTime;
            dir = -1;
        }
        if (Input.GetKey(KeyCode.D) && player == 1) {
            this.transform.position += Vector3.right * movespeed * Time.deltaTime;
            dir = 1;
        }
        if (Input.GetKey(KeyCode.W) && player == 1) {
            this.transform.position += Vector3.up * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && player == 1) {
            this.transform.position += Vector3.down * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && player == 1) {
            Ray ray = new Ray();
            ray.direction = new Vector3(dir, 0, 0);
            ray.origin = transform.position;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10)) {

                if (hit.collider.tag == "Hitbox") {
                    print("Cheetos");
                    Debug.DrawRay(ray.origin, ray.direction, Color.green);
                    Destroy(hit.transform.gameObject.transform.parent.gameObject);
                    Instantiate(explosion, hit.transform.position, new Quaternion (0, 0, 0, 0));
                    exp.Play();
                }
            }
            else {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
            }
        }

        // player 2
        if (Input.GetKey(KeyCode.LeftArrow) && player == 2) {
            this.transform.position += Vector3.left * movespeed * Time.deltaTime;
            dir = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow) && player == 2) {
            this.transform.position += Vector3.right * movespeed * Time.deltaTime;
            dir = 1;
        }
        if (Input.GetKey(KeyCode.UpArrow) && player == 2) {
            this.transform.position += Vector3.up * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && player == 2) {
            this.transform.position += Vector3.down * movespeed * Time.deltaTime;
        }
	}
}
