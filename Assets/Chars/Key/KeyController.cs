using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Chars.Key
{
    public class KeyController : MonoBehaviour
    {
        public void addForce()
        {
            Debug.LogError("qwe");
            
            GetComponent<Rigidbody>().velocity = new UnityEngine.Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f,1f));
            GetComponent<Rigidbody>().AddForce(0, 8000,0);
            GetComponent<Rigidbody>().AddForce(0, 10000,0);
        }
    }
}
