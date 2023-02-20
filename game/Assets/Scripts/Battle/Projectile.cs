using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Battle;

namespace RPG.Battle
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1;
        [SerializeField] int damage = 5;

        Health target = null;

        // Update is called once per frame
        void Update()
        {
            if (target == null) return;

            transform.LookAt(GetAimLocation());
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void SetTarget(Health target)
        {
            this.target = target;
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();

            if (targetCapsule == null) return target.transform.position;

            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Health>() != target) return;
            // target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
