using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCube : MonoBehaviour
{
    [SerializeField]
    private GameObject _instanceGo;
    [SerializeField]
    private int _instanceCount;
    [SerializeField]
    private bool _bRandPos = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _instanceCount; i++)
        {
            Vector3 pos = new Vector3(i * 1.5f, 0, 0);
            GameObject pGO = GameObject.Instantiate<GameObject>(_instanceGo);
            pGO.transform.SetParent(gameObject.transform);
            if (_bRandPos)
            {
                pGO.transform.localPosition = Random.insideUnitSphere * 15.0f;
                // pGO.GetComponent<Renderer>().material.color =
                //     new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
                // pGO.GetComponent<Renderer>().material.SetColor("_Color1",  new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));
                   
                // MaterialPropertyBlock block = new MaterialPropertyBlock();
                // block.SetColor("_Color", new Color(Random.Range(0, 1f),Random.Range(0, 1f),Random.Range(0, 1f)));
                // pGO.GetComponent<MeshRenderer>().SetPropertyBlock(block);
            }
            else
            {
                pGO.transform.localPosition = pos;
            }
        }
    }
}
