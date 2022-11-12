import tkinter as tk
from tkinter import END, ttk
from tkinter import messagebox
import mysql.connector
#import modelo e DAO
from produto import Produto
from produtoDAO import ProdutoDAO

class TelaInserir():
    # criar uma instância da classe modelo (Produto)
    __prod = Produto()
    # criar nova instância da classe DAO (ProdutoDAO)
    __prodDAO = ProdutoDAO()
    
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
        self.__txtqtdEstoque.grid(row=2,column=1,sticky=tk.W)
        # - (validatecommand) comando enquanto em execução, independente de uma ação não relacionado 
        # com apertar um botão, isso é com o command


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
            # - trazer infos para as váriaveis que estão no txt da tela 
            # e armazenar na instância da classe modelo (Produto) 
            self.__prod.nomeProd = self.__txtNomeProduto.get() 
            self.__prod.descProd = self.__txtDescProduto.get() 
            self.__prod.qtdEstoque = self.__txtqtdEstoque.get() 
            self.__prod.precoProd = self.__txtPrecoProduto.get().replace(',','.') 
            
            self.__prodDAO.prod = self.__prod 
            self.__prodDAO.Inserir()
            
            
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
