import mysql.connector
import tkinter as tk
from tkinter import ttk
from tkinter import messagebox
from barbeiros import Barbeiros
from barbeirosDAO import BarbeirosDAO
from clientes import Clientes
from clientesDAO import ClientesDAO
from cortes import Cortes 
from cortesDAO import CortesDAO
from agenda import Agenda
from agendaDAO import AgendaDAO 
from telacortes import TelaCortes
from telaRegister import TelaRegister

# ComboBox de cortes, e barbeiros disponíveis!
# cadastro de clientes e suas informações e barbeiros

class Tela():
    
    
    __barbeiros = Barbeiros()
    __barbeirosDAO = BarbeirosDAO()
    __clientes = Clientes()
    __clientesDAO = ClientesDAO()
    __cortes = Cortes()
    __cortesDAO = CortesDAO()
    agenda = Agenda()
    __agendaDAO = AgendaDAO()
    __telaCortes = TelaCortes()
    __telaRegister = TelaRegister()
    
    def __init__ (self, janela):
        janela = tk.Toplevel()
        janela.geometry("300x150")
        janela.title('Tela Principal') 
        ########################### - "Título"
        self.__frame1 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2)
        self.__frame1.pack(padx=5,pady=5)

        ttk.Label(self.__frame1, text = 'BarberShop - Peaky Blinders', font = ('Calibri',18)).pack()
        ttk.Label(self.__frame1, text = '(Frios e Calculistas)').pack()
        ####################################################################################
        # - janela que linka barbeiro, cliente, corte e preço com table agenda, também linkando
        # funções a outras janelas com suas próprias razões
        
        self.__frame2 = ttk.Frame(janela)
        self.__frame2.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame2, text = 'Escolha sua opção:').pack()
        
        self.__frame3 = ttk.Frame(janela)
        self.__frame3.pack(padx=5,pady=5)
        
        self.__btnCortes = ttk.Button(self.__frame3,
        text = 'Cadastro de Cortes',command=self.Cortes)
        self.__btnCortes.pack(side=tk.LEFT)
        
        self.__btnCadastro = ttk.Button(self.__frame3,
        text = 'Cadastro de clientes', command = self.Clientes)
        self.__btnCadastro.pack(side=tk.LEFT)

        ####################################################################################
        self.__frmLinha1 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha1.pack()
        ####################################################################################
        self.__frame4 = ttk.Frame(janela)
        self.__frame4.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame4, text = 'Barbeiros:').grid(row=0,column=0,sticky=tk.W)
        self.__comboBoxBarbeiros = ttk.Combobox(self.__frame4)
        self.__comboBoxBarbeiros['state'] = 'readonly' 
        self.__comboBoxBarbeiros.grid(row=0, column=1,sticky=tk.W)

        self.__btnOKBarbeiros = ttk.Button(self.__frame4, text = 'OK', command=self.pesquisarIDBarbeiros)
        self.__btnOKBarbeiros.grid(row=0, column=2, sticky=tk.W)

        ttk.Label(self.__frame4, text = 'Disponibilidade: ').grid(row=1,column=0,sticky=tk.W)
        self.__labelDisponibilidade = ttk.Label(self.__frame4, text='')
        self.__labelDisponibilidade.grid(row=1,column=1,sticky=tk.W)
        ####################################################################################
        self.__frmLinha2 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha2.pack()
        ####################################################################################
        self.__frame5 = ttk.Frame(janela)
        self.__frame5.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame5, text = 'Clientes:').grid(row=0,column=0,sticky=tk.W)
        self.__comboBoxClientes = ttk.Combobox(self.__frame5)
        self.__comboBoxClientes['state'] = 'readonly' 
        self.__comboBoxClientes.grid(row=0, column=1,sticky=tk.W)

        self.__btnOKClientes = ttk.Button(self.__frame5, text='OK', command=self.pesquisarIDClientes)
        self.__btnOKClientes.grid(row=0, column=2, sticky=tk.W)
        
        self.__btnExcluirClientes = ttk.Button(self,self.__frame5,text = 'Excluir Cliente',command=self.excluirClientes)
        self.__btnExcluirClientes.grid(row=0, column=3, sticky=tk.W)

        ttk.Label(self.__frame5, text = 'Telefone: ').grid(row=2,column=0,sticky=tk.W)
        self.__labelTelefone = ttk.Label(self.__frame5, text='')
        self.__labelTelefone.grid(row=1,column=1,sticky=tk.W)
        ####################################################################################
        self.__frmLinha3 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha3.pack()
        ####################################################################################
        self.__frame6 = ttk.Frame(janela)
        self.__frame6.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame6, text = 'Cortes:').grid(row=0,column=0,sticky=tk.W)
        self.__comboBoxCortes = ttk.Combobox(self.__frame6)
        self.__comboBoxCortes['state'] = 'readonly' 
        self.__comboBoxCortes.grid(row=0, column=1,sticky=tk.W)

        self.__btnOKCortes = ttk.Button(self.__frame6, text='OK', command=self.pesquisarIDCortes)
        self.__btnOKCortes.grid(row=0, column = 2, sticky=tk.W)
        
        self.__btnExcluirCortes = ttk.Button(self,self.__frame5,text = 'Excluir Corte',command=self.excluirCortes)
        self.__btnExcluirCortes.grid(row=0, column=3, sticky=tk.W)

        ttk.Label(self.__frame6, text = 'Preço: R$').grid(row=1,column=0,sticky=tk.W)
        self.__labelPrice = ttk.Label(self.__frame6, text='')
        self.__labelPrice.grid(row=1,column=1,sticky=tk.W)
        
        ####################################################################################
        self.__frmLinha3 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha3.pack()
        ####################################################################################
        self.__frame7 = ttk.Frame(janela)
        self.__frame7.pack(padx=5,pady=5)
        ttk.Label(self.__frame7, text = 'Lucro Total: R$').grid(row=0,column=0,sticky=tk.W)
        self.__labelLucro = ttk.Label(self.__frame7, text='')
        self.__labelLucro.grid(row=0,column=1,sticky=tk.W)
        ####################################################################################
        self.__frmLinha4 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha4.pack()
        ####################################################################################
        self.__btnLucro = ttk.Button(self.__frame7, text = 'Calcular o Lucro', 
        command=self.calcularLucroTotal)
        self.__btnLucro.grid(row=1, column =0, sticky=tk.W)
        ####################################################################################
        self.__frmLinha5 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha5.pack()
        ####################################################################################
        self.__frame8 = ttk.Frame(janela)
        self.__frame8.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame8, text='Data do Corte:').grid(row=1,column=0,sticky=tk.W)
        self.__txtDataCorte = tk.Entry(self.__frame8)
        self.__txtDataCorte.grid(row=1,column=1,sticky=tk.W)

        self.__btnConfirmar = ttk.Button(self.__frame8, text='Confirmar Dados',command = self.links)
        self.__btnConfirmar.grid(row=6, column=0, columnspan=3, sticky=tk.NSEW)
        ####################################################################################
        self.__frmLinha6 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha6.pack()
        ####################################################################################
        self.__frame9 = ttk.Frame(janela)
        self.__frame9.pack(padx=5,pady=5)
        ttk.Label(self.__frame9, text = 
                  'Lembre-se de Excluir o cadastro de todos os clientes no final do Dia!!! ').grid(
                   row=0,column=0,sticky=tk.W)
        self.__labelWarning= ttk.Label(self.__frame9, text='')
        self.__labelWarning.grid(row=0,column=1,sticky=tk.W)
        ####################################################################################
        # Criar 2 listas para cada ComboBox
        # - barbeiros, clientes e cortes
        self.__NomelistaBarbeiros = []
        self.__listaIdBarbeiros = []
        self.carregarComboBarbeiros()
        
        self.__NomelistaClientes = []
        self.__listaIdClientes = []
        self.carregarComboClientes()
        
        self.__NomelistaCortes = []
        self.__listaIdCortes = []
        self.carregarComboCortes()
        ####################################################################################
    
    def calcularLucroTotal(self):
        self.__listaClientes = []
        self.__listaPriceCortes = []
        
        self.__cortesDAO.conectar()
        self.__clientesDAO.conectar()
        
        cursor = self.__cortesDAO.listarTudo()
        for(id_Cortes, descGen,price) in cursor:
            self.__listaPriceCortes.append(price)
        Cortes = self.__listaPriceCortes
        
        cursor = self.__clientesDAO.listarTudo()
        for(id_cliente, clienteNome,telefone) in cursor:
            self.__listaClientes.append(id_cliente)
        qtdClientes = len(self.__listaClientes)
        
        valorTotal = Cortes * qtdClientes
        self.__labelLucro['text'] = valorTotal
        
        self.__cortesDAO.fecharConexao()
        self.__clientesDAO.fecharConexao()
    
    def carregarComboBarbeiros (self):
        self.__barbeirosDAO.conectar()
        cursor = self.__barbeirosDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        self.__listaIdBarbeiros.clear
        self.__NomelistaBarbeiros.clear
        for(id_barbeiros, barbeiroNome,disponivelOU) in cursor:
            self.__NomelistaBarbeiros.append(barbeiroNome) # armazena o nome do barbeiro
            self.__listaIdBarbeiros.append(id_barbeiros) # armazena o ID do barbeiro
        # Exibir o nome da lista NomelistaBarbeiros
        self.__comboBoxBarbeiros['values'] = self.__NomelistaBarbeiros
        self.__barbeirosDAO.fecharConexao()
        
    def pesquisarIDBarbeiros(self):
        self.__barbeirosDAO.conectar()
        ## Capturar o ID do barbeiro através do Texto escolhido (nome)
        global textoSelecionadoBarbeiros
        textoSelecionadoBarbeiros = self.__comboBoxBarbeiros.get()
        numLinhaSelecionadaBarbeiros = self.__NomelistaBarbeiros.index(textoSelecionadoBarbeiros)
        self.id_barbeiros = self.__listaIdBarbeiros[numLinhaSelecionadaBarbeiros]
        # Id transferido para classe DAO
        self.__barbeirosDAO.__barbeiros.id_barbeiros = self.id_barbeiros
        # método de pesquisa
        self.__barbeirosDAO.pesquisarBarbeiro
        # exibiu o resultado na tela no labelPrice
        self.__labelDisponibilidade['text'] =  self.__barbeirosDAO.__barbeiros.disponivelOU
        self.__barbeirosDAO.fecharConexao()
        
    def carregarComboClientes (self):
        self.__clientesDAO.conectar()
        cursor = self.__clientesDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        self.__listaIdClientes.clear
        self.__NomelistaClientes.clear
        for(id_cliente, clienteNome,telefone) in cursor:
            self.__NomelistaClientes.append(clienteNome) # armazena o nome do cliente
            self.__listaIdClientes.append(id_cliente) # armazena o ID do cliente
        # Exibir o nome da lista NomelistaClientes
        self.__comboBoxClientes['values'] = self.__NomelistaClientes
        self.__clientesDAO.fecharConexao()
        
    def pesquisarIDClientes(self):
        self.__clientesDAO.conectar()
        ## Capturar o ID do cliente através do Texto escolhido (nome)
        global textoSelecionadoCliente
        textoSelecionadoCliente = self.__comboBoxClientes.get()
        numLinhaSelecionadaClientes = self.__NomelistaClientes.index(textoSelecionadoCliente)
        self.id_cliente = self.__listaIdClientes[numLinhaSelecionadaClientes]
        # Id transferido para classe DAO
        self.__clientesDAO.Clientes.id_cliente = self.id_cliente
        # método de pesquisa
        self.__clientesDAO.pesquisarClientes
        # exibiu o resultado na tela no labelTelefone
        self.__labelTelefone['text'] =  self.__clientesDAO.Clientes.telefone
        self.__clientesDAO.fecharConexao()
        
    def carregarComboCortes (self):
        self.__cortesDAO.conectar()
        cursor = self.__cortesDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        self.__listaIdCortes.clear
        self.__NomelistaCortes.clear
        for(id_Cortes, descGen,price) in cursor:
            self.__NomelistaCortes.append(descGen) # armazena o nome do corte
            self.__listaIdCortes.append(id_Cortes) # armazena o ID do corte
        # Exibir o nome da lista NomelistaCortes
        self.__comboBoxCortes['values'] = self.__NomelistaCortes
        self.__cortesDAO.fecharConexao()
    
    def pesquisarIDCortes(self):
        self.__cortesDAO.conectar()
        ## Capturar o ID do CORTE através do Texto escolhido (nome)
        global textoSelecionadoCorte
        textoSelecionadoCorte = self.__comboBoxCortes.get()
        numLinhaSelecionadaCortes = self.__NomelistaCortes.index(textoSelecionadoCorte)
        self.__id_Cortes = self.__listaIdCortes[numLinhaSelecionadaCortes]
        # Id transferido para classe DAO
        self.__cortesDAO.CORTES.id_Cortes = self.__id_Cortes
        # método de pesquisa
        self.__cortesDAO.pesquisarCortes
        # exibiu o resultado na tela no labelPrice
        self.__labelPrice['text'] =  self.__cortesDAO.CORTES.price
        self.__cortesDAO.fecharConexao()
    
    def links(self):
        if textoSelecionadoCorte or textoSelecionadoBarbeiros or textoSelecionadoCliente == '':
            return messagebox.showwarning('Aviso!!!','Favor escolher o barbeiro, cliente e corte que têm ligação')
        # - para impedir que alguém aperte o cadastrar sem escolher as outras opções. Funciona?
        self.__agendaDAO.conectar() 
        self.__agendaDAO.agenda.corteDesejadofk = self.id_Cortes # - não está azulzinho :( 
        self.__agendaDAO.agenda.descGen = textoSelecionadoCorte
        self.__agendaDAO.agenda.Barbeirofk = self.id_barbeiros 
        self.__agendaDAO.agenda.barbeiroNome = textoSelecionadoBarbeiros
        self.__agendaDAO.agenda.Clientefk = self.id_cliente 
        self.__agendaDAO.agenda.clienteNome = textoSelecionadoCliente
        self.__agendaDAO.agenda.LucroTotalDiario = self.__labelLucro.cget() 
        self.__agendaDAO.agenda.dataHoraCorte = self.__txtDataCorte.get 
        # Executar Inserir no cadastrar
        self.__agendaDAO.inserir()
        # Refresh na tela
        self.carregarComboBarbeiros()
        self.carregarComboClientes()
        self.carregarComboCortes()
        messagebox.showinfo('Barbeiro','As informações foram cadastradas com sucesso!')
        self.__agendaDAO.fecharConexao()   
     
    def excluirCortes(self):
        self.__cortesDAO.conectar()
        # realmente não faço idéia de como está aqui
        # tentei fazer com o sistema do ItemSelecionado e
        # listBox mas acho que não ia combinar por já ter feito com
        # combobox antes. De todo modo, tentei improvisar aqui prof
        # mas acho que está zuado :(
        TableRETURN = self.__cortesDAO.pesquisarCortes.fetchone()
        if TableRETURN != None:
            resp = messagebox.askyesno('Cortes','Deseja realmente exluir este Corte já cadastrado?')
            if resp == True:
                self.__cortes.id_Cortes = TableRETURN # - ?
                self.__cortesDAO.CORTES = self.id_Cortes # porquê não está azulzinho ?
                self.__cortesDAO.Excluir() 
                messagebox.showwarning('Cortes','Exclusão bem sucedida!!!')
            else:
                messagebox.showwarning('Cortes','Exclusão Cancelada!!!')
        else:
            messagebox.showerror('Cortes','Por favor selecionar um Corte!!!')
        self.__cortesDAO.fecharConexao()   
        
    def excluirClientes(self):
        self.__clientesDAO.conectar()
        TableRETURN = self.__clientesDAO.pesquisarClientes.fetchone()
        if TableRETURN != None:
            resp = messagebox.askyesno('Clientes','Deseja realmente exluir o cadastro deste Cliente?')
            if resp == True:
                self.__clientes.id_cliente = TableRETURN # - ?
                self.__clientesDAO.Clientes = self.id_cliente
                self.__clientesDAO.Excluir() 
                messagebox.showwarning('Clientes','Exclusão bem sucedida!!!')
            else:
                messagebox.showwarning('Clientes','Exclusão Cancelada!!!')
        else:
            messagebox.showerror('Clientes','Por favor selecionar um cadastro de Cliente!!!')
        self.__clientesDAO.fecharConexao()   
    #########################################################################    
    def Cortes(self, janela):
        janela.withdraw() 
        telaCortes = TelaCortes(janela)
    def Clientes(self, janela):
        janela.withdraw()
        telaRegister = TelaRegister(janela)
    ##########################################################################
    
        
