import mysql.connector
from barbeiros import Barbeiros

class BarbeirosDAO():
    __barbeiros = Barbeiros()
    @property
    def barbeiros(self):
        return self.__barbeiros
    @barbeiros.setter
    def barbeiros(self, barbeiros):
        self.__barbeiros = barbeiros
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
        sql = ('SELECT * FROM barbeiros')
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor
        return TableRETURN   
    
    def pesquisarBarbeiro(self): 
        sql = ('SELECT * FROM barbeiros WHERE id_barbeiros =' + str(self.__barbeiros.id_barbeiros))
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor.fetchone()
        self.barbeiros.id_barbeiros = TableRETURN[0]
        self.barbeiros.barbeiroNome = TableRETURN[1]
