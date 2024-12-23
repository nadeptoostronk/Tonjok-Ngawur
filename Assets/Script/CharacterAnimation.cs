using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
   private Animator anim;

   private void Awake()
   {
    anim = GetComponent<Animator>();
   }

   public void Run(float speed) {
    anim.SetFloat(AnimationTags.Run, Mathf.Abs(speed));
   }

   public void Jump(bool isJumping) {
    anim.SetBool(AnimationTags.Jumping_Bool, isJumping);
   }

   public void Attack1() {
    anim.SetTrigger(AnimationTags.Attack1_Trigger);
   }

   public void Attack2() {
    anim.SetTrigger(AnimationTags.Attack2_Trigger);
   }

   public void Ulti() {
    anim.SetTrigger(AnimationTags.Ulti_Trigger);
   }

   public void Hurt() {
      anim.SetTrigger(AnimationTags.Hurt_Trigger);
   }

   public void Defense(bool isDefense) {
      anim.SetBool(AnimationTags.Defense_Bool, isDefense);
   }

   public void Die(bool isDie) {
      anim.SetBool(AnimationTags.Die_Bool, isDie);
   }
}
