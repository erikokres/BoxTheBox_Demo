using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DS.BoxTheBox.Boss
{

    public class BossFireSpiral : MonoBehaviour
    {

        // [SerializeField] private int bulletAmount = 10;
        [SerializeField] private float angle = 0f;
        private Vector2 bulletMoveDirection;
        // Start is called before the first frame update
        void OnEnable()
        {
            InvokeRepeating("Fire", 0f, 0.1f);
        }

        private void Fire(){
            
            for (int i = 0; i <= 1 ; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = BossBulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<BulletBoss>().SetMoveDirection(bulDir);

            }
            
            angle += 10f;

            if(angle >= 360f){
                angle = 0f;
            }
        }

        private void OnDisable() {
            CancelInvoke();
        }
    }
}
