using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
public class wallet : MonoBehaviour
{
    public Tilemap grid;
    public float money = 101;
    public GameObject Selector;
    public GameObject turrentToPlace;
    public LayerMask TurretLayer;
    public GameObject[] Turrents;
    public float[] prices;
    public float currentPrice;
    public Text moneyText;

    public void chooseTurret(int tNumber) {
        turrentToPlace = Turrents[tNumber];
        currentPrice = prices[tNumber];
    }
    public void spend(float amount) {
        if (money - amount > 0)
        {
            money = money - amount;
            moneyText.text = "Money: " + money.ToString();
        }
    }

    public void moneygained(float earned){
        money = money + earned;
        moneyText.text = "Money: " + money.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPrice = prices[0];
        moneyText.text = "Money: " + money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            turrentToPlace = null;
        }
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = grid.WorldToCell(mouseWorldPos);
        if (grid.HasTile(coordinate))
        {
            Vector3 location = grid.GetCellCenterWorld(coordinate);
            Selector.transform.position = location;
            RaycastHit2D hit = Physics2D.Raycast(location, Vector3.forward, 10, TurretLayer);
            if (hit.collider == null)
            {
                if (!Selector.activeSelf)
                {
                    Selector.SetActive(true);
                }
            }
            else
            {
                if (Selector.activeSelf)
                {
                    Selector.SetActive(false);
                }
                Debug.Log(hit.collider.name);
            }
           
            if (Input.GetMouseButtonDown(0) && turrentToPlace != null)
            {
                
                if (money - currentPrice >= 0)
                {
                    spend(currentPrice);

                    Instantiate(turrentToPlace, location, Quaternion.identity);
                }
            }
        }
    }
}
