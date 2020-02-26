using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Camera;
    float TranslationStep = 100f;
    float RotationStep = 100f;

    private Vector3 Translation;
    private Vector3 Rotation;

    void Update()
    {
        //reset the vectors
        Translation = Vector3.zero;
        Rotation = Vector3.zero;

        //Translation controls
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Forward");
            Translation.z += TranslationStep;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Backward");
            Translation.z -= TranslationStep;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            Translation.x -= TranslationStep;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            Translation.x += TranslationStep;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Up");
            Translation.y += TranslationStep;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Down");
            Translation.y -= TranslationStep;
        }

        //Rotation controls
        //Pitch
        if (Input.GetKey(KeyCode.Home))
        {
            Debug.Log("Pitch Up");
            Rotation.x -= RotationStep;
        }
        if (Input.GetKey(KeyCode.End))
        {
            Debug.Log("Pitch Down");
            Rotation.x += RotationStep;
        }

        //Bank
        if (Input.GetKey(KeyCode.PageUp))
        {
            Debug.Log("Bank Left");
            Rotation.z -= RotationStep;
        }
        if (Input.GetKey(KeyCode.Insert))
        {
            Debug.Log("Bank Right");
            Rotation.z += RotationStep;
        }

        //Yaw
        if (Input.GetKey(KeyCode.Delete))
        {
            Debug.Log("Yaw Left");
            Rotation.y -= RotationStep;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            Debug.Log("Yaw Right");
            Rotation.y += RotationStep;
        }

        //Rotate
        Camera.Rotate(Rotation * Time.deltaTime);
        Camera.Translate(Translation * Time.deltaTime);
    }
}

