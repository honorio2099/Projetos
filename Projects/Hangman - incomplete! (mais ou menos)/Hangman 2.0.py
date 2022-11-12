import os
import random
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
tema = 'fruta'
secret = ['banana']
tentativas = 5
consequences = [0,- 1,- 2]
###########################
acertos = 0
erros = 0 
option = 0
randomT = tentativas + random.choice(consequences)
underlines = " _ "
choice = ""
braveAttempt = ""
Gamefinish = False
letras = None
if letras is None:
    letras = []
Wrong = []
x = []
def interface():
    print("=============================================")
    print("|               JOGO DA FORCA               |")
    print("|-------------------------------------------|")
    print("|  OBS: Tentar a sorte pode ser tentador    |")
    print("| mas se errar, você pode perder algumas    |")
    print("| tentativas valiosas...                    |")
    print("=============================================")
    print("Tema do Jogo:", tema)
    if len(Wrong) > 0:
        print("Letras erradas -", *Wrong, sep= " ")
    print("Tentativas Restantes -",tentativas)
    print("-----------------------------------")
    print()
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
while Gamefinish != True:
    os.system('clear') 
    interface()
    print()
    option = int(input('Deseja escolher a letra ou tentar a sorte com a palavra direto? ([1] - Escolher a Letra | [2] - Tentar a Sorte)'))
    print("------------------------------------")
    for letra in secret[0]:
        if letra.lower() in letras:
            print(letra, end = ' ')
        else:
            print('_', end = " ")
        acertos += 1
    print()
    if option == 1: 
        choice = input('*Digite a letra escolhida*')
        choice = choice.lower()
        letras.append(choice)
    if choice not in secret[0]:
        Wrong.append(choice)
        erros += 1
        tentativas = tentativas - 1 #as tentativas só podem subtrair depois que todas as letras da secret forem comparadas com a choice (usar a ideia da palindroma), senão após a primeira tentativa ele encerra o programa
        print()
        print('Você errou :(')
    if option == 2:
        braveAttempt = input('*Digite a palavra correta*')
        if braveAttempt != secret[0]:
            print("Você tentou a sorte e errou! As consequências podem ser caras...")
            tentativas += randomT
            erros += 1
    Gamefinish = True
    for letra in secret[0]:
        if letra.lower not in letras: 
            Gamefinish = False
    final=[','.join(item.split(' ')) for item in secret[0]]
    if final in letras:
        Gamefinish = True
        break
    if braveAttempt == secret[0]:
        if tentativas >= 5:
            print('Você acertou a palavra de cara! Parabéns!!!')
            break
        else:
            print('Você acertou a palavra direto! Você teve',erros,'erros.')
            break
print()
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