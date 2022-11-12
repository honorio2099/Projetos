import tkinter as tk
from tkinter import END, ttk
from tkinter import messagebox
import mysql.connector

class TelaInserir():

    def __init__(self,window):
        window = tk.Toplevel()
        window.title('Inserir Produtos')

        self.__frame1 = ttk.Frame(window)
        self.__frame1.pack()

        ttk.Label(self.__frame1,text = 'Nome do Produto:').grid(row=0,column=0,sticky=tk.W)
        vcmdC1 = (self.__frame1.register(self.mudarCorNome), '%P')
        self.__txtNomeProduto = tk.Entry(self.__frame1)
        self.__txtNomeProduto.config(validate='key',validatecommand=vcmdC1) 
        self.__txtNomeProduto.grid(row=0,column=1,sticky=tk.W)

        ttk.Label(self.__frame1,text = 'Descrição').grid(row=1,column=0,sticky=tk.W)
        vcmdC2 = (self.__frame1.register(self.mudarCorDesc), '%P')
        self.__txtDescProduto = tk.Entry(self.__frame1)
        self.__txtDescProduto.config(validate='key',validatecommand=vcmdC2) 
        self.__txtDescProduto.grid(row=1,column=1,sticky=tk.W)

        ttk.Label(self.__frame1,text = 'Estoque').grid(row=2,column=0,sticky=tk.W)
        vcmd = (self.__frame1.register(self.verificarNum), '%P')
        self.__txtqtdEstoque = tk.Entry(self.__frame1)
        self.__txtqtdEstoque.config(validate = 'key',validatecommand=vcmd) 
        # - (validatecommand) comando enquanto em execução, independente de uma ação, como apertar um botão, isso é com o command
        self.__txtqtdEstoque.grid(row=2,column=1,sticky=tk.W)

        ttk.Label(self.__frame1,text = 'Preço R$:').grid(row=3,column=0,sticky=tk.W)
        vcmdR = (self.__frame1.register(self.verificarNumReal), '%P')
        self.__txtPrecoProduto = tk.Entry(self.__frame1)
        self.__txtPrecoProduto.config(validate = 'key', validatecommand = vcmdR) 
        self.__txtPrecoProduto.grid(row=3,column=1,sticky=tk.W)

        self.__btnSalvar = ttk.Button(self.__frame1,text = 'Salvar', command = self.saveadd)
        self.__btnSalvar.grid(row=4,column=0,columnspan=2,sticky=tk.W)

    def saveadd(self):
        # 1º passo - trazer info dos txts para as váriaveis
        if self.__txtNomeProduto.get() == '' or self.__txtDescProduto.get() == '' or self.__txtqtdEstoque.get() == '' or self.__txtPrecoProduto.get() == '':
            messagebox.showerror('Inserir','Preencher as informações em vermelho !!!')
            if self.__txtNomeProduto.get() == '' :
                self.__txtNomeProduto['bg'] = 'red'
            if self.__txtDescProduto.get() == '' :
                self.__txtDescProduto['bg'] = 'red'
            if self.__txtqtdEstoque.get() == '' :
                self.__txtqtdEstoque['bg'] = 'red'
            if self.__txtPrecoProduto.get() == '' :
                self.__txtPrecoProduto['bg'] = 'red'
        else:
            nomeProduto = self.__txtNomeProduto.get() 
            DescProduto = self.__txtDescProduto.get() 
            qtdEstoque = self.__txtqtdEstoque.get() 
            PrecoProduto = self.__txtPrecoProduto.get().replace(',','.') 

        # 2º passo - Criar uma conexão entre o Mysql e o Python
            cnx= mysql.connector.connect(
                host = '127.0.0.1',  # - pode trocar pelo IP Local ou da máquina
                database = 'mycompany', # nome da database
                user = 'root', # nome do usuário, sempre root
                password = 'griloseco347') # senha, duhh

        # 3º passo - Criar um caminho de acesso entre Python e Mysql   
            cursor = cnx.cursor()

        # 4º passo - Criar Inserts substituindo as váriaveis no comando   
            add_product = ('INSERT INTO PRODUTOS VALUES (0,%s,%s,%s,%s)')
            data_product = (nomeProduto,DescProduto,qtdEstoque,PrecoProduto)

        # 5º - executar o comando do INSERT no Mysql
            cursor.execute(add_product,data_product)

        # 6º passo - gravar e fechar a conexão
            cnx.commit()
            cursor.close()
            cnx.close()
            
            # limpar os txt's
            self.__txtNomeProduto.delete(0, END)
            self.__txtDescProduto.delete(0, END)
            self.__txtqtdEstoque.delete(0, END)
            self.__txtPrecoProduto.delete(0, END)
        ####################################################################
            messagebox.showinfo('Informação','Dados Cadastrados com Sucesso!')
            
    def verificarNum(self,valor):
        if valor.isdigit():
            self.__txtqtdEstoque ['bg'] = 'white'
            return True
        else:
             messagebox.showwarning('Aviso!','Digitar Apenas Números Inteiros!!!')
             self.__txtqtdEstoque.focus()
             return False
         
    def verificarNumReal(self,valor):
        valor = valor.replace(',',".")
        try:
            float(valor)
            self.__txtPrecoProduto ['bg'] = 'white'
            return True
        except:
             messagebox.showwarning('Aviso!','Digitar Números!!!')
             self.__txtPrecoProduto.focus()
             return False
         
    def mudarCorNome(self,valor):
        self.__txtNomeProduto ['bg'] = 'white'
        return True
    def mudarCorDesc(self,valor):
        self.__txtDescProduto ['bg'] = 'white'
        return True
