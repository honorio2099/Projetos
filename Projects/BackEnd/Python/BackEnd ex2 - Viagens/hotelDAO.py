import mysql.connector
from hotel import Hotel

class HotelDAO():
    
    __hotel = Hotel()
    
    @property
    def hotel(self):
        return self.__hotel

    @hotel.setter
    def hotel(self, hotel):
        self.__hotel = hotel
    ########################################
    def __init__ (self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'viagemlegal', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
    
    def listarTudo(self):
        sql = ('SELECT * FROM HOTEL')
        self.__cursor.execute(sql)
        TableResp = self.__cursor
        return TableResp
    # cuidado com os nomes dos comandos de database, pode dar erro de localização se o comando for errado
    def pesquisarID(self):
        sql = ('SELECT * FROM HOTEL WHERE idHotel =' + str(self.__hotel.idHotel))
        self.__cursor.execute(sql)
        TableResp = self.__cursor.fetchone()
        self.hotel.idHotel = TableResp[0] # exatamente nessa ordem, já
        self.hotel.nomeHotel = TableResp[1] # que é a ordem que está
        self.hotel.diariaHotel = TableResp[2] # no banco de dados
        self.hotel.VagasHotel = TableResp[3]
        