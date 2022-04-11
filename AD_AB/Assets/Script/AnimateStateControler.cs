using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateStateControler : MonoBehaviour
{
    //variables de animador
    public Animator anim;


    float velocityZ = 0f;
    float velocityX = 0f;

    public float acceleration = 2.0f;
    public float desacceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;

    int VelocityZHash;
    int VelocityXHash;
    // Start is called before the first frame update
    void Start()
    {
        VelocityZHash = Animator.StringToHash("velocityZ");
        VelocityXHash = Animator.StringToHash("velocityX");
    }


    // Update is called once per frame
    void Update()
     {
        //revisar si el jugador presiona w a d o shif izquierdo
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftdPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity; ;

        changeVelocity(forwardPressed, leftdPressed, rightPressed, runPressed, currentMaxVelocity);
        lockOrResetVelocity(forwardPressed, leftdPressed, rightPressed, runPressed, currentMaxVelocity);

        anim.SetFloat(VelocityZHash, velocityZ);
        anim.SetFloat(VelocityXHash, velocityX);
    }
    //aceleraciones y desaceleraciones
    void changeVelocity(bool forwardPressed, bool leftdPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {
        //velocidad en direacion Z
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        //velocidad a la izquierda
        if (leftdPressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        //velocidad a la derecha
        if (rightPressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //decrecer velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * desacceleration;
        }

        //incrementa velocityX si no izquierda y VelocityX0
        if (!leftdPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * desacceleration;
        }
        //incrementa velocityX si no derecha y VelocityX0
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * desacceleration;
        }
    }
    void lockOrResetVelocity(bool forwardPressed, bool leftdPressed, bool rightPressed, bool runPressed, float currentMaxVelocity)
    {

        //resetear velocidadZ
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }


        //rest velocityX
        if (!leftdPressed && !rightPressed && velocityX != 0.0f && (velocityX > -currentMaxVelocity && velocityX < currentMaxVelocity))
        {
            velocityX = 0.0f;
        }

        //lock forward
        if (forwardPressed && runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
            //deceselerar la velocidad maxima de caminar
        }
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * desacceleration;
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }

        //lock forward
        if (leftdPressed && runPressed && velocityX < -currentMaxVelocity)
        {
            velocityX = -currentMaxVelocity;
            //deceselerar la velocidad maxima de caminar
        }
        else if (leftdPressed && velocityX < -currentMaxVelocity)
        {
            velocityX += Time.deltaTime * desacceleration;

            if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05))
            {
                velocityX = -currentMaxVelocity;
            }
        }
        else if (leftdPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        {
            velocityX = -currentMaxVelocity;
        }

        //lock forward
        if (rightPressed && runPressed && velocityX > currentMaxVelocity)
        {
            velocityX = currentMaxVelocity;
            //deceselerar la velocidad maxima de caminar
        }
        else if (rightPressed && velocityX > currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * desacceleration;
            if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05))
            {
                velocityX = currentMaxVelocity;
            }
        }
        else if (rightPressed && velocityX < currentMaxVelocity && velocityX > (currentMaxVelocity - 0.05f))
        {
            velocityX = currentMaxVelocity;
        }
    }

}
