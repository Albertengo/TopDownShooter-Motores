using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using interfaz;
using BotsEnemigos;

namespace Jugador
{
    public class VidaJugador : MonoBehaviour
    {
        #region variables
        public float SaludMax = 15; //variable fija
        public float Salud;
        public SliderHealth healthbar;
        [SerializeField] private float HPdropHealing; //lo que cure el objeto de curacion, valga la redundancia
        public Win_Lose screenL;
        #endregion

        #region funciones basicas
        void Start()
        {
            Salud = SaludMax;
            healthbar.startHealthBar(Salud);
            //Debug.Log("Nivel de vida: " + Salud);
        }

        #endregion

        #region code

        //Funcion collision para que cuando colisiones con enemigo, tome da�o.
        public void OnCollisionEnter2D(Collision2D collision) //OnCollisionStay2D funciona pero baja muy rapido la vida
        {
            if (collision.gameObject.CompareTag("Enemy1"))
                 Da�o(2);

            if (collision.gameObject.CompareTag("Enemy2"))
                Da�o(3);

            if (collision.gameObject.CompareTag("Enemy3"))
                Da�o(5);
            
        }

        public void Da�o(float da�oRecibido) //funcion con la mecanica de tomar da�o.
        {
            Salud -= da�oRecibido;
            healthbar.SetHealth(Salud);
            if (Salud <= 0)
            {
                //Debug.Log("Moriste.");
                screenL.ActiveScreen();
                healthbar.Desactivar();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) //para hacer curar y hacer desaparecer
        {
            if (collision.gameObject.CompareTag("Curar"))
            {
                if ((Salud + HPdropHealing) > SaludMax)
                {
                    Salud = SaludMax;
                }
                else
                {
                    Salud += HPdropHealing;
                }
                healthbar.SetHealth(Salud);
                //Debug.Log("El nuevo nivel de vida es:" + Salud);
                collision.gameObject.SetActive(false);
            }

        }
        #endregion
    }
}
