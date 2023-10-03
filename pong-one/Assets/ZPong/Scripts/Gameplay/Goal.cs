using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZPong
{

    public class Goal : MonoBehaviour
    {
        private BoxCollider2D collider;


        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<BoxCollider2D>();

            SetHeightBounds();

            GameManager.Instance.SetGoalObj(this);
        }

        public void SetHeightBounds()
        {
            collider.size = new Vector2(collider.size.x, UIScaler.Instance.GetUIHeight());
        }
    }

}