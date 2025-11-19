using UnityEngine;
using UnityEngine.UI;

public class FingerTouchPhone : MonoBehaviour
{
    //[SerializeField] private BoxCollider Button9;
    private textstuff text;

    private void OnTriggerEnter(Collider other)
    {

        text.onPress9();
        Debug.Log("fuck man");
        print("fuck man2");


    }
}
