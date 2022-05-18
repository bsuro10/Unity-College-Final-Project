using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterlifeGateScript : MonoBehaviour
{
    public List<GameObject> crystals;
    public GameObject door;
    public CameraShakeScript cameraShakeScript;

    private bool m_checkingForCrystals = false;
    private SphereCollider m_sphereCollider;
    private bool m_interactable = true;

    void Start()
    {
        m_sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (!m_checkingForCrystals)
        {
            StartCoroutine(CheckIfCrystalPresents());
        }
        if (m_interactable && crystals.Count == 0)
        {
            m_interactable = false;
            StartCoroutine(cameraShakeScript.Shake(7f, 0.02f));
            door.SetActive(true);
        }
    }

    IEnumerator CheckIfCrystalPresents()
    {
        m_checkingForCrystals = true;
        Collider[] hits = Physics.OverlapSphere(m_sphereCollider.transform.position, m_sphereCollider.radius);
        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                int crystalIndex = crystals.FindIndex(crystal => crystal.CompareTag(hit.tag));
                Debug.Log(crystalIndex);
                if (crystalIndex != -1)
                    crystals.RemoveAt(crystalIndex);
            }
        }
        yield return new WaitForSeconds(1f);
        m_checkingForCrystals = false;
    }
}
