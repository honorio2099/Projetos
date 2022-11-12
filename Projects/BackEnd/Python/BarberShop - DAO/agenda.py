from datetime import datetime 
  
class Agenda():   
     
    __id_agenda: int
    __corteDesejadofk: int
    __descGen: str
    __Barbeirofk: int 
    __barbeiroNome: str
    __Clientefk: int 
    __clienteNome: str
    __LucroTotal: str
    __dataHoraCorte: datetime 
    
    @property
    def id_agenda(self):
        return self.__id_agenda
    @id_agenda.setter
    def id_agenda(self, id_agenda):
        self.__id_agenda = id_agenda
    
    @property
    def corteDesejadofk(self):
        return self.__corteDesejadofk
    @corteDesejadofk.setter
    def corteDesejadofk(self, corteDesejadofk):
        self.__corteDesejadofk = corteDesejadofk
        
    @property
    def descGen(self):
        return self.__descGen
    @descGen.setter
    def descGen(self, descGen):
        self.__descGen = descGen
    
    @property
    def Barbeirofk(self):
        return self.__Barbeirofk
    @Barbeirofk.setter
    def Barbeirofk(self, Barbeirofk):
        self.__Barbeirofk = Barbeirofk
        
    @property
    def barbeiroNome(self):
        return self.__barbeiroNome
    @barbeiroNome.setter
    def barbeiroNome(self, barbeiroNome):
        self.__barbeiroNome = barbeiroNome
    
    @property
    def Clientefk(self):
        return self.__Clientefk
    @Clientefk.setter
    def Clientefk(self, Clientefk):
        self.__Clientefk = Clientefk
    
    @property
    def clienteNome(self):
        return self.__clienteNome
    @clienteNome.setter
    def clienteNome(self, clienteNome):
        self.__clienteNome = clienteNome
     
    @property
    def LucroTotalDiario(self):
        return self.__LucroTotalDiario
    @LucroTotalDiario.setter
    def LucroTotalDiario(self, LucroTotalDiario):
        self.__LucroTotalDiario = LucroTotalDiario 
        
    @property
    def dataHoraCorte(self):
        return self.__dataHoraCorte
    @dataHoraCorte.setter
    def dataHoraCorte(self, dataHoraCorte):
        self.__dataHoraCorte = dataHoraCorte
    
    
    
    
    