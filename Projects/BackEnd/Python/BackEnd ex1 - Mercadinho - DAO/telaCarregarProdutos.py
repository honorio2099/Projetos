import tkinter as tk
from tkinter import ttk 
import mysql.connector
from tkinter import messagebox
#import modelo e DAO
from produto import Produto
from produtoDAO import ProdutoDAO

class TelaCarregarProdutos():
    
    __ListaIdProdutos = list
    # criar uma instância da classe modelo (Produto)
    __prod = Produto()
    # criar nova instância da classe DAO (ProdutoDAO)
    __prodDAO = ProdutoDAO()
    
    def __init__(self,window,idSelecionado):
        if idSelecionado > 0:
            window = tk.Toplevel
            window.title('Carregando o Produto')
            
            self.__frame1 = tk.Frame(window)
            self.__frame1.pack()
            
            self.__prodDAO.prod.idProd = idSelecionado
            self.__prodDAO.PesquisarID
            self.__prod = self.__prodDAO.prod
             
            ttk.Label(self.__frame1,text='Id Produto:').grid(row=0,column=0,sticky=tk.W)
            IdProd = tk.StringVar()
            IdProd.set(str(self.__prod.idProd))
            self.__txtIdProd = tk.Entry(self.__frame1,textvariable=IdProd,state=tk.DISABLED)
            self.__txtIdProd.grid(row=0,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Nome do Produto:').grid(row=1,column=0,sticky=tk.W)
            nomeProd = tk.StringVar()
            nomeProd.set(str(self.__prod.nomeProd))
            self.__txtnomeProd = tk.Entry(self.__frame1,textvariable=nomeProd,state=tk.DISABLED)
            self.__txtnomeProd.grid(row=1,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Descrição:').grid(row=2,column=0,sticky=tk.W)
            descProd = tk.StringVar()
            descProd.set(str(self.__prod.descProd))
            self.__txtdescProd = tk.Entry(self.__frame1,textvariable=descProd,state=tk.DISABLED)
            self.__txtdescProd.grid(row=2,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Quantidade em Estoque:').grid(row=3,column=0,sticky=tk.W)
            qtdEstoque = tk.StringVar()
            qtdEstoque.set(str(self.__prod.qtdEstoque))
            self.__txtqtdEstoque = tk.Entry(self.__frame1,textvariable=qtdEstoque,state=tk.DISABLED)
            self.__txtqtdEstoque.grid(row=3,column=1,sticky=tk.W)
            
            ttk.Label(self.__frame1,text='Preço R$:').grid(row=4,column=0,sticky=tk.W)
            precoProd = tk.StringVar()
            precoProd.set(str(self.__prod.precoProd))
            self.__txtprecoProd = tk.Entry(self.__frame1,textvariable=precoProd,state=tk.DISABLED)
            self.__txtprecoProd.grid(row=4,column=1,sticky=tk.W)
            
            # fechar cursor
            self.__prodDAO.fecharConexao
            
        else:
            messagebox.showinfo('Informação','Selecione um produto por favor!')
