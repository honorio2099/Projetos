from datetime import datetime

class Pacote():
    __idpacote: int
    __nomeCliente: str
    __idDestino: int
    __idHotel: int
    __idEmp: int
    __dataEmbarque: datetime
    __qtdDiarias: int
    __valorFinal: float
    ##############################################
    # obrigatório para os foreign Keys
    # é nescessário criar as variáveis string referentes
    __nomeDestino: str
    __nomeHotel: str
    __nomeEmpresaAerea: str
    ##########################################################
    @property
    def idpacote(self):
        return self.__idpacote
    @idpacote.setter
    def idpacote(self, idpacote):
        self.__idpacote = idpacote
        
    @property
    def nomeCliente(self):
        return self.__nomeCliente
    @nomeCliente.setter
    def nomeCliente(self, nomeCliente):
        self.__nomeCliente = nomeCliente
        
    @property
    def idDestino(self):
        return self.__idDestino
    @idDestino.setter
    def idDestino(self, idDestino):
        self.__idDestino = idDestino
    
    @property
    def idHotel(self):
        return self.__idHotel
    @idHotel.setter
    def idHotel(self, idHotel):
        self.__nomeHotel = idHotel
        
    @property
    def idEmp(self):
        return self.__idEmp
    @idEmp.setter
    def idEmp(self, idEmp):
        self.__idEmp = idEmp
    
    @property
    def dataEmbarque(self):
        return self.__dataEmbarque
    @dataEmbarque.setter
    def dataEmbarque(self, dataEmbarque):
        self.__dataEmbarque = dataEmbarque
    
    @property
    def qtdDiarias(self):
        return self.__qtdDiarias
    @qtdDiarias.setter
    def qtdDiarias(self, qtdDiarias):
        self.__qtdDiarias = qtdDiarias
        
    @property
    def valorFinal(self):
        return self.__valorFinal
    @valorFinal.setter
    def valorFinal(self, valorFinal):
        self.__valorFinal = valorFinal
    
    @property
    def nomeDestino(self):
        return self.__nomeDestino
    @nomeDestino.setter
    def nomeDestino(self, nomeDestino):
        self.__nomeDestino = nomeDestino
    
    @property
    def nomeHotel(self):
        return self.__nomeHotel
    @nomeHotel.setter
    def nomeHotel(self, nomeHotel):
        self.__nomeHotel = nomeHotel

    @property
    def nomeEmpresaAerea(self):
        return self.__nomeEmpresaAerea
    @nomeEmpresaAerea.setter
    def nomeEmpresaAerea(self, nomeEmpresaAerea):
        self.__nomeEmpresaAerea = nomeEmpresaAerea
    
    
    