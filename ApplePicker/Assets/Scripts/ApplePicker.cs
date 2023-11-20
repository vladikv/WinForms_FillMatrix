using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketButtomY = -14f;
    public float basketSpacingY = 2f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketButtomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; 

        mousePos2D.z = -Camera.main.transform.position.z; 

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    { //a
      // ќтыскать €блоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject; // b
        if (collidedWith.tag == "Apple" ) { 
            Destroy(collidedWith);
        }
    }
}

