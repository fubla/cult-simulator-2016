using UnityEngine;
using System.Collections;

// Handles Cult random Animations and calls PoseCheck
public class SimpleRandom : StateMachineBehaviour {
    static private int Bow           = Animator.StringToHash("Base Layer.metarig|bow");
    static private int LookUp        = Animator.StringToHash("Base Layer.metarig|lookUp");
    static private int Idle          = Animator.StringToHash("Base Layer.metarig|Idle");
    static private int HandsForward  = Animator.StringToHash("Base Layer.metarig|HandForward");
    static private int HandsSideways = Animator.StringToHash("Base Layer.metarig|handsSideways");

    // Animator.StringtoHash not marked as const?!
    // public enum AnimationNameHashes {
    // }

    System.Random randomGen = new System.Random();
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float newSpeed = animator.speed;

        // hashes not constant, cannot use switch case
        if (stateInfo.fullPathHash == Bow) {
            newSpeed = GameManager.gm.PoseCheck(Position.none, Position.none, Position.down);

        } else if (stateInfo.fullPathHash == LookUp) {
            newSpeed = GameManager.gm.PoseCheck(Position.none, Position.none, Position.up);

        // } else if (stateInfo.fullPathHash == Idle) {
        //    newSpeed = GameManager.gm.PoseCheck(Position.none, Position.none, Position.none);

        } else if (stateInfo.fullPathHash == HandsForward) {
            newSpeed = GameManager.gm.PoseCheck(Position.front, Position.front, Position.none);

        } else if (stateInfo.fullPathHash == HandsSideways) {
            newSpeed = GameManager.gm.PoseCheck(Position.left, Position.right, Position.none);

        } else {
            Debug.Log("Animation hash not found! not added or typoed!");
        }


        animator.speed = newSpeed;
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
        animator.SetInteger("Selector", randomGen.Next(5));
    }

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
