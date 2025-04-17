using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Fall : MonoBehaviour
{
  public GameObject fallObject;
  public GameObject player;
  private Vector3 activeCenter;
  public float radius;
  public float offset;
  public float fallTimer; // object fall is dependant on fall timer
  private List<GameObject> dropClones = new List<GameObject>(); // List to track all drops
                                                                // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnObject", 5.0f, fallTimer);
    player = GameObject.FindWithTag("Player");

  }

  // Update is called once per frame
  void Update()
  {
    activeCenter = player.transform.position + new Vector3(0, offset, 0); // area above player where things are spawned
    DestroyObject();
    // Check all drops and destroy them

  }
  public void SpawnObject()
  {
    Vector3 randomPosition = activeCenter + Random.insideUnitSphere * radius;
    GameObject d = Instantiate(fallObject, randomPosition, Quaternion.identity);
    dropClones.Add(d);

    // Modify the new drop's components
    d.GetComponent<MeshRenderer>().enabled = true;
    d.GetComponent<Rigidbody>().useGravity = true;


  }
  public void DestroyObject()
  {
    // Check all drops and destroy them if they go too low
    for (int i = dropClones.Count - 1; i >= 0; i--)
    {
      if (dropClones[i] != null && dropClones[i].transform.position.y < player.transform.position.y - offset)
      {
        Destroy(dropClones[i]);
        dropClones.RemoveAt(i);
      }
      else if (dropClones[i] != null && dropClones[i].transform.position.y < -10)
      {
        Destroy(dropClones[i]);
        dropClones.RemoveAt(i);
      }
      /*if(isTouching(player,dropClones[i])){
				Destroy(dropClones[i]);
                dropClones.RemoveAt(i);
			}*/
    }
  }
}


