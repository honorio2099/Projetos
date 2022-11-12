Algoritmo "Jogo da Velha"
// Disciplina   : [Algoritmos]
// Professor   : Francisco Vichi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 22/05/2022
Var
   // Seção de Declarações das variáveis
   jogo: vetor [1..3,1..3] de caractere
   posicao: inteiro
   A,B: inteiro
   L,C, Fim: inteiro
   qtde,QTDE2,cont: inteiro
   resp,player,vic: caractere

procedimento interface()
Inicio
   escreval("==================================================")
   escreval("                  Jogo da Velha                   ")
   escreval("==================================================")
   escreval ("+-----+-----+----+")
   para L de 1 ate 3 faca
      para C de 1 ate 3 faca
         escreva ("! ")
         escreva ("",jogo[L,C]:1)
         escreva ("  |")
      fimpara
      escreval ()
      escreval ("+-----+-----+----+")
   fimpara
   escreval("==================================================")
fimprocedimento

procedimento fimdejogo()
Inicio
   para L de 1 ate 3 faca
      se (jogo[L,1] = jogo[L,2]) e (jogo[L,2] = jogo[L,3]) entao
         Fim <- 1
         vic <- player
      fimse
   fimpara
   para L de 1 ate 3 faca
      se (jogo[1,L] = jogo[2,L]) e (jogo[2,L] = jogo[3,L]) entao
         fim <- 1
         vic <- player
      fimse
   fimpara
   se (jogo[1,1] = jogo[2,2]) e (jogo[2,2] = jogo[3,3]) entao
      fim <- 1
      vic <- player
   fimse
   se (jogo[1,3] = jogo[2,2]) e (jogo[2,2] = jogo[3,1]) entao
      fim <- 1
      vic <- player
   fimse
   se jogo[A,B] <> jogo[A,B] entao
      escreval(" Velha # ")
      fim <- 1
   fimse
fimprocedimento

procedimento logicaprincipal()
Inicio
   A <- 1
   B <- 1
   enquanto (jogo[A,B] <> resp) faca
      se (jogo[A,B] <> resp) entao
         B <- B + 1
         se (B > 3) entao
            A <- A + 1
            B <- 1
         fimse
         se (A > 3) entao
            A <- 1
            limpatela
            interface()
            escreval()
            escreva("Erro, Jogada Inválida! ")
            leia (resp)
         fimse
      fimse
   fimenquanto
fimprocedimento


Inicio
   // Seção de Comandos, procedimento, funções, operadores, etc...

   para L de 1 ate 3 faca
      para C de 1 ate 3 faca
         cont <- cont + 1
         jogo[L,C] <- Numpcarac(cont)
      fimpara
   fimpara
   interface()
   repita
      escreval("--------------------------------------")
      escreva("Quem vai começar jogando: (X) ou (O) ? ")
      leia(player)
      se player = "X" entao
         qtde <- 1
      fimse
      se player = "O" entao
         qtde <- 2
      fimse
      se ((player) <> ("X")) ou ((player) <> ("O")) entao
         escreval("Favor, Informar entre (X) ou (O)")
      fimse
   ate ((player) = ("X")) ou ((player) = ("O"))
   limpatela
   interface()
   repita
      escreval("-----------------------------")
      escreva ("Em que posição deseja jogar? ")
      leia (resp)
      logicaprincipal()
      escolha qtde
      caso 1
         jogo[A,B] <- "X"
      caso 2
         jogo[A,B] <- "O"
         qtde <- 0
      fimescolha
      qtde <- qtde + 1
      limpatela
      interface()
      fimdejogo()
   ate (fim = 1)
   escreval("Fim de Partida!")
   escreval("O jogador vencedor foi o ", vic,", Parabéns!")

Fimalgoritmo