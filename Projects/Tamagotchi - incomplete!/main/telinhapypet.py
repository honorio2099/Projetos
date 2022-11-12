import tkinter as tk
from tkinter import messagebox
from PIL import ImageTk, Image
from pypet import Pypet

class TelinhaPypet:
  def __init__(self,janelinha):
    #################################################################
    # PRINCIPAL PROBLEMA: tentei usar o .pack_forget para esconder  #
    # a caixa de entrada (Entry) e os botões OK após os botões      #
    # principais serem pressionados mas dá erro, tornando           #
    # insustentável a existência de uma nova caixa e botão OK       #
    # a cada vez que os botões principais forem pressionados e      #
    # que por extensão, também não seja possível alterar os valores #
    # desejados como fome, saúde e etc...                           #
    #################################################################
    self.pypet = Pypet()
    janelinha.title('Pypet Game!')
    self.frame = tk.Frame(janelinha)
    self.frame.pack()

    self.name = tk.Label(self.frame, text = '')
    self.name.pack()

    self.__level = tk.Label(text='Level:' + str(self.pypet.lvlUP))
    self.__level.pack(side = 'top',anchor = "nw")
    # melhor que apertar um botão para ver o level é
    # vê-lo a todo momento, a intenção é colocar na posição
    # máxima do topo e máxima a esquerda, logo abaixo do
    # título, pypet game, mas não estou acertando a posição
    
    self.up = tk.Button
    self.up.bind('<Up>',self.showinfo)
    # Up Arrow Key não funciona e dá erro no programa,
    # impedindo que a função para mostrar as informações
    # aconteça
    
    self.n = tk.Button(self.frame, text = 'Nome')
    self.n['bg'] = 'black'
    self.n['fg'] = 'white'
    self.n.bind('<Button-1>',self.altnome)
    self.n.pack()

    self.hunger = tk.Button(self.frame, text= 'Alimentar')
    self.hunger['bg'] = 'green'
    self.hunger['fg'] = 'white'
    self.hunger.bind('<Button-1>', self.killHunger)
    self.hunger.pack()

    self.heal = tk.Button(self.frame, text= 'Curar +')
    self.heal['bg'] = 'red'
    self.heal['fg'] = 'white'
    self.heal.bind('<Button-1>', self.healing)
    self.heal.pack()

    self.play = tk.Button(self.frame, text= 'Brincar')
    self.play['bg'] = 'yellow'
    self.play.bind('<Button-1>', self.playtime)
    self.play.pack()
    
  def showinfo(self,event):
     messagebox.showinfo("Informações sobre seu Pypet", self.pypet.mostrar)

  def altnome (self, event): 
    self.txt0 = 'Deseja adicionar ou mudar o nome de seu PyPet?'
    messagebox.askokcancel("Novo nome?", self.txt0)
    self.EnterName = tk.Entry(self.frame,border=2)
    self.EnterName['width'] = 10
    self.EnterName.pack(padx=10,pady=10)
    
    self.btn = tk.Button(self.frame,text='OK')
    self.btn.bind('<Button-1>',self.showname,self.namebtnHide_button,self.nameHide_button)
    self.btn.pack(padx=10,pady=10)
    # A intenção é fazer o ok realizar a ação de dar nome ao 
    # pypet e apagar o botão ok e o entry até que o botão nome
    # seja pressionado novamente. Lógica não funciona
  def showname (self,event):  
    self.pypet.nome = self.EnterName.get()
    self.name['text'] = self.pypet.nome
  def nameHide_button(self,event):
    self.EnterName.pack_forget()
  def namebtnHide_button(self,event):
    self.btn.pack_forget()
  

  def killHunger(self,event):
    self.txt1 = 'Informe o quanto deseja alimentar seu Pypet:'
    messagebox.showinfo("Matar a fome", self.txt1)
    self.informHunger = tk.Entry(self.frame,border=2)
    self.informHunger['width'] = 10
    self.informHunger.pack(padx=10,pady=10)
    self.pypet.fome = self.informHunger.get()
    if self.informHunger > 100:
      self.txthunger0 = 'Você quer matar o coitado com tanta comida usuário!!?? (ง︡'-'︠)ง'
      messagebox.showinfo("-_-", self.txthunger0)
      self.pypet.fome = 100
    if self.informHunger < 0:
      self.txthunger1 = 'Isso não deveria ser possível usuário, além de ser muita maldade. Como você fez isso??'
      messagebox.showinfo("-_-", self.txthunger1)
      self.pypet.fome = 0


  def healing(self,event):
    self.txt2 = 'Informe o quanto deseja curar seu Pypet:'
    messagebox.showinfo("Aumentar Saúde", self.txt2)
    self.informHealing = tk.Entry(self.frame,border=2)
    self.informHealing['width'] = 10
    self.informHealing.pack(padx=10,pady=10)
    self.pypet.saude += self.informHealing.get()
    if self.informHealing > 100:
      self.txtheal0 = 'Você vai causar uma overdose de remédios  no pobre Pypet usuário, você deveria cuidar dele!! (ง︡'-'︠)ง'
      messagebox.showinfo("-_-", self.txtheal0,icon='warning')
      self.pypet.saude = 100
    if self.informHealing < 0:
      self.txtheal1 = 'Isso não deveria ser possível usuário, além de ser muita maldade. Como você fez isso??'
      messagebox.showinfo("-_-", self.txtheal1,icon='warning')
      self.pypet.saude = 0

      
  def playtime(self,event):
    self.txt3 = 'Como pretende brincar? [1] - Ver TV (melhora baixa) [2] - Jogar bola (melhora mediana) [3] - Jogar Video-Game (Melhora muito)'
    messagebox.showinfo("Brincar", self.txt3)
    self.informPlaying = tk.Entry(self.frame,border=2)
    self.informPlaying['width'] = 10
    self.informPlaying.pack(padx=10,pady=10)
    self.y = self.informPlaying.get()
    while self.y < 0 or self.y > 3 or self.y != int:
      if self.y < 0:
        self.txtplay1 = 'Favor, escolher opção entre 1 e 3!'
        messagebox.showinfo("-_-", self.txtplay1)
        self.txt3 = 'Como pretende brincar? [1] - Ver TV (melhora baixa) [2] - Jogar bola (melhora mediana) [3] - Jogar Video-Game (Melhora muito)'
        messagebox.showinfo("Brincar", self.txt3)
        self.informPlaying = tk.Entry(self.frame,border=2)
        self.informPlaying['width'] = 10
        self.informPlaying.pack(padx=10,pady=10)
        self.y = self.informPlaying.get()
      if self.y > 3:
        self.txtplay2 = 'Favor, escolher opção entre 1 e 3!'
        messagebox.showinfo("-_-", self.txtplay2)
        self.txt3 = 'Como pretende brincar? [1] - Ver TV (melhora baixa) [2] - Jogar bola (melhora mediana) [3] - Jogar Video-Game (Melhora muito)'
        messagebox.showinfo("Brincar", self.txt3)
        self.informPlaying = tk.Entry(self.frame,border=2)
        self.informPlaying['width'] = 10
        self.informPlaying.pack(padx=10,pady=10)
        self.y = self.informPlaying.get()
      if self.y != int:
        self.txtplay3 = 'Escolha números e não letras usuário! Favor, respeitar as opções...'
        messagebox.showinfo("-_-", self.txtplay3)
        self.txtplay2 = 'Favor, escolher opção entre 1 e 3!'
        messagebox.showinfo("-_-", self.txtplay2)
        self.txt3 = 'Como pretende brincar? [1] - Ver TV (melhora baixa) [2] - Jogar bola (melhora mediana) [3] - Jogar Video-Game (Melhora muito)'
        messagebox.showinfo("Brincar", self.txt3)
        self.informPlaying = tk.Entry(self.frame,border=2)
        self.informPlaying['width'] = 10
        self.informPlaying.pack(padx=10,pady=10)
        self.y = self.informPlaying.get()
    if self.y == 1:
      self.pypet.x += -1
    if self.y == 2:
      self.pypet.x += -2
    if self.y == 3:
      self.pypet.x += -3
  
  #############fotinhas#######################################
  # criar a função faz com que a lógica das fotas não aconteça
  # fazendo com que não apareça nenhuma foto do Pypet ou talvex
  # só seja coisa do PIL do meu VS Code mesmo
  def fotinhas (self):
    i= 0
    while i == 0:
      if self.pypet.idade <= 10:
        self.frame1 = tk.Frame(width = 40, height = 40)
        self.frame1.pack()
        self.imgpypet = ImageTk.PhotoImage(Image.open("NewBorn Pypet.jpg"))
        self.label_imagem = tk.Label(self.frame,image=  self.imgpypet)
        self.label_imagem['width'] = 140
        self.label_imagem.pack()
      if self.pypet.idade >= 10 and self.pypet.humor == 'Feliz' or  self.pypet.humor == 'Super Alegre!' or self.pypet.fome > 70 and  self.pypet.saude > 70  :
        self.frame1 = tk.Frame(width = 40, height = 40)
        self.frame1.pack()
        self.imgpypet = ImageTk.PhotoImage(Image.open("HappyPypet.jpg"))
        self.label_imagem = tk.Label(self.frame,image= self.imgpypet)
        self.label_imagem['width'] = 140
        self.label_imagem.pack()
    if self.pypet.idade >= 10 and self.pypet.fome < 50 and self.pypet.saude  < 50:
        self.frame1 = tk.Frame(width = 40, height = 20)
        self.frame1.pack()
        self.imgpypet = ImageTk.PhotoImage(Image.open("NeedyPypet.jpg"))
        self.label_imagem = tk.Label(self.frame,image= self.imgpypet)
        self.label_imagem['width'] = 140
        self.label_imagem.pack()
    if self.pypet.idade >= 10 and self.pypet.humor == 'Triste' or self.pypet.humor == 'Com depressão':
        self.frame1 = tk.Frame(width = 40, height = 20)
        self.frame1.pack()
        self.imgpypet = ImageTk.PhotoImage(Image.open("BoredorStandbyPypet.jpg"))
        self.label_imagem = tk.Label(self.frame,image= self.imgpypet)
        self.label_imagem['width'] = 140
        self.label_imagem.pack()
    if self.pypet.idade >= 10 and self.pypet.humor == 'Contente' or self.pypet.fome > 45 and self.pypet.fome < 60 or self.pypet.saude > 45 and self.pypet.saude < 60 :
        self.frame1 = tk.Frame(width = 40, height = 20)
        self.frame1.pack()
        self.imgpypet = ImageTk.PhotoImage(Image.open("defaultPypet.jpeg"))
        self.label_imagem = tk.Label(self.frame,image= self.imgpypet)
        self.label_imagem['width'] = 140
        self.label_imagem.pack()
#############fotinhas#####################################
