using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      /*  EnemyCharacter human = other.GetComponent<BaseHuman>() as EnemyCharacter;// base humaný enemy Charackter gibi kullan yani tür dönüþümü yap diyoruz sýnýf olarak

        if (human) // base human sýnýfýný çaðýrýyoruz buraya
        {
            human.OnEnemyTrigger();
           
        }

        */ 

        //þimdi de interface ile uygulmasýný görelim    
        IDamageArea damageArea = other.GetComponent<IDamageArea>();
        if (damageArea != null) 
        {
            damageArea.OnEnteredDamageArea();
        
        }
        // böylelikle interfacedeki metoda eriþim saðlayabildim.
    }
}
