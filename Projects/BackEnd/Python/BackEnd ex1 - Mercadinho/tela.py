import tkinter as tk
from tkinter import ttk 
from tkinter import messagebox
import mysql.connector
from telaInserir import TelaInserir
from telaCarregarProdutos import TelaCarregarProdutos
from telaAlterarProdutos import TelaAlterarProdutos


class Tela():

    __ListaIdProdutos = list
    
    def __init__(self,window):
        self.__window = window
        self.__frame1 = ttk.Frame(window)
        self.__frame1.pack()

        self.__btnCarregar = ttk.Button(self.__frame1,
        text='Carregar Produto',command=self.carregar)
        self.__btnCarregar.pack(side=tk.LEFT)

        self.__btnInserir = ttk.Button(self.__frame1,
        text='Inserir',command=self.Inserir)
        self.__btnInserir.pack(side=tk.LEFT)

        self.__btnAlterar = ttk.Button(self.__frame1,
        text='Alterar',command=self.alterar)
        self.__btnAlterar.pack(side=tk.LEFT)

        self.__btnAtualizarLista = ttk.Button(self.__frame1,
        text='Atualizar Lista')
        self.__btnAtualizarLista.pack(side=tk.LEFT)

        self.__btnExcluir = ttk.Button(self,self.__frame1,
        text='Excluir',command=self.excluir)
        self.__btnCarregar.pack(side=tk.LEFT)

        self.__frame2 = ttk.Frame(window)
        self.__frame2.pack()

        ttk.Label(self.__frame2,text='Lista de Produtos').pack(side=tk.LEFT)
        self.__scroll = ttk.Scrollbar(self.__frame2,orient=tk.VERTICAL)
        self.__listarprodutos = tk.Listbox(self.__frame2,height=5)
        self.__scroll.config(command=self.__listarprodutos.yview)
        self.__scroll.pack(side=tk.RIGHT,fill=tk.Y)
        self.__listarprodutos.pack(side=tk.LEFT,fill=tk.BOTH,expand=1)
    
    def Inserir(self):
        telaInserir = TelaInserir(self.__window)
        
    def SetList(self):
        # 1º passo- Criar uma conexão entre o Mysql e o Python
        cnx= mysql.connector.connect(
            host = '127.0.0.1',  # - pode trocar pelo IP Local ou da máquina
            database = 'mycompany', # nome da database
            user = 'root', # nome do usuário, sempre root
            password = 'griloseco347') # senha, duhh
        # 2º passo - Criar um caminho de acesso entre Python e Mysql   
        cursor = cnx.cursor()
        # 3 º passo - Criar o comando SQL de select
        sql = 'SELECT * FROM PRODUTOS'
        # 4º passo - executar o comando
        cursor.execute(sql)        
        # 5º passo - varrer o cursor e preencher o LISTBOX
        # IMPORTANTE - apagar as infos que estão no LISTBOX antes de colocar novas
        qtdItens = self.__listarprodutos.size()
        self.__listarprodutos.delete(0,qtdItens)
        self.__ListaIdProdutos.clear()
        for (IdProd,nomeProduto,DescProduto,qtdEstoque,PrecoProduto) in cursor:
            self.__ListaIdProdutos.append(IdProd)
            self.__listarprodutos.insert(tk.END,nomeProduto)
        # 6º passo - fechar a conexão
        cursor.close()
        cnx.close()
        
    def itemSelecionado(self):
        if len(self.__listarprodutos.curselection()) > 0:
            return int(self.__ListaIdProdutos[self.__listarprodutos.curselection()[0]])
        else:
            return - 1
        
    def carregar(self):
        telaCarregarProdutos = TelaCarregarProdutos(self.__window, self.itemSelecionado(),)
        
    def alterar(self):
        telaAlterarProdutos = TelaAlterarProdutos(self.__window, self.itemSelecionado())
        
    def excluir(self):
        if self.itemSelecionado() > 0:
            resp = messagebox.askyesno('Produtos','Deseja realmente exluir este produto?')
            if resp == True:
                    # Criação de comando e conexão entre Python e Mysql 
                cnx= mysql.connector.connect(
                    host = '127.0.0.1',  
                    database = 'mycompany', 
                    user = 'root', 
                    password = 'griloseco347') 
                cursor = cnx.cursor()
                sql = 'DELETE * FROM PRODUTOs WHERE idProd = ' + self.itemSelecionado
                cursor.execute(sql)       
                cnx.commit()
                cursor.close()
                cnx.close()
                messagebox.showwarning('Produtos','Exclusão bem sucedida!!!')
            else:
                messagebox.showwarning('Produtos','Exclusão Cancelada!!!')
        else:
            messagebox.showerror('Produtos','Por favor selecionar um produto!!!')
        
            