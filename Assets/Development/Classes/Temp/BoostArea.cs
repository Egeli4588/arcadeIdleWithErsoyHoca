using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      /*  EnemyCharacter human = other.GetComponent<BaseHuman>() as EnemyCharacter;// base human� enemy Charackter gibi kullan yani t�r d�n���m� yap diyoruz s�n�f olarak

        if (human) // base human s�n�f�n� �a��r�yoruz buraya
        {
            human.OnEnemyTrigger();
           
        }

        */ 

        //�imdi de interface ile uygulmas�n� g�relim    
        IDamageArea damageArea = other.GetComponent<IDamageArea>();
        if (damageArea != null) 
        {
            damageArea.OnEnteredDamageArea();
        
        }
        // b�ylelikle interfacedeki metoda eri�im sa�layabildim.
    }
}
