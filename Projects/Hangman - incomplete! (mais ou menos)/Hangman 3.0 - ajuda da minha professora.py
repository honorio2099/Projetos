import os


def interface():
    os.system('clear') 
    print("=============================================")
    print("|               JOGO DA FORCA               |")
    print("|-------------------------------------------|")
    print("|  OBS: Tentar a sorte pode ser tentador    |")
    print("| mas se errar, você pode perder algumas    |")
    print("| tentativas valiosas...                    |")
    print("=============================================")
    print("Tema do Jogo:", tema)
    for letra in secret[0]:
      print('_', end = " ")      
      
    print("")
    if len(Wrong) > 0:
        print("Letras erradas -", *Wrong, sep= " ")
    print("Tentativas Restantes -",tentativas)
    print("-----------------------------------")
    print("")
    print(final)
    if tentativas == 5 or tentativas > 5:
        print(HANGMAN[0])
    elif tentativas == 4:
        print(HANGMAN[1])
    elif tentativas == 3:
        print(HANGMAN[2])
    elif tentativas == 2:
        print(HANGMAN[3])
    elif tentativas == 1:
        print(HANGMAN[4])
        print("Você está a uma tentativa de ser enforcado(a). Tome cuidado")
    else:
         print(HANGMAN[5])
         print()
         print("FIM DE JOGO!!! Você foi enforcado(a) e enterrado(a)!")
    global option
    option = int(input('([1] - Escolher a Letra | [2] - Tentar a Sorte)'))
    

HANGMAN = ['''
  +---+
  |   |
      |
      |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
      |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
  |   |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========''', '''
  +---+
--|-- |
| O | |
|/|\| |
|/ \| |
----- |
=========''']
# Conteúdo do programa apto a mudança de acordo com o jogo desejado:
tema = 'insetos'
secret = ['ant']
tentativas = 5
###########################
acertos = 0
erros = 0 
option = 0
underlines = " _ "
choice = ""
braveAttempt = ""
Gamefinish = False
letras = None
final = []
if letras is None:
    letras = []
Wrong = []
x = []
    
while Gamefinish != True:
  interface()
   
  if option == 1: 
    print("-----------------------------------")
    choice = input('*Digite a letra escolhida*')
    choice = choice.lower()
    letras.append(choice)
  
  if choice not in secret[0]:
    Wrong.append(choice)
    erros += 1
    tentativas = tentativas - 1 
    print()
    print('Você errou :(')
  else:
    if( len(final) == 0):
      for i in range(len(secret[0])):
        if choice == secret[0][i]:
          letra = secret[0][i]
          final.insert(i, letra)
        else:
          final.insert(i,' _ ')
    else:
      for i in range(len(secret[0])):
        if choice == secret[0][i]:
          letra = secret[0][i]
          final[i] = letra

  #para descobrir se acertamos a palavra e sair do WHILE
  qtdAcertos = 0  
  for i in range(len(secret[0])):
    if final[i] == secret[0][i]:
      qtdAcertos +=1

  if qtdAcertos == len(secret[0]):
    Gamefinish = True
  ##########################
    

if Gamefinish == True:
    if erros > 0:
        print("Você Ganhou o Jogo e descobriu a palavra secreta!!! você teve",erros,"erros.")
    if erros == 0:
        print("Você Ganhou o Jogo e descobriu a palavra secreta sem nenhum erro!!!")
elif Gamefinish == True and tentativas == 0:
    if acertos >= len(secret) - 1:
        print("Oops! Parece que você não conseguiu descobrir a palavra secreta mas chegou bem perto!!! A palavra secreta era",secret,'. Foi Quase!')
    else:
        print("Oops! Parece que você não conseguiu descobrir a palavra secreta. A palavra secreta era",secret)