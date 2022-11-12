import mysql.connector
from clientes import Clientes

class ClientesDAO():
    __Clientes = Clientes()
    @property
    def Clientes(self):
        return self.__Clientes
    @Clientes.setter
    def Clientes(self, Clientes):
        self.__Clientes = Clientes
    ########################################
    def conectar(self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'barbearia', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
        
    def fecharConexao(self):
        self.__cursor.close()
        self.__cnx.close()
    
    def listarTudo(self):
        sql = ('SELECT * FROM Clientes')
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor
        return TableRETURN  
    
    def pesquisarClientes(self): 
        sql = ('SELECT * FROM Clientes WHERE id_cliente =' + str(self.Clientes.id_cliente))
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor.fetchone()
        self.Clientes.id_cliente = TableRETURN[0]
        self.Clientes.clienteNome = TableRETURN[1]
        self.Clientes.telefone = TableRETURN[2]
    
    def Inserir(self, Clientes):
        sql = ('INSERT INTO Clientes VALUES (0,%s,%s)')
        sqlDados = (self.__Clientes.clienteNome,self.__Clientes.telefone)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
        
    def Excluir(self):
        sql = ('DELETE * FROM Clientes WHERE id_cliente = ' + str(self.__Clientes.id_cliente))
        self.__cursor.execute(sql)
        self.__cnx.commit()
        
        