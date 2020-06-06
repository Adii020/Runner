using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
	public GameObject obstacle;
	public GameObject powerup;
	public GameObject powerup2;
	float timeElapsed = 0;
	float spawnCycle = .3f;
	bool spawnPowerup = true;
	bool spawnPowerup2 = true;
	public System.Random random = new System.Random();
	public ArrayList array = new ArrayList();
	
	// Use this for initialization
	void Start()
	{
		
		array.Add(-2f);
		array.Add(0f);
		array.Add(2f);
	}

	// Update is called once per frame
	void Update()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle)
		{
			GameObject temp;
			int objnumber = Random.Range(1, 4);
			//Debug.Log(objnumber);
			if (objnumber == 1)
			{
				temp = (GameObject)Instantiate(powerup);
				//-2,0,2
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3((float)array[(random.Next(0, array.Count))], pos.y, pos.z);

			}
			else if (objnumber == 2)
			{
				temp = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3((float)array[(random.Next(0, array.Count))], pos.y, pos.z);
			}
			/*else if (objnumber == 3)
			{
				temp = (GameObject)Instantiate(powerup2);
				//-2,0,2
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3((float)array[(random.Next(0, array.Count))], pos.y, pos.z);


			}*/


			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}

	}
}
