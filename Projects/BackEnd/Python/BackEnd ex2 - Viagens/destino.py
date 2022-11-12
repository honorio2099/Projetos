

class Destino():

    __idDestino:int 
    __nomeDestino:str
    __adicionalDestino:float 

    @property
    def idDestino(self):
        return self.__idDestino

    @idDestino.setter
    def idDestino(self, idDestino):
        self.__idDestino = idDestino

    @property
    def nomeDestino(self):
        return self.__nomeDestino
    
    @nomeDestino.setter
    def nomeDestino(self, nomeDestino):
        self.__nomeDestino = nomeDestino

    @property
    def adicionalDestino(self):
        return self.__adicionalDestino
    
    @adicionalDestino.setter
    def adicionalDestino(self, adicionalDestino):
        self.__adicionalDestino = adicionalDestino