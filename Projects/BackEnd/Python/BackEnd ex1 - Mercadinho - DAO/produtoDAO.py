import mysql.connector
from produto import Produto
from produtoDAO import ProdutoDAO

class  ProdutoDAO():
    #instância da classe Modelo da Tabela
    __prod = Produto()
    
    @property
    def prod(self):
        return self.__prod
    
    @prod.setter
    def prod(self, prod):
        self.__prod = prod
    ##########################################
    # conexão e ponto de acesso
    def __init__(self):
        self.__cnx = mysql.connector.connect(
                host = '127.0.0.1',  
                database = 'mycompany', 
                user = 'root', 
                password = 'griloseco347') 
        self.__cursor = self.__cnx.cursor()
    
    def Inserir(self, Produto):
        sql = ('INSERT INTO PRODUTOS VALUES (0,%s,%s,%s,%s)')
        sqlDados = (self.__prod.nomeProd,self.__prod.descProd,self.__prod.qtdEstoque,self.__prod.precoProd)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
        
        
    def AlterarProduto(self):
        sql = ('UPDATE PRODUTOS SET nomeProd=%s,descProd=%s,qtdEstoque=%s,precoProd=%s WHERE idProd=%s' )
        sqlDados = (self.__prod.nomeProd,self.__prod.descProd,self.__prod.qtdEstoque,self.__prod.precoProd, 
                    self.__prod.idProd)
        self.__cursor.execute(sql, sqlDados)
        self.__cnx.commit()
        
        
    def listarTudo(self):
        sql = ('SELECT * FROM PRODUTOS')
        self.__cursor.execute(sql)
        TabelaResp = self.__cursor
        return TabelaResp
    
    
    def PesquisarID(self):
        sql = 'SELECT * FROM PRODUTOs WHERE idProd = ' + str(self.__prod.idProd)
        self.__cursor.execute(sql)
        respostaBD = self.__cursor.fetchone()
        self.__prod.idProd = respostaBD[0]
        self.__prod.nomeProd = respostaBD[1]
        self.__prod.descProd = respostaBD[2]
        self.__prod.qtdEstoque = respostaBD[3]
        self.__prod.precoProd = respostaBD[4]
    
    
    def Excluir(self):
        sql = ('DELETE * FROM PRODUTOS WHERE idProd = ' + str(self.__prod.idProd))
        self.__cursor.execute(sql)
        self.__cnx.commit()
    
    def fecharConexao(self):
        self.__cursor.close()
        self.__cnx.close()