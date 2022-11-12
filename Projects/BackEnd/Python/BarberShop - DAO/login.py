import sys
import tkinter as tk
from tkinter import ttk
from tkinter import messagebox
from tela import Tela
from usuarioDAO import UsuarioDAO

class Login(): 
    
    def __init__ (self, Mainwindow):
        self.__root = Mainwindow
        self.__root = tk.Toplevel()
        self.__root.geometry("300x150") 
        self.__root.title('Login')  
        #########################################
        self.__password = tk.StringVar()
        self.__usuario = tk.StringVar()
        #########################################
        self.__frame = ttk.Frame(self.__root)
        self.__frame.pack(padx = 10, pady = 10, fill = 'x', expand = True)

        self.__labelUsuario = ttk.Label(self.__frame, text="Nome de Usuário:")
        self.__labelUsuario.pack(fill='x', expand=True)
        self.__txtUsuario = ttk.Entry(self.__frame, textvariable=self.__usuario)
        self.__txtUsuario.pack(fill='x', expand=True)

        self.__lblPassword = ttk.Label(self.__frame, text = "Senha:")
        self.__lblPassword.pack(fill='x', expand=True)
        self.__txtPassword = ttk.Entry(self.__frame, textvariable = self.__password, show = "*")
        self.__txtPassword.pack(fill='x', expand=True)

        self.__btnLogin = ttk.Button(self.__frame, text = "Login", command = self.login_clicked)
        self.__btnLogin.pack(fill = 'x', expand = True, pady = 10)
        
        if self.__tentativas > 3:
            sys.exit('Encerrando Programa...') 
            # forçar finalização do programa
            # tá dando certo isso? não faço idéia -_-
        ##################################################################
    
    def login_clicked(self):
        # criar Instância da classe usuarioDAO
        self.__usuarioDAO = UsuarioDAO()
        # transferir as informações para o modelo da classe DAO
        self.__usuarioDAO.conectar
        self.__usuarioDAO.usuario.loginUsuario = self.__txtUsuario.get()
        self.__usuarioDAO.usuario.SenhaUsuario = self.__txtPassword.get()
    
        if self.__usuarioDAO.verificarLogin() == True:
            self.__msg = f'Você entrou a senha: {self.__password.get()} e o login: {self.__usuario.get()}. Eles estão corretos.'
            messagebox.showinfo(
            title = 'Informação',
            message = self.__msg)
            self.__root.withdraw()
            self.tela = Tela(self.__root)
        else:
            self.__tentativas =  self.__tentativas + 1
            if self.__tentativas  == 1:
                messagebox.showerror('Informação','Senha ou Login Errados!!! (Duas Tentativas Restantes)')
            elif self.__tentativas  == 2: 
                messagebox.showerror('Atenção!','Senha ou Login Errados!!! (Uma Tentativa Restantes)')
            else:
                messagebox.showerror('Tentativas Esgotadas','Senha ou Login Errados!!! Encerrando Programa...')
        self.__usuarioDAO.fecharConexao
           
            
        
    

    
