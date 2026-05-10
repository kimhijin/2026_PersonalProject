using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace _03.Scripts.RollerCaster
{
    public class TrackController : MonoBehaviour
    {
        private SplineContainer _container;
        public List<Track> tracks;
        public Track currentTrack;
        public BezierKnot currentKnot;

        private void Awake()
        {
            _container = GetComponent<SplineContainer>();
        }

        [ContextMenu("Generate Tracks")]
        public void GenerateTracks()
        {
            Spline spline = _container.Spline;
            
            BezierKnot  knot = new  BezierKnot ();
            knot.Position  = transform.position;
            knot.Rotation = transform.rotation;
            
            knot.TangentIn = new Vector3(-1,0,0);
            knot.TangentOut = new Vector3(1,0,0);
            
            spline.Add(knot);
            
            currentTrack.SetUp(knot);
            currentKnot = knot;
        }

        [ContextMenu("Left Tracks")]
        public void LeftTrack()
        {
            currentTrack.LeftTrack(2,_container.Spline);
        }
        [ContextMenu("Right Tracks")]
        public void RightTrack()
        {
            currentTrack.RightTrack(2);
        }
    }
}