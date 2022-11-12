
class Usuario():
    __id_senha:int 
    __NomeUsuario: str
    __loginUsuario:str 
    __SenhaUsuario: str
    
    @property
    def id_senha(self):
            return self.__id_senha
    @id_senha.setter
    def id_senha(self, id_senha):
        self.__id_senha = id_senha
        
    @property
    def NomeUsuario(self):
            return self.__NomeUsuario
    @NomeUsuario.setter
    def NomeUsuario(self, NomeUsuario):
        self.__NomeUsuario = NomeUsuario
        
    @property
    def loginUsuario(self):
            return self.__loginUsuario
    @loginUsuario.setter
    def loginUsuario(self, loginUsuario):
        self.__loginUsuario = loginUsuario
    
    @property
    def SenhaUsuario(self):
            return self.__SenhaUsuario
    @SenhaUsuario.setter
    def SenhaUsuario(self, SenhaUsuario):
        self.__SenhaUsuario = SenhaUsuario
    
    