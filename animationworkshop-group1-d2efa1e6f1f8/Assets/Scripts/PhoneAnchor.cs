using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class PhoneAnchor : MonoBehaviour
{
    [SerializeField] private GameObject phone;
    [SerializeField] private Rigidbody phonerb;

    [SerializeField] private GameObject player;
    private Vector3 phonePos;
    private Vector3 anchorOffset = new Vector3(0.35f, -0.6f, -0.154f);

    private Coroutine returnCoroutine; //gemmer en reference til en coroutine.

    //phoneReturn forhindrer at flere coroutines køere samtidigt. hvis man ikke gør dette, kan interpolationen potentielt blive "jerky"

    public void phoneReturn()
    {
        if (returnCoroutine != null)
            StopCoroutine(returnCoroutine);

        returnCoroutine = StartCoroutine(ReturnAfterDelay(3f));
    }

    private IEnumerator ReturnAfterDelay(float delay)
    {
        phonerb.isKinematic = false;
        phonerb.useGravity = true;

        // vent før vi eksikverer resten af koden. kan kun gøres med IEnumerator.
        yield return new WaitForSeconds(delay);

        phonePos = phone.transform.position;

        float t = 0f;

        phonerb.isKinematic = true;
        phonerb.useGravity = false;
        //bug: hvis man bevæger sig mens interpolation kører. anker den sig til det forkerte sted.
        Vector3 target = player.transform.position + anchorOffset;

        // interpolerer mellem 2 punkter. ved at definere hastigheden af interpolationen som T, som gror hvert frame.
        while (t < 1f)
        {
            target = player.transform.position + anchorOffset;

            t += Time.deltaTime;
            phone.transform.position = Vector3.Lerp(phonePos, target, t);
            yield return null; /* dette er for at sikrer at interpolationen ikke sker lige med det samme ved at få coroutinen til at stoppe for et frame
                                * før den fortsætter videre i koden. hvis den ikke yielder færdiggøres interpolationen på et sekund. */
        }
       

        phone.transform.position = target; //for at forhindre at interpolationen overskyder.
        returnCoroutine = null; //markerer coroutinen som færdig.
    }
}