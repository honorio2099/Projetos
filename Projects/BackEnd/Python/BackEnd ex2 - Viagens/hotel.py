
class Hotel():
     
    __idHotel: int
    __nomeHotel: str
    __diariaHotel: float
    __VagasHotel: int
    
    @property
    def idHotel(self):
        return self.__idHotel

    @idHotel.setter
    def idHotel(self, idHotel):
        self.__nomeHotel = idHotel
        
    @property
    def nomeHotel(self):
        return self.__nomeHotel

    @nomeHotel.setter
    def nomeHotel(self, nomeHotel):
        self.__nomeHotel = nomeHotel
    
    @property
    def diariaHotel(self):
        return self.__diariaHotel

    @diariaHotel.setter
    def diariaHotel(self, diariaHotel):
        self.__diariaHotel = diariaHotel
        
    @property
    def VagasHotel(self):
        return self.__VagasHotel

    @VagasHotel.setter
    def VagasHotel(self, VagasHotel):
        self.__VagasHotel = VagasHotel
    