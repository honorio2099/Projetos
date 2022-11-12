
class Cortes():
    __id_Cortes: int 
    __descGen: str 
    __price: float
########################################
    @property
    def id_Cortes(self):
        return self.__id_Cortes
    @id_Cortes.setter
    def id_Cortes(self, id_Cortes):
            self.__id_Cortes = id_Cortes
    @property
    def descGen(self):
        return self.__descGen
    @descGen.setter
    def descGen(self, descGen):
            self.__descGen = descGen
    @property
    def price(self):
        return self.__price
    @price.setter
    def price(self, price):
            self.__price = price
########################################