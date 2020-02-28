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
            Translation.z += TranslationStep;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Translation.z -= TranslationStep;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Translation.x -= TranslationStep;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Translation.x += TranslationStep;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Translation.y += TranslationStep;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Translation.y -= TranslationStep;
        }

        //Rotation controls
        //Pitch
        if (Input.GetKey(KeyCode.Home))
        {
            Rotation.x -= RotationStep;
        }
        if (Input.GetKey(KeyCode.End))
        {
            Rotation.x += RotationStep;
        }

        //Bank
        if (Input.GetKey(KeyCode.PageUp))
        {
            Rotation.z -= RotationStep;
        }
        if (Input.GetKey(KeyCode.Insert))
        {
            Rotation.z += RotationStep;
        }

        //Yaw
        if (Input.GetKey(KeyCode.Delete))
        {
            Rotation.y -= RotationStep;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            Rotation.y += RotationStep;
        }

        //Rotate
        Camera.Rotate(Rotation * Time.deltaTime);
        Camera.Translate(Translation * Time.deltaTime);
    }
}

