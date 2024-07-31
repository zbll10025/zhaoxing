using System.Collections;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class phychik : MonoBehaviour
    {
        public Rigidbody2D bodyrig;
        public bool isPlatform;
        public Vector2 offestground;
        public float R;
        public LayerMask Platform;
        private void Awake()
        {
            bodyrig = GetComponent<Rigidbody2D>();
            Platform = LayerMask.GetMask("Platform");
            R =0.15f;
        }
        private void Update()
        {
            check();
        }


        public void check()
        {
            isPlatform = Physics2D.OverlapCircle((Vector2)transform.position + offestground, R, Platform);
        }
        public void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere((Vector2)transform.position +offestground, R);
        }

    }
}