using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : Interactable
{
    public Animator _animacion;
    private bool battleStarted = false;
    public SpriteRenderer flash;    // Textura blanca que usamos para hacer el parpadeo (asociar en el inspector)

    [Range(1, 4)]
    public int nFlashes;            // Numero de flashes antes de comenzar la animación de transición (modificar en el inspector)

    public float shaderAnimationSeconds;    // Tiempo que dura la animación de transición al combate
    public float maxShaderTime;     // Valor de _IntroTime en el que la animación del shader está completa
    public float currentTime = 0;          // Valor actual de _IntroTime
    public float shaderTimeStep;           // La cantidad en la que aumenta el valor de _IntroTime cada vez que se llama a UpdateBattleIntro
    private float flashTimeStep = 0.1f;     // La cantidad en la que cambia la transparencia (color.alpha) del flash cada vez que se llama a UpdateFlash()

    private int flashDirection = 1;         // Sentido del fade del flash. 1 = se hace opaco, 0 = se hace transparente.

    // Start is called before the first frame update
    void Start()
    {
        // Habilitamos la variable _IntroTime para controlar el shader desde aquí
        _animacion = GetComponent<Animator>();
        shaderTimeStep = maxShaderTime / 100.0f;
    }

    // Update is called once per frame
    public override void Update()    
    {
        base.Update();
        battleStarted = battle;
   
        if (battleStarted) {
            UpdateFlash();
            if (currentTime >= maxShaderTime)
            {
                InvokeRepeating("UpdateBattleIntroNext", 0.5f, shaderAnimationSeconds / 100.0f);        
            }
        } 
    }


    void UpdateFlash() {
        // Actualizamos la transparencia del flash
        Color c = flash.color;
        c.a = c.a + flashTimeStep * flashDirection;
        flash.color = c;

        if (c.a <= 0 || c.a >= 1) flashDirection *= -1; // Cambiamos el sentido del fade para hacer el parpadeo del flash
        if (c.a <= 0) nFlashes--;   

        // Cuando hayamos hecho todos los flashes pasamos a la animación del shader
        if (nFlashes <= 0) {
            battleStarted = false;
            randNum = 1;
            InvokeRepeating("UpdateBattleIntro", 0.5f, shaderAnimationSeconds / 100.0f);
            SceneManager.LoadScene("BattleScene");
        }

    }

    // Esta función hace la animación del shader, actualizando el parámetro _IntroTime, que controla dicha animación

    
    void UpdateBattleIntro() {
        currentTime += shaderTimeStep;

        if (currentTime >= maxShaderTime){
            CancelInvoke();
        }
    }
    
     void UpdateBattleIntronNext() {
        currentTime -= shaderTimeStep;
        if (currentTime < 0)
            CancelInvoke();
    }
}

