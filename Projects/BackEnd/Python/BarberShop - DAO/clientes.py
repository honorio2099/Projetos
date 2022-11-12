
class Clientes():
    __id_cliente: int 
    __clienteNome: str
    __telefone: int
    
    @property
    def id_cliente(self):
        return self.__id_cliente
    @id_cliente.setter
    def id_cliente(self, id_cliente):
        self.__id_cliente = id_cliente
    
    @property
    def clienteNome(self):
        return self.__clienteNome
    @clienteNome.setter
    def clienteNome(self, clienteNome):
        self.__clienteNome = clienteNome
    
    @property
    def telefone(self):
        return self.__telefone
    @telefone.setter
    def telefone(self, telefone):
        self.__telefone = telefone
        
       