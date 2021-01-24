using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public static class ExtensionMethods
    {

        public static void ClearChildren(Transform t)
        {
            foreach (Transform child in t)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
