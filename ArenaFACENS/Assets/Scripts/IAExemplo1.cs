using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAExemplo1 : MonoBehaviour {

	//private variables
    [SerializeField]
	LayerMask detectable; //Filtra o que é detectável por CharacterCommands.GetVision()
	Vector3 distance; //Distância entre o objeto e o personagem
	

	//public Variables
    public CharacterBehaviours characterBehaviours; //Esse é o script que possui as funções padrões e atributos do personagem

    // Player initialization
    void Awake () {
        characterBehaviours.PlayerName = "Player Name"; //Nome do seu personagem

        //Esses são os atributos que influeciam no desempenho do seu personagem no momento. Você tem 10 pontos para distribuir entre esses atributos:
        characterBehaviours.Vision = 5;
        characterBehaviours.Speed = 5;
	}
	
    //Essa parte do script é executada a cada 2 frames, é aqui que iremos chamar as funções do CharacterCommands
    //São esses: Charactercommands.GetVision(), CharacterCommands.SetPath(), CharacterCommands.CatchFood() e Charactercommands.CatchWeapon
	void FixedUpdate () {
        //Esse if DEVE ser colocado no começo do update para que o personagem não possa fazer mais nada ao ficar sem Hunger
        if (characterBehaviours.Hunger <= 0)
        {
            return;
        }

		characterBehaviours.FoundItems = CharacterCommands.GetVision(transform, characterBehaviours.Vision, detectable); //Lista de itens coletáveis detectados pelo GetVision()

        //Estrutura de decisão para traçar um caminho à determinado ítem
		if (characterBehaviours.FoundItems[0].transform.position != transform.position)
        {
			if (characterBehaviours.FoundItems[0])
			CharacterCommands.SetPath(transform, characterBehaviours.FoundItems[0].transform.position, characterBehaviours.Speed); //Nesse exemplo decidimos pegar o primeiro ítem da lista, não necessariamente o mais perto.
        }

		distance = characterBehaviours.FoundItems [0].transform.position - transform.position;                  //Nesse exemplo detectamos se estamos perto do item usando a distância entre o personagem e o ítem
                                                                                                                //Usamos essa lógica para ter certeza de que iremos pegar o item que definimos na estrutura de decisão
		if (distance.magnitude < 0.3f && characterBehaviours.FoundItems [0].tag == "Food")                      //Ao invés de pegar todos os itens que passarem pelo personagem
		{
			CharacterCommands.CatchFood(characterBehaviours, characterBehaviours.FoundItems [0].gameObject);
		}

		if (distance.magnitude < 0.3f && characterBehaviours.FoundItems [0].tag == "Weapon") 
		{
			CharacterCommands.CatchWeapon(characterBehaviours, characterBehaviours.FoundItems [0].gameObject);
		}
	
	}
}
