using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPaper : MonoBehaviour
{
    private GameObject objPaper;
    [SerializeField] private Color colorParticle;
    [SerializeField] private GameObject particle;

    void Update()
    {
        objPaper = GameObject.Find("GameEngine");
    }

    //Esta mandando essas mensagens para outro script que esta dentro do GameEngine
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (this.gameObject.tag)
            {
                case "Paper":
                    objPaper.SendMessage("GetPaper");
                    break;
                default:
                    break;
            }

            //Colocando cor nas particulas
            if (particle != null)
            {

                GameObject myParticle = Instantiate(particle);
                myParticle.transform.position = this.transform.position;

                ParticleSystem ps = myParticle.GetComponent<ParticleSystem>();
                ParticleSystem.MainModule psmain = ps.main;
                psmain.startColor = colorParticle;
                Destroy(this.gameObject);
            }
        }
    }
}
