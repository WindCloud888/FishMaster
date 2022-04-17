using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FishMaker : MonoBehaviour
{

	public Transform fishHolder;
	public Transform[] genPosition;
	public GameObject[] fishPrefabs;

	public float fishGenWaitTime = 0.5f;
	public float waveGenWaitTime = 0.3f;

	void Start()
	{
		InvokeRepeating("MakeFishes", 0, waveGenWaitTime);
	}

	void MakeFishes()
	{
		int genPosIndex = Random.Range(0, genPosition.Length);
		int fishPreIndex = Random.Range(0, fishPrefabs.Length);
		int maxNum = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxNum;
		int maxSpeed = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxSpeed;
		int num = Random.Range((maxNum / 2) + 1, maxNum);
		int speed = Random.Range(maxSpeed / 2, maxSpeed);
		int moveType = Random.Range(0, 2);     //0:直走;   1:转弯    
		int angOffset;                             //仅直走生效，直走的倾斜角
		int angSpeed;                             //仅转弯生效，转弯的角速度

        if (moveType == 0)
        {
			angOffset = Random.Range(-22, 22);
			StartCoroutine(GenStraightFish(genPosIndex, fishPreIndex, num, speed, angOffset));

		}
        else
        {
            if (Random.Range(0, 2) == 0)   //是否取负的角速度
			{
				angSpeed = Random.Range(-15, -9);		
			}
            else
            {
				angSpeed = Random.Range(9, 15);
            }
			StartCoroutine(GenTurnFish(genPosIndex, fishPreIndex, num, speed, angSpeed));
		}

	}

	IEnumerator GenStraightFish(int genPosIndex,int fishPreIndex,int num,int speed,int angOffset)
    {
		for(int i = 0; i < num; i++)
        {
			GameObject fish=Instantiate(fishPrefabs[fishPreIndex]);
			fish.transform.SetParent(fishHolder, false);
			fish.transform.localPosition = genPosition[genPosIndex].localPosition;
			fish.transform.localRotation = genPosition[genPosIndex].localRotation;
			fish.transform.Rotate(0, 0, angOffset);
			fish.GetComponent<SpriteRenderer>().sortingOrder += i;
			fish.AddComponent<Ef_Move>().speed = speed;
			yield return new WaitForSeconds(fishGenWaitTime);
        }
    }

	IEnumerator GenTurnFish(int genPosIndex, int fishPreIndex, int num, int speed, int angSpeed)
	{
		for (int i = 0; i < num; i++)
		{
			GameObject fish = Instantiate(fishPrefabs[fishPreIndex]);
			fish.transform.SetParent(fishHolder, false);
			fish.transform.localPosition = genPosition[genPosIndex].localPosition;
			fish.transform.localRotation = genPosition[genPosIndex].localRotation;
			fish.GetComponent<SpriteRenderer>().sortingOrder += i;
			fish.AddComponent<Ef_Move>().speed = speed;
			fish.AddComponent<Ef_Rotate>().speed = angSpeed;
			yield return new WaitForSeconds(fishGenWaitTime);
		}
	}
}