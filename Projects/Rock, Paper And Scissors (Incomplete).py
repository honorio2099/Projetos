import os
import random
def interface():
    print("=================================")
    print("| Rock, Paper and Scissors Game |")
    print("=================================")
choices = ['rock','paper','scissors']
cont = 0
winsC = 0
winsP = 0
tie = 0
time = ''
while cont != 4:
    interface()
    player = input("Choose Between Rock, Paper or Scissors: ")
    comp = random.choice(choices)
    print('The Player choice is:',player)
    print('The Computer choice is:',comp)
    if player == ('Rock') or ('rock') and comp == ('Rock') or ('rock'):
        print("It's a TIE! Both chose Rock!")
        tie += 1
    if player == ('Paper') or ('paper') and comp == ('Paper') or ('paper'):
        print("It's a TIE! Both chose Paper!")
        tie += 1
    if player == ('Scissors') or ('scissors') and comp == ('Scissors') or ('scissors'):
        print("It's a TIE! Both chose Scissors!")
        tie += 1

    if player == ('Rock') or ('rock') and comp == ('Paper') or ('paper'):
        print("Computer Won!")
        winsC += 1

    if player == ('Paper') or ('paper') and comp == ('Rock') or ('rock'):
        print("Player Won!")
        winsP += 1

    if player == ('Scissors') or ('scissors') and comp == ('Paper') or ('paper'):
        print("Player Won!")
        winsP += 1

    if player == ('Paper') or ('paper') and comp == ('Scissors') or ('scissors'):
        print("Computer Won!")
        winsC += 1

    if player == ('Rock') or ('rock') and comp == ('Scissors') or ('scissors'):
        print("Player Won!")
        winsP += 1

    if player == ('Scissors') or ('scissors') and comp == ('Rock') or ('rock'):
        print("Computer Won!")
        winsC += 1
    cont += 1
    time = input('Press Enter to continue')
    os.system('clear')
  
if winsC > winsP:
    print("The Computer Won the Game !!!")
if winsP > winsC:
    print("The Player Won the Game !!!")
