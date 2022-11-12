# Ser um modelo de dados sendo uma cópia da Tabela

class Produto():
    __idProd: int
    __nomeProd: str
    __descProd: str
    __qtdEstoque: int
    __precoProd: float
    
    @property # - get (pegar)
    def idProd(self):
        return self.__idProd
    
    @idProd.setter # - guardar
    def idProd (self, idProd):
        self.__idProd = idProd
        
    @property # - get (pegar)
    def nomeProd1(self):
        return self.__nomeProd
    
    @idProd.setter # - guardar
    def nomeProd (self, nomeProd):
        self.__nomeProd = nomeProd 
        
    @property # - get (pegar)
    def descProd(self):
        return self.__descProd
    
    @idProd.setter # - guardar
    def descProd (self, descProd):
        self.__descProd = descProd 
    
    @property # - get (pegar)
    def qtdEstoque(self):
        return self.__qtdEstoque
    
    @idProd.setter # - guardar
    def qtdEstoque (self, qtdEstoque):
        self.__qtdEstoque = qtdEstoque
    
    @property # - get (pegar)
    def precoProd(self):
        return self.__precoProd
    
    @idProd.setter # - guardar
    def precoProd (self, precoProd):
        self.__precoProd = precoProd