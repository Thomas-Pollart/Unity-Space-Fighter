using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFighter
{
    public class DeleteWhenOutOfBounds : MonoBehaviour
    {
        [SerializeField]
        private float yposLimit = -15f;

        private void Update()
        {
            DeleteTargetWhenOutOfBounds();
        }

        private void DeleteTargetWhenOutOfBounds()
        {
            if (transform.position.y < yposLimit)
                Destroy(gameObject);
        }
    }
}
