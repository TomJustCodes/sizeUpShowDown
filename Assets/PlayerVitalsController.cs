using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets
{
    public class PlayerVitalsController: MonoBehaviour
    {

        public Material skin;
        public Material flash;
        public int percent;
        Rigidbody rb;
        public TMPro.TextMeshProUGUI tmp;

        public TMPro.TextMeshProUGUI tmpLives;
        public int playerno;

        public int lives = 3;
        public void Start()
        {
            rb = GetComponent<Rigidbody>();
            skin = GetComponentInChildren<SkinnedMeshRenderer>().material;
        }
        public void hit(Vector3 direction, int ammount)
        {
            Debug.LogError("qwwqe" + GetComponent<PlayerAttackController>().blocking.ToString());
            if (GetComponent<PlayerAttackController>().blocking == false)
            {
                rb.AddForce(new Vector3(direction.x, 0, direction.z).normalized * ammount * 5 * (1 + (percent / 50)));
                percent += (ammount / 100);
                tmp.text = percent + "%";
                
            
                StartCoroutine(BlinkSkinColor());


            }
            
        }
        IEnumerator BlinkSkinColor()
        {

            GetComponentInChildren<SkinnedMeshRenderer>().material = flash;
            //GetComponentInChildren<SkinnedMeshRenderer>().SetMaterials(new List<Material>{skin});
            yield return new WaitForSeconds(0.2f); // Wait for a short duration

            GetComponentInChildren<SkinnedMeshRenderer>().material = skin; // Revert to the original color
        }
                
        
        public void setLives(int lives)
        {
            this.lives = lives;
            tmpLives.text = lives + " Lives";
            tmp.text = percent + "%";


            if (lives == 0)
            {
                GameObject.Find("wepoilfhweoipufhwef").GetComponent<EndGameController>().qwe.SetActive(true);
            }
        }





    }
}
