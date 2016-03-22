using UnityEngine;
using System.Collections;

public class Joueur : MonoBehaviour {
    //Variable public qui gère la vitesse
    public float speed = 1.0f;
    //Bool pour vérifier que le personnage n'est pas déjà entrain de sauter
    private bool isJumping = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    //FixedUpdate est utilisé car les ecarts entre deux appelles sont les mêmes
    void FixedUpdate()
    {
    
      //On check si la touche escpace est enfoncé
      if (Input.GetKeyDown(KeyCode.Space))
        {
            //L'action de saut ne se fait que si le bool est à true
            if (!this.isJumping)
            {
                //On utilise une Coroutine pour pouvoir faire une pause pendant le saut
                StartCoroutine(Jump());
            }
        }
      //On check si la touche Q est pressé
      if (Input.GetKey(KeyCode.Q))
        {
            //On translate le personnage vers la gauche
            transform.Translate(Vector2.left * this.speed * Time.deltaTime);
            //On fait en sorte que le personnage regarde dans la direction du déplacemment
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //On check si la touche Q est pressé
        if (Input.GetKey(KeyCode.D))
        {
            //On translate le personnage vers la gauche
            transform.Translate(Vector2.right * this.speed * Time.deltaTime);
            //On fait en sorte que le personnage regarde dans la direction du déplacemment
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


    IEnumerator Jump()
    {
        //On met le bool à true
        this.isJumping = true;
        //On applique une force au rigidBody vers le haut
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        //On fait la pause de 1.5s
        yield return new WaitForSeconds(1.5f);
        //On remet le bool a false
        this.isJumping = false;
    }
}
