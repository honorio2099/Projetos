import os
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
tema = 'Super-Heróis'
secret = ['spiderman']
tentativas = 5
acertos = 0
erros = 0 # Está aqui caso o jogador queira testar a sorte
###########################
option = 0
y = [secret]
underlines = " _ "
choice = ""
Wrong = []
x = []
def interface():
    print("==========================================")
    print("|             JOGO DA FORCA              |")
    print("==========================================")
    print("Tema do Jogo:", tema)
    if len(Wrong) > 0:
        print("Letras erradas -", *Wrong, sep= ",")
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
    else:
         print(HANGMAN[5])
         print()
         print("FIM DE JOGO!!! Você foi enforcado(a) e enterrado(a)!")
while tentativas > 0:
    os.system('clear') 
    interface()
    choice = input('*Digite a letra escolhida ou a palavra secreta*')
    choice = choice.lower()
    print()
    for x in range(len(secret[0])):
        if choice in secret[0]:
                y[0][x] = choice
                print(*y[x]) 
                acertos += 1 #os acertos só podem contar depois que forem verificadas todas os indices de secret com a choice e for encontrada a choice (usar ideia da palindroma)
        elif choice not in secret[0]:
            Wrong.append(choice)
            erros += 1
            tentativas = tentativas - 1 #as tentativas só podem subtrair depois que todas as letras da secret forem comparadas com a choice (usar a ideia da palindroma), senão após a primeira tentativa ele encerra o programa
            print('Você errou :(')
    print (underlines * len(secret))
    if choice == secret[0]:
        acertos = len(secret)
    if acertos >= len(secret):
        print("Você Ganhou o Jogo e descobriu a palavra secreta sem nenhum erro!!!")
        if erros > 0:
            print("Você Ganhou o Jogo e descobriu a palavra secreta!!! você teve",erros,"erros.")
            break
print()
if tentativas == 0:
    print("Oops! Parece que você não conseguiu descobrir a palavra secreta. A palavra secreta era",secret)

    
    
    
    
    
    