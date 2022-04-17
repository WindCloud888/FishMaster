using UnityEngine;

public class GunFollow : MonoBehaviour {
	public RectTransform UGUICanvas;
	public Camera mainCamera;

	void Update () {
		Vector3 mousePos;
		//把鼠标在屏幕上的坐标转化成在UGUI上的坐标
		RectTransformUtility.ScreenPointToWorldPointInRectangle(UGUICanvas,new Vector2(Input.mousePosition.x,Input.mousePosition.y),mainCamera,out mousePos);
		float z;
        if (mousePos.x > transform.position.x)
        {
			//Vector2 Vector3一直以来都是向量，其实一直都是用向量来表示位置的，现在向量相剪，自然能得到一个向量
			z = -Vector3.Angle(Vector3.up, mousePos - transform.position);
        }
        else
        {
			z = Vector3.Angle(Vector3.up, mousePos - transform.position);
		}
		transform.localRotation = Quaternion.Euler(0, 0, z);

	}
}
