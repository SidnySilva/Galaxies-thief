using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sound
{
    Shoot, Destroy, PowerUp, SShoot, Bip
}
public class AudioController : MonoBehaviour
{
    public AudioClip shoot, destroy, powerup, Sshoot, bip;
    private AudioSource audi;
    public static AudioController instance;
    

    
    void Start()
    {
        audi = GetComponent<AudioSource>();
        instance = this;
    }

    public static void PlaySounds(sound currentSound)
    {
        switch(currentSound)
        {
            case sound.Shoot:
                instance.audi.PlayOneShot(instance.shoot);
            break;
            
            case sound.SShoot:
                instance.audi.PlayOneShot(instance.Sshoot);
            break;

            case sound.PowerUp:
                instance.audi.PlayOneShot(instance.powerup);
            break;

            case sound.Destroy:
                instance.audi.PlayOneShot(instance.destroy);
            break;
            
            case sound.Bip:
                instance.audi.PlayOneShot(instance.bip);
            break;
        }
    }

    

    
}
