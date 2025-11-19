using UnityEngine;


//public class PhoneAnchorOld : MonoBehaviour
//{

//    [SerializeField] GameObject phone;
//    [SerializeField] GameObject player;
//    private Vector3 phonePos;
//    //private Vector3 phoneAnchor = new Vector3(-0.209f, 0.286f, 0.154f);
//    //private CalcAnchor phoneAnchor;
//    private Vector3 AnchorPoint = new Vector3(-0.209f, 0.286f, -2f);



//    public Vector3 findPhonePos()
//    {
//        phonePos = phone.transform.position;

//        return phonePos;
//    }

//    float T = 0f;
//    float duration = 1f;
//    public void Mjolnir()
//    {
//        for (T = 0; T < 1;)
//        {
//            T += 0.1f;
//            phone.transform.position = Vector3.Lerp(phonePos, AnchorPoint, T);
//        }
//    }
//    public void phoneReturn()
//    {
//        findPhonePos();
//        //Invoke(nameof(Mjolnir), 3f);
//        Mjolnir();
//    }

//}
public class CalcAnchor : MonoBehaviour
{

    [SerializeField] GameObject phone;
    [SerializeField] GameObject player;

    private Vector3 AnchorPoint;
    public Vector3 returnAnchor()
    {
        phone.transform.position = player.transform.position;
        phone.transform.position += new Vector3(-0.209f, 0.286f, 0.154f);
        AnchorPoint = phone.transform.position;

        return AnchorPoint;
    }
}
