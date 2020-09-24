using UnityEngine;

public class SpiderAnimationAttack : StateMachineBehaviour
{
    private AudioSource _audioSource;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<BoxCollider>().enabled = true;
        animator.gameObject.GetComponent<BoxCollider>().isTrigger = true;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {// Ref: https://answers.unity.com/questions/728518/making-my-player-attack-and-do-damage-when-button.html
        // Here's where I put code that will be exevuted during the animatiobn
        int hitRange = 20;
        RaycastHit hit;
        Vector3 forward = animator.transform.TransformDirection(Vector3.forward);
        Vector3 origin = animator.transform.position;

        if (Physics.Raycast(origin, forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Human")
            {
                PlaySoundWithInterval(1.5f, 0.5f);

                //IncreaseCountdown(hit.transform.gameObject.GetComponent<Human>().TimeValue);
                hit.transform.gameObject.SendMessage("SetInactiveHuman");
            }
        }

    }

    /// <summary>
    /// Find and plays the soundeffect for eating humans
    /// </summary>
    /// <param name="audioDuration"></param>
    /// <param name="audioStartPoint"></param>
    void PlaySoundWithInterval(float audioDuration, float audioStartPoint = 0.01f)
    {
        // ref: https://forum.unity.com/threads/soundchannel-cpp.371808/#post-2411098
        _audioSource = GameObject.Find("CrunchEffect").GetComponent<AudioSource>();
        _audioSource.time = Mathf.Min(audioDuration, _audioSource.clip.length - audioStartPoint);

        _audioSource.Play();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var testar = animator.gameObject.GetComponent<BoxCollider>().enabled = false;
        animator.gameObject.GetComponent<BoxCollider>().isTrigger = false;

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
