using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Chars.Key
{
    public class KeyboardController : MonoBehaviour
    {
        public int intended = 90;
        public int dir = 1;
        public void Start()
        {
            
        }
        public void Update()
        {
           

            if (dir == 1)
            {
                if (transform.eulerAngles.x < intended)
                {
                    transform.Rotate(5, 0, 0);
                }
            }
            else
            {
                if (transform.eulerAngles.x > intended)
                {
                    transform.Rotate(-5 , 0, 0);
                }
            }
            
        }
    }
}
