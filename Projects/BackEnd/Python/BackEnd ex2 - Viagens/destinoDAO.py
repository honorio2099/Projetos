import mysql.connector
from destino import Destino

class DestinoDAO():
    __destino = Destino()
    
    @property
    def destino(self):
        return self.__destino

    @destino.setter
    def destino(self, destino):
        self.__destino = destino
    ########################################
    def __init__ (self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'viagemlegal', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
        
    def listarTudo(self):
        sql = ('SELECT * FROM DESTINO')
        self.__cursor.execute(sql)
        TableResp = self.__cursor
        return TableResp
    # cuidado com os nomes dos comandos de database, pode dar erro de localização se o comando for errado
    def pesquisarID(self): 
        sql = ('SELECT * FROM DESTINO WHERE idDestino =' + str(self.__destino.idDestino))
        self.__cursor.execute(sql)
        TableResp = self.__cursor.fetchone()
        self.destino.idDestino = TableResp[0]
        self.destino.nomeDestino = TableResp[1]
        self.destino.adicionalDestino = TableResp[2]
        
        
        