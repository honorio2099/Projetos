import tkinter as tk
from tkinter import ttk 
import mysql.connector
from tkinter import messagebox

class TelaCarregarProdutos():
    
    def __init__(self,window,idSelecionado):
        if idSelecionado > 0:
            window = tk.Toplevel
            window.title('Carregando o Produto')
            
            self.__frame1 = tk.Frame(window)
            self.__frame1.pack()
             # 1º passo- Criar uma conexão entre o Mysql e o Python
            cnx= mysql.connector.connect(
                host = '127.0.0.1',  # - pode trocar pelo IP Local ou da máquina
                database = 'mycompany', # nome da database
                user = 'root', # nome do usuário, sempre root
                password = 'griloseco347') # senha, duhh
            # 2º passo - Criar um caminho de acesso entre Python e Mysql   
            cursor = cnx.cursor()
            # 3 º passo - Criar o comando SQL de select
            sql = 'SELECT * FROM PRODUTOs WHERE idProd = ' + str(idSelecionado)
            # 4º passo - executar o comando
            cursor.execute(sql)       
            # 5º passo - pegar somente a primeira linha da resposta do comando SELECT
            respostaBD = cursor.fetchone()
            # 6º Montar a tela e exibir as informações
            ttk.Label(self.__frame1,text='Id Produto:').grid(row=0,column=0,sticky=tk.W)
            IdProd = tk.StringVar()
            IdProd.set(str(respostaBD[0]))
            self.__txtIdProd = tk.Entry(self.__frame1,textvariable=IdProd,state=tk.DISABLED)
            self.__txtIdProd.grid(row=0,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Nome do Produto:').grid(row=1,column=0,sticky=tk.W)
            nomeProd = tk.StringVar()
            nomeProd.set(str(respostaBD[1]))
            self.__txtnomeProd = tk.Entry(self.__frame1,textvariable=nomeProd,state=tk.DISABLED)
            self.__txtnomeProd.grid(row=1,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Descrição:').grid(row=2,column=0,sticky=tk.W)
            descProd = tk.StringVar()
            descProd.set(str(respostaBD[2]))
            self.__txtdescProd = tk.Entry(self.__frame1,textvariable=descProd,state=tk.DISABLED)
            self.__txtdescProd.grid(row=2,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Quantidade em Estoque:').grid(row=3,column=0,sticky=tk.W)
            qtdEstoque = tk.StringVar()
            qtdEstoque.set(str(respostaBD[3]))
            self.__txtqtdEstoque = tk.Entry(self.__frame1,textvariable=qtdEstoque,state=tk.DISABLED)
            self.__txtqtdEstoque.grid(row=3,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Preço R$:').grid(row=4,column=0,sticky=tk.W)
            precoProd = tk.StringVar()
            precoProd.set(str(respostaBD[4]))
            self.__txtprecoProd = tk.Entry(self.__frame1,textvariable=precoProd,state=tk.DISABLED)
            self.__txtprecoProd.grid(row=4,column=1,sticky=tk.W)
            
            # fechar cursor
            cursor.close()
            cnx.close()
            
        else:
            messagebox.showinfo('Informação','Selecione um produto por favor!')
