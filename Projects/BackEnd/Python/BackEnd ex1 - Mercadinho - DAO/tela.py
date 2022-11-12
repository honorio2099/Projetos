import tkinter as tk
from tkinter import ttk 
from tkinter import messagebox
import mysql.connector
from telaInserir import TelaInserir
from telaCarregarProdutos import TelaCarregarProdutos
from telaAlterarProdutos import TelaAlterarProdutos
#import modelo e DAO
from produto import Produto
from produtoDAO import ProdutoDAO


class Tela():

    __ListaIdProdutos = list
    # criar uma instância da classe modelo (Produto)
    __prod = Produto()
    # criar nova instância da classe DAO (ProdutoDAO)
    __prodDAO = ProdutoDAO()
    
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
        text='Atualizar Lista', command=self.SetList)
        self.__btnAtualizarLista.pack(side=tk.LEFT)

        self.__btnExcluir = ttk.Button(self,self.__frame1,
        text='Excluir',command=self.excluir)
        self.__btnExcluir.pack(side=tk.LEFT)

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
        cursor = self.__prodDAO.listarTudo()
        # 5º passo - varrer o cursor e preencher o LISTBOX
        # IMPORTANTE - apagar as infos que estão no LISTBOX antes de colocar novas
        qtdItens = self.__listarprodutos.size()
        self.__listarprodutos.delete(0,qtdItens)
        self.__ListaIdProdutos.clear()
        for (IdProd,nomeProduto,DescProduto,qtdEstoque,PrecoProduto) in cursor:
            self.__ListaIdProdutos.append(IdProd)
            self.__listarprodutos.insert(tk.END,nomeProduto)
    
        
    def itemSelecionado(self):
        if len(self.__listarprodutos.curselection()) > 0:
            return int(self.__ListaIdProdutos[self.__listarprodutos.curselection()[0]])
        else:
            return - 1
        
    def carregar(self):
        telaCarregarProdutos = TelaCarregarProdutos(self.__window, self.itemSelecionado())
        
    def alterar(self):
        telaAlterarProdutos = TelaAlterarProdutos(self.__window, self.itemSelecionado())
        
    def excluir(self):
        if self.itemSelecionado() > 0:
            resp = messagebox.askyesno('Produtos','Deseja realmente exluir este produto?')
            if resp == True:
                self.__prod.idProd = self.itemSelecionado()
                self.__prodDAO.prod = self.__prod
                self.__prodDAO.Excluir() 
                messagebox.showwarning('Produtos','Exclusão bem sucedida!!!')
            else:
                messagebox.showwarning('Produtos','Exclusão Cancelada!!!')
        else:
            messagebox.showerror('Produtos','Por favor selecionar um produto!!!')
        
            