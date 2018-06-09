using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviours : Character {

    Text playerNameText; //Nome do seu personagem

    private void Start()
    {
        if (Weapon == null)
        {
            Weapon = Instantiate(Resources.Load<Weapon>("Prefabs/DemFists"), transform.position, Quaternion.identity);
            CharacterCommands.CatchWeapon(this, Weapon.gameObject);
        }
        if (GetComponentInChildren<Canvas>())
        {
            playerNameText = GetComponentInChildren<Text>();   //PlayerNameText é um componente do canvas filho do prefab. Deve ser referenciado dessa maneira para que o nome do seu personagem apareça na tela do jogo
            playerNameText.text = PlayerName;
        }
    }


    
}
