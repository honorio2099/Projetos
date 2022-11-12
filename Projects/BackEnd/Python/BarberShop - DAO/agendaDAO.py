import mysql.connector
from datetime import datetime 
from agenda import Agenda

class AgendaDAO():
    __agenda = Agenda()
    @property
    def agenda(self):
        return self.__agenda
    @agenda.setter
    def agenda(self, agenda):
        self.__agenda = agenda
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
    
    def inserir(self):
        sql = 'INSERT INTO pacote VALUES (0,%s,%s,%s,%s,%s,%s,%s)'
        dataBD = datetime.strptime(self.__agenda.dataHoraCorte, '%d/%m/%Y') 
        dataMySQL = datetime.strftime(dataBD,'%Y/%m/%d')
        ###########################################################################
        sqlDados = (self.agenda.corteDesejadofk,self.agenda.descGen,
                    self.agenda.Barbeirofk,self.agenda.barbeiroNome,
                    self.agenda.Clientefk,self.agenda.clienteNome,
                    self.agenda.LucroTotalDiario,
                    dataMySQL)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
        