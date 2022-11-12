import tkinter as tk
from tkinter import END, ttk 
import mysql.connector
from tkinter import messagebox

class TelaAlterarProdutos ():
    
    def __init__(self,window,idSelecionado):
        
        self.__id = idSelecionado
        
        if idSelecionado > 0:
            window = tk.Toplevel
            window.title('Alterar o Produto')
            
            self.__frame1 = tk.Frame(window)
            self.__frame1.pack()
            
            # Criação de comando e conexão entre Python e Mysql 
            cnx= mysql.connector.connect(
                host = '127.0.0.1',  
                database = 'mycompany', 
                user = 'root', 
                password = 'griloseco347') 
            cursor = cnx.cursor()
            sql = 'SELECT * FROM PRODUTOs WHERE idProd = ' + str(idSelecionado)
            cursor.execute(sql)       
            respostaBD = cursor.fetchone()
            
            # Montar tela e exibir as informações
            ttk.Label(self.__frame1,text='Id Produto:').grid(row=0,column=0,sticky=tk.W)
            IdProd = tk.StringVar()
            IdProd.set(str(respostaBD[0]))
            self.__txtIdProd = tk.Entry(self.__frame1,textvariable=IdProd)
            self.__txtIdProd.grid(row=0,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Nome do Produto:').grid(row=1,column=0,sticky=tk.W)
            nomeProd = tk.StringVar()
            nomeProd.set(str(respostaBD[1]))
            vcmdC1 = (self.__frame1.register(self.mudarCorNomeAlterar), '%P')
            self.__txtnomeProd = tk.Entry(self.__frame1,textvariable=nomeProd)
            self.__txtnomeProd.config(validate='key',validatecommand=vcmdC1) 
            self.__txtnomeProd.grid(row=1,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Descrição:').grid(row=2,column=0,sticky=tk.W)
            descProd = tk.StringVar()
            descProd.set(str(respostaBD[2]))
            vcmdC2 = (self.__frame1.register(self.mudarCorDescAlterar), '%P')
            self.__txtdescProd = tk.Entry(self.__frame1,textvariable=descProd)
            self.__txtdescProd.config(validate='key',validatecommand=vcmdC2)
            self.__txtdescProd.grid(row=2,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Quantidade em Estoque:').grid(row=3,column=0,sticky=tk.W)
            qtdEstoque = tk.StringVar()
            qtdEstoque.set(str(respostaBD[3]))
            vcmd = (self.__frame1.register(self.verificarNumAlterar), '%P')
            self.__txtqtdEstoque = tk.Entry(self.__frame1,textvariable=qtdEstoque)
            self.__txtqtdEstoque.config(validate = 'key',validatecommand=vcmd) 
            self.__txtqtdEstoque.grid(row=3,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Preço R$:').grid(row=4,column=0,sticky=tk.W)
            precoProd = tk.StringVar()
            precoProd.set(str(respostaBD[4]))
            vcmdR = (self.__frame1.register(self.verificarNumRealAlterar), '%P')
            self.__txtprecoProd = tk.Entry(self.__frame1,textvariable=precoProd)
            self.__txtprecoProd.config(validate = 'key', validatecommand = vcmdR) 
            self.__txtprecoProd.grid(row=4,column=1,sticky=tk.W)
            
            self.__btnAlterar = tk.Button(self.__frame1,text='Alterar',command=self.AlterarProduto)
            self.__btnAlterar.grid(row=5,column=1,sticky=tk.W)
            
            ####################################################################
            # limpar os txt's
            self.__txtnomeProd.delete(0, END)
            self.__txtdescProd.delete(0, END)
            self.__txtqtdEstoque.delete(0, END)
            self.__txtprecoProd.delete(0, END)
            ####################################################################
        else:
            messagebox.showinfo('Produtos','Selecione um produto por favor!')
            ####################################################################
    def AlterarProduto(self):
        if self.__txtnomeProd.get() == '' or self.__txtdescProd.get() == '' or self.__txtqtdEstoque.get() == '' or self.__txtprecoProd.get() == '':
            messagebox.showerror('Inserir','Preencher as informações em vermelho !!!')
            if self.__txtnomeProd.get() == '' :
                self.__txtnomeProd['bg'] = 'red'
            if self.__txtdescProd.get() == '' :
                self.__txtdescProd['bg'] = 'red'
            if self.__txtqtdEstoque.get() == '' :
                self.__txtqtdEstoque['bg'] = 'red'
            if self.__txtprecoProd.get() == '' :
                self.__txtprecoProd['bg'] = 'red'
        else:
        # 1º passo - pegar as informações da tela e guardar em variáveis
            novonomeprod = self.__txtnomeProd.get()
            novaDescProd = self.__txtdescProd.get()
            novoQTDProd = self.__txtqtdEstoque.get()
            novoPrecoProd = self.__txtprecoProd.get().replace(',','.') 
        # Criação de comando e conexão entre Python e Mysql 
            cnx= mysql.connector.connect(
                host = '127.0.0.1',  
                database = 'mycompany', 
                user = 'root', 
                password = 'griloseco347') 
            cursor = cnx.cursor()
            sql = 'UPDATE PRODUTOS SET nomeProd=%s,descProd=%s,qtdEstoque=%s,precoProd=%s WHERE idProd=%s' 
            dadosSQL =(novonomeprod,novaDescProd,novoQTDProd,novoPrecoProd,self.__id)
            cursor.execute(sql)       
        
        # SALVAR E FECHAR
            cnx.commit()
            cursor.close()
            cnx.close()
        
            messagebox.showinfo('Produtos','Dados alterados com sucesso!')
            
    def verificarNumAlterar(self,valor):
        if valor.isdigit():
            self.__txtqtdEstoque ['bg'] = 'white'
            return True
        else:
             messagebox.showwarning('Aviso!','Digitar Apenas Números Inteiros!!!')
             self.__txtqtdEstoque.focus()
             return False
         
    def verificarNumRealAlterar(self,valor):
        valor = valor.replace(',',".")
        try:
            float(valor)
            self.__txtPrecoProduto ['bg'] = 'white'
            return True
        except:
             messagebox.showwarning('Aviso!','Digitar Números!!!')
             self.__txtPrecoProduto.focus()
             return False
         
    def mudarCorNomeAlterar(self,valor):
        self.__txtnomeProd ['bg'] = 'white'
        return True
    def mudarCorDescAlterar(self,valor):
        self.__txtdescProd ['bg'] = 'white'
        return True


        
        
