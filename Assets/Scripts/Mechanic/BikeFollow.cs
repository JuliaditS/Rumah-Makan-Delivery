using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeFollow : MonoBehaviour
{
    public BikePath MyPath;
    public Pesanan pesanan;
    [SerializeField] float moveSpeed = 2f;
    public string namaPesanan;
    public Transform rumah;
    public AudioClip suaraMotor;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Start()
    {
        
    }


    void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            MyPath.PathToFollow[MyPath.PathIndex].transform.position,
            moveSpeed * Time.deltaTime);
        if (transform.position == MyPath.PathToFollow[MyPath.PathIndex].transform.position)
        {
            MyPath.PathIndex += 1;

        }
        if (MyPath.PathIndex == MyPath.PathToFollow.Length)
        {
            MyPath.PathIndex = 0;
            pesanan.isPesananSampe = true;
            if (!pesanan.isDropBener)
            {
                LevelManager.Instance.uang -= pesanan.makanan[0].harga;
            }
            else
            {
                pesanan.MunculDuit(pesanan.finalPesanan, rumah);


            }
            Destroy(gameObject);
            Destroy(pesanan.gameObject);
        }


    }

    public void AntarPesanan()
    {
        
    
    }
}
