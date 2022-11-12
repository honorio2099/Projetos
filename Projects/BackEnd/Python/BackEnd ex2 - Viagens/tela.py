import tkinter as tk
from tkinter import ttk
from tkinter import messagebox
from destinoDAO import DestinoDAO
from hotelDAO import HotelDAO
from empDAO import EmpresaAereaDAO
from pacoteDAO import PacoteDAO


class Tela():

    __DestinoDAO = DestinoDAO()
    __hotelDAO = HotelDAO()
    __empDAO = EmpresaAereaDAO()
    __pacDAO = PacoteDAO()

    def __init__(self, window):
        self.__frame1 = ttk.Frame(window, relief=tk.RAISED, borderwidth=2)
        self.__frame1.pack(padx=5,pady=5)

        ttk.Label(self.__frame1, text='Viagens Legal - Agência de Turismo', font=('Calibri',18)).pack()

        self.__frame2 = ttk.Frame(window)
        self.__frame2.pack(padx=5,pady=5)
        
        #criando a escolha para a primeira tabela
        ttk.Label(self.__frame2, text='Escolha seu destino:').grid(row=0,column=0,sticky=tk.W)

        self.__cmbDestino = ttk.Combobox(self.__frame2)
        self.__cmbDestino['state'] = 'readonly' 
        self.__cmbDestino.grid(row=0, column=1,sticky=tk.W)

        self.__btnOKDestino = ttk.Button(self.__frame2, text='OK', command=self.pesquisarIDdestino)
        self.__btnOKDestino.grid(row=0, column=2, sticky=tk.W)

        ttk.Label(self.__frame2, text='Adicional %:').grid(row=1,column=0,sticky=tk.W)
        self.__lblAdicionalDest = ttk.Label(self.__frame2, text='')
        self.__lblAdicionalDest.grid(row=1,column=1,sticky=tk.W)
        ####################################################################################

        self.__frmLinha = ttk.Frame(window, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha.pack()

        self.__frame3 = ttk.Frame(window)
        self.__frame3.pack(padx=5,pady=5)
        ####################################################################################
        
        ###### tabela hotel
        ttk.Label(self.__frame3, text='Escolha seu hotel:').grid(row=0,column=0,sticky=tk.W)

        self.__cmbHotel = ttk.Combobox(self.__frame3)
        self.__cmbHotel['state'] = 'readonly'
        self.__cmbHotel.grid(row=0, column=1, sticky=tk.W)

        self.__btnOkHotel = ttk.Button(self.__frame3, text='OK', command=self.pesquisarIDhotel)
        self.__btnOkHotel.grid(row=0, column=2, sticky=tk.W)

        ttk.Label(self.__frame3, text='Valor R$:').grid(row=1,column=0,sticky=tk.W)
        self.__lblPrecoHotel = ttk.Label(self.__frame3, text='')
        self.__lblPrecoHotel.grid(row=1,column=1,sticky=tk.W)

        ttk.Label(self.__frame3,text='Qtd de Vagas:').grid(row=2,column=0,sticky=tk.W)
        self.__lblQtdVagasHotel = ttk.Label(self.__frame3, text='')
        self.__lblQtdVagasHotel.grid(row=2,column=1,sticky=tk.W)
        #####################################################################################

        self.__frmLinha1 = ttk.Frame(window, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha1.pack()

        self.__frame4 = ttk.Frame(window)
        self.__frame4.pack(padx=5,pady=5)
        ####################################################################################
        
        ###### tabela empresa aérea
        ttk.Label(self.__frame4, text='Escolha a empresa aérea:').grid(row=0,column=0,sticky=tk.W)

        self.__cmbEmpresa = ttk.Combobox(self.__frame4)
        self.__cmbEmpresa['state'] = 'readonly'
        self.__cmbEmpresa.grid(row=0, column=1, sticky=tk.W)
        # não tendo botão, é para colocar 
        self.__cmbEmpresa.bind('<<ComboboxSelected>>',self.pesquisarIDEmpresa)

        ttk.Label(self.__frame4, text='Qtd de Vagas:').grid(row=1,column=0,sticky=tk.W)
        self.__lblQtdVagasEmp = ttk.Label(self.__frame4, text='')
        self.__lblQtdVagasEmp.grid(row=1,column=1,sticky=tk.W)
        
        
        ###########################################################################################

        self.__frmLinha2 = ttk.Frame(window, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha2.pack()

        self.__frame5 = ttk.Frame(window)
        self.__frame5.pack(padx=5,pady=5)
        ####################################################################################
        
        ttk.Label(self.__frame5, text='Nome do Cliente:').grid(row=0,column=0,sticky=tk.W)
        self.__txtNomeCli = tk.Entry(self.__frame5)
        self.__txtNomeCli.grid(row=0,column=1,sticky=tk.W)

        ttk.Label(self.__frame5, text='Data da Viagem:').grid(row=1,column=0,sticky=tk.W)
        self.__txtDataViagem = tk.Entry(self.__frame5)
        self.__txtDataViagem.grid(row=1,column=1,sticky=tk.W)

        ttk.Label(self.__frame5, text='Qtd de diárias:').grid(row=2,column=0,sticky=tk.W)
        self.__txtQtdDiarias = tk.Entry(self.__frame5)
        self.__txtQtdDiarias.grid(row=2,column=1,sticky=tk.W)

        self.__btnCalcular = ttk.Button(self.__frame5, text='Calcular Valor Viagem',command = self.calcularTotal)
        self.__btnCalcular.grid(row=2, column=2, sticky=tk.W)

        self.__lblErro = ttk.Label(self.__frame5, foreground='red')
        self.__lblErro.grid(row=4,column=0,columnspan=3 ,sticky=tk.S)

        ttk.Label(self.__frame5, text='Valor Viagem:').grid(row=5,column=0,sticky=tk.W)
        self.__lblTotalViagem = ttk.Label(self.__frame5, text='')
        self.__lblTotalViagem.grid(row=5,column=1,sticky=tk.W)

        self.__btnCadastrarViagem = ttk.Button(self.__frame5, text='Cadastrar Viagem',command = self.cadastrarViagem)
        self.__btnCadastrarViagem.grid(row=6, column=0, columnspan=3, sticky=tk.NSEW)

        ########################################################################################################
        # Criar 2 listas para cada ComboBox
        # - destino
        self.__NomelistaDestino = []
        self.__listaIdDestino = []
        ###########################################
        # - hotel
        self.__NomelistaHotel = []
        self.__listaIdHotel = []
        ###########################################
        # - empresa
        self.__NomelistaEmpresa = []
        self.__listaIdEmpresa = []
        ###########################################
        # exibir
        self.carregarComboDestino()
        self.carregarComboHotel()
        self.carregarComboEmpresa()
        
    def carregarComboDestino (self):
        cursor = self.__DestinoDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        self.__listaIdDestino.clear
        self.__NomelistaDestino.clear
        for(idDestino, nomeDestino,adicionalDestino) in cursor:
            self.__NomelistaDestino.append(nomeDestino) # armazena o nome do destino
            self.__listaIdDestino.append(idDestino) # armazena o ID do destino
        # Exibir o nome da lista NomelistaDestino
        self.__cmbDestino['values'] = self.__NomelistaDestino
    
    def carregarComboHotel (self):
        cursor = self.__hotelDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        
        self.__NomelistaHotel.clear
        self.__listaIdHotel.clear
        for(idHotel, nomeHotel,diariaHotel,VagasHotel) in cursor:
            self.__NomelistaHotel.append(nomeHotel)
            self.__listaIdHotel.append(idHotel)
        self.__cmbHotel['values'] = self.__NomelistaHotel
        
    def carregarComboEmpresa (self):
        cursor = self.__empDAO.listarTudo() # cursor poderia ser qualquer outra coisa
        
        self.__NomelistaEmpresa.clear
        self.__listaIdEmpresa.clear
        for(idEmp, nomeEmpresaAerea,qtdVagas) in cursor:
            self.__NomelistaEmpresa.append(nomeEmpresaAerea)
            self.__listaIdEmpresa.append(idEmp)
        self.__cmbEmpresa['values'] = self.__NomelistaEmpresa
    
        
    def pesquisarIDdestino(self):
        ## Capturar o ID do destino através do Texto escolhido (nome)
        textoSelecionado = self.__cmbDestino.get()
        numLinhaSelecionada = self.__NomelistaDestino.index(textoSelecionado)
        self.__idDestino = self.__listaIdDestino[numLinhaSelecionada]
        # Id transferido para classe DAO
        self.__DestinoDAO.destino.idDestino = self.__idDestino
        # método de pesquisa
        self.__DestinoDAO.pesquisarID
        # exibiu o resultado na tela no lblAdicionalDest
        self.__lblAdicionalDest['text'] = self.__DestinoDAO.destino.adicionalDestino
    
    def pesquisarIDhotel(self):
        ## Capturar o ID do hotel através do Texto escolhido (nome)
        textoSelecionado = self.__cmbHotel.get()
        numLinhaSelecionada = self.__NomelistaHotel.index(textoSelecionado)
        self.__idHotel = self.__listaIdHotel[numLinhaSelecionada]
        # Id transferido para classe DAO
        self.__hotelDAO.hotel.idHotel = self.__idHotel
        # método de pesquisa
        self.__hotelDAO.pesquisarID
        # exibiu o resultado na tela no lblqtdVagas e lblpreço
        self.__lblPrecoHotel['text'] = self.__hotelDAO.hotel.diariaHotel
        self.__lblQtdVagasHotel['text'] = self.__hotelDAO.hotel.VagasHotel
        
    # métodos com bind precisam de dois parâmetros, bind e event
    
    def pesquisarIDEmpresa(self, event):
        ## Capturar o ID do hotel através do Texto escolhido (nome)
        textoSelecionado = self.__cmbEmpresa.get()
        numLinhaSelecionada = self.__NomelistaEmpresa.index(textoSelecionado)
        self.__idEmp = self.__listaIdEmpresa[numLinhaSelecionada]
        # Id transferido para classe DAO
        self.__empDAO.emp.idEmp = self.__idEmp
        # método de pesquisa
        self.__empDAO.pesquisarID()
        # exibiu o resultado na tela no lblqtdVagas e lblpreço
        self.__lblQtdVagasEmp['text'] = self.__empDAO.emp.qtdVagas
    
    def calcularTotal(self):
        valorDiaria = float(self.__lblPrecoHotel.cget('text'))
        qtdDiarias = float(self.__txtQtdDiarias.get())
        adicionalDestino = float(self.__lblAdicionalDest.cget['text'])
        valorHotel = valorDiaria * qtdDiarias
        totalPagar = valorHotel + (valorHotel*adicionalDestino/100)
        
        self.__lblTotalViagem['text'] = totalPagar
       
    def cadastrarViagem(self):
        self.__pacDAO.pacote.dataEmbarque = self.__txtDataViagem.get()
        self.__pacDAO.pacote.idDestino = self.__idDestino
        self.__pacDAO.pacote.idEmp = self.__idEmp
        self.__pacDAO.pacote.idHotel = self.__idHotel
        self.__pacDAO.pacote.nomeCliente = self.__txtNomeCli.get()
        self.__pacDAO.pacote.qtdDiarias = self.__txtQtdDiarias.get()
        self.__pacDAO.pacote.valorFinal =self.__lblTotalViagem.cget('text')
        # Executar Inserir no cadastrar
        self.__pacDAO.inserir()
        # Refresh na tela
        self.carregarComboDestino()
        self.carregarComboHotel()
        self.carregarComboEmpresa()
        messagebox.showinfo('Vendas','Pacote cadastrado com sucesso!')





   
   






