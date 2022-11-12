import mysql.connector
from usuario import Usuario

class UsuarioDAO():
    
    __usuario = Usuario()
    @property
    def usuario(self):
        return self.__usuario
    @usuario.setter
    def usuario(self, usuario):
        self.__usuario = usuario
    ########################################
    def conectar (self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'barbearia', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
        
    def fecharConexao(self):
        self.__cursor.close()
        self.__cnx.close()
    
    def verificarLogin (self):
        self.conectar()
        sql = 'SELECT FROM SENHA WHERE loginUsuario =%s and senhaUsu =%s'
        sqlDados = (self.__usuario.loginUsuario,self.__usuario.SenhaUsuario)
        self.__cursor.execute(sql, sqlDados)
        respostaBD = self.__cursor.fetchone()
        
        if respostaBD != None:
            self.__usuario.loginUsuario = respostaBD[2]
            self.__usuario.SenhaUsuario = respostaBD[3]
            self.fecharConexao()
            return True
        else:
            self.fecharConexao()
            return False