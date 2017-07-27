// Fixed Joint Grab Attach|GrabAttachMechanics|50040
namespace VRTK.GrabAttachMechanics
{
    using UnityEngine;

    /// <summary>
    /// The Fixed Joint Grab Attach script is used to create a simple Fixed Joint connection between the object and the grabbing object.
    /// </summary>
    /// <example>
    /// `VRTK/Examples/005_Controller_BasicObjectGrabbing` demonstrates this grab attach mechanic all of the grabbable objects in the scene.
    /// </example>
    [AddComponentMenu("VRTK/Scripts/Interactions/Grab Attach Mechanics/VRTK_FixedJointGrabAttach")]
    public class Custom_FixedJointGrabAttach : VRTK_BaseJointGrabAttach
    {

        GameManager GM;

        [Tooltip("Maximum force the joint can withstand before breaking. Infinity means unbreakable.")]
        public float breakForce = 1500f;

        public void Awake()
        {
            GM = GameManager.Instance;
        }

        protected override void CreateJoint(GameObject obj)
        {
            givenJoint = obj.AddComponent<FixedJoint>();
            givenJoint.breakForce = (grabbedObjectScript.IsDroppable() ? breakForce : Mathf.Infinity);
            base.CreateJoint(obj);
        }

        public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
        {
            Debug.Log("Grabbed!!!");
            GM.isHoldingObjective = true;

            if (base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint))
            {
                SnapObjectToGrabToController(givenGrabbedObject);
                return true;
            }

            return false;

        }
    }
}