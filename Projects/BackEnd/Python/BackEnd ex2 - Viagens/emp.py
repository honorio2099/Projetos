
class EmpresaAerea():
     
    __idEmp: int
    __nomeEmpresaAerea: str
    __qtdVagas: int
    
    @property
    def idEmp(self):
        return self.__idEmp

    @idEmp.setter
    def idEmp(self, idEmp):
        self.__idEmp = idEmp
        
    @property
    def nomeEmpresaAerea(self):
        return self.__nomeEmpresaAerea

    @nomeEmpresaAerea.setter
    def nomeEmpresaAerea(self, nomeEmpresaAerea):
        self.__nomeEmpresaAerea = nomeEmpresaAerea
        
    @property
    def qtdVagas(self):
        return self.__qtdVagas

    @qtdVagas.setter
    def qtdVagas(self, qtdVagas):
        self.__qtdVagas = qtdVagas