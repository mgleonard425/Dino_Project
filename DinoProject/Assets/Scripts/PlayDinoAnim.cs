using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayDinoAnim : MonoBehaviour {

        AROrigin arOrigin;
        GameObject dino;
        ARMarker baseMarker;
        Camera camera;
        GameObject dinoDex;
        Button button;

        // Use this for initialization
        void Start () {
                dino = GameObject.FindGameObjectWithTag("Dino");
                arOrigin = this.gameObject.GetComponentInParent<AROrigin>();
                camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
                button = dino.GetComponent<Button>();
                dinoDex = GameObject.FindGameObjectWithTag("TriDex");
        }

        void OnMarkerFound(ARMarker marker) {
                if(baseMarker == null) {
                        baseMarker = arOrigin.GetBaseMarker();
                }
                dinoDex.SetActive(false);
        }

        void OnMarkerLost(ARMarker marker){
                if(baseMarker.Equals(marker)){
                        baseMarker = arOrigin.GetBaseMarker();
                        dino.SetActive(true);
                        dinoDex.SetActive(false);
                }
        }

        void OnMarkerTracked(ARMarker marker){
                if(marker.Tag.Equals("hiro")) {
                // if(baseMarker != null && !(baseMarker.Equals(marker))) {
                        dino.transform.position = camera.transform.position;
                        // dino.transform.position = arOrigin.transform.position;
                        // dino.transform.rotation = arOrigin.transform.rotation;
                        dino.SetActive(false);
                        ShowText();
                }
        }

        void ShowText() {
                dinoDex.transform.position = dino.transform.position;
                dinoDex.SetActive(true);
        }

        // Update is called once per frame
        void Update () {

        }
}
