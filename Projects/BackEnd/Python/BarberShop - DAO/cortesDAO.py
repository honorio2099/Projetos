import mysql.connector
from cortes import Cortes

class CortesDAO():
    __CORTES = Cortes()
    @property
    def CORTES(self):
        return self.__CORTES
    @CORTES.setter
    def CORTES(self, CORTES):
        self.__CORTES = CORTES
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
        sql = ('SELECT * FROM Cortes')
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor
        return TableRETURN   
    
    def pesquisarCortes(self): 
        sql = ('SELECT * FROM Cortes WHERE id_Cortes =' + str(self.__CORTES.id_Cortes))
        self.__cursor.execute(sql)
        TableRETURN = self.__cursor.fetchone()
        self.CORTES.id_Cortes = TableRETURN[0]
        self.CORTES.descGen = TableRETURN[1]
        self.CORTES.price = TableRETURN[2]
    
    def Inserir(self, CORTES):
        sql = ('INSERT INTO Cortes VALUES (0,%s,%s)')
        sqlDados = (self.__CORTES.descGen, self.__CORTES.price)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
    
    def Excluir(self):
        sql = ('DELETE * FROM Cortes WHERE id_Cortes = ' + str(self.__CORTES.id_Cortes))
        self.__cursor.execute(sql)
        self.__cnx.commit()