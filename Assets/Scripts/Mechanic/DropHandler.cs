using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    
    public Pesanan pesanan;
    delegate void _delegate();
    _delegate m_delegate;
    public Transform pembeli;
    public Transform rumah;

    private BikeFollow bk;

    public GameObject prefabBike;
    public AudioClip dropBener;
    public AudioClip dropSalah;
    public bool isDropBener;




    public void OnDrop(PointerEventData eventData)
    {
        pesanan = eventData.pointerDrag.GetComponentInParent<Pesanan>();
        rumah = eventData.pointerDrag.transform.parent.parent;
        
        pembeli = pesanan.pembeli.transform;
        if (pesanan != null)
        {
       
            if (pesanan.finalPesanan.id == transform.name) {
                pesanan.isDropBener = true;
                LevelManager.Instance.source.PlayOneShot(dropBener);
                m_delegate = Turun;
                LevelManager.Instance.emotionPoint += 1;
                pesanan.m_delegate -= pesanan.Flashing;
                pesanan.m_delegate += pesanan.CancelFlashing;
                pesanan.rumah = rumah;
                pesanan.namaPesanan = pesanan.finalPesanan.nama;

                LevelManager.Instance.currentPesanan -= 1;
                LevelManager.Instance.completePesanan++;


                GameObject bike = Instantiate(prefabBike, transform);
                
                Destroy(eventData.pointerDrag);

                BikePath path = null;
                foreach(Transform eachChild in rumah)
                {
                        
                    if (eachChild.name == pesanan.finalPesanan.id)
                    {
                        path = eachChild.GetComponent<BikePath>();
                        bike.GetComponent<BikeFollow>().MyPath = path;
                        
                        bike.GetComponent<BikeFollow>().pesanan = pesanan;
                        bike.GetComponent<BikeFollow>().namaPesanan = pesanan.finalPesanan.nama;
                        bike.GetComponent<BikeFollow>().rumah = rumah;
                    }
                }
                path.bike = bike;
                bike.GetComponent<BikeFollow>().AntarPesanan();
                LevelManager.Instance.source.PlayOneShot(bike.GetComponent<BikeFollow>().suaraMotor);

                //MunculDuit(pesanan.makanan[0].nama);
            }
            else
            {
                pesanan.isDropBener = false;
                LevelManager.Instance.source.PlayOneShot(dropSalah, 1);
                m_delegate = Turun;
                LevelManager.Instance.emotionPoint -= 2;
                pesanan.m_delegate -= pesanan.Flashing;
                pesanan.m_delegate += pesanan.CancelFlashing;
                LevelManager.Instance.currentPesanan -= 1;

                pesanan.rumah = rumah;
                pesanan.namaPesanan = pesanan.finalPesanan.nama;
                Destroy(eventData.pointerDrag);

                GameObject bike  = Instantiate(prefabBike,transform);

                BikePath path = null;
                foreach (Transform eachChild in rumah)
                {
                    if (eachChild.name == transform.name)
                    {
                        path = eachChild.GetComponent<BikePath>();
                        bike.GetComponent<BikeFollow>().MyPath = path;
                        bike.GetComponent<BikeFollow>().pesanan = pesanan;
                        bike.GetComponent<BikeFollow>().namaPesanan = pesanan.finalPesanan.nama;
                        bike.GetComponent<BikeFollow>().rumah = rumah;
                    }
                }
                path.bike = bike;
                bike.GetComponent<BikeFollow>().AntarPesanan();
                LevelManager.Instance.source.PlayOneShot(bike.GetComponent<BikeFollow>().suaraMotor);
                //Misalkan nanti dirubah lagi tinggal uncomment
                //LevelManager.Instance.uang -= pesanan.makanan[0].harga;

            }

        }
    }

    void Turun() {
        pembeli.transform.localPosition = Vector3.zero;
        pesanan.isDropped = true;
        pesanan.isComplete = true;
        m_delegate -= Turun;
        pesanan.m_delegate += pesanan.DestroyPesanan;
    }



    private void Update()
    {
        if (m_delegate == null)
            return;
        else
            m_delegate();
    }

    
}
