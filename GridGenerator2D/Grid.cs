using UnityEngine;
using System.Collections;

//Permet de rajouter une case dans le menu unity
[AddComponentMenu("Custom/Editor")]

public class Grid : MonoBehaviour {


    //Paramètre qui gère auteur, largeur et couleur de notre grille
    public float width = 1.0f;
    public float height = 1.0f;
    public Color color = Color.yellow;

    void OnDrawGizmos()
    {
        //On récupère la position x y de la caméra
        Vector3 pos = Camera.current.transform.position;
        //On initialise la couleur
        Gizmos.color = this.color;
        
        //Premiere boucle
        for(float y = pos.y - 250.0f; y < pos.y + 250.0f; y+= this.height)
        {
            //La fonction Draw Line prend le point de départ et d'arrivé de deux vector
            Gizmos.DrawLine(
                    new Vector3(-250.0f, Mathf.Floor(y / this.height) * this.height, 0.0f),
                    new Vector3(250.0f, Mathf.Floor(y / this.height) * this.height, 0.0f));
        }

        //Deuxième boucle
        for (float x = pos.y - 250.0f; x < pos.x + 250.0f; x += this.width)
        {
            Gizmos.DrawLine(
                    new Vector3(Mathf.Floor(x / this.width) * this.width, -250.0f ,  0.0f),
                    new Vector3(Mathf.Floor(x / this.width) * this.width, 250.0f , 0.0f));
        }

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
