import mysql.connector
from emp import EmpresaAerea

class EmpresaAereaDAO():
    
    __emp = EmpresaAerea()
    
    @property
    def emp(self):
        return self.__emp

    @emp.setter
    def emp(self, emp):
        self.__emp = emp
    ########################################
    def __init__ (self):
        self.__cnx = mysql.connector.connect(
            host = '127.0.0.1',  
            database = 'viagemlegal', 
            user = 'root', 
            password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
    
    def listarTudo(self):
        sql = ('SELECT * FROM EMPRESA_AEREA')
        self.__cursor.execute(sql)
        TableResp = self.__cursor
        return TableResp
    # cuidado com os nomes dos comandos de database, pode dar erro de localização se o comando for errado
    def pesquisarID(self):
        sql = ('SELECT * FROM EMPRESA_AEREA WHERE idDestino =' + str(self.emp.idEmp))
        self.__cursor.execute(sql)
        TableResp = self.__cursor.fetchone()
        self.emp.idEmp = TableResp[0]
        self.emp.nomeEmpresaAerea = TableResp[1]
        self.emp.qtdVagas = TableResp[2]
        
        