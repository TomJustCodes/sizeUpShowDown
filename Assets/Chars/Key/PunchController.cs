using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Chars.Key
{
    
    internal class PunchController : MonoBehaviour
    {
        public int ignplayer;
        public float delay = 0.2f;
        public void Start()
        {
            
        }
        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Tenter");
            PlayerVitalsController pvc = other.gameObject.GetComponent<PlayerVitalsController>();
            PlayerController pv = other.gameObject.GetComponent<PlayerController>();
            //Debug.Log(pvc.playerno);
            
            if (pvc != null)
            {
                if (ignplayer != pvc.playerno)
                {
                    Debug.LogError(ignplayer);
                    Debug.LogError(pv.playercode);
                    other.GetComponent<PlayerVitalsController>().hit(-1 * (this.transform.parent.position - other.transform.position), 1000);
                }
                
            }
        }

        IEnumerator WaitToDelete()
        {
            
            yield return new WaitForSeconds(delay);
            
            transform.parent.position = new Vector3(1000, 1000, 1000);
            //StopCoroutine(WaitToDelete());

        }
        public void waitToDelete()
        {
            
            StartCoroutine(WaitToDelete());
        }
    }
}
