using UnityEngine;
using System.Collections;

public class ConnectMarkersWithLine : MonoBehaviour {
    AROrigin arOrigin;
    LineRenderer line;
    ARMarker baseMarker;

    // Use this for initialization
    void Start () {
        line = GameObject.FindGameObjectWithTag ("arLine").GetComponent<LineRenderer>();
        arOrigin = this.gameObject.GetComponentInParent<AROrigin>(); // Unity v4.5 and later.
    }

    void OnMarkerFound(ARMarker marker)
    {
        if (baseMarker == null) {
            baseMarker = arOrigin.GetBaseMarker();
        }
    }

    void OnMarkerLost(ARMarker marker){
        if(baseMarker.Equals(marker)){
            baseMarker = arOrigin.GetBaseMarker();
        }
    }

    void OnMarkerTracked(ARMarker marker){
        //Make sure that we have a baseMarker and another marker which is not the baseMarker
        if (baseMarker != null && !(baseMarker.Equals (marker))) {
            Vector3 positionStart = ARUtilityFunctions.PositionFromMatrix (arOrigin.transform.localToWorldMatrix);
            line.SetPosition (0, positionStart);
            Vector3 positionTarget = ARUtilityFunctions.PositionFromMatrix (arOrigin.transform.localToWorldMatrix * baseMarker.TransformationMatrix.inverse * marker.TransformationMatrix);
            line.SetPosition (1, positionTarget);
            line.SetWidth (0.001f / positionTarget.magnitude, 0.001f / positionTarget.magnitude);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
