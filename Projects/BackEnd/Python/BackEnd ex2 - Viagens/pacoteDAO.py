from datetime import datetime
import mysql.connector
from pacote import Pacote

class PacoteDAO():
    
    __pacote = Pacote()
    
    @property
    def pacote(self):
        return self.__pacote

    @pacote.setter
    def pacote(self, pacote):
        self.__pacote = pacote
    ########################################
    def __init__ (self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'viagemlegal', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
        
    def inserir(self):
        sql = 'INSERT INTO pacote VALUES (0,%s,%s,%s,%s,%s,%s,%s)'
        
        # data (aparentemente dá um trabalhão) - arrumar para o padrão americano (MySQL)
        # YYYY/MM/DD - %Y/%m/%d - %Y/%m/%d 
        # 1º converter a str data para uma variável DATE
        dataBD = datetime.strptime(self.__pacote.dataEmbarque, '%d/%m/%Y') 
        # 2º converter a variável DATE para str/Date no formato MySQL
        dataMySQL = datetime.strftime(dataBD,'%Y/%m/%d')
        ###########################################################################
        sqlDados = (self.pacote.nomeCliente,self.pacote.idDestino,self.pacote.idHotel,self.pacote.idEmp,
                    dataMySQL,self.pacote.qtdDiarias,self.pacote.valorFinal)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
        