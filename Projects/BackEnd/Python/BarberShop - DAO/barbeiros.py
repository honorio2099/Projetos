class Barbeiros():
    __id_barbeiros: int 
    __barbeiroNome: str 
    __disponivelOU: str
########################################
    @property
    def id_barbeiros(self):
        return self.__id_barbeiros
    @id_barbeiros.setter
    def id_barbeiros(self, id_barbeiros):
            self.__id_barbeiros = id_barbeiros
    @property
    def barbeiroNome(self):
        return self.__barbeiroNome
    @barbeiroNome.setter
    def barbeiroNome(self, barbeiroNome):
            self.__barbeiroNome = barbeiroNome
    @property
    def disponivelOU(self):
        return self.__disponivelOU
    @disponivelOU.setter
    def disponivelOU(self, disponivelOU):
            self.__disponivelOU = disponivelOU