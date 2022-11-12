import re
import mysql.connector
import tkinter as tk
from tkinter import ttk
from tkinter import END, ttk
from tkinter import messagebox
from clientes import Clientes
from clientesDAO import ClientesDAO
from tela import Tela

class TelaRegister():
    __tela = Tela()
    __Clientes = Clientes()
    __ClientesDAO = ClientesDAO()
    
    def __init__ (self, master):
        janelaPrincipal = master
        janela = tk.Toplevel()
        janela.geometry("300x150")
        janela.title('Tela de cadastro de Clientes') 
        janela.wm_protocol("WM_DELETE_WINDOW", self.fecharJanela)
        self.__frame1 = ttk.Frame(janela)
        self.__frame1.pack()

        ttk.Label(self.__frame1,text = 'Nome do Cliente:').grid(row=0,column=0,sticky=tk.W)
        cornomeCliente = (self.__frame1.register(self.mudarCorNome), '%P')
        self.__txtNomeCliente = tk.Entry(self.__frame1)
        self.__txtNomeCliente.config(validate='key',validatecommand = cornomeCliente) 
        self.__txtNomeCliente.grid(row=0,column=1,sticky=tk.W)
        # - ^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$
        # expressão regular de telefone, tentar implementar
        ttk.Label(self.__frame1,text = 'Telefone do Cliente:').grid(row=1,column=0,sticky=tk.W)
        corTelefoneCliente = (self.__frame1.register(self.mudarCorTelefone), '%P')
        self.__txtTelefoneCliente = tk.Entry(self.__frame1) # - 
        self.__txtTelefoneCliente.config(validate='key',validatecommand = corTelefoneCliente) 
        self.__txtTelefoneCliente.grid(row=1,column=1,sticky=tk.W)
        
        self.__btnSalvar = ttk.Button(self.__frame1,text = 'Cadastrar Cliente', command = self.CADASTRO)
        self.__btnSalvar.grid(row=2,column=0,columnspan=2,sticky=tk.W)
     
    def fecharJanela(self, janela, janelaPrincipal):
         janelaPrincipal.deiconify() 
         janela.destroy()  
        
    def CADASTRO(self, janela):
        # 1º passo - trazer info dos txts para as váriaveis
        if self.__txtNomeCliente.get() == '' or self.__txtTelefoneCliente.get() == '':
            messagebox.showwarning('Cadastro','Por favor, preencher as informações em vermelho !!!')
            if self.__txtNomeCliente.get() == '' :
                self.__txtNomeCliente['bg'] = 'red'
            if self.__txtTelefoneCliente.get() == '' :
                self.__txtTelefoneCliente['bg'] = 'red'
        else:
            # - trazer infos para as váriaveis que estão no txt da tela 
            # e armazenar na instância da classe modelo (Produto) 
            self.__Clientes.clienteNome = self.__txtNomeCliente.get() 
            self.__Clientes.telefone = self.__txtTelefoneCliente.get() 
            
            self.__ClientesDAO.Clientes = self.__Clientes 
            self.__ClientesDAO.Inserir()
            
            # limpar os txt's
            self.__txtNomeCliente.delete(0, END)
            self.__txtTelefoneCliente.delete(0, END)
        ####################################################################
            messagebox.showinfo('Informação','Dados Cadastrados com Sucesso!')
                        
    def mudarCorNome(self,valor):
        self.__txtNomeCliente ['bg'] = 'white'
        return True
    def mudarCorTelefone(self,valor):
        self.__txtTelefoneCliente ['bg'] = 'white'
        return True
         