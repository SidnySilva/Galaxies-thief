// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet3 : MonoBehaviour
// {
//   [SerializeField]
//   float vel = 8f;
//   public bool        Cabe, 
//               Pa1=false,
//               Pa2=false,
//               Pa3=false,
//               Pa4=false,
//               Pa5=false;

//   public static Bullet instance;
//   void Start()
//   {
//   instance = this;
//   }
//   void Update()
//   {
//       transform.Translate(Vector3.up*vel*Time.deltaTime); 
//       if(transform.position.y>18f||transform.position.y<-24f||transform.position.x<-38f||transform.position.x>31f)
//       {
//           Destroy(this.gameObject);
//       }
//   }
//   public void OnTriggerEnter2D(Collider2D col)
//   {
//             if(col.gameObject.tag=="Enemy"||col.gameObject.tag=="Meteoro"||col.gameObject.tag=="Part5"||col.gameObject.tag=="Part4"||col.gameObject.tag=="Part3"||col.gameObject.tag=="Part2"||col.gameObject.tag=="Part1")
//             {
//               Destroy(this.gameObject);
              
//             }
//             if(col.gameObject.tag == "Part5")
//             {
//               Pa5 = true;
//             }
//             if(col.gameObject.tag == "Part4")
//             {
//               Pa4 = true;
//             }
//             if(col.gameObject.tag == "Part3")
//             {
//               Pa3 = true;
//             }
//             if(col.gameObject.tag == "Part2")
//             {
//               Pa2 = true;
//             }
//             if(col.gameObject.tag == "Part1")
//             {
//               Pa1 = true;
//             }
//             if(col.gameObject.tag == "Cabeça")
//             {
//               Cabe = true;
//             }
            
            
          
//     }
// }
