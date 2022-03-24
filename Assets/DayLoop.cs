using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLoop : MonoBehaviour
{
    public Material[] skyboxMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.right, 2f * Time.deltaTime);

        //bir nokta etrafýnda döndürmek için kullanýlýr bu fonksiyon
        //noktayý olusturduk ilk parametrede sonra yönu sectik , zamaný seçtik 
    }
}
