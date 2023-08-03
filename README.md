# MinimolApplication
Este projeto faz parte do Teste Técnico para a vaga de Mid-Level Programmer da Minimol Games.

## Sobre o Projeto
### Instruções:
O projeto é um ”Shooter” onde o jogador vai tentar matar a maior quantidade de inimigos
possíveis, porém existem alguns problemas:
- O jogador deveria morrer quando o inimigo encosta nele.
- A performance do jogo cai quando:
- Existem muitos inimigos
- Conforme o jogador atira
### O que deve ser feito:
- Identifique as causas dos problemas acima e faça as correções que julgar
adequadas.
- Implemente a criação dos inimigos na fase.
- Implemente as alterações necessárias para que o jogador possa ser atingido mais
vezes antes de morrer.

## Problemas Encontrados

### O projeto original possui vários problemas críticos que podem ocasionar perda de eficiência. Entre os principais problemas, podemos destacar os seguintes:
1) Chamadas de métodos como "GetComponent" e "FindObjectOfType" dentro de métodos como "OnCollisonEnter" e "Update"

![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/1a9dc51f-147b-4c8d-afb2-a9184f0f6b37)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/f294a036-8cdb-4417-bd49-a9adc027def9)


2) Instanciação e Destruição de Objetos de forma não otimizada, podendo causar um grande consumo de recursos

![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/8b3c326b-5395-443e-a2b6-0634898fd550)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/75c50381-f4e8-44e4-bfa4-8779478080d9)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/1ff698c6-adec-4535-b549-ebfafb1d1ab7)


### Além dos problemas mais críticos, podemos observar outros pontos passíveis de otimização

3) Detectar colisões por meio do OnColisionEnter do objeto Enemy
4) Realizar movimentação do inimigo sem utilizar recursos nativos da Unity mais otimizados
5) Não seguir boas práticas de escrita de código

## Soluções e Alterações
### Para resolver os problemas mais críticos, foram utilizadas algumas técnicas, como:
1) Para o problema causado pelo uso excessivo do "GetComponent" e "FindObjectOfType", adotou-se o padrão de projeto Singleton para a criação de um Objeto "ServiceLocator", que possui referência para o Objeto "PlayerController" que está constantemente sendo acessado por diversos locais do projeto, sendo necessário fazer referência deste objeto apenas uma unica vez, neste caso, pelo próprio inspector da Unity.

![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/e38234c7-c0bd-4f14-b282-923e9fe7665c)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/e3e74c65-3a45-47ba-a322-8b941bade009)

2) Para o problema causado pela Instanciação e Destruição não otimizada, adotou-se o padrão de projeto Object Pooling, que reaproveita objetos que seriam criados e destruídos de forma frequente, reutilizando aqueles que já foram utilizados, e que, após seu uso, passam a estar disponíveis para utilização novamente. Este padrão de projeto foi utilizado tanto para inimigos quanto para balas.

![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/f330e38e-83d7-47fc-8da4-ae1bd9648338)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/836241cc-fa16-4ef7-be32-f85321fe41c7)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/2cec9963-c295-4554-981e-30f7f4be71fb)
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/fa576d6c-6563-421e-95b7-c6908fd1e695)


3) Para resolver o problema das colisões dos inimigos, passou-se a utilizar o evento "OnTriggerEnter" para detectar colisões no Player ao invés de detectar a colisão no Enemy.
4) 
   ![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/410f3125-863b-4e1a-b1bf-bb3efd262652)

5) Para a movimentação do Inimigo, passou-se a utilizar o Component NavmeshAgent, em uma função que é chamada quando o GameObject do Enemy fica ativo, e a cada vez que o player se movimenta, fazendo o uso do padrão de projeto Delegate, para mudar o destino da movimentação.
   
![image](https://github.com/Pedrohenrimp/MinimolApplication/assets/59147319/48bfdd33-ef4f-4bc1-91fb-f37512b1b06f)

6) Para as boas práticas de escrita de código, além da utilização dos padrões de projeto citados, como, Singleton, ObjectPooling, e Delegate, também foram utilizado os princípios S.O.L.I.D. da programação orientada a objetos, quando os mesmos fazem sentido para o projeto.


### Outros Detalhes
Além das melhorias citadas acima, foram implementadas pequenas alterações para tornar o projeto mais dinâmico:
1) Flexibilização da morte do Player utilizando um sistema de contagem de vida que diminui a cada nova colisão;
2) Flexibilização do tempo de spawn dos Inimigos, bem como o raio de spawn (circunferência a partir da posição do Player);
3) Flexibilização da quantidade máxima de objetos criados utilizando o Object Pooling;
4) Criação de feedback visual simples para a contagem de vida do Player, contagem de inimigos abatidos e indicação de fim do jogo;
5) Possibilidade de Reiniciar o jogo sem precisar reiniciar a aplicação para facilitar os testes.

