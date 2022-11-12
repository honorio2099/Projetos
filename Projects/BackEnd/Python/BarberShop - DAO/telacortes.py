import mysql.connector
import tkinter as tk
from tkinter import ttk
from tkinter import END, ttk
from tkinter import messagebox
from cortes import Cortes
from cortesDAO import CortesDAO

class TelaCortes():
    
    __cortes = Cortes()
    __cortesDAO = CortesDAO()
    
    def __init__ (self, janela):
        janelaPrincipal= janela
        janela = tk.Toplevel()
        janela.geometry("300x150")
        janela.title('Tela de Cortes') 
        janela.wm_protocol("WM_DELETE_WINDOW", self.fecharJanela)
        # - janela com combox dos cortes
        self.__frame1 = ttk.Frame(janela)
        self.__frame1.pack(padx=5,pady=5)
        
        ttk.Label(self.__frame1,text = 'Estilo do Corte:').grid(row=0,column=0,sticky=tk.W)
        corCorte = (self.__frame1.register(self.mudarCorCorte), '%P')
        self.__txtCorte = tk.Entry(self.__frame1)
        self.__txtCorte.config(validate='key',validatecommand = corCorte) 
        self.__txtCorte.grid(row=0,column=1,sticky=tk.W)
        
        ttk.Label(self.__frame1,text = 'Preço do Corte:').grid(row=1,column=0,sticky=tk.W)
        numPrice = (self.__frame1.register(self.NumPrice), '%P')
        self.__txtPrice = tk.Entry(self.__frame1) # - 
        self.__txtPrice.config(validate='key',validatecommand = numPrice) 
        self.__txtPrice.grid(row=1,column=1,sticky=tk.W)
        
        self.__btnSalvar = ttk.Button(self.__frame1,text = 'Cadastrar Corte', command = self.CADASTRO)
        self.__btnSalvar.grid(row=2,column=0,columnspan=2,sticky=tk.W)
     
        ####################################################################################
        self.__frmLinha1 = ttk.Frame(janela, relief=tk.RAISED, borderwidth=2, width=400, height=5)
        self.__frmLinha1.pack()
        ####################################################################################
    
    def CADASTRO(self, janela):
        # 1º passo - trazer info dos txts para as váriaveis
        if self.__txtCorte.get() == '' or self.__txtPrice.get() == '':
            messagebox.showwarning('Cadastro','Por favor, preencher as informações em vermelho !!!')
            if self.__txtCorte.get() == '' :
                self.__txtCorte['bg'] = 'red'
            if self.__txtPrice.get() == '' :
                self.__txtPrice['bg'] = 'red'
        else:
            # - trazer infos para as váriaveis que estão no txt da tela 
            # e armazenar na instância da classe modelo (Produto) 
            self.__cortes.descGen = self.__txtCorte.get() 
            self.__cortes.price = self.__txtPrice.get() 
            
            self.__cortesDAO.CORTES = self.__cortes 
            self.__cortesDAO.Inserir()
            
            # limpar os txt's
            self.__txtCorte.delete(0, END)
            self.__txtPrice.delete(0, END)
        ####################################################################
            messagebox.showinfo('Informação','Dados Cadastrados com Sucesso!')
            
    def fecharJanela(self, janela, janelaPrincipal):
        janelaPrincipal.deiconify() 
        janela.destroy()  
    
    def mudarCorCorte(self,valor):
        self.__txtCorte ['bg'] = 'white'
        return True
    def NumPrice(self,valor):
        valor = valor.replace(',',".")
        try:
            float(valor)
            self.__txtPrice ['bg'] = 'white'
            return True
        except:
             messagebox.showwarning('Aviso!','Digitar Números!!!')
             self.__txtPrice.focus()
             return False
   